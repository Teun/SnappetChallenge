import React from 'react';
import bobRoss from '../assets/img/bobRoss.jpg';
import styled from 'styled-components';
import 'reset-css';

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
  return (
    <Container className="HappyLittleTree">
      <BobRoss
        src={bobRoss}
        alt="Join me, as we produce coloured depictions of vertically
        challenged fauna with a positive mindset."
      />
      <h1 style={{background: 'rgba(0,0,0,0)'}}>
        Time for some happy little accidents.
      </h1>
    </Container>
  );
};
