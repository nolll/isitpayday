import frequencyTypes from './frequencyTypes';

const monthlyPayday = 25;
const weeklyPayday = 5;
const fallbackTimezone = 'Europe/Stockholm';

const getDefaultTimezone = () => {
  try {
    const clientTimezone = Intl.DateTimeFormat().resolvedOptions().timeZone;
    return !!clientTimezone ? clientTimezone : fallbackTimezone;
  } catch {
    return fallbackTimezone;
  }
};

export default {
  monthlyPayday: monthlyPayday,
  weeklyPayday: weeklyPayday,
  payday: monthlyPayday,
  getDefaultTimezone,
  frequency: frequencyTypes.monthly,
  country: 'SE',
};
