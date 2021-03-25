import { useState } from "react";
import "./App.scss";
import HeaderBar from "./components/header-bar/header-bar";
import SideBar from "./components/side-bar/side-bar";
import HomeScreen from "./screens/home-screen/home-screen";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import StudentsScreen from "./screens/students-screen/students-screen";

function App() {
  const [isLoading, setIsLoading] = useState(false);

  return (
    <Router>
      <div className="app-content">
        <HeaderBar isLoading={isLoading} />
        <div className="content-container">
          <SideBar setIsLoading={setIsLoading} />
          <Switch>
            <Route path="/students">
              <StudentsScreen setIsLoading={setIsLoading} />
            </Route>
            <Route path="/">
              <HomeScreen setIsLoading={setIsLoading} />
            </Route>
          </Switch>
        </div>
      </div>
    </Router>
  );
}

export default App;
