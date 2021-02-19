import styled from 'styled-components';

export default styled.div`
  display: flex;
  flex-direction: ${props => props.flexDirection || 'column'};
  align-items: ${props => props.alignItems || 'center'};
  justify-content: ${props => props.justifyContent || 'center'};
  flex: ${props => props.flex || 'inherit'};
`;
