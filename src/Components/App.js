import React, {useEffect} from 'react';
import {useDispatch} from 'react-redux';
import axios from 'axios';
import 'reset-css';

import {
  setByUserId,
  setByDomain
} from '../redux/actions/data';
import Classroom from './Pages/Classroom';

export const App = () => {

  const dispatch = useDispatch();
  useEffect(() => {
    axios({
      method: 'get',
      url: 'http://localhost:9000/todaysResults',
    })
    .then(({data}) => {
      dispatch(setByUserId(data.userResultsPerDomain));
      dispatch(setByDomain(data.classResultsPerDomain));
    });
  }, []);
  return (
    <>
      <Classroom />
    </>
  );
};
