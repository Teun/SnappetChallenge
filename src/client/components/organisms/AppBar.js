import React from 'react';
import t from 'prop-types';
import {AppBar as MuiAppBar, Typography, Toolbar, IconButton} from '@material-ui/core';
import {Menu as MenuIcon} from '@material-ui/icons';
import {useDispatch} from 'react-redux';

import {showDrawer} from '../../redux/actions/ui';

export const AppBar = ({title, onMenuClick}) => (
  <MuiAppBar position="static">
    <Toolbar>
      <IconButton
        id="sidemenu-button"
        onClick={onMenuClick}
        edge="start"
        color="inherit"
        aria-label="menu">
        <MenuIcon />
      </IconButton>
      <Typography variant="h6">{title}</Typography>
    </Toolbar>
  </MuiAppBar>
);

AppBar.propTypes = {
  title: t.oneOfType([t.string, t.element]),
  onMenuClick: t.func
};

const ConnectedAppBar = args => {
  const dispatch = useDispatch();
  const onMenuClick = () => dispatch(showDrawer());

  return <AppBar {...args} onMenuClick={onMenuClick} />;
};

export default ConnectedAppBar;
