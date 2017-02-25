import * as React from 'react';
import { NavMenu } from './NavMenu';

export interface LayoutProps {
	body: React.ReactElement<any>;
}

export class Layout extends React.Component<LayoutProps, void> {
	public render() {
		return <div className='o-container o-container--xlarge'>
			<div className='o-grid o-grid--wrap'>
				<div className='o-grid__cell o-grid__cell--no-gutter o-grid__cell--width-100 o-grid__cell--width-25@medium'>
					<NavMenu />
				</div>
				<div className='o-grid__cell'>
					{this.props.body}
				</div>
			</div>
		</div>;
	}
}
