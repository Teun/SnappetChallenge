import React from 'react';
import renderer from 'react-test-renderer';

import GradientBar from '../GradientBar';

describe('components', () => {
  describe('molecules', () => {
    describe('GradientBar', () => {
      test('should render GradientBar with current at 0 and maximum as 200', () => {
        const tree = renderer.create(<GradientBar current={0} maximun={200} />).toJSON();
        expect(tree).toMatchSnapshot();
      });

      test('should render GradientBar with current at 50 and maximum as 100', () => {
        const tree = renderer.create(<GradientBar current={50} maximun={200} />).toJSON();
        expect(tree).toMatchSnapshot();
      });

      test('should render GradientBar with current at 100 and maximum as 100', () => {
        const tree = renderer.create(<GradientBar current={100} maximun={200} />).toJSON();
        expect(tree).toMatchSnapshot();
      });
    });
  });
});
