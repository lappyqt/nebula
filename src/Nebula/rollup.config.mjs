import typescript from "@rollup/plugin-typescript";
import nodeResolve from "@rollup/plugin-node-resolve";
import terser from "@rollup/plugin-terser";
import scss from "rollup-plugin-scss";

export default {
    input: "./wwwroot/ts/main.ts",
    output: {
        file: "wwwroot/dist/bundle.min.js",
        format: "cjs",
        assetFileNames: '[name][extname]'
    },
    plugins: [
        typescript(),
        nodeResolve({ browser: true }),
        terser(),
        scss({
            outputStyle: 'compressed'
        })
    ]
}