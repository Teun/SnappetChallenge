import * as React from 'react';
import { Link } from 'react-router';

export class NavMenu extends React.Component<void, void> {
	public render() {
		return <ul className='c-nav '>
			<li className="c-nav__content u-centered c-text--loud">SCHOOL</li>
			<li>
				<Link to={'/'} className="c-nav__item" activeClassName='c-nav__item--active'>
					<i className="fa fa-star"></i> Home
				</Link>
			</li>
			<li>
				<Link to={'/userstats'} className="c-nav__item" activeClassName='c-nav__item--active'>
					<i className="fa fa-bar-chart"></i> Overview
				</Link>
			</li>
		</ul>;
	}
}
