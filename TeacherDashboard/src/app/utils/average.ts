export const average = (values: Array<number>, decimals = 2): number => {
  if (!values.length) {
    return 0;
  }

  const average = values.reduce((a, b) => a + b, 0) / values.length;
  return Math.round(average * Math.pow(10, decimals)) / Math.pow(10, decimals);
}
