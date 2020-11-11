import React from 'react';
import styled from 'styled-components';
import {SvgIcon, Tooltip} from '@material-ui/core';
import {Person} from '@material-ui/icons';
import {useSelector} from 'react-redux';
import {view} from 'ramda';
import {byUserIdState} from '../../redux/reducers/data';

const Container = styled.div`
  height: 100%;
  width: 100%;
`;

const styles = {
  color: 'red',
  height: '128px',
  width: '128px',
  padding: '-12px',
  margin: '-12px',
  cursor: 'pointer',
};

const ChildrenOverview = () => {

  const byUserId = useSelector(view(byUserIdState));

  return (
    <Container>
      {byUserId.map(({UserId}) =>
        <Tooltip key={UserId} title={`ID = ${UserId}`}>
          <SvgIcon component={Person} style={styles} onClick={() => console.log('joehoe')} />
        </Tooltip>
      )}
    </Container>
  );
};

export default ChildrenOverview;
