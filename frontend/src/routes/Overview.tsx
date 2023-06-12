import React from 'react';
import { snappetApi } from '../api';

export default function Overview () {
  const studentsData = snappetApi.getStudentsData();
  return (
    <div>
        {Object.keys(studentsData).map((userId) => <li key={userId}>{userId}</li>)}
    </div>
  );
}
