export const groupBy = (array, keyGetter) => {
  const map = new Map();

  array.forEach((item) => {
    const key = keyGetter(item);
    const collection = map.get(key);

    if (!collection) {
      map.set(key, [item]);
    } else {
      collection.push(item);
    }
  });

  return map;
}
