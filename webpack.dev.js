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
      type: 'https',
    },
    proxy: [
      {
        context: ['/api'],
        target: 'https://api.isitpayday.com',
        secure: false,
        changeOrigin: true,
        pathRewrite: { '^/api': '' },
      },
    ],
  },
});
