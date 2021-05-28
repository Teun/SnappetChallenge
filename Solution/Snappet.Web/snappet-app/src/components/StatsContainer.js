import React from 'react';
import "./stats-container.css";

const StatsContainer = (props) => (
    <div>
        <div className="chart-container-header">{props.title}</div>
        <div className="chart-container-content">{props.children}</div>
    </div>
)

export default StatsContainer;