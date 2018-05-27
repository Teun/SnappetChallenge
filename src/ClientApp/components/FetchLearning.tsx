import * as React from 'react';
import { Link, RouteComponentProps } from 'react-router-dom';
import { connect } from 'react-redux';
import { ApplicationState } from '../store';
import * as moment from 'moment';
import { LearningObjectivesState, actionCreators, LearningObjective } from '../store/LearningObjectives';
import { XYPlot, HorizontalBarSeries, VerticalBarSeries, VerticalGridLines, HorizontalGridLines, XAxis, YAxis } from 'react-vis';

// At runtime, Redux will merge together...
type LearningObjectivesProps =
    LearningObjectivesState        // ... state we've requested from the Redux store
    & typeof actionCreators      // ... plus action creators we've requested
    & RouteComponentProps<{ dateIndex: string }>; // ... plus incoming routing parameters

class FetchLearning extends React.Component<LearningObjectivesProps, {}> {
    componentWillMount() {
        // This method runs when the component is first added to the page
        let startDateIndex = parseInt(this.props.match.params.dateIndex) || 0;
        this.props.requestLearningObjectives(startDateIndex);
    }

    componentWillReceiveProps(nextProps: LearningObjectivesProps) {
        // This method runs when incoming props (e.g., route params) change
        let startDateIndex = parseInt(nextProps.match.params.dateIndex) || 0;
        this.props.requestLearningObjectives(startDateIndex);
    }

    public render() {
        return <div>
            <h1>Learning objectives - Daily Report</h1>
            {this.renderDescription()}
            {this.renderPagination()}
            {this.props.date && this.renderChart()}
            {this.renderForecastsTable()}
        </div>;
    }

    private renderChart() {
        const { domains } = this.props;
       
        const data = domains.map(item => ({ x: item.xAxis, y: item.yAxis }));

        return (
            <fieldset className='fieldset'>
                <legend className='fieldsetLegend'>Progress per each domain</legend>
                <XYPlot
                    height={300}
                    width={500}
                    xType="ordinal"
                    yType="linear"
                    >
                    <VerticalGridLines />
                    <VerticalGridLines />
                    <XAxis title="Domains" />
                    <YAxis title="Progress" />
                    <VerticalBarSeries color="#ee4e07" data={data} />
                </XYPlot>
            </fieldset>
        );
    }

    private renderDescription() {
        const { date, objectives } = this.props;

        if (!date)
            return;

        let momentDate = date ? moment(date).utc() : date;

        if (!objectives || objectives.length === 0)
            return <p>No data to show for the day <code>{momentDate.format('YYYY-MM-DD')}</code></p>;

        return <p>The class activity based on learning objectves and the achieved progress from the beggining of the day : <code>{momentDate.format('YYYY-MM-DD')}</code> until <code>{momentDate.format('HH:mm:SS a')}</code></p>;
    }

    private renderForecastsTable() {
        let { objectives, dateIndex } = this.props;
        return <table className='table'>
            <thead>
                <tr className='table-header'>
                    <th>Learning Objective</th>
                    <th>Domain</th>
                    <th>Total Progress</th>
                    <th>Average Difficulty</th>
                    <th>Submitted Asnwers</th>
                    <th>Students Attended</th>
                </tr>
            </thead>
            <tbody>
                {objectives.map(learning =>
                    <tr key={learning.title}>
                        <td> <Link to={`/fetchstudent/${dateIndex}/${learning.title}`}>{learning.title}</Link></td>
                        <td>{learning.domain}</td>
                        <td>{learning.totalProgress}</td>
                        <td>{learning.averageDifficulty}</td>
                        <td>{learning.totalSubmittedAnswers}</td>
                        <td>{learning.totalStudents}</td>
                    </tr>
                )}
            </tbody>
        </table>;
    }

    private renderPagination() {
        let prevDateIndex = (this.props.dateIndex || 0) - 1;
        let nextDateIndex = (this.props.dateIndex || 0) + 1;

        return <p className='clearfix text-center'>
            <Link className='btn btn-default pull-left' to={`/fetchlearning/${prevDateIndex}`}>Previous Day</Link>
            {nextDateIndex <= 0 && <Link className='btn btn-default pull-right' to={`/fetchlearning/${nextDateIndex}`}>Next Day</Link>}
            {this.props.isLoading ? <span>Loading...</span> : []}
        </p>;
    }
}

export default connect(
    (state: ApplicationState) => state.learningObjectives, // Selects which state properties are merged into the component's props
    actionCreators                 // Selects which action creators are merged into the component's props
)(FetchLearning) as typeof FetchLearning;
