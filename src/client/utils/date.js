export const UTCtoLocaleString = date => {
  const locale = new Date(date);
  const d = locale.getDate().toString().padStart(2, '0');
  const M = (locale.getMonth() + 1).toString().padStart(2, '0');
  const y = locale.getFullYear();

  const H = locale.getHours().toString().padStart(2, '0');
  const m = locale.getMinutes().toString().padStart(2, '0');

  return `${y}-${M}-${d}T${H}:${m}`;
};

export const localeToUTC = date => new Date(date).toISOString();
