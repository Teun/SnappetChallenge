export const LabelTranslationModel = (input: string) => {
  if(input === 'yesterday') return 'gisteren';
  else if(input === 'previous-week') return 'Vorige week';
  else if(input ==='previous-month') return 'vorige maand';
  else return '';
}
