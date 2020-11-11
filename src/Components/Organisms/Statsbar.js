import { Button } from '@material-ui/core';
import React from 'react';
import styled from 'styled-components';

const Container = styled.div`
  /* height: 100%; */
  width: auto;
  background: #80cbc4;
  box-shadow: 0 0 6px #004d40;
  display: flex;
  flex-direction: column;
  align-items: center;
  padding: 16px;
`;

const Title = styled.h1`
  font-size: 40px;
  margin: 32px;
`;

const Domain = styled(Button)`
  margin-bottom: 16px;
`;

const Statsbar = () => {
  return (
    <Container>
      <Title>Statsbar</Title>
      <Domain
        fullWidth
        color="primary"
        variant="contained"
        style={{marginBottom: '16px'}}
      >
        Button
      </Domain>
      <Domain
        fullWidth
        color="primary"
        variant="contained"
        style={{marginBottom: '16px'}}
      >
        Button
      </Domain>
      <Domain
        fullWidth
        color="primary"
        variant="contained"
        style={{marginBottom: '16px'}}
      >
        Button
      </Domain>
      <Domain
        fullWidth
        color="primary"
        variant="contained"
        style={{marginBottom: '16px'}}
      >
        Button
      </Domain>
    </Container>
  );
};

export default Statsbar;
