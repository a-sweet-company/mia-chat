<template>
  <header class="header">
    <nav>
      <router-link
        v-for="option in options"
        :key="option.name"
        :to="option.path"
        :class="{ active: activeOption === option.name }"
        @click="setActive(option.name, option.path)"
      >
        {{ option.name }}
      </router-link>
      <button @click="logout" :disabled="isLoggingOut">
        {{ isLoggingOut ? 'Saindo...' : 'LOGOUT' }}
      </button>
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
      isLoggingOut: false,
    };
  },
  methods: {
    setActive(option, path) {
      this.activeOption = option;
      if (sessionStorage.getItem('isAuthenticated')) {
        sessionStorage.setItem('selectedRoute', path);
      }
    },
    logout() {
      this.isLoggingOut = true;
      
      setTimeout(() => {
        // Clear all relevant session storage
        sessionStorage.clear();
        
        // Reset the loading state
        this.isLoggingOut = false;
        
        // Then redirect to loading
        this.$router.push('/');
        console.log('Logout realizado com sucesso!');
      }, 2000);
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
  background-color: var(--color-azul);
  color: var(--color-branco);
  border-color: var(--color-azul);
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