import React from 'react';
import "./subject-stats-table.css";


const SubjectStatsTable = (props) => (
    <table>

        <thead>
            <tr>
                <th>Subject</th>
                <th>Answers Submitted</th>
                <th>Correct</th>
                <th>Incorrect</th>
                <th>Avg. Progress</th>
                <th>Avg. Difficulty</th>
            </tr>
        </thead>

        <tbody>
            {props.children}
        </tbody>
    </table>
)

export default SubjectStatsTable;