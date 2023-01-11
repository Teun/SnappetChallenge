import { useSelector } from "react-redux";
import { getLearningObjectiveData } from "../store/workSelector";
import { Accordion } from "react-bootstrap";
import { LearningObjectiveItem } from "./LearningObjectiveItem";

export const LearningObjectiveOverview = () => {
  const learningObjectiveData = useSelector(getLearningObjectiveData) || [];

  return (
    <>
      {learningObjectiveData.map(({ field, data, index }) => (
        <Accordion
          key={`learning-objective-${field}`}
          defaultActiveKey={`learning-objective-${field}`}
        >
          <Accordion.Item eventKey={`learning-objective-${field}`}>
            <Accordion.Header>{field}</Accordion.Header>
            <Accordion.Body>
              {Object.keys(data).map((learningObjective, index) => (
                <LearningObjectiveItem
                  key={`learning-objective-item-${index}-${data[learningObjective]}`}
                  learningObjectiveTitle={learningObjective}
                  learningObjectiveValue={data[learningObjective]}
                />
              ))}
            </Accordion.Body>
          </Accordion.Item>
        </Accordion>
      ))}
    </>
  );
};
