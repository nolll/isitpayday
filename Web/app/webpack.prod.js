const { merge } = require('webpack-merge');
const common = require('./webpack.config.js');

module.exports = merge(common, {
    mode: 'production',
    plugins: getPlugins(),
    devtool: 'source-map'
});

function getPlugins() {
    const plugins = [];

    if (process.env.ANALYZE_BUNDLE) {
        const BundleAnalyzerPlugin = require('webpack-bundle-analyzer').BundleAnalyzerPlugin;

        plugins.push(new BundleAnalyzerPlugin());
    }

    return plugins;
}