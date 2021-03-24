import StudentItem from "../../components/student-item/student-item";
import SubjectBox from "./child-components/subject-box/subject-box";
import "./home-screen.scss";

const HomeScreen = () => {
  const countUsers = () => {};

  return (
    <div class="home-screen-content">
      <div class="home-screen-header-bar">Home</div>
      <div class="home-screen-sub-content">
        <div class="home-screen-summary-box">
          <div class="home-screen-summary-headings">
            <div class="home-screen-summary-child-spacer"></div>
            <div class="home-screen-summary-heading">Maths</div>
            <div class="home-screen-summary-heading">English</div>
            <div class="home-screen-summary-heading">Science</div>
          </div>
          <div class="home-screen-summary-row">
            <StudentItem />
            <SubjectBox />
            <SubjectBox />
            <SubjectBox />
            <SubjectBox />
          </div>
        </div>
      </div>
    </div>
  );
};

export default HomeScreen;
