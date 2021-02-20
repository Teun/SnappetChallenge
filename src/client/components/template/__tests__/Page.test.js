import React from 'react';
import renderer from 'react-test-renderer';

import {Page} from '../Page';

describe('components', () => {
  describe('templates', () => {
    describe('Page', () => {
      test('should render Page with the provided title and children', () => {
        const $element = renderer.create(
          <Page>
            <h3>An random h1 title</h3>
          </Page>
        );
        const tree = $element.toJSON();
        const root = $element.root;

        expect(tree).toMatchSnapshot();
        expect(root.findByType('h3').children).toEqual(['An random h1 title']);
      });
    });
  });
});
