import { useSelector } from "react-redux"
import styled from "styled-components"
import { store } from "../app/store"
import { getActiveFilter } from "../selectors/subject_selectors"
import { Button } from "./styled_components/styled_filter_components"

const FILTER_TYPES = ["Subject", "Domain"]

const StyledFilterContainer = styled.div`
  display: flex;
  width: 100%;
  justify-content: space-evenly;
`

const handleFilterClick = (e) => {
  return store.dispatch({ type: "SET_ACTIVE_SUBJECT", subject: e.target.value })
}

export const FilterContainer = () => {
  const activeFilter = useSelector(getActiveFilter)

  return (
    <StyledFilterContainer>
      {FILTER_TYPES.map((filter) => (
        <Button key={`${filter}-type`} value={filter} active={activeFilter === filter} onClick={handleFilterClick}>
          {filter}
        </Button>
      ))}
    </StyledFilterContainer>
  )
}
