export const UTCtoLocaleString = date => {
  let locale;
  try {
    locale = new Date(date);
  } catch (error) {
    locale = new Date();
  }

  const d = locale.getDate().toString().padStart(2, '0');
  const M = (locale.getMonth() + 1).toString().padStart(2, '0');
  const y = locale.getFullYear();

  const H = locale.getHours().toString().padStart(2, '0');
  const m = locale.getMinutes().toString().padStart(2, '0');

  return `${y}-${M}-${d}T${H}:${m}`;
};

export const localeToUTC = date => {
  try {
    return new Date(date).toISOString();
  } catch (error) {
    return null;
  }
};
