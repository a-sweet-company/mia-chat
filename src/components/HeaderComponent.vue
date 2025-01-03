<template>
  <header class="header">
    <nav>
      <router-link
        v-for="option in options"
        :key="option.name"
        :to="option.path"
        :class="{ active: activeOption === option.name }"
      >
        {{ option.name }}
      </router-link>
      <button @click="logout">Logout</button>
    </nav>
  </header>
</template>


<script>
export default {
  data() {
    return {
      options: [
        { name: 'CHAT', path: '/chat' },
        { name: 'SOBRE', path: '/about' },
        { name: 'PERFIL', path: '/perfil' }, 
      ],
      activeOption: 'CHAT',
    };
  },
  methods: {
    setActive(option) {
      this.activeOption = option;
    },
    logout() {
      sessionStorage.removeItem('isAuthenticated'); // Remove a autenticação
      this.$router.push('/'); // Redireciona para a página inicial
      console.log('Logout realizado com sucesso!');
    },
  },
};
</script>

<style scoped>
.header {
  display: flex;
  justify-content: center;
  background-color: none;
  padding: 20px 0;
}

.header nav {
  display: flex;
  gap: 70px;
}

.header nav a {
  text-decoration: none;
  color: var(--color-cinza);
  padding: 4px 60px;
  border: 1px solid var(--color-preto);
  background-color: none;
  border-radius: 6px; 
  transition: all 0.3s ease;
  font-size: 1.0rem;
}

.header nav a:hover {
  background-color: var(--color-azul);
  color: var(--color-branco);
  border-color: var(--color-azul);
}

.header nav a.active {
  background-color: var(--color-cinza);
  color: var(--color-branco);
  border-color: var(--color-cinza);
}
.header nav button {
  text-decoration: none;
  color: var(--color-cinza);
  padding: 4px 60px;
  border: 1px solid var(--color-preto);
  background-color: none;
  border-radius: 6px; 
  transition: all 0.3s ease;
  font-size: 1.0rem;
 
}
.header nav button:hover {
  background-color: var(--color-vermelho-erro);
  color: var(--color-branco);
  border-color: var(--color-vermelho-erro);
}
@media (max-width: 768px) {
  .header nav {
    gap: 10px;
  }
  .header nav a {
    padding: 6px 12px;
    font-size: 0.8rem;
  }
}
</style>