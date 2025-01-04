// router/index.js
import Vue from 'vue'
import VueRouter from 'vue-router'
import HomeView from '@/views/HomeView.vue'
import Chat from '@/views/ChatView.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Login',
    component: HomeView
  },
  {
    path: '/chat',
    name: 'Chat',
    component: Chat,
    meta: { requiresAuth: true }
  },
  {
    path: '/about',
    name: 'About',
    
    component: () => import( '../views/AboutView.vue')
  }
  ,{
    path: '/loading',
    name: 'Loading',
    
    component: () => import( '../views/LoadingView.vue')
  }
]

const router = new VueRouter({
  routes
})

router.beforeEach((to, from, next) => {
  const isAuthenticated = sessionStorage.getItem('isAuthenticated')

  // Se a rota exigir autenticação, verifica se o usuário está autenticado
  if (to.matched.some(record => record.meta.requiresAuth)) {
    if (!isAuthenticated) {
      next({ path: '/' }) // Se não estiver autenticado, vai para login
    } else {
      next() // Caso contrário, pode acessar a rota
    }
  } else {
    // Evitar redirecionamento automático para /chat quando o usuário não está autenticado
    if (to.path === '/' && isAuthenticated) {
      next({ path: '/chat' }) // Redireciona para /chat se o usuário estiver autenticado
    } else {
      next() // Deixa o fluxo continuar normalmente
    }
  }
})


export default router