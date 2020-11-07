import React from 'react';
import PropTypes from 'prop-types';
import styled from 'styled-components';

const Container = styled.div`
  height: auto;
  width: auto;
`;

const Name = ({thingy}) => {
  return (
    <Container>
      joe
    </Container>
  );
};

Name.propTypes = {
  thingy: PropTypes.bool.isRequired,
};

export default Name;
