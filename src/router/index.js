import Vue from 'vue';
import Router from 'vue-router';

import Home from '@/views/HomeView.vue';

Vue.use(Router);

export default new Router({
  mode: 'history', // Use o modo de history para URLs amigáveis
  routes: [
    {
      path: '/',
      name: 'Home',
      component: Home
    },
    // Outras rotas...
  ]
});
