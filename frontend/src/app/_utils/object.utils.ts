export function removeEmpty(obj: { [key: string]: any }): object {
    const newObj: { [key: string]: any } = {};
    Object.keys(obj).forEach((key) => {
        if (obj[key] === Object(obj[key])) {
            newObj[key] = removeEmpty(obj[key]);
        } else if (obj[key] !== undefined && obj[key]) {
            newObj[key] = obj[key];
        }
    });
    return newObj;
}
