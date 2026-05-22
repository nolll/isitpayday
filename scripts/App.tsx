import { useState, useEffect, useMemo } from 'react';
import { useQuery } from '@tanstack/react-query';
import dayjs from 'dayjs';
import advancedFormat from 'dayjs/plugin/advancedFormat';
import { CountryForm } from '@/components/CountryForm';
import { TimezoneForm } from '@/components/TimezoneForm';
import { FrequencyForm } from '@/components/FrequencyForm';
import { PaydayForm } from '@/components/PaydayForm';
import type { Country } from '@/types/Country';
import type { Frequency } from '@/types/Frequency';
import type { Timezone } from '@/types/Timezone';
import type { PaydayResponse } from '@/types/PaydayResponse';
import ajax from '@/ajax';
import urls from '@/urls';
import defaults from '@/defaults';
import storage from '@/storage';
import { frequencyTypes } from '@/frequencyTypes';

dayjs.extend(advancedFormat);

const getTimezones = (): Timezone[] => {
  const ids = (Intl as any).supportedValuesOf('timeZone') as string[];
  return ids.map((id: string) => ({ id, name: id }));
};

export const App = () => {
  const [payday, setPayday] = useState(() => storage.getPayday());
  const [timezone, setTimezone] = useState(() => storage.getTimezone());
  const [frequency, setFrequency] = useState(() => storage.getFrequency());
  const [country, setCountry] = useState(() => storage.getCountry());

  const email = 'info@isitpayday.com';
  const apiHost = 'api.isitpayday.com';

  const paydayUrl =
    frequency === frequencyTypes.weekly ? urls.weeklyUrl(payday, timezone, country) : urls.monthlyUrl(payday, timezone, country);

  const {
    data: optionsData,
    isSuccess: isOptionsReady,
    isError: isOptionsError,
  } = useQuery({
    queryKey: ['options'],
    queryFn: async () => {
      const [countriesResponse, frequenciesResponse] = await Promise.all([
        ajax.get<Country[]>(urls.countriesUrl),
        ajax.get<Frequency[]>(urls.frequenciesUrl),
      ]);
      return { countries: countriesResponse, frequencies: frequenciesResponse, timezones: getTimezones() };
    },
  });

  const {
    data: paydayData,
    isSuccess: isPaydayReady,
    isError: isPaydayError,
  } = useQuery({
    queryKey: ['payday', paydayUrl],
    queryFn: () => ajax.get<PaydayResponse>(paydayUrl),
  });

  useEffect(() => {
    if (!optionsData) return;
    const isSavedTimezoneValid = !!optionsData.timezones.find((tz) => tz.id === timezone);
    if (!isSavedTimezoneValid) {
      const defaultTz = defaults.getDefaultTimezone();
      storage.saveTimezone(defaultTz);
      setTimezone(defaultTz);
    }
  }, [optionsData]);

  const countries = optionsData?.countries ?? [];
  const frequencies = optionsData?.frequencies ?? [];
  const timezones = optionsData?.timezones ?? [];
  const isPayday = paydayData?.isPayDay ?? false;
  const nextPayday = paydayData ? new Date(paydayData.nextPayDay) : null;
  const localTime = paydayData?.localTime ?? '';

  const error = isOptionsError ? 'Error loading options' : isPaydayError ? 'Error loading payday' : '';
  const isReady = isPaydayReady && isOptionsReady;
  const message = error ? 'Error' : isPayday ? 'YES!!1!' : 'No =(';

  const nextPaydayMessage = useMemo(
    () => (nextPayday === null ? '' : `Next payday is ${dayjs(nextPayday).format('MMM D')}`),
    [nextPayday],
  );

  const formattedLocalTime = useMemo(
    () => (localTime ? `Your local time: ${dayjs(localTime).format('MMM D YYYY, HH:mm:ss')}` : ''),
    [localTime],
  );

  const mailtoUrl = `mailto:${email}`;
  const apiUrl = `https://${apiHost}`;

  const handleCountryChange = (newCountry: string) => {
    storage.saveCountry(newCountry);
    setCountry(newCountry);
  };

  const handleTimezoneChange = (newTimezone: string) => {
    storage.saveTimezone(newTimezone);
    setTimezone(newTimezone);
  };

  const handlePaydayChange = (newPayday: number) => {
    storage.savePayday(newPayday);
    setPayday(newPayday);
  };

  const handleFrequencyChange = (newFrequency: string) => {
    storage.saveFrequency(newFrequency);
    const newPayday = newFrequency === frequencyTypes.weekly ? defaults.weeklyPayday : defaults.monthlyPayday;
    storage.savePayday(newPayday);
    setFrequency(newFrequency);
    setPayday(newPayday);
  };

  if (!isReady) return null;

  return (
    <div>
      <p className="message">
        <span>{message}</span>
      </p>
      {!isPayday && <p className="next-payday">{nextPaydayMessage}</p>}
      {error && (
        <p className="error">
          <span>{error}</span>
        </p>
      )}
      <div className="settings">
        <h2>Settings</h2>
        <FrequencyForm value={frequency} frequencies={frequencies} onChange={handleFrequencyChange} />
        <PaydayForm value={payday} frequencyId={frequency} onChange={handlePaydayChange} />
        <CountryForm value={country} countries={countries} onChange={handleCountryChange} />
        <TimezoneForm value={timezone} timezones={timezones} onChange={handleTimezoneChange} />
      </div>
      <p className="footer">{formattedLocalTime}</p>
      <p className="contact">
        Api: <a href={apiUrl}>{apiHost}</a>
        <br />
        Bugs and suggestions: <a href={mailtoUrl}>{email}</a>
      </p>
    </div>
  );
};
