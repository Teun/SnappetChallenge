/// <reference types="next" />
/// <reference types="next/types/global" />

import '@emotion/react';
import { Theme as MuiTheme } from '@material-ui/core/styles';

declare module '@emotion/react' {
  export interface Theme extends MuiTheme {}
}
