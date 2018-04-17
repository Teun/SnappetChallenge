import createNumberMask from 'text-mask-addons/dist/createNumberMask';


/**
 * Transform an masked currency to javascript value
 * @param value The value to be transformed
 */
export const CurrencyToValue = (value: any): number => {
    const currency = value;
    const pr = /([+-]?[0-9|^.|^,]+)[\.|,]([0-9]+)$/igm.exec(currency);
    const result = Number.parseFloat(pr ? pr[1].replace(/[.,]/g, '') + '.' + pr[2] : currency.replace(/[^0-9-+]/g, ''));
    return result;
};

/**
 * The currency mask object
 */
export const CurrencyMask = createNumberMask(
{
    prefix: 'R$ ',
    thousandsSeparatorSymbol: '.',
    allowDecimal: true,
    decimalSymbol: ','
});
