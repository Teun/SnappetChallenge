import styled from "styled-components"

const StyledListItem = styled.div`
  padding: 4px 12px;
  margin-bottom: 12px;
  border-bottom: 2px solid #eee;
  .list-item__title {
    color: #e95f15;
    margin: 0px;
  }
`

const StyledSubListItem = styled.div`
  display: flex;
  &:not(:last-child) {
    border-bottom: 1px solid #eeeeee90;
  }
  .sub-list-item__title {
    flex: 1;
    white-space: nowrap;
    text-overflow: ellipsis;
    overflow: hidden;
    margin-right: 32px;
  }
  .sub-list-item__value {
    font-weight: 600;
  }
`

const ListItem = ({ title, children }) => {
  return (
    <StyledListItem>
      <h4 className="list-item__title">{title}</h4>
      <div>{children}</div>
    </StyledListItem>
  )
}

const SubListItem = ({ title, value }) => {
  return (
    <StyledSubListItem>
      <p className="sub-list-item__title">{title}</p>
      <p className="sub-list-item__value">{value}</p>
    </StyledSubListItem>
  )
}

export { SubListItem, ListItem, StyledSubListItem, StyledListItem }
