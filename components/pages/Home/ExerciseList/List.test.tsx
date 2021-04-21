import React from 'react';
import { render } from '@testing-library/react';

import List from './List';
import { testList } from '@lib/testUtils';

describe('List', () => {
  it('matches snapshot', () => {
    const { container } = render(<List exercises={testList} />);
    expect(container).toMatchSnapshot();
  });
});
