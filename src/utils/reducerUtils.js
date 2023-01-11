export const groupBy = (items, key) =>
  items.reduce(
    (result, item) => ({
      ...result,
      [item[key]]: [...(result[item[key]] || []), item],
    }),
    {}
  );

export const accumulateTotals = (array = [], field) => {
  return array.reduce(
    (totals, work) => (
      (totals[work[field]] = (totals[work[field]] || 0) + 1), totals
    ),
    {}
  );
};
