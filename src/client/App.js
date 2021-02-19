import React from 'react';
import {ThemeProvider, StylesProvider} from '@material-ui/core/styles';
import CssBaseline from '@material-ui/core/CssBaseline';

import theme from './theme';
import Home from './components/pages/Home';

import '@fontsource/roboto';

export default () => (
  <StylesProvider injectFirst>
    <ThemeProvider theme={theme}>
      <CssBaseline />
      <Home />
    </ThemeProvider>
  </StylesProvider>
);
