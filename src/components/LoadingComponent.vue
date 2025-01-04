<template>
    <div class="loading-container">
      <img src="@/assets/tohru.gif" alt="Carregando..." class="tohru-gif" />
      <p class="loading-text">Carregando...</p>
    </div>
  </template>

<script>
export default {
  mounted() {
    setTimeout(() => {
      const isAuthenticated = sessionStorage.getItem('isAuthenticated');
      
      // After logout, redirect to login page
      if (!isAuthenticated) {
        this.$router.push('/');
      } else {
        // If authenticated, go to their intended destination
        const targetPath = sessionStorage.getItem('selectedRoute') || '/chat';
        this.$router.push(targetPath);
      }
    }, 3000);
  }
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
  