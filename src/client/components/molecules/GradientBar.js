import React from 'react';
import styled from 'styled-components';
import t from 'prop-types';

const Container = styled.div`
  height: 16px;
  width: 100%;
  position: relative;
  background: linear-gradient(
    90deg, rgba(255,0,0,1) 0%, rgba(232,255,0,1) 50%, rgba(14,255,0,1) 100%
  );
`;

const Marker = styled.div`
  height: 22px;
  width: 3px;
  margin-top: -4px;
  background-color: black;
  margin-left: calc(${props => (100 / props.maximun) * props.current}% - 1.5px);

  span {
    position: absolute;
    width: 20px;
    text-align: center;
    margin-left: -8px;
    margin-top: 3px;
  }
`;

const GradientBar = ({current = 0, maximun = 100}) => (
  <Container>
    <Marker current={current} maximun={maximun}>
      <span>{current?.toFixed(0)}</span>
    </Marker>
  </Container>
);

GradientBar.propTypes = {
  current: t.number,
  maximun: t.number
};

export default GradientBar;
