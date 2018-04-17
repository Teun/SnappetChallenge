import './index.css';

import ClassResults from './containers/ClassResults';

import render from './render';

const app = (container) => {
  render(ClassResults, container.querySelector('.js-main-app'), { store: false });
};

// Init the components
// eslint-disable-next-line
app(document);

// Define a global JS function that can be called from window object (BE can init FE components)
// eslint-disable-next-line
window.reinitJs = app;
