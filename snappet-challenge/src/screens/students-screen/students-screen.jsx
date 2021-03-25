import { useEffect, useState } from "react";
import StudentItem from "../../components/student-item/student-item";
import { getStudentsApiData } from "../../libs/studentsApi";
import { ToastContainer, toast } from "react-toastify";
import "./students-screen.scss";

const StudentsScreen = ({ setIsLoading }) => {
  const [studentList, setStudentList] = useState([]);

  useEffect(() => {
    getStudents();
  }, []); // eslint-disable-line react-hooks/exhaustive-deps

  const getStudents = async () => {
    setIsLoading(true);
    const result = await getStudentsApiData();
    if (Array.isArray(result)) {
      setStudentList(result);
    } else {
      toast.error(
        "There was a problem accessing the data. Please check that the API is up and running"
      );
    }
    setIsLoading(false);
  };

  return (
    <div className="students-screen-content">
      <div className="content-header-bar">Students</div>
      <div className="students-screen-students">
        {studentList.map((studentItem, i) => {
          return (
            <div className="students-screen-student-item" key={i}>
              <StudentItem studentDetails={studentItem} key={i} />
            </div>
          );
        })}
        <ToastContainer />
      </div>
    </div>
  );
};

export default StudentsScreen;
