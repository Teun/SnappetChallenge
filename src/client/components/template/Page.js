import React from 'react';
import t from 'prop-types';
import styled from 'styled-components';
import {
  Drawer, List, ListItem, ListItemIcon as MuiListItemIcon, ListItemText as MuiListItemText
} from '@material-ui/core';
import {Assignment as ReportIcon, InfoRounded as InfoIcon} from '@material-ui/icons';
import {useDispatch, useSelector} from 'react-redux';
import {identity, view} from 'ramda';
import {createSelector} from 'reselect';
import {Link} from 'react-router-dom';

import View from '../atoms/View';
import AppBar from '../organisms/AppBar';
import theme from '../../theme';
import {drawerIsOpenState} from '../../redux/reducers/ui';
import {hideDrawer} from '../../redux/actions/ui';

const Content = styled(View)`
  padding: ${theme.spacing(2)}px;
  justify-content: stretch;
  align-items: stretch;
`;

const ListItemIcon = styled(MuiListItemIcon)`
  min-width: 36px;
`;

const ListItemText = styled(MuiListItemText)`
  a {
    text-decoration: none;
  }
`;

export const Page = ({title, drawerIsOpen, onCloseDrawer, children}) => (
  <View flex="1" alignItems="stretch">
    <Drawer anchor="left" open={drawerIsOpen} onClose={onCloseDrawer}>
      <List>
        <ListItem>
          <ListItemIcon><ReportIcon /></ListItemIcon>
          <ListItemText>
            <Link to="/">Report</Link>
          </ListItemText>
        </ListItem>
        <ListItem>
          <ListItemIcon><InfoIcon /></ListItemIcon>
          <ListItemText>
            <Link to="/about">About</Link>
          </ListItemText>
        </ListItem>
      </List>
    </Drawer>
    {title && <AppBar title={title} />}
    <Content>
      {children}
    </Content>
  </View>
);

Page.propTypes = {
  title: t.oneOfType([t.string, t.element]),
  children: t.oneOfType([
    t.element, t.arrayOf(t.element)
  ]).isRequired,
  drawerIsOpen: t.bool,
  onCloseDrawer: t.func,
};

const isOpenSelector = createSelector([view(drawerIsOpenState)], identity);

const ConnectedPage = args => {
  const drawerIsOpen = useSelector(isOpenSelector);
  const dispatch = useDispatch();

  const onCloseDrawer = () => dispatch(hideDrawer());

  return <Page onCloseDrawer={onCloseDrawer} drawerIsOpen={drawerIsOpen} {...args} />;
};

export default ConnectedPage;
