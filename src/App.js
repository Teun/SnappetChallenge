import React, { useEffect } from "react"
import "./App.css"
import { BrowserRouter as Router, Switch, Route } from "react-router-dom"
import DailyOverview from "./pages/DailyOverview"
import DailyLog from "./pages/DailyLog"
import Header from "./components/Header"
import { store } from "./app/store"
import styled from "styled-components"

const PageArea = styled.div`
  position: fixed;
  background-color: #f5f6fa;
  justify-content: center;
  display: flex;
  height: calc(100vh - 49px);
  width: 100vw;
`

function App() {
  useEffect(() => {
    fetch("work.json")
      .then((res) => res.json())
      .then((data) => {
        store.dispatch({ type: "SET_WORK_DATA", payload: data })
      })
      .catch((error) => console.log("Fetching local json error:", error))
  }, [])

  return (
    <Router>
      <Header />
      <PageArea>
        <Switch>
          <Route path="/" exact component={DailyOverview} />
          <Route path="/logs" exact component={DailyLog} />
        </Switch>
      </PageArea>
    </Router>
  )
}

export default App
