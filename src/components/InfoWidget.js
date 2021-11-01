import { useEffect, useRef } from "react"
import { useSelector } from "react-redux"
import styled from "styled-components"
import useScrollToTop from "../hooks/useScrollToTop"
import { getLearningObjectiveData, getActiveFilter } from "../selectors/subject_selectors"
import { ListItem, SubListItem } from "./styled_components/styled_list_components"

const StyledWidgetBox = styled.div`
  width: 480px;
  height: 500px;
  border-radius: 8px;
  overflow: scroll;
  background-color: #fff;
  border: 1px solid #eee;
  box-shadow: 0px 5px 15px 0px #aaaaaa25;
`

const InfoWidgetHeading = styled.div`
  position: sticky;
  top: 0;
  background-color: #fff;
  z-index: 1;
  padding: 4px 12px;
  margin-bottom: 8px;
  display: flex;
  align-items: center;
  justify-content: space-between;
  border-bottom: 1px solid #eee;
`

const InfoWidget = () => {
  const learningData = useSelector(getLearningObjectiveData)
  const currentFilter = useSelector(getActiveFilter)
  const { elementRef } = useScrollToTop(currentFilter)

  return (
    <StyledWidgetBox ref={elementRef}>
      <InfoWidgetHeading>
        <h3>{`Daily ${currentFilter} Undertaken`}</h3>
        <p>Total</p>
      </InfoWidgetHeading>

      {learningData.map(({ field, data }) => (
        <ListItem key={`info-${field}`} title={field}>
          {Object.keys(data).map((learningObjective) => (
            <SubListItem key={`sub-info-${data[learningObjective]}`} title={learningObjective} value={data[learningObjective]} />
          ))}
        </ListItem>
      ))}
    </StyledWidgetBox>
  )
}

export default InfoWidget
