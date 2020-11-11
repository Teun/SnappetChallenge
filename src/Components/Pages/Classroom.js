import React from 'react';
import styled from 'styled-components';
import ChildrenOverview from '../Organisms/ChildrenOverview';
import Statsbar from '../Organisms/Statsbar';

const Container = styled.div`
  height: 100vh;
  width: 100vw;
  display: grid;
  grid-template-columns: 1fr 320px;
  background: #e1f5fe;
`;

const Classroom = () =>
  <Container>
    <ChildrenOverview />
    <Statsbar />
  </Container>;

export default Classroom;
