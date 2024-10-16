<template>
    <div class="home-container">
      <Header />
  
      <main class="main-content">
        <!-- Container Esquerdo -->
        <section class="left-container">
          <h1>Não fique sozinho,</h1>
          <p>Converse com alguém que entende você.</p>
          <div class="subscribe-section">
            <p>Receba atualizações exclusivas e seja um dos primeiros a experimentar novas funcionalidades.</p>
            <form @submit.prevent="subscribe">
              <input type="email" placeholder="Digite seu email" v-model="email" />
              <button type="submit">Inscrever-se</button>
            </form>
          </div>
        </section>
  
        <!-- Container Direito -->
        <section class="right-container">
          <div class="chat-preview">
            <div class="user-message">
              <span>You 23:40</span>
              <p>Eu tava pensando aqui... como seria seu dia perfeito?</p>
            </div>
            <div class="sarah-message">
              <span>Sarah 23:40</span>
              <p>
                Ai, nada bobo! Eu adoro essas perguntas. Acho que meu dia perfeito começaria
                com uma conversa tranquila...
              </p>
            </div>
          </div>
        </section>
      </main>
  
      <Footer />
    </div>
  </template>
  
  <script>
  import Header from '../components/HeaderComponent.vue';
  import Footer from '../components/FooterComponent.vue';
  
  export default {
    components: {
      Header,
      Footer
    },
    data() {
      return {
        email: ""
      };
    },
    methods: {
      subscribe() {
        console.log(`Inscrito com o email: ${this.email}`);
      }
    }
  };
  </script>
  
  <style scoped>
  /* Paleta de cores */
  :root {
    --blue-color: #0055FF;
    --green-color: #26C467;
    --red-color: #FF5454;
    --yellow-color: #FFD400;
    --sarahPink-color: #FFC5DB;
    --background-color: #FFF7E5;
    --h1-color: #000000;
  }
  
  /* Layout geral */
  .home-container {
    display: flex;
    flex-direction: column;
    justify-content: space-between;
    min-height: 100vh;
    background-color: var(--background-color);
    color: var(--h1-color);
    font-family: 'Arial', sans-serif;
    overflow-x: hidden;
  }
  
  /* Containers principais */
  .main-content {
    display: flex;
    flex: 1;
  }
  
  /* Container Esquerdo */
  .left-container {
    flex: 1;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    padding: 40px;
    background-color: var(--background-color);
  }
  
  .left-container h1 {
    font-size: 2.5rem;
    color: var(--h1-color);
    margin-bottom: 10px;
    text-align: center;
  }
  
  .left-container p {
    font-size: 1.2rem;
    margin-bottom: 20px;
    text-align: center;
  }
  
  .subscribe-section {
    width: 100%;
    text-align: center;
  }
  
  .subscribe-section form {
    display: flex;
    justify-content: center;
    align-items: center;
    margin-bottom: 10px;
  }
  
  .subscribe-section input {
    padding: 10px;
    margin-right: 10px;
    border: 2px solid var(--h1-color);
    width: 400px;
    height: 20px;
    border-radius: 10px;
    background-color: var(--background-color);
  }
  
  .subscribe-section button {
    padding: 10px 20px;
    height: 40px;
    border: 2px solid var(--h1-color);
    border-radius: 10px;
    cursor: pointer;
    transition: background-color 0.3s;
  }
  
  .subscribe-section button:hover {
    background-color: var(--blue-color);
  }
  
  /* Container Direito */
  .right-container {
    flex: 1;
    display: flex;
    justify-content: center;
    align-items: center;
    background-color: var(--background-color);
  }
  
  /* Preview do chat */
  .chat-preview {
    display: flex;
    flex-direction: column;
    background-color: white;
    border-radius: 10px;
    padding: 20px;
    width: 350px;
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
  }
  
  .user-message,
  .sarah-message {
    margin-bottom: 10px;
  }
  
  .user-message p,
  .sarah-message p {
    background-color: var(--sarahPink-color);
    padding: 10px;
    border-radius: 5px;
    font-size: 1rem;
  }
  </style>
  