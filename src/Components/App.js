import React, {useEffect} from 'react';
import {useDispatch, useSelector} from 'react-redux';
import styled from 'styled-components';
import axios from 'axios';
import 'reset-css';
import {groupBy, view} from 'ramda';

import bobRoss from '../assets/img/bobRoss.jpg';
import {
  setRawData,
  setIsLoading,
  setByUserId,
  setByDomain,
} from '../redux/actions/data';
import {
  isLoadingState,
  byUserIdState,
  byDomainState
} from '../redux/reducers/data';

const happyLittleTree = `Join me, as we produce coloured depictions of
vertically challenged fauna with a positive mindset.`;

const Container = styled.div`
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  height: 100vh;
  background: #5da9ab;
  color: #F2F2F2;
`;

const BobRoss = styled.img`
  margin: 16px;
  border-radius: 80px;
  height: 70%;
`;

export const App = () => {

  const isLoading = useSelector(view(isLoadingState));
  const byUserId = useSelector(view(byUserIdState));
  const byDomain = useSelector(view(byDomainState));

  const dispatch = useDispatch();
  useEffect(() => {
    dispatch(setIsLoading(true));
    axios({
      method: 'get',
      url: 'http://localhost:9000/dataset',
    })
    .then(({data}) => dispatch(setRawData(data)))
    .then(({payload}) => {
      dispatch(setByUserId(groupBy(x => x.UserId, payload)));
      dispatch(setByDomain(groupBy(x => x.Domain, payload)));
    })
    .then(dispatch(setIsLoading(false)));
  }, []);
  console.log(isLoading);
  console.log(byUserId);
  console.log(byDomain);
  return (
    <Container className="HappyLittleTree">
      <BobRoss
        src={bobRoss}
        alt={happyLittleTree}
      />
      <h1 style={{background: 'rgba(0,0,0,0)'}}>
        {happyLittleTree}
      </h1>
    </Container>
  );
};
