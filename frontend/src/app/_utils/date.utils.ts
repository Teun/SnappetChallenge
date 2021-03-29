export function toJSONLocal(date: any): string {
    const local = typeof date === 'string' ? new Date(date) : date;
    local.setMinutes(date.getMinutes() - date.getTimezoneOffset());
    return local.toJSON().slice(0, 10);
}
