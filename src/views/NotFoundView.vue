<template>
  <div class="not-found">
    <h1>404 - Página Não Encontrada</h1>
    <p>Ops! Parece que a página que você está procurando não existe.</p>
    <router-link to="/">Voltar para a Página Inicial</router-link>
    <router-link to="/chat">Ir para o Chat</router-link>                                               
  </div>
</template>

<script>
export default {
  name: 'NotFoundView',
};
</script>

<style scoped>
.not-found {
  text-align: center;
  margin-top: 50px;
}

h1 {
  font-size: 3em;
  color: var(--color-vermelho-erro);
}

p {
  font-size: 1.2em;
  margin: 20px 0;
}

a {
  display: block;
  margin-top: 10px;
  color: var(--color-azul);
  text-decoration: none;
  font-weight: bold;
}

a:hover {
  text-decoration: underline;
  color: var(--color-preto);
  transition: color 0.3s ease;
}
</style>
