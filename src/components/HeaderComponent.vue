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
        { name: 'APOIAR', path: '/apoiar' },
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
/* Header container */
.header {
  display: flex;
  justify-content: center;
  background-color: none;
  padding: 20px 0;
}

/* Navegação com gap */
.header nav {
  display: flex;
  gap: 70px;
}

/* Estilo dos botões */
.header nav a {
  text-decoration: none;
  color: #333;
  padding: 4px 60px;
  border: 1px solid #000000;
  background-color: none;
  border-radius: 6px; 
  transition: all 0.3s ease;
  font-size: 1.0rem;
}

/* Hover */
.header nav a:hover {
  background-color: #1199CE;
  color: #fff;
  border-color: #1199CE;
}

/* Aba ativa */
.header nav a.active {
  background-color: #353535;
  color: #fff;
  border-color: #353535;
}

/* Ajustes para dispositivos móveis */
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