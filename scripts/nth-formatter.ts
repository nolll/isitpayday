const shouldFormatsAsFirst = (s: string) => s.endsWith('1') && !s.endsWith('11');
const shouldFormatsAsSecond = (s: string) => s.endsWith('2') && !s.endsWith('12');
const shouldFormatsAsThird = (s: string) => s.endsWith('3') && !s.endsWith('13');

export const formatNth = (n: number) => {
  const s = n.toString();
  if (shouldFormatsAsFirst(s)) return `${s}st`;
  if (shouldFormatsAsSecond(s)) return `${s}nd`;
  if (shouldFormatsAsThird(s)) return `${s}rd`;
  return `${s}th`;
};
