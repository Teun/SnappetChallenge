import React from 'react';
import "./subject-stats-table.css";


const StudentsStatsTable = (props) => (
    <table>

        <thead>
            <tr>
                <th>StudentId</th>
                <th>Subject</th>
                <th>Answers Submitted</th>
                <th>Correct</th>
                <th>Incorrect</th>                
            </tr>
        </thead>

        <tbody>
            {props.children}
        </tbody>
    </table>
)

export default StudentsStatsTable;