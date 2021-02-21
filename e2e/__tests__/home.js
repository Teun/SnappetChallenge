const {expect} = require('chai');

Feature('home');

Scenario('home report screen title', ({I}) => {
  I.amOnPage('/');
  I.see('Report');
});

Scenario('about report screen title', ({I}) => {
  I.amOnPage('/about');
  I.see('Snappet Challenge');
});

Scenario('open and close the drawer menu and check the menu items', ({I}) => {
  I.amOnPage('/');
  I.click({css: '#sidemenu-button'});
  I.see('Report', {css: '#drawer-menu'});
  I.see('About', {css: '#drawer-menu'});

  I.click({css: '#about-link'});

  I.waitToHide({css: '#drawer-menu'});
  I.dontSeeElement({css: '#drawer-menu'});
});

Scenario('initial `date from` and `date to` must be ', async ({I}) => {
  I.amOnPage('/');

  I.dontSeeElement({css: '.MuiDataGrid-overlay'});

  const initialRows = await I.grabNumberOfVisibleElements({css: '.MuiDataGrid-row'});

  I.fillField({css: '#datetime-from'}, '26030020170000');
  I.fillField({css: '#datetime-to'}, '24020020140000');

  I.seeElement({css: '.MuiDataGrid-overlay'});

  I.see('Total of correct answers: 0', {css: '#summary'});
  I.see('Total of students: 0', {css: '#summary'});
  I.see('Total of exercises: 0', {css: '#summary'});

  expect(initialRows).to.be.greaterThan(0);
});
