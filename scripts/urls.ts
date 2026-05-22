export default {
  monthlyUrl: (payday: number, timezone: string, country: string) =>
    `/api/monthly?payday=${payday}&country=${country}&timezone=${timezone}`,
  weeklyUrl: (payday: number, timezone: string, country: string) =>
    `/api/weekly?payday=${payday}&country=${country}&timezone=${timezone}`,
  countriesUrl: '/api/countries',
  frequenciesUrl: '/api/frequencies',
};
