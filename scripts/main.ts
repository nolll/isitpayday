import { createRoot } from 'react-dom/client';
import { createElement } from 'react';
import { QueryClient, QueryClientProvider } from '@tanstack/react-query';
import App from '@/App';
import '@/styles';
import '../images/favicon.png';
import '../images/money.jpg';

const queryClient = new QueryClient();

createRoot(document.getElementById('app')!).render(
  createElement(QueryClientProvider, { client: queryClient }, createElement(App)),
);
