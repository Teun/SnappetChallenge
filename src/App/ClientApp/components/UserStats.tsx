import * as React from 'react';
import { Link } from 'react-router';
import { connect } from 'react-redux';
import { ApplicationState } from '../store';
import * as UserStatsState from '../store/UserStats';
import * as s from 'react-sparklines';

// At runtime, Redux will merge together...
type UserStatsProps =
	UserStatsState.UserStatsState     // ... state we've requested from the Redux store
	& typeof UserStatsState.actionCreators   // ... plus action creators we've requested
	& { params: { startDateIndex: string } };       // ... plus incoming routing parameters

class FetchData extends React.Component<UserStatsProps, {helpDisplayed: boolean}> {

	constructor(props) {
		super(props);
		this.state = {
			helpDisplayed: false
		};
	}

	componentWillMount() {
		// This method runs when the component is first added to the page
		let startDateIndex = parseInt(this.props.params.startDateIndex) || 0;
		this.props.requestUserStats(startDateIndex);
	}

	componentWillReceiveProps(nextProps: UserStatsProps) {
		// This method runs when incoming props (e.g., route params) change
		let startDateIndex = parseInt(nextProps.params.startDateIndex) || 0;
		this.props.requestUserStats(startDateIndex);
	}

	round(x: number) {
		return Math.round(x * 100) / 100;
	}

	public render() {
		if (this.props.errorLoading) {
			return <div>
				<h1 className="c-heading">Oops...</h1>
				<div className="c-alert c-alert--warning">
					<p className="c-paragraph">Something went wrong.</p>
					<p className="c-paragraph c-text--loud">Could not load data.</p>
				</div>
			</div>;
		}

		return <div>
			<button
				className="c-button c-button--ghost u-small"
				style={{ float: "right", marginTop: "1em" }}
				onClick={() => this.setState({ helpDisplayed: true })}>
				Show help <i className="fa fa-question-circle"></i>
			</button>
			<h1 className="c-heading"
				style={{ paddingTop: 0 }}>Overview</h1>
			<p className="c-paragraph">
				This report gives an overview of user performance within a period.
			</p>

			{this.renderHelp()}
			{this.renderPeriod()}
			{this.renderStatsTable()}
			{this.renderPagination()}
			
		</div>;
	}

	private renderHelp() {
		const cell = "o-grid__cell o-grid__cell--width-100 o-grid__cell--width-50@large o-grid__cell--width-33@xlarge";
		return <div>
			<div
				className="c-overlay c-overlay--dismissable"
				style={{ display: this.state.helpDisplayed ? "block" : "none" }}
				onClick={() => this.setState({ helpDisplayed: false })}></div>
			<div className={"o-drawer o-drawer--top" + (this.state.helpDisplayed ? " o-drawer--visible u-highest" : "")}>
				<div className="c-card help">
					<header className="c-card__header">
						<h2 className="c-heading">
							Help
							<div className="c-heading__sub">What do table columns mean?</div>
						</h2>
					</header>
					<div className="c-card__body help__body">
						<div className='o-grid o-grid--wrap'>
							<div className={cell}>
								<dt className="c-text--loud">User name</dt><dd>The name of the user (randomly generated).</dd>
							</div>
							<div className={cell}>
								<dt className="c-text--loud">Exercises</dt><dd>The total number of exercises the user attempted to solve during the period.</dd>
							</div>
							<div className={cell}>
								<dt className="c-text--loud">Solved on 1st try</dt><dd>The number of exercises the user solved on the first attempt during the period.</dd>
							</div>
							<div className={cell}>
								<dt className="c-text--loud">E. solved</dt><dd>The number of exercises the user solved during the period.</dd>
							</div>
							<div className={cell}>
								<dt className="c-text--loud">Avg. tries per exercise</dt><dd>The average number of attempts the user made per exercise.</dd>
							</div>
							<div className={cell}>
								<dt className="c-text--loud">1st try rate</dt><dd>The ratio of the number of exercises correctly solved on the first try to the number of all solved exercises.</dd>
							</div>
							<div className={cell}>
								<dt className="c-text--loud">Total progress</dt><dd>The sum of all progress increments for the period.</dd>
							</div>
							<div className={cell}>
								<dt className="c-text--loud">Latest progress</dt><dd>This column shows the running sum of last ten non-zero Progress values within the period. Gives an idea of the trend.</dd>
							</div>
						</div>
					</div>
					<footer className="c-card__footer">
						<div style={{display: "inline-block"}}>
							<button className="c-button c-button--info"
									onClick={() => this.setState({ helpDisplayed: false })}
									style={{ minWidth: "6em" }}>Close</button>
						</div>
					</footer>
				</div>
			</div>
		</div>
	}

	private renderPeriod() {
		const {periodStart, periodEnd} = this.props;
		if (!periodStart || !periodEnd) {
			return [];
		}
		const start = new Date(periodStart).toDateString();
		const end = new Date(periodEnd).toString();
		return <div style={{marginBottom: "0.5em"}}
			className="c-card u-pillar-box--large">
			<div className="c-card-item">
				<p className="c-paragraph">
					Period: {start} — {end}
				</p>
			</div>
		</div>;
	}

	private renderStatsTable() {
		const th = (text) => <th className="c-table__cell">{text}</th>;
		return <table className="c-table c-table--striped c-table--condensed">
			<thead className="c-table__head">
				<tr className="c-table__row c-table__row--heading">
					{th("User name")}
					{th("Exercises")}
					{th("Solved on 1st try")}
					{th("E. solved")}
					{th("Avg. tries per exercise")}
					{th("1st try rate")}
					{th("Total progress")}
					{th("Latest progress")}
				</tr>
			</thead>
			<tbody className="c-table__body">
				{this.props.stats.map(item =>
					<tr className="c-table__row" key={item.id}>
						<td className="c-table__cell">{item.userName}</td>
						<td className="c-table__cell">{item.exercisesAttempted}</td>
						<td className="c-table__cell">{item.exercisesSolvedOnFirstTry}</td>
						<td className="c-table__cell">{item.exercisesSolved}</td>
						<td className="c-table__cell">{this.round(item.avgTriesPerExercise)}</td>
						<td className="c-table__cell">{this.round(item.correctFirstTryRate)}</td>
						<td className="c-table__cell">{item.totalProgress}</td>
						<td className="c-table__cell">
							<div className="sparkline">
								<s.Sparklines data={item.latestProgressCusum} >
									<s.SparklinesLine color="blue" />
									<s.SparklinesSpots />
								</s.Sparklines>
							</div>
						</td>
					</tr>
				)}
			</tbody>
		</table>;
	}

	private renderPagination() {
		const prevStartDateIndex = this.props.startDateIndex - 7;
		const nextStartDateIndex = this.props.startDateIndex + 7;
		const showPrev = prevStartDateIndex >= -21;
		const showNext = nextStartDateIndex <= 0;
		return <div className="c-pagination">
			{showPrev && <div className="c-pagination__controls c-pagination__controls--backward">
				<Link className='c-pagination__control' to={`/userstats/${prevStartDateIndex}`}>
					<i className="fa fa-chevron-left"></i>
				</Link>
			</div>}
			<div className="c-pagination__controls">
				{this.props.isLoading && <span>Loading...</span>}
			</div>
			{showNext && <div className="c-pagination__controls c-pagination__controls--forward">
				<Link className='c-pagination__control' to={`/userstats/${nextStartDateIndex}`}>
					<i className="fa fa-chevron-right"></i>
				</Link>
			</div>}
		</div>;
	}
}

export default connect(
	(state: ApplicationState) => state.userStats, // Selects which state properties are merged into the component's props
	UserStatsState.actionCreators                 // Selects which action creators are merged into the component's props
)(FetchData);
