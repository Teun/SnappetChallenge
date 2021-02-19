import React from 'react';
import renderer from 'react-test-renderer';

import View from '../View';

describe('components', () => {
  describe('atoms', () => {
    describe('View', () => {
      test('should render a View element as a flex div', () => {
        const tree = renderer.create(<View>content</View>).toJSON();
        expect(tree).toMatchSnapshot();
        expect(tree).toHaveStyleRule('display', 'flex');
        expect(tree).toHaveStyleRule('flex-direction', 'column');
        expect(tree).toHaveStyleRule('justify-content', 'center');
        expect(tree).toHaveStyleRule('align-items', 'center');
        expect(tree).toHaveStyleRule('flex', 'inherit');
      });

      test('should render a View element with flex-start aligned content', () => {
        const tree = renderer.create(
          <View justifyContent="flex-start" alignItems="flex-start">content</View>
        ).toJSON();
        expect(tree).toMatchSnapshot();
        expect(tree).toHaveStyleRule('display', 'flex');
        expect(tree).toHaveStyleRule('flex-direction', 'column');
        expect(tree).toHaveStyleRule('justify-content', 'flex-start');
        expect(tree).toHaveStyleRule('align-items', 'flex-start');
        expect(tree).toHaveStyleRule('flex', 'inherit');
      });

      test('should render a View element with flex size 5 and direction row', () => {
        const tree = renderer.create(
          <View flex="5" flexDirection="row">content</View>
        ).toJSON();
        expect(tree).toMatchSnapshot();
        expect(tree).toHaveStyleRule('display', 'flex');
        expect(tree).toHaveStyleRule('flex-direction', 'row');
        expect(tree).toHaveStyleRule('justify-content', 'center');
        expect(tree).toHaveStyleRule('align-items', 'center');
        expect(tree).toHaveStyleRule('flex', '5');
      });
    });
  });
});
