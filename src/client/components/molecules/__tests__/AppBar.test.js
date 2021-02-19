import React from 'react';
import renderer from 'react-test-renderer';

import AppBar from '../AppBar';

describe('components', () => {
  describe('molecules', () => {
    describe('AppBar', () => {
      test('should render AppBar with the provided title', () => {
        const $element = renderer.create(<AppBar title="my custom title" />);
        const tree = $element.toJSON();
        const root = $element.root;

        expect(tree).toMatchSnapshot();
        expect(tree.type).toBe('header');
        expect(root.findByType('h6').children).toEqual(['my custom title']);
      });
    });
  });
});
