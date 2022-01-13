const webpack = require('webpack');
const path = require('path');
const MiniCssExtractPlugin = require('mini-css-extract-plugin');
const { VueLoaderPlugin } = require('vue-loader');
const HtmlWebpackPlugin = require('html-webpack-plugin');
const { CleanWebpackPlugin } = require('clean-webpack-plugin');
const CssMinimizerPlugin = require("css-minimizer-webpack-plugin");

module.exports = {
    entry: './scripts/main.ts',
    output: {
        filename: '[name]-[contenthash].js',
        path: path.resolve(__dirname, '../wwwroot/dist'),
        publicPath: '/dist/'
    },
    devtool: 'source-map',
    module: {
        rules: [
            {
                test: /\.css/,
                use: [
                    { loader: MiniCssExtractPlugin.loader },
                    { loader: 'css-loader' }
                ]
            },
            {
                test: /\.vue$/,
                use: [{
                    loader: 'vue-loader'
                }],
                exclude: /node_modules/
            },
            {
                test: /\.js$/,
                loader: 'babel-loader',
                exclude: /node_modules/
            },
            {
                test: /\.ts$/,
                use: [
                    { loader: 'babel-loader' },
                    {
                        loader: 'ts-loader',
                        options: {
                            appendTsSuffixTo: [/\.vue$/]
                        }
                    }
                ],
                exclude: /node_modules/
            }
        ]
    },
    plugins: [
        new CleanWebpackPlugin(),
        new MiniCssExtractPlugin({
            filename: 'main-[contenthash].css'
        }),
        new VueLoaderPlugin(),
        new HtmlWebpackPlugin({
            filename: path.resolve(__dirname, '../Views/Generated/Script.cshtml'),
            template: path.resolve(__dirname, './templates/script-template.txt'),
            inject: false
        }),
        new HtmlWebpackPlugin({
            filename: path.resolve(__dirname, '../Views/Generated/Style.cshtml'),
            template: path.resolve(__dirname, './templates/style-template.txt'),
            inject: false
        })
    ],
    resolve: {
        alias: {
            '@': path.resolve(__dirname, './scripts')
        },
        extensions: ['.ts', '.js', '.vue']
    },
    optimization: {
        splitChunks: {
            chunks: 'all',
            name: 'vendor'
        },
        minimizer: [
            new CssMinimizerPlugin(),
        ],
    },
    stats: { children: false }
};
