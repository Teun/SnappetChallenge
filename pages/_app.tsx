import React from 'react';
import { AppProps } from 'next/app';
import Head from 'next/head';
import { MuiThemeProvider, StylesProvider } from '@material-ui/core';
import { ThemeProvider } from '@emotion/react';

import { muiTheme } from '@lib/theme';

const MyApp: React.FC<AppProps> = ({ Component, pageProps }) => (
  <AppBootstrap>
    <Head>
      <meta
        name="viewport"
        content="minimum-scale=1, initial-scale=1, width=device-width"
      />
    </Head>
    <Component {...pageProps} />
  </AppBootstrap>
);

export default MyApp;

const AppBootstrap = ({ children }) => (
  <StylesProvider injectFirst>
    <MuiThemeProvider theme={muiTheme}>
      <ThemeProvider theme={muiTheme}>{children}</ThemeProvider>
    </MuiThemeProvider>
  </StylesProvider>
);
