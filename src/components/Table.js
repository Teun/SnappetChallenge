import _ from "lodash"
import styled from "styled-components"

const Table = styled.table`
  border-collapse: collapse;
  position: relative;
  background-color: #fff;
  border-radius: 8px;

  tbody td {
    border-bottom: 1px solid #eee;
  }
  tbody tr:nth-child(odd) td {
    background-color: #34a3d71c;
  }
`
const TableHeadCell = styled.th`
  position: sticky;
  text-transform: uppercase;
  top: 0;
  left: 0;
  background: #fff;
  height: 40px;
`
// Incomplete Table component
const OverviewList = ({ data = [], headers = [] }) => {
  return (
    <Table>
      <thead>
        {headers.map((str) => (
          <TableHeadCell>{str}</TableHeadCell>
        ))}
      </thead>
      <tbody>
        {data.map((obj = {}, index) => {
          return (
            <tr>
              {headers.map((str) => (
                <td>{obj[str]}</td>
              ))}
            </tr>
          )
        })}
      </tbody>
    </Table>
  )
}

export default OverviewList
