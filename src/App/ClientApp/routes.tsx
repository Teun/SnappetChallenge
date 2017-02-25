import * as React from 'react';
import { Router, Route, HistoryBase } from 'react-router';
import { Layout } from './components/Layout';
import Home from './components/Home';
import UserStats from './components/UserStats';

export default <Route component={ Layout }>
	<Route path='/' components={{ body: Home }} />
	<Route path='/userstats' components={{ body: UserStats }}>
		<Route path='(:startDateIndex)' /> { /* Optional route segment that does not affect NavMenu highlighting */ }
	</Route>
</Route>;

// Enable Hot Module Replacement (HMR)
if (module.hot) {
	module.hot.accept();
}
