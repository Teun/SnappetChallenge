import React from 'react';
export * from 'react-virtualized';

const autoSizerProps = {
  height: 100,
  width: 100,
};
export const AutoSizer = (props) => {
  return <div>{props.children(autoSizerProps)}</div>;
};
