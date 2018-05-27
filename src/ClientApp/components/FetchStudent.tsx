import * as React from 'react';
import { Link, RouteComponentProps } from 'react-router-dom';
import { connect } from 'react-redux';
import { ApplicationState } from '../store';
import { StudentsState, actionCreators, Student } from '../store/Students';

// At runtime, Redux will merge together...
type StudentsProps =
    StudentsState        // ... state we've requested from the Redux store
    & typeof actionCreators      // ... plus action creators we've requested
    & RouteComponentProps<{ dateIndex: string, learningObjective: string }>; // ... plus incoming routing parameters

class FetchStudent extends React.Component<StudentsProps, {}> {
    componentWillMount() {
        const { dateIndex, learningObjective } = this.props.match.params;
        let startDateIndex = parseInt(dateIndex) || 0;
        this.props.requestStudents(startDateIndex, learningObjective || '' );
    }

    componentWillReceiveProps(nextProps: StudentsProps) {
        const { dateIndex, learningObjective } = nextProps.match.params;
        let startDateIndex = parseInt(dateIndex) || 0;
        this.props.requestStudents(startDateIndex, learningObjective || '');
    }

    public render() {
        return <div>
            <h1>Students Progress - {this.props.learningObjective}</h1>
            {this.renderPagination()}
            {this.renderForecastsTable()}
        </div>;
    }

    private renderForecastsTable() {
        let { students } = this.props;
        return <table className='table'>
            <thead>
                <tr className='table-header'>
                    <th>Student ID</th>
                    <th>Subject</th>
                    <th>Progress</th>
                    <th>Average Difficulty</th>
                    <th>Correct Attempts</th>
                    <th>InCorrect Attempts</th>
                    <th>Unique Exercises</th>
                    <th>Submitted Answers</th>
                </tr>
            </thead>
            <tbody>
                {students.map(student =>
                    <tr key={student.id}>
                        <td>{student.id}</td>
                        <td>{student.subject}</td>
                        <td>{student.currentProgress}</td>
                        <td>{student.averageDifficulty}</td>
                        <td>{student.correctAttempts}</td>
                        <td>{student.inCorrectAttempts}</td>
                        <td>{student.uniqueExercises}</td>
                        <td>{student.submittedAnswers}</td>
                    </tr>
                )}
            </tbody>
        </table>;
    }

    private renderPagination() {
        const { dateIndex, learningObjective } = this.props;

        const prevDateIndex = (dateIndex || 0) - 1;
        const nextDateIndex = (dateIndex || 0) + 1;

        return <p className='clearfix text-center'>
            <Link className='btn btn-default pull-left' to={`/fetchstudent/${prevDateIndex}/${learningObjective}`}>Previous Day</Link>
            {nextDateIndex <= 0 && <Link className='btn btn-default pull-right' to={`/fetchstudent/${nextDateIndex}/${learningObjective}`}>Next Day</Link>}
            {this.props.isLoading ? <span>Loading...</span> : []}
        </p>;
    }
}

export default connect(
    (state: ApplicationState) => state.students, // Selects which state properties are merged into the component's props
    actionCreators                 // Selects which action creators are merged into the component's props
)(FetchStudent) as typeof FetchStudent;
