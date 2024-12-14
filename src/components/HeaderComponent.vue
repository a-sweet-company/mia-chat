<template>
  <header class="header">
    <nav>
      <router-link
        v-for="option in options"
        :key="option.name"
        :to="option.path"
        :class="{ active: option.name === activeOption, hover: hoveredOption === option.name }"
        @mouseover.native="hoveredOption = option.name"
        @mouseleave.native="hoveredOption = null"
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
        { name: 'Perfil', path: '/perfil' },
        {name: 'Sobre', path: '/sobre'}
      ],
      hoveredOption: null
    };
  },
  methods: {
    setActive(option) {
      this.$emit('update:activeOption', option);
    }
  }
};
</script>

<style scoped>
/* Estilo geral do header */
.header {
  display: flex;
  justify-content: center; /* Centraliza horizontalmente o conteúdo */
  background-color: var(--branco);
  padding: 15px 20px;
  width: 100vw;
  font-family: "Jost", sans-serif; /* Aplica a fonte Jost ao header */
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
  border-radius: 10px;
  transition: all 0.3s ease; /* Suaviza a transição */
  margin-right: 5vw; 
  border: solid 1.5px #2E2E2E;
  padding-right: 10vw;
  font-family: "Jost", sans-serif; /* Aplica a fonte Jost aos links */
  
}

/* Estilo para o link ativo */
.header nav a.active {
  color: #ffffff;
  background-color: #1199CE;
  font-weight: bold;
}

/* Efeito de hover nos links */
.header nav a.hover {
  color: #fff;
  background-color: #2E2E2E; /* Cor de fundo no hover */
  transform: scale(1.1); /* Aumenta o tamanho do link ao passar o mouse */
  box-shadow: 0 2px 5px rgba(0, 0, 0, 0.2); /* Adiciona uma sombra ao hover */
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