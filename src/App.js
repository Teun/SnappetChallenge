import React, { useEffect } from "react";
import { useDispatch } from "react-redux";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import Sidebar from "./features/sidebar/Sidebar";
import HomeScreen from "./features/screens/HomeScreen";
import { fetchWorkData } from "./features/work/store/workSlice";
import { DailyOverview } from "./features/work/components/DailyOverview";
import { LearningObjectiveOverview } from "./features/work/components/LearningObjectiveOverview";
import { PerformanceReport } from "./features/work/components/PerformanceReport";

const App = () => {
  const dispatch = useDispatch();

  useEffect(() => {
    dispatch(fetchWorkData());
  }, [dispatch]);

  return (
    <>
      <Router>
        <Sidebar />
        <Switch>
          <Route path="/dailyoverview" exact component={DailyOverview} />
          <Route
            path="/learningObjective"
            exact
            component={LearningObjectiveOverview}
          />
          <Route
            path="/performanceReport"
            exact
            component={PerformanceReport}
          />
          <Route path="/" exact component={HomeScreen} />
        </Switch>
      </Router>
    </>
  );
};

export default App;
