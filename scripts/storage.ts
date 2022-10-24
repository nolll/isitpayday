import cookie from 'js-cookie';
import defaults from './defaults';

function getPayday() {
  const payday = cookie.get('payday');
  return payday ? Number(payday) : defaults.payday;
}

function savePayday(payday: number) {
  setCookie('payday', payday.toString());
}

function getTimezone() {
  const timezone = cookie.get('timezone');
  return timezone ? timezone : defaults.getDefaultTimezone();
}

function saveTimezone(timezone: string) {
  setCookie('timezone', timezone);
}

function getFrequency() {
  const frequency = cookie.get('frequency');
  if (frequency) {
    return frequency;
  }
  return defaults.frequency;
}

function saveFrequency(frequency: string) {
  setCookie('frequency', frequency);
}

function getCountry() {
  const country = cookie.get('country');
  return country ? country : defaults.country;
}

function saveCountry(country: string) {
  setCookie('country', country);
}

function setCookie(name: string, value: string) {
  cookie.set(name, value, { expires: 3650 });
}

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
