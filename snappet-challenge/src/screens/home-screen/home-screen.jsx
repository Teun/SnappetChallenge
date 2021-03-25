import { useEffect, useState } from "react";
import StudentItem from "../../components/student-item/student-item";
import SubjectBox from "./child-components/subject-box/subject-box";
import {
  getApiDashboardData,
  getApiSubjects,
} from "../../libs/dashboardDataApi";

import "./home-screen.scss";
import DateSelector from "../../components/date-selector/date-selector";
import { staticStartDate } from "../../libs/general";

const HomeScreen = ({ setIsLoading }) => {
  const [dashboardData, setDashboardData] = useState([]);
  const [subjectHeadings, setSubjectHeadings] = useState([]);
  const [currentDate, setCurrentDate] = useState(staticStartDate);
  const [formattedDate, setFormattedDate] = useState("");

  useEffect(() => {
    const newFormattedDate = getFormattedCurrentDate(currentDate);
    getDashboardData(newFormattedDate);
  }, []); // eslint-disable-line react-hooks/exhaustive-deps

  const getDashboardData = async (summaryDate) => {
    setIsLoading(true);
    await getSubjects(summaryDate);
    const result = await getApiDashboardData(summaryDate);
    if (result) {
      setDashboardData(result);
    }
    setIsLoading(false);
  };

  const getSubjects = async (summaryDate) => {
    setIsLoading(true);
    const result = await getApiSubjects(summaryDate);
    if (result) {
      setSubjectHeadings(result);
    }
    setIsLoading(false);
  };

  const handleLeftDatePressed = () => {
    let newDate = currentDate;
    newDate.setDate(currentDate.getDate() - 1);
    const formattedDate = getFormattedCurrentDate(newDate);
    setCurrentDate(newDate);
    getDashboardData(formattedDate);
  };

  const handleRightDatePressed = () => {
    let newDate = currentDate;
    newDate.setDate(currentDate.getDate() + 1);
    const formattedDate = getFormattedCurrentDate(newDate);
    setCurrentDate(newDate);
    getDashboardData(formattedDate);
  };

  const getFormattedCurrentDate = (newDate) => {
    const newFormattedDate =
      newDate.getFullYear() +
      "-" +
      (newDate.getMonth() + 1) +
      "-" +
      newDate.getDate();
    setFormattedDate(newFormattedDate);

    return newFormattedDate;
  };

  return (
    <div className="home-screen-content">
      <div className="content-header-bar">Home</div>
      <DateSelector
        handleRightDatePressed={handleRightDatePressed}
        handleLeftDatePressed={handleLeftDatePressed}
        formattedDate={formattedDate}
      />
      <div className="home-screen-sub-content">
        {dashboardData.length > 0 && (
          <div className="home-screen-summary-box">
            <div className="home-screen-summary-headings">
              <div className="home-screen-summary-child-spacer"></div>
              {subjectHeadings.map((subject, i) => {
                return (
                  <div className="home-screen-summary-heading" key={i}>
                    {subject}
                  </div>
                );
              })}
            </div>
            {dashboardData.map((studentItem, i) => {
              return (
                <div className="home-screen-summary-row" key={i}>
                  <StudentItem studentDetails={studentItem} />
                  {subjectHeadings.map((subject, j) => {
                    return (
                      <div className="home-screen-summary-heading" key={j}>
                        <SubjectBox
                          subjectDetails={studentItem.subjects.find(
                            (x) => x.subjectName === subject
                          )}
                        />
                      </div>
                    );
                  })}
                </div>
              );
            })}
          </div>
        )}
        {!dashboardData.length > 0 && (
          <div className="home-screen-no-data">
            No data to show for this period
          </div>
        )}
      </div>
    </div>
  );
};

export default HomeScreen;
