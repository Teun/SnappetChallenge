import "./student-item.scss";
import { FaChild } from "react-icons/fa";
const StudentItem = () => {
  return (
    <div class="student-item-content">
      <FaChild class="student-icon" />
      <div class="student-name-text">User 123</div>
    </div>
  );
};

export default StudentItem;
