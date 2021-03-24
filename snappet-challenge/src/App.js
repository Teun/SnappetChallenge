import "./App.css";
import HeaderBar from "./components/header-bar/header-bar";
import SideBar from "./components/side-bar/side-bar";
import HomeScreen from "./screens/home-screen/home-screen";

function App() {
  return (
    <div className="app-content">
      <HeaderBar />
      <div class="content-container">
        <SideBar />
        <HomeScreen />
      </div>
    </div>
  );
}

export default App;
