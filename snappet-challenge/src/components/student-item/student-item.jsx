import "./student-item.scss";
import { FaChild } from "react-icons/fa";
const StudentItem = ({ studentDetails }) => {
  return (
    <div className="student-item-content">
      <FaChild className="student-icon" />
      <div className="student-name-text">User {studentDetails.userId}</div>
    </div>
  );
};

export default StudentItem;
