import React from 'react';
import { useRouteError, isRouteErrorResponse } from 'react-router-dom';

export default function ErrorPage () {
  const error = useRouteError();

  if (isRouteErrorResponse(error)) {
    return (

      <div id="error-page">
        <h1>Something went wrong!</h1>
        <h2>{error.status}</h2>
        <p>{error.statusText}</p>
        {error.data?.message && <p>{error.data.message}</p>}
    <a href={'/'}>Go home</a>

      </div>
    );
  } else {
    return (
      <div>
        Unknown error
        <a href={'/'}>Go home</a>
      </div>
    );
  }
}
