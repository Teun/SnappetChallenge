import React from 'react';
import {view} from 'ramda';
import {useDispatch, useSelector} from 'react-redux';
import styled from 'styled-components';
import {ArrowBack} from '@material-ui/icons';
import {SvgIcon} from '@material-ui/core';

import {setFocusedUser} from '../../redux/actions/data';
import {byDomainState, focusedUserState} from '../../redux/reducers/data';

const Container = styled.div`
  position: relative;
  width: auto;
  background: #b2dfdb;
  box-shadow: 0 0 6px #004d40;
  display: flex;
  flex-direction: column;
  align-items: center;
  padding: 16px;
`;

const returnSvgStyles = {
  position: 'absolute',
  width: '32px',
  height: '32px',
  top: '8px',
  left: '8px',
  cursor: 'pointer',
};

const Title = styled.h1`
  font-size: 32px;
  margin: 32px;
`;

const DomainCard = styled.div`
  width: 100%;
  padding: 16px;
  box-shadow: 5px 5px 5px #26a69a;
  border-radius: 8px;
  background: #80cbc4;
  margin-bottom: 16px;
  box-sizing: border-box;
  display: flex;
  flex-direction: column;
`;

const DomainTitle = styled.h3`
  font-size: 20px;
  font-weight: bold;
  margin-bottom: 8px;
`;

const DomainInfo = styled.span`
  margin-bottom: 8px;
`;

const Statsbar = () => {
  const dispatch = useDispatch();
  const byDomain = useSelector(view(byDomainState));
  const {UserId, DomainResults} = useSelector(view(focusedUserState));

  const displayedData = DomainResults ? DomainResults : byDomain;

  return (
    <Container>
      {UserId &&
        <SvgIcon
          component={ArrowBack}
          style={returnSvgStyles}
          onClick={() => dispatch(setFocusedUser({}))}
        />}
      <Title>
        {UserId ? `${UserId}'s progress` : 'Class progress'}
      </Title>
      {displayedData && Object.entries(displayedData).map(([domain, {amount, progression}]) =>
        <DomainCard key={domain}>
          <DomainTitle>{domain}</DomainTitle>
          <DomainInfo>Exercises done: {amount}</DomainInfo>
          <DomainInfo>Progression: {progression}</DomainInfo>
        </DomainCard>
      )}
    </Container>
  );
};

export default Statsbar;
