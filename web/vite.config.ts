import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'
import tailwindcss from '@tailwindcss/vite'

// https://vite.dev/config/
export default defineConfig({
  plugins: [
    react(),
    tailwindcss(),
  ],
  server: {
    proxy: {
      // If your API route is /message (no /api prefix), add a rewrite:
      "/api": {
        target: "http://localhost:5064",
        changeOrigin: true,
      },
    },
  },
});
