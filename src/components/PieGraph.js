import { useEffect, useState } from "react"
import { VictoryPie, VictoryLabel, VictoryContainer } from "victory"

const makeGraphData = (obj) => {
  return Object.keys(obj).map((key) => ({ x: key, y: obj[key], label: key }))
}

const COLORS = ["#f6cf19", "#34a3d7", "#c32451", "#e95f15", "#9dc429"] // Snappet Colors

const DEFAULT_PIE_DATA = [{ y: 0 }, { y: 0 }, { y: 100 }] // set to zero to allow initial animation to work

const ANIMATE_PRESETS = {
  duration: 1000,
  onLoad: { duration: 1000 },
}

const PieGraph = ({ data }) => {
  const [graphicData, setGraphicData] = useState(DEFAULT_PIE_DATA)

  useEffect(() => {
    const graphData = makeGraphData(data)

    if (graphData.length > 0) {
      setGraphicData(graphData)
    }
  }, [data])

  return (
    <div>
      <VictoryPie
        containerComponent={<VictoryContainer />}
        height="400"
        theme={{ pie: { colorScale: COLORS } }}
        labelComponent={<VictoryLabel renderInPortal />}
        animate={ANIMATE_PRESETS}
        data={graphicData}
      />
    </div>
  )
}

export default PieGraph
