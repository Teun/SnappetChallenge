import React from 'react';
import t from 'prop-types';
import styled from 'styled-components';

import AppBar from '../molecules/AppBar';
import theme from '../../theme';

const Container = styled.div`
  min-height: 100vh;
`;

const Content = styled.div`
  padding: ${theme.spacing(2)}px;
`;

const Page = ({title, children}) => (
  <Container >
    <AppBar title={title} />
    <Content>
      {children}
    </Content>
  </Container>
);

Page.propTypes = {
  title: t.oneOfType([t.string, t.element]),
  children: t.element,
};

export default Page;
