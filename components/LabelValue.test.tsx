import React from 'react';
import { render } from '@testing-library/react';

import LabelValue from './LabelValue';

describe('LabelValue', () => {
  it('matches snapshot', () => {
    const { container } = render(<LabelValue label="test" value="value" />);
    expect(container).toMatchSnapshot();
  });
});
