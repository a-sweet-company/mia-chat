<template>
    <div class="home-container">
      <Header />
      
      <head>
      <link href="https://fonts.googleapis.com/css2?family=Jost:wght@400;500;600&display=swap" rel="stylesheet">
      </head>

  
      <main class="main-content">
        <!-- Container Esquerdo -->
        <section class="left-container">
          <h1>Não fique sozinho,</h1>
          <h2>Converse com alguém que entende você.</h2>
          <div class="subscribe-section">
            <div class="sarah-section">
              <div class="lado-esquerdo">
                <img class="avatar-sarah" src="../assets/sarah-avatar-2-removebg-preview 1.png" alt="Sarah" />
              </div>
              <div class="lado-direito">
                <img class="logo-sarah" src="../assets/sarah-color-logo.png" alt="Sarah"/>
                <button class="sarah-button" type="submit">Conhecer Sarah</button>
              </div>
            </div>
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
  /* Layout geral */
  .home-container {
    display: flex;
    flex-direction: column;
    justify-content: space-between;
    min-height: 100vh;
    background-color: var(--background-color);
    color: var(--h1-color);
    font-family: 'Jost', sans-serif; 
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
    margin-bottom: -10px;
    text-align: start;
    width: 87%;
    border: 1px solid black;
  }
  
  .left-container h2 {
    font-size: 1.5rem;
    color: var(--h2-color);
    margin-bottom: 5px;
    text-align: start;
    width: 87%;
    border: 1px solid black;
  }
  
  .left-container p {
    font-size: 1.0rem;
    margin-bottom: 10px;
    margin-left: 3vw;
    width: 90%;
    text-align: start;
    color: var(--h2-color);
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
  