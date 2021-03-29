export function isNumeric(str) {
    if (typeof str != "string") {
        return false;
    }
    return !isNaN(str) && !isNaN(parseFloat(str));
}

export function log(message, value) {
    console.log('\x1b[36m%s\x1b[0m', `🟦 ${message}`, value);
}

export function isEmpty(obj, debug = true) {
    if (Object.keys(obj).length === 0) {
        debug && log('Validating request params failed - no input ', obj);
        return true;
    }
    return false;
}
