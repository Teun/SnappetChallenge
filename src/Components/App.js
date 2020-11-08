import React from 'react';
import {useDispatch} from 'react-redux';
import styled from 'styled-components';
import axios from 'axios';
import 'reset-css';

import bobRoss from '../assets/img/bobRoss.jpg';
import {setByDomain} from '../redux/actions/data';

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

  const dispatch = useDispatch();

  return (
    <Container className="HappyLittleTree">
      <BobRoss
        src={bobRoss}
        alt={happyLittleTree}
      />
      <h1 style={{background: 'rgba(0,0,0,0)'}}>
        {happyLittleTree}
      </h1>
      <button onClick={() =>
        axios({
          method: 'get',
          url: 'http://localhost:9000/dataset',
        })
        .then(({data}) => dispatch(setByDomain(data)))}
      >
        Click me
      </button>
    </Container>
  );
};
