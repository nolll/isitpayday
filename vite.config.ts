import { resolve } from "path";
import vue from "@vitejs/plugin-vue";

function getProxy() {
  return {
    "/api": {
      //target: 'https://api.isitpayday.com',
      target: "https://localhost:5010",
      rewrite: (path) => path.replace(/^\/api/, ""),
      changeOrigin: true,
      secure: false,
      ws: true,
    },
  };
}

export default {
  resolve: {
    alias: {
      "@": resolve(__dirname, "./scripts"),
    },
  },
  plugins: [vue()],
  server: {
    proxy: getProxy(),
  },
};
