import { resolve } from "path";
import { defineConfig } from "vite";
import react from "@vitejs/plugin-react";

function getProxy() {
  return {
    "/api": {
      //target: 'https://api.isitpayday.com',
      target: "https://localhost:5010",
      rewrite: (path: string) => path.replace(/^\/api/, ""),
      changeOrigin: true,
      secure: false,
      ws: true,
    },
  };
}

export default defineConfig({
  resolve: {
    alias: {
      "@": resolve(__dirname, "./scripts"),
    },
  },
  plugins: [react()],
  server: {
    port: 9000,
    proxy: getProxy(),
  },
});
