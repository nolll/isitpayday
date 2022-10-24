export default {
    getName(payday: number) {
        if (payday === 1)
            return 'Monday';
        if (payday === 2)
            return 'Tuesday';
        if (payday === 3)
            return 'Wednesday';
        if (payday === 4)
            return 'Thursday';
        if (payday === 5)
            return 'Friday';
        if (payday === 6)
            return 'Saturday';
        return 'Sunday';
    }
};
