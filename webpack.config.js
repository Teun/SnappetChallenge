const webpack = require('webpack');
const path = require('path');
const HtmlWebpackPlugin = require('html-webpack-plugin');
const {CleanWebpackPlugin} = require('clean-webpack-plugin');

module.exports = {
  mode: process.env.DEVELOPMENT ? 'development' : 'production',
  devtool: process.env.DEVELOPMENT && 'eval-source-map',
  entry: {
    main: path.resolve(__dirname, './src/client/index.js'),
  },
  output: {
    path: path.resolve(__dirname, './dist'),
    filename: '[name].bundle.js',
  },
  module: {
    rules: [
      {
        test: /\.js$/,
        exclude: /node_modules/,
        use: ['babel-loader'],
      },
      {
        test: /\.(?:ico|gif|png|jpg|jpeg)$/i,
        type: 'asset/resource',
      },
      {
        test: /\.(woff(2)?|eot|ttf|otf|svg|)$/,
        type: 'asset/inline',
      },
      {
        test: /\.css$/i,
        use: ['css-loader'],
      },
    ],
  },
  plugins: [
    new HtmlWebpackPlugin({
      // just a random fancy name :)
      title: 'Teacher Class Reporter',
      template: path.resolve(__dirname, './src/client/index.html'),
      filename: 'index.html',
    }),
    new CleanWebpackPlugin(),
    new webpack.HotModuleReplacementPlugin(),
  ],
  devServer: {
    stats: 'errors-only',
    historyApiFallback: true,
    contentBase: path.resolve(__dirname, './dist'),
    open: true,
    compress: true,
    hot: true,
    port: 5000,
    publicPath: '/',
    overlay: {
      warnings: true,
      errors: true
    },
    proxy: {
      '/api': {
        target: {
          host: '0.0.0.0',
          protocol: 'http:',
          port: 4000
        },
      }
    },
  },
  optimization: {
    minimize: false,
  },
  performance: {
    hints: false,
    maxEntrypointSize: 512000,
    maxAssetSize: 512000
  }
};
