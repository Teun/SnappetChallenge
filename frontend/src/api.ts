import { ElementInterface } from './interfaces/exercise.interface';

interface StudentDataI {
  exercicesIds: string[]
}

const studentsData: { [key: string]: StudentDataI } = { };

export function getStudentsData () {
  return studentsData;
}

export async function uploadWork () {
  const response = await fetch('http://localhost:3000/work.json');
  const data: [ElementInterface] = await response.json();

  data.forEach(element => {
    if (studentsData[element.UserId] === undefined) {
      studentsData[element.UserId] = {
        exercicesIds: [element.ExerciseId.toString()]
      };
    } else {
      studentsData[element.UserId].exercicesIds.push(element.ExerciseId.toString());
    }
  });

  return data;
}

export const snappetApi = {
  getStudentsData
};
