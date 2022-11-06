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
        https: true,
        proxy: {
            '/api': {
                target: 'https://isitpayday-api.herokuapp.com',
                secure: false,
                changeOrigin: true
            }
        }
    }
});
