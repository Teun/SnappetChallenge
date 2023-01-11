import { useSelector } from "react-redux";
import { StudentPerformanceBarChart } from "./charts/StudentPerformanceBarChart";
import { getWorkError, getWorkLoadingStatus } from "../store/workSlice";
import { getPerformanceReportData } from "../store/workSelector";
import { Container, Row, Col } from "react-bootstrap";
import { Header } from "../../screens/Header";
import Loader from "../../screens/Loader";
import Message from "../../screens/Message";

const prepareGraphData = (data) => {
  return Object.keys(data).map((key) => ({
    category: data[key]["field"],
    false: data[key]["data"][0],
    correct: data[key]["data"][1],
  }));
};

export const PerformanceReport = () => {
  const performanceReport = useSelector(getPerformanceReportData) || [];
  const graphData = prepareGraphData(performanceReport);
  const loadingStatus = useSelector(getWorkLoadingStatus);
  const workDataError = useSelector(getWorkError);

  return (
    <Container className="py-3">
      <Header />
      <Row>
        <Col>
          <div className="card border-secondary mb-3">
            <div className="card-header">
              <h3>Student Performance</h3>
            </div>
            <div className="card-body">
              {loadingStatus ? (
                <Loader />
              ) : workDataError ? (
                <Message variant="danger">{workDataError}</Message>
              ) : (
                <StudentPerformanceBarChart data={graphData} />
              )}
            </div>
          </div>
        </Col>
      </Row>
    </Container>
  );
};
