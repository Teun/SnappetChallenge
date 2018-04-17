import React from 'react';
import ReactDOM from 'react-dom';
import { Provider } from 'react-redux';

export default (Component, container, options = {
  store: false,
  config: {},
}) => {
  if (container) {
    if (options.store) {
      ReactDOM.render(
        // eslint-disable-next-line
        <Provider store={window.store}>
          <Component {...options.props} />
        </Provider>,
        container,
      );
    } else {
      ReactDOM.render(
        <Component {...options.props} />,
        container,
      );
    }
  }
};
