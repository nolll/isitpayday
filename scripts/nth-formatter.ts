function shouldFormatsAsFirst(s: string) {
    return s.endsWith('1') && !s.endsWith('11');
}

function shouldFormatsAsSecond(s: string) {
    return s.endsWith('2') && !s.endsWith('12');
}

function shouldFormatsAsThird(s: string) {
    return s.endsWith('3') && !s.endsWith('13');
}

export default {
    format(n: number) {
        const s = n.toString();
        if (shouldFormatsAsFirst(s))
            return `${s}st`;
        if (shouldFormatsAsSecond(s))
            return `${s}nd`;
        if (shouldFormatsAsThird(s))
            return `${s}rd`;
        return `${s}th`;
    }
};
