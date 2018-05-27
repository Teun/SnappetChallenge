import * as React from 'react';
import { RouteComponentProps } from 'react-router-dom';

export default class Home extends React.Component<RouteComponentProps<{}>, {}> {
    public render() {
        return <div>
            <h1>Snapet Challenge!</h1>
            <p>Welcome to the Snappet class reports, you can view a summary of your class activity</p>
        </div>;
    }
}
