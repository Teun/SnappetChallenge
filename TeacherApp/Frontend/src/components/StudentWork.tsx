import React, { FunctionComponent, useEffect, useState } from 'react';
import styled from 'styled-components';
import {
  Chart as ChartJS,
  CategoryScale,
  LinearScale,
  BarElement,
} from 'chart.js';
import * as CATEGORIES from './../constants/Categories';
import * as ENDPOINTS from './../constants/Endpoints';
import { Bar } from 'react-chartjs-2';
import { Student } from '../types/student';
import { Work } from '../types/work';

ChartJS.register(
  CategoryScale,
  LinearScale,
  BarElement
);

export const options = {
  indexAxis: 'y' as const,
  elements: {
    bar: {
      borderWidth: 5,
    },
  },
  responsive: true,
  plugins: {
    legend: {
      position: 'right' as const,
    },
    title: {
      display: true,
      text: 'Correct answer chart per student.',
    },
  },
};

type Props = {
  subject: string;
  objective: string | null;
};

const StudentWorksPage: FunctionComponent<Props> = ({ subject, objective }) => {
  // States.
  const [students, setStudents] = useState<Student[]>([]);
  const [works, setWorks] = useState<Work[]>([]);
  const [correct, setCorrect] = useState<number[]>([]);

  const dataBar = {
    labels: students.map((student: Student) => student['studentId']),
    datasets: [
      {
        label: 'Correct answers',
        backgroundColor: '#EC932F',
        borderColor: 'rgba(255,99,132,1)',
        borderWidth: 1,
        hoverBackgroundColor: 'rgba(255,99,132,0.4)',
        hoverBorderColor: 'rgba(255,99,132,1)',
        data: correct,
      },
    ]
  };

  const fetchStudentsData = () => {
    fetch(ENDPOINTS.FETCH_STUDENTS, {
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
      setStudents(data);
    }).catch((error) => {
      console.log(error);
    });
  }

  const fetchWorks = async (subject: string, learningObjective: string | null) => {
    await fetch(ENDPOINTS.FETCH_WORKS, {
      method: 'POST',
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({
        subject,
        learningObjective,
      }),
    })
    .then((response) => {
      if (response.ok) {
        return response.json();
      } else {
        console.log('There is an error when fetching the data.')
      }
    }).then((data: Work[]) => {
      setWorks(data);
    }).catch((error) => {
      console.log(error);
    });
  }

  const getCorrectAnswers = (works: Work[]) => {
    const correctAnswers: number[] = [];
      students.map((student) => {
        const worksOfStudent = works.filter((work) => work.userId === student.studentId);
        if (worksOfStudent.length === 0) {
          correctAnswers.push(0);
        } else {
          const correctCount = worksOfStudent.filter((workOfStudent) => workOfStudent.correct).length;
          correctAnswers.push(correctCount);
        }
      });
      setCorrect(correctAnswers)
  }

  useEffect(() => {
    // Fetch students' data.
    fetchStudentsData();
  }, [])

  // Set data based on chosen subject and learning objective.
  useEffect(() => {
    if (subject !== CATEGORIES.SUBJECT && objective !== CATEGORIES.OBJECTIVE) {
      fetchWorks(subject, objective);
    } else if (subject !== CATEGORIES.SUBJECT) {
      fetchWorks(subject, null);
    }
  }, [subject, objective])

  useEffect(() => {
    if (works.length > 0) {
      getCorrectAnswers(works);
    }
  }, [works])

  return (
      <BarWrapper>
        <Bar options={options} data={dataBar} />
      </BarWrapper>
  )
}

const BarWrapper = styled.div`
  height: 55vh;
  width: auto; 
  position: relative;
  margin: 0 2vw;
  margin-bottom: 1em; 
  padding: 1em;
  display: flex;
  justify-content: center;
`;

export default StudentWorksPage;
