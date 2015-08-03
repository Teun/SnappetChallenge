# Snappet Challenge
What did my class do today? or even better, what can we do with all the available data.

## Required tools
1. NodeJS
1. Bower
1. Grunt

## Setting up this project
1. [Install NodeJS](https://nodejs.org/) with the installer matching your OS
1. Open your favourite command interface and navigate to the root of this project
1. Run `npm install` and afterwards run `bower install` (This will install `node_modules` and `source/vendors`)
1. Type `grunt` to build all files into the distribution folder
1. You can now open your browser and view the website within `dist/` or within `source/app/`

## Grunt command(s) available
1. `grunt `: This is currently the only grunt command available.

## Background information
#### JSON:
1. The JSON is formatted with the Grunt task `seperateJSON` and outputs it into 2 separate files within `dist/json/`:
  1. `data.json`: Rather then showing multiple translations with the same value, the grunt task will generate an unique id and replaces the text with this id. (This saves +/-2,5MB bandwidth and allows faster filtering).
  1. `translations.json`: The string replaced by an id in `data.json`, is put within this file by `{"id": "Text"}`

#### Libraries
1. This Challenge was made with AngularJS, lodash, moment.js and highcharts

#### Structure
1. All codes follow CODESTYLE.md and are checked with the ESLINT validation at the beginning of the  `Grunt` command
1. AngularJS load structure:
 1. Boostrap -> Config -> Run -> Controller <- Provider <- Directive


#### Grunt
1. All Grunt tasks are loaded with `grunt-load-config` and can be found - individual - in the `Grunt` folder
