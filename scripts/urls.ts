export default {
    monthlyUrl(payday: number, timezone: string, country: string) {
        return `/api/monthly?payday=${payday}&country=${country}&timezone=${timezone}`;
    },
    weeklyUrl(payday: number, timezone: string, country: string) {
        return `/api/weekly?payday=${payday}&country=${country}&timezone=${timezone}`;
    },
    optionsUrl: '/api/options'
};
