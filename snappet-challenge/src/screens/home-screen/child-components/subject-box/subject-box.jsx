import "./subject-box.scss";
import { FaArrowCircleDown } from "react-icons/fa";
import { AiFillStar } from "react-icons/ai";
import { RiErrorWarningLine } from "react-icons/ri";

const SubjectBox = ({ subjectDetails }) => {
  return (
    <div
      className="subject-box"
      style={{ display: subjectDetails ? "flex" : "none" }}
    >
      {subjectDetails && (
        <div className="subject-box-row">
          <div className="subject-box-text-row">
            <div className="subject-box-name-text">Aggregate:</div>
            <div className="subject-box-value-text">
              {subjectDetails.aggregate}%
            </div>
          </div>
          <div className="subject-box-text-row">
            <div className="subject-box-name-text">Progress:</div>
            <div className="subject-box-value-text">
              {subjectDetails.progress} points
            </div>
          </div>
        </div>
      )}
      {subjectDetails && (
        <div>
          {subjectDetails.progress > 0 && (
            <AiFillStar className="subject-box-icon subject-box-icon-advancing" />
          )}
          {subjectDetails.progress < 0 && (
            <FaArrowCircleDown className="subject-box-icon subject-box-icon-regressing" />
          )}
          {subjectDetails.progress === 0 && (
            <RiErrorWarningLine className="subject-box-icon subject-box-icon-stagnating" />
          )}
        </div>
      )}
    </div>
  );
};

export default SubjectBox;
