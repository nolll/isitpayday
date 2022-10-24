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
        path: path.resolve(__dirname, './dist'),
        publicPath: '/'
    },
    devtool: 'source-map',
    module: {
        rules: [
            // {
            //     test: /\.(png|jpg)$/i,
            //     type: 'asset/resource',
            // },
            {
                test: /\.(png|jpg)$/i,
                use: [
                    {
                        loader: 'file-loader',
                    },
                ],
            },
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
        new webpack.DefinePlugin({
            __VUE_OPTIONS_API__: false,
            __VUE_PROD_DEVTOOLS__: true
        }),
        new CleanWebpackPlugin(),
        new MiniCssExtractPlugin({
            filename: 'main-[contenthash].css'
        }),
        new VueLoaderPlugin(),
        new HtmlWebpackPlugin({
            template: path.resolve(__dirname, './index.html')
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
