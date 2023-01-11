import { useSelector } from "react-redux";
import {
  getFilteredSubjectOverview,
  getActiveFilter,
} from "../store/workSelector";
import { DailyOverviewPieChart } from "./charts/DailyOverviewPieChart";
import { LearningObjectiveOverview } from "./LearningObjectiveOverview";
import { Container, Row, Col } from "react-bootstrap";
import { getWorkError, getWorkLoadingStatus } from "../store/workSlice";
import Loader from "../../screens/Loader";
import Message from "../../screens/Message";
import { Header } from "../../screens/Header";

export const DailyOverview = () => {
  const subjectData = useSelector(getFilteredSubjectOverview) || [];
  const currentFilter = useSelector(getActiveFilter);
  const loadingStatus = useSelector(getWorkLoadingStatus);
  const workDataError = useSelector(getWorkError);

  return (
    <Container>
      <Header />
      <Row>
        <Col sm={4}>
          <div className="card border-secondary mb-3">
            <div className="card-header">
              <h3>Learning Objective Totals</h3>
            </div>
            <div className="card-body">
              {loadingStatus ? (
                <Loader />
              ) : workDataError ? (
                <Message variant="danger">{workDataError}</Message>
              ) : (
                <LearningObjectiveOverview />
              )}
            </div>
          </div>
        </Col>
        <Col sm={8}>
          <div className="card border-secondary mb-3">
            <div className="card-header">
              <h3>{currentFilter}</h3>
            </div>
            <div className="card-body">
              {loadingStatus ? (
                <Loader />
              ) : workDataError ? (
                <Message variant="danger">{workDataError}</Message>
              ) : (
                <DailyOverviewPieChart data={subjectData} />
              )}
            </div>
          </div>
        </Col>
      </Row>
    </Container>
  );
};
