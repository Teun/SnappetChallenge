import React, {useState} from 'react';
import bobRoss from '../assets/img/bobRoss.jpg';
import styled from 'styled-components';
import axios from 'axios';
import 'reset-css';

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
`;

export const App = () => {
  const [bobRossQuote, setBobRossQuote] = useState('');

  return (
    <Container className="HappyLittleTree">
      <BobRoss
        src={bobRoss}
        alt={happyLittleTree}
      />
      <h1 style={{background: 'rgba(0,0,0,0)'}}>
        {bobRossQuote}
      </h1>
      <button onClick={() =>
        axios({
          method: 'get',
          url: 'http://localhost:9000/bobRoss',
          responseType: 'stream'
        })
        .then(({data}) => setBobRossQuote(data))}
      >
        Click me
      </button>
    </Container>
  );
};
