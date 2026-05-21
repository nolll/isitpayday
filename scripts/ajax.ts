export default {
  get: (url: string) => fetch(url).then((res) => res.json()),
};
