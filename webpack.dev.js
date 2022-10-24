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
            '/api/options': {
                target: 'http://localhost:9000',
                router: () => 'https://isitpayday-api.herokuapp.com',
                logLevel: 'debug',
                secure: false,
                changeOrigin: true
            },
            '/api/monthly': {
                target: 'http://localhost:9000',
                router: () => 'https://isitpayday-api.herokuapp.com',
                logLevel: 'debug',
                secure: false,
                changeOrigin: true
            },
            '/api/weekly': {
                target: 'http://localhost:9000',
                router: () => 'https://isitpayday-api.herokuapp.com',
                logLevel: 'debug',
                secure: false,
                changeOrigin: true
            }
         }
    }
});
