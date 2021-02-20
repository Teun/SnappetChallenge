import React from 'react';
import {Switch, Route} from 'react-router-dom';

import About from '../components/pages/About';
import Home from '../components/pages/Home';

const routes = [{
  path: '/home',
  Component: () => <Home />,
}, {
  path: '/about',
  Component: () => <About />,
}];

export default () => (
  <Switch>
    {routes.map(({path, Component}) => (
      <Route key={path} path={path} render={Component} />
    ))}
    <Route path="/" render={() => <Home />} />

  </Switch>
);
