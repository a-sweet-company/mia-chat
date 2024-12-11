import Vue from 'vue';
import Router from 'vue-router';

// Importação das views
import HomeView from '@/views/HomeView.vue';
import AboutView from '@/views/AboutView.vue';

Vue.use(Router);

export default new Router({
  mode: 'history', // Remove o hash (#) da URL
  base: process.env.BASE_URL, // Define a base da aplicação
  routes: [
    {
      path: '/', // Caminho da rota
      name: 'Home', // Nome da rota
      component: HomeView, // Componente associado
    },
    {
      path: '/about', // Caminho da rota
      name: 'About', // Nome da rota
      component: AboutView, // Componente associado
    },
    // Página 404 (Opcional)
    {
      path: '*',
      name: 'NotFound',
      component: () => import('@/views/NotFoundView.vue'), // Importação dinâmica
    },
  ],
});
