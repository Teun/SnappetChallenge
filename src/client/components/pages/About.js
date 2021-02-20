import React from 'react';
import {Typography} from '@material-ui/core';

import Page from '../template/Page';
import View from '../atoms/View';

export default () => (
  <Page title="About">
    <View>
      <Typography variant="h2">Snappet Challenge</Typography>
      <Typography variant="body1">
        The idea behind this about page is simply to show the navigation within the app.
        <br />
        (Connected to redux store)
      </Typography>
      <Typography variant="p">http://snappet.herokuapp.com</Typography>
    </View>
  </Page>
);
