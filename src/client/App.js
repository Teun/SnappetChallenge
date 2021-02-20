import React from 'react';
import {ThemeProvider, StylesProvider} from '@material-ui/core/styles';
import CssBaseline from '@material-ui/core/CssBaseline';
import {ConnectedRouter} from 'connected-react-router';
import {Provider} from 'react-redux';

import theme from './theme';
import store from './store';
import Router from './router';
import history from './history';

import '@fontsource/roboto';

export default () => (
  <Provider store={store}>
    <ConnectedRouter history={history}>
      <StylesProvider injectFirst>
        <ThemeProvider theme={theme}>
          <CssBaseline />
          <Router />
        </ThemeProvider>
      </StylesProvider>
    </ConnectedRouter>
  </Provider>
);
