var path = require('path');

module.exports = [{
    entry: './Client/app/_run.ts',
    output: {
        filename: 'bundle.js',
        path: path.resolve(__dirname, 'Content')
    },
    module: {
        rules: [
          {
              test: /\.tsx?$/,
              loader: 'ts-loader',
              exclude: /node_modules/,
          },
        ]
    },
    resolve: {
        modules: ['node_modules', 'Client/app'],
        extensions: [".tsx", ".ts", ".js"]
    },
}];