import styled from "styled-components"
import { Link, useLocation } from "react-router-dom"

const HEADER_MENU_ITEMS = [
  { label: "Daily Overview", path: "/" },
  { label: "Daily Logs", path: "/logs" },
]

const StyledHeader = styled.header`
  display: flex;
  align-items: center;
  gap: 24px;
  padding-right: 48px;
  justify-content: flex-end;
  height: 48px;
  border-bottom: 1px solid #eee;
`

const StyledHeaderLink = styled(Link)`
  text-decoration: none;
  padding: 4px 12px;
  border-radius: 4px;
  border: 1px solid #c3245190;
  background-color: #fff;
  color: #c32451;
  font-weight: 600;
  text-align: center;
  transition: all 0.3s cubic-bezier(0.645, 0.045, 0.355, 1);

  ${({ active }) =>
    active &&
    `
    background-color: #c32451;
    color: #fff;
  `}
`

const HeaderLink = ({ label, path }) => {
  const { pathname } = useLocation()
  return (
    <StyledHeaderLink active={pathname === path} to={path}>
      {label}
    </StyledHeaderLink>
  )
}

const Header = () => {
  return (
    <StyledHeader>
      {HEADER_MENU_ITEMS.map((headerItemProps) => (
        <HeaderLink key={`header-${headerItemProps.path}`} {...headerItemProps} />
      ))}
    </StyledHeader>
  )
}

export default Header
