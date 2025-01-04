<template>
    <div class="loading-container">
      <img src="@/assets/tohru.gif" alt="Carregando..." class="tohru-gif" />
      <p class="loading-text">Carregando...</p>
    </div>
  </template>
  
  <script>
  export default {
    mounted() {
      // Redireciona automaticamente para o Chat após 3 segundos
      setTimeout(() => {
        this.$router.push('/chat');
      }, 3000);
    },
  };
  </script>
  
  <style scoped>
  .loading-container {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    height: 100vh;
    background-color: var(--color-branco-claro);
  }
  
  .loading-gif {
    width: 150px;
    height: 150px;
  }
  
  .loading-text {
    font-size: 1.5rem;
    color: var(--color-preto);
    margin-top: 20px;
  }
  </style>
  