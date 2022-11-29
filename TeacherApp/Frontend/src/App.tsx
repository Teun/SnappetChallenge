import React, { useEffect, useState } from 'react';
import * as CATEGORIES from './constants/Categories';
import * as ENDPOINTS from './constants/Endpoints';
import StudentWorksPage from './components/StudentWork';
import './App.css';
import Dropdown from './components/Dropdown';
import styled from 'styled-components';

function App() {
  const [subjects, setSubjects] = useState([]);
  const [subject, setSubject] = useState(CATEGORIES.SUBJECT);
  const [objectives, setObjectives] = useState([]);
  const [objective, setObjective] = useState(CATEGORIES.OBJECTIVE);

  const fetchSubjects = () => {
    fetch(ENDPOINTS.FETCH_SUBJECTS, {
      method: 'GET',
      headers: { "Content-Type": "application/json" },
    })
    .then((response) => {
      if (response.ok) {
        return response.json();
      } else {
        console.log('There is an error when fetching the data.')
      }
    }).then((data) => {
      setSubjects(data);
    }).catch((error) => {
      console.log(error);
    });
  }

  const fetchObjectives = async (subject: string) => {
    await fetch(ENDPOINTS.FETCH_OBJECTIVES, {
      method: 'POST',
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(subject),
    })
    .then((response) => {
      if (response.ok) {
        return response.json();
      } else {
        console.log('There is an error when fetching the data.')
      }
    }).then((data) => {
      setObjectives(data);
    }).catch((error) => {
      console.log(error);
    });
  }

  useEffect(() => {
    // Fetch all subjects.
    fetchSubjects();
  }, []);

  useEffect(() => {
    if (subject && subject !== CATEGORIES.SUBJECT) {
      fetchObjectives(subject);
    }
  }, [subject]);

  return (
    <div className="App">
      <header className="App-header">
        <h1>Student Progress Report</h1>
        <p>Correct answers chart  per student.</p>
      </header>
      <SelectionWrapper>
          <Dropdown 
            title={CATEGORIES.SUBJECT} 
            options={subjects} 
            checked={subject} 
            setChecked={setSubject} 
          />
          <Dropdown 
            title={CATEGORIES.OBJECTIVE} 
            options={objectives} 
            checked={objective} 
            setChecked={setObjective} 
            disabled={subject === CATEGORIES.SUBJECT}
          />
        </SelectionWrapper>
        <StudentWorksPage subject={subject} objective={objective} />
    </div>
  );
}

const SelectionWrapper = styled.div`
  display: flex;
  justify-content: center;
`;

export default App;
