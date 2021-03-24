import "./subject-box.scss";

const SubjectBox = () => {
  return (
    <div class="subject-box">
      <div class="subject-box-text-row">
        <div class="subject-box-name-text">Average:</div>
        <div class="subject-box-value-text">80%</div>
      </div>
      <div class="subject-box-text-row">
        <div class="subject-box-name-text">Score today:</div>
        <div class="subject-box-value-text">80%</div>
      </div>
    </div>
  );
};

export default SubjectBox;
