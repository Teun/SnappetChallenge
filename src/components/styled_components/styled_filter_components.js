import styled from "styled-components"

const Button = styled.button`
  min-width: 120px;
  padding: 12px;
  background: ${({ active }) => (active ? "#fff" : "transparent")};
  border: 2px solid #eee;
  border-radius: 8px;
  font-family: "ABeeZee";
  font-weight: 700;
  cursor: pointer;
  color: ${({ active }) => (active ? "#000000" : "#00000090")};

  opacity: 1;
  transition: all 0.3s cubic-bezier(0.645, 0.045, 0.355, 1);

  &:hover {
    opacity: 0.8;
  }
`
export { Button }
