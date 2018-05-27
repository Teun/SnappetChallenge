import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import Home from './components/Home';
import FetchLearning from './components/FetchLearning';
import FetchStudent from './components/FetchStudent';

export const routes = <Layout>
    <Route exact path='/' component={ Home } />
    <Route path='/fetchlearning/:dateIndex?' component={FetchLearning} />
    <Route exact path='/fetchstudent/:dateIndex?/:learningObjective?' component={FetchStudent} />
</Layout>;