import cookie from 'js-cookie';
import defaults from './defaults';

const getPayday = () => {
  const payday = cookie.get('payday');
  return payday ? Number(payday) : defaults.payday;
};

const savePayday = (payday: number) => {
  setCookie('payday', payday.toString());
};

const getTimezone = () => {
  const timezone = cookie.get('timezone');
  return timezone ? timezone : defaults.getDefaultTimezone();
};

const saveTimezone = (timezone: string) => {
  setCookie('timezone', timezone);
};

const getFrequency = () => {
  const frequency = cookie.get('frequency');
  if (frequency) {
    return frequency;
  }
  return defaults.frequency;
};

const saveFrequency = (frequency: string) => {
  setCookie('frequency', frequency);
};

const getCountry = () => {
  const country = cookie.get('country');
  return country ? country : defaults.country;
};

const saveCountry = (country: string) => {
  setCookie('country', country);
};

const setCookie = (name: string, value: string) => {
  cookie.set(name, value, { expires: 3650 });
};

export default {
  getPayday: getPayday,
  getTimezone: getTimezone,
  getFrequency: getFrequency,
  getCountry: getCountry,
  savePayday: savePayday,
  saveTimezone: saveTimezone,
  saveFrequency: saveFrequency,
  saveCountry: saveCountry,
};
