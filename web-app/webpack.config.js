const HtmlWebpackPlugin = require('html-webpack-plugin');
const { CleanWebpackPlugin } = require('clean-webpack-plugin');

const path = require('path');

module.exports = {
    mode: "development",

    entry: "./src/index.js",

    output: {
        path: path.resolve(__dirname, "dist"),
        filename: "[name].[hash].js"
    },

    resolve: {
      modules: [
        path.resolve(__dirname, "src"),
        path.resolve(__dirname, "node_modules")
      ]
    },

    module: {
        rules: [
          {
            test: /\.js$/,
            exclude: /(node_modules)/,
            use: {
              loader: "babel-loader"
            }
          },
          {
            test: /(\.scss)$/,
            use: [
              "style-loader",
              {
                loader: "css-loader",
                options: {
                  modules: true
                }
              },
              "sass-loader"
            ]
          },
        ]
    },

    plugins: [
      new CleanWebpackPlugin(),
      
      new HtmlWebpackPlugin({
        template: path.resolve(__dirname, "src/index.html")
      })
    ],

    devServer: {
        contentBase: path.resolve(__dirname, "dist"),
        compress: true,
        host: 'localhost',
        port: 3000,
        historyApiFallback: true,
        writeToDisk: true,
        open: true
    }
}