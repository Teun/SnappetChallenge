import { useState } from "react"
import { useSelector } from "react-redux"
import styled from "styled-components"
import { store } from "../app/store"
import { FilterContainer } from "../components/Filters"
import InfoWidget from "../components/InfoWidget"
import PieGraph from "../components/PieGraph"
import { getFilteredDailyOverview } from "../selectors/subject_selectors"

const PageContainer = styled.div`
  display: flex;
  height: calc(100vh - 49px);
  width: 100vw;
  gap: 80px;
  align-items: center;
  justify-content: center;
`

const GraphFilterContainer = styled.div`
  display: flex;
  flex-direction: column;
  align-items: center;
  gap: 24px;
`

const DailyOverview = () => {
  const todaysSubjectData = useSelector(getFilteredDailyOverview) || []
  return (
    <PageContainer>
      <InfoWidget />
      <GraphFilterContainer>
        <FilterContainer />
        <PieGraph data={todaysSubjectData} />
      </GraphFilterContainer>
    </PageContainer>
  )
}

export default DailyOverview
