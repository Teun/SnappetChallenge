import "./date-selector.scss";
import { AiFillCaretLeft, AiFillCaretRight } from "react-icons/ai";

const DateSelector = ({
  handleLeftDatePressed,
  handleRightDatePressed,
  formattedDate,
}) => {
  return (
    <div className="date-selector-content">
      <div
        className="date-selector-left-button"
        onClick={() => handleLeftDatePressed()}
      >
        <AiFillCaretLeft className="date-selector-icon" />
      </div>
      <div className="date-selector-current-day">{formattedDate}</div>
      <div
        className="date-selector-right-button"
        onClick={() => handleRightDatePressed()}
      >
        <AiFillCaretRight className="date-selector-icon" />
      </div>
    </div>
  );
};

export default DateSelector;
