import { resolve } from 'path';
import { defineConfig } from 'vite';
import react from '@vitejs/plugin-react';

const getChunks = (id: string) => (id.includes('node_modules') ? 'vendors' : null);

const getAlias = () => ({
  '@': resolve(__dirname, './scripts'),
});

const getProxy = () => ({
  '/api': {
    //target: 'https://api.isitpayday.com',
    target: 'https://localhost:5010',
    rewrite: (path: string) => path.replace(/^\/api/, ''),
    changeOrigin: true,
    secure: false,
    ws: true,
  },
});

export default defineConfig({
  resolve: {
    alias: getAlias(),
  },
  plugins: [react()],
  server: {
    port: 9000,
    proxy: getProxy(),
  },
  build: {
    rollupOptions: {
      output: {
        manualChunks: getChunks,
      },
    },
  },
});
