var path = require('path');
var HtmlWebpackPlugin = require('html-webpack-plugin');

module.exports = {
  entry: './src/index.js',
  output: {
    filename: 'bundle.js',
    path: path.resolve(__dirname, 'dist')
  },
  plugins: [new HtmlWebpackPlugin({
    'title': 'Base Reactjs Template',
    'template': 'public/base_template.ejs'
  })],
  module: {
    loaders: [
      {
	test: /\.js$/,
	exclude: /(node_modules|bower_components)/,
	loader: 'babel-loader',
	query: {
	  presets: ['es2015', 'react']
	}
      }
    ]
  }
}; 
