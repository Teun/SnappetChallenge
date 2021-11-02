import { useSelector } from "react-redux"
import styled from "styled-components"
import Table from "../components/Table"
import { getTodaysWork } from "../selectors/objective_selectors"

const PageContainer = styled.div`
  height: calc(100vh - 50px);
  display: flex;
  width: 100%;
  justify-content: center;
  align-items: center;
  position: relative;
`

const TableContainer = styled.div`
  width: 80vw;
  height: calc(80vh - 50px);
  overflow: scroll;
  border-radius: 8px;
  border: 12px solid #fff;
`

const DailyLog = () => {
  const todaysData = useSelector(getTodaysWork) || []
  const headers = Object.keys(todaysData[0] || {}).sort()
  return (
    <PageContainer>
      <TableContainer>
        <Table headers={headers} data={todaysData} />
      </TableContainer>
    </PageContainer>
  )
}

export default DailyLog
