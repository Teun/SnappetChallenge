import React from 'react';
import styled from 'styled-components';
import {SvgIcon, Tooltip} from '@material-ui/core';
import {Person} from '@material-ui/icons';
import {useSelector, useDispatch} from 'react-redux';
import {view} from 'ramda';

import {
  setFocusedUser,
} from '../../redux/actions/data';
import {byUserIdState} from '../../redux/reducers/data';

const Container = styled.div`
  height: 100%;
  width: 100%;
`;

const profileSvgStyles = {
  color: '#ff6f00',
  height: '128px',
  width: '128px',
  padding: '-12px',
  margin: '-12px',
  cursor: 'pointer',
};

const ChildrenOverview = () => {
  const dispatch = useDispatch();
  const byUserId = useSelector(view(byUserIdState));

  return (
    <Container>
      {byUserId.map(user =>
        <Tooltip key={user.UserId} title={`ID = ${user.UserId}`}>
          <SvgIcon
            component={Person}
            style={profileSvgStyles}
            onClick={() => dispatch(setFocusedUser(user))}
          />
        </Tooltip>
      )}
    </Container>
  );
};

export default ChildrenOverview;
