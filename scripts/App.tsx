import { useState, useEffect, useMemo } from "react";
import dayjs from "dayjs";
import advancedFormat from "dayjs/plugin/advancedFormat";
import CountryForm from "@/components/CountryForm";
import TimezoneForm from "@/components/TimezoneForm";
import FrequencyForm from "@/components/FrequencyForm";
import PaydayForm from "@/components/PaydayForm";
import type { Country } from "@/types/Country";
import type { Frequency } from "@/types/Frequency";
import type { Timezone } from "@/types/Timezone";
import type { PaydayResponse } from "@/types/PaydayResponse";
import ajax from "@/ajax";
import urls from "@/urls";
import defaults from "@/defaults";
import storage from "@/storage";
import frequencyTypes from "@/frequencyTypes";

dayjs.extend(advancedFormat);

export default function App() {
  const [error, setError] = useState("");
  const [isOptionsReady, setIsOptionsReady] = useState(false);
  const [isPaydayReady, setIsPaydayReady] = useState(false);
  const [isPayday, setIsPayday] = useState(false);
  const [nextPayday, setNextPayday] = useState<Date | null>(null);
  const [localTime, setLocalTime] = useState("");
  const [payday, setPayday] = useState(() => storage.getPayday());
  const [timezone, setTimezone] = useState(() => storage.getTimezone());
  const [frequency, setFrequency] = useState(() => storage.getFrequency());
  const [country, setCountry] = useState(() => storage.getCountry());
  const [countries, setCountries] = useState<Country[]>([]);
  const [timezones, setTimezones] = useState<Timezone[]>([]);
  const [frequencies, setFrequencies] = useState<Frequency[]>([]);

  const email = "info@isitpayday.com";
  const apiHost = "api.isitpayday.com";

  const isReady = isPaydayReady && isOptionsReady;
  const message = error ? "Error" : isPayday ? "YES!!1!" : "No =(";

  const nextPaydayMessage = useMemo(() => {
    if (nextPayday === null) return "";
    return `Next payday is ${dayjs(nextPayday).format("MMM D")}`;
  }, [nextPayday]);

  const formattedLocalTime = useMemo(() => {
    if (localTime) return dayjs(localTime).format("MMM D YYYY, HH:mm:ss");
    return "";
  }, [localTime]);

  const mailtoUrl = `mailto:${email}`;
  const apiUrl = `https://${apiHost}`;

  const paydayUrl =
    frequency === frequencyTypes.weekly
      ? urls.weeklyUrl(payday, timezone, country)
      : urls.monthlyUrl(payday, timezone, country);

  const getTimezones = (): Timezone[] => {
    const ids = (Intl as any).supportedValuesOf("timeZone") as string[];
    return ids.map((id: string) => ({ id, name: id }));
  };

  const loadPayday = async () => {
    try {
      const response = await ajax.get<PaydayResponse>(paydayUrl);
      setIsPayday(response.isPayDay);
      setNextPayday(new Date(response.nextPayDay));
      setLocalTime(response.localTime);
      setIsPaydayReady(true);
    } catch {
      setError("Error loading payday");
    }
  };

  const loadOptions = async () => {
    try {
      const [countriesResponse, frequenciesResponse] = await Promise.all([
        ajax.get<Country[]>(urls.countriesUrl),
        ajax.get<Frequency[]>(urls.frequenciesUrl),
      ]);
      const timezoneList = getTimezones();
      setCountries(countriesResponse);
      setFrequencies(frequenciesResponse);
      setTimezones(timezoneList);
      setIsOptionsReady(true);

      const currentTimezone = storage.getTimezone();
      const isSavedTimezoneValid = !!timezoneList.find(
        (tz) => tz.id === currentTimezone,
      );
      if (!isSavedTimezoneValid) {
        const defaultTz = defaults.getDefaultTimezone();
        storage.saveTimezone(defaultTz);
        setTimezone(defaultTz);
      }
    } catch {
      setError("Error loading options");
    }
  };

  // Reload payday whenever the URL changes (also fires on initial mount)
  useEffect(() => {
    loadPayday();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [paydayUrl]);

  // Load options once on mount
  useEffect(() => {
    loadOptions();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

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
    const newPayday =
      newFrequency === frequencyTypes.weekly
        ? defaults.weeklyPayday
        : defaults.monthlyPayday;
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
        <FrequencyForm
          value={frequency}
          frequencies={frequencies}
          onChange={handleFrequencyChange}
        />
        <PaydayForm
          value={payday}
          frequencyId={frequency}
          onChange={handlePaydayChange}
        />
        <CountryForm
          value={country}
          countries={countries}
          onChange={handleCountryChange}
        />
        <TimezoneForm
          value={timezone}
          timezones={timezones}
          onChange={handleTimezoneChange}
        />
      </div>
      <p className="footer">{formattedLocalTime}</p>
      <p className="contact">
        Api: <a href={apiUrl}>{apiHost}</a>
        <br />
        Bugs and suggestions: <a href={mailtoUrl}>{email}</a>
      </p>
    </div>
  );
}
