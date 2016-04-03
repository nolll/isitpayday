var webpack = require("webpack");

module.exports = {
    entry: __dirname + "/Scripts/app.js",
    output: {
        path: __dirname + "/assets",
        filename: "scripts.js"
    },
    devtool: "source-map",
    plugins: [
        new webpack.ProvidePlugin({
            "fetch": "imports?this=>global!exports?global.fetch!whatwg-fetch"
        })
    ]
};