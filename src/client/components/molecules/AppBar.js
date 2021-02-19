import React from 'react';
import t from 'prop-types';
import {AppBar as MuiAppBar, Typography, Toolbar, IconButton} from '@material-ui/core';
import {Menu as MenuIcon} from '@material-ui/icons';

const AppBar = ({title}) => (
  <MuiAppBar position="static">
    <Toolbar>
      <IconButton edge="start" color="inherit" aria-label="menu">
        <MenuIcon />
      </IconButton>
      <Typography variant="h6">{title}</Typography>
    </Toolbar>
  </MuiAppBar>
);

AppBar.propTypes = {
  title: t.oneOfType([t.string, t.element])
};

export default AppBar;
