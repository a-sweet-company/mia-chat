<template>
  <header class="header">
    <nav>
      <router-link
        v-for="option in options"
        :key="option.name"
        :to="option.path"
        :class="{ active: activeOption === option.name }"
        @click="setActive(option.name)"
      >
        {{ option.name }}
      </router-link>
    </nav>
  </header>
</template>

<script>
export default {
  data() {
    return {
      options: [
        { name: 'CHAT', path: '/chat' },
        { name: 'SOBRE', path: '/sobre' },
        { name: 'HOME', path: '/' },
        { name: 'PERFIL', path: '/perfil' },
      ],
      activeOption: 'CHAT',
    };
  },
  methods: {
    setActive(option) {
      this.activeOption = option;
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