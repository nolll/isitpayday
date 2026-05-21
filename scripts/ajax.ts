export default {
  get: <T>(url: string): Promise<T> => fetch(url).then((res) => res.json()),
};
