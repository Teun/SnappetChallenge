/*
 * For a detailed explanation regarding each configuration property, visit:
 * https://jestjs.io/docs/en/configuration.html
 */

module.exports = {
  // Automatically clear mock calls and instances between every test
  clearMocks: true,

  // A map from regular expressions to module names or to arrays of module names that allow to stub out resources with a single module
  moduleNameMapper: {
    '^@components(.*)$': '<rootDir>/components$1',
    '^@lib(.*)$': '<rootDir>/lib$1',
    '^@Data(.*)$': '<rootDir>/Data$1',
  },

  // A list of paths to modules that run some code to configure or set up the testing framework before each test
  setupFilesAfterEnv: ['./lib/setupTests.ts'],
};
