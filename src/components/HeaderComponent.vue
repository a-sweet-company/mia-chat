<template>
  <header class="header">
    <nav>
      <router-link
        v-for="option in options"
        :key="option.name"
        :to="option.path"
        :class="{ active: option.name === activeOption }"
        @mouseover="hoveredOption = option.name"
        @mouseleave="hoveredOption = null"
        @click="setActive(option.name)"
      >
        {{ option.name }}
      </router-link>
    </nav>
  </header>
</template>

<script>
export default {
  props: ['activeOption'],
  data() {
    return {
      options: [
        { name: 'Home', path: '/' },
        { name: 'Chat', path: '/chat' },
        { name: 'Settings', path: '/settings' },
      ],
      hoveredOption: null,
    };
  },
  methods: {
    setActive(option) {
      this.$emit('update:activeOption', option);
    },
  },
};
</script>

<style scoped>
/* Estilo geral do header */
.header {
  display: flex;
  justify-content: center; /* Centraliza horizontalmente o conteúdo */
  background-color: #f4f4f4;
  padding: 15px 20px;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  width: 100%;
}

/* Estilo da navegação */
.header nav {
  display: flex;
  gap: 20px; /* Espaçamento entre os links */
}

/* Estilo dos links */
.header nav a {
  color: #333;
  text-decoration: none;
  padding: 10px 15px;
  border-radius: 5px;
  transition: all 0.3s ease; /* Suaviza a transição */
}

/* Efeito de hover nos links */
.header nav a:hover {
  color: #fff;
  background-color: #1199CE; /* Cor de fundo no hover */
}

/* Estilo para o link ativo */
.header nav a.active {
  color: #fff;
  background-color: #1199CE;
  font-weight: bold;
}

/* Estilo responsivo para telas menores */
@media (max-width: 768px) {
  .header {
    padding: 10px 15px;
  }

  .header nav {
    gap: 10px; /* Reduz o espaçamento entre os links */
  }

  .header nav a {
    padding: 8px 10px; /* Reduz o padding dos links */
    font-size: 0.9rem; /* Ajusta o tamanho da fonte */
  }
}
</style>
