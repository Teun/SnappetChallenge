import { Accordion } from "react-bootstrap";
import { Container, Row, Col } from "react-bootstrap";

export const LearningObjectiveItem = ({
  learningObjectiveTitle,
  learningObjectiveValue,
}) => {
  return (
    <>
      <Accordion.Body>
        <Container>
          <Row>
            <Col sm={9}>{learningObjectiveTitle}</Col>
            <Col sm={3}>
              <div className="float-end">{learningObjectiveValue}</div>
            </Col>
          </Row>
        </Container>
      </Accordion.Body>
    </>
  );
};
