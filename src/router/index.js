import Vue from "vue";
import Router from "vue-router";
import HomeView from "@/views/HomeView.vue";
import AboutView from "@/views/AboutView.vue";

Vue.use(Router);

export default new Router({
  mode: "history", // Remove o hash (#) da URL
  base: process.env.BASE_URL, // Define a base da aplicação
  routes: [
    {
      path: "/", // Caminho da rota
      name: "Home", // Nome da rota
      component: HomeView, // Componente associado
    },
    {
      path: "/about", // Caminho da rota
      name: "About", // Nome da rota
      component: AboutView, // Componente associado
    },
    {
      path: "/chat", // Caminho da rota
      name: "Chat", // Nome da rota
      component: () => import("@/views/ChatView.vue"), // Importação dinâmica
    },
    // Página 404 (Opcional)
    {
      path: "*",
      name: "NotFound",
      component: () => import("@/views/NotFoundView.vue"), // Importação dinâmica
    },
  ],
});
