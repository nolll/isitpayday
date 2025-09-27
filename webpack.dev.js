const path = require('path');
const { merge } = require('webpack-merge');
const common = require('./webpack.config.js');

module.exports = merge(common, {
  mode: 'development',
  devServer: {
    static: {
      directory: path.join(__dirname, 'dist'),
    },
    compress: true,
    port: 9000,
    server: {
      type: 'http',
    },
    proxy: [
      {
        context: ['/api'],
        //target: 'https://api.isitpayday.com',
        target: 'https://localhost:5010',
        secure: false,
        changeOrigin: true,
        pathRewrite: { '^/api': '' },
      },
    ],
  },
});
