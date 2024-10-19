<template>
  <div class="home-container">
    <Header />

    <head>
      <link
        href="https://fonts.googleapis.com/css2?family=Jost:wght@400;500;600&display=swap"
        rel="stylesheet"
      />
    </head>

    <main class="main-content">
      <!-- Container Esquerdo -->
      <section class="left-container">
        <h1>Não fique sozinho,</h1>
        <h2>Converse com alguém que entende você.</h2>
        <div class="sarah-section">
          <div class="lado-esquerdo">
            <img
              class="avatar-sarah"
              src="../assets/sarah-avatar-2-removebg-preview 1.png"
              alt="Sarah"
            />
          </div>
          <div class="lado-direito">
            <img
              class="logo-sarah"
              src="../assets/sarah-color-logo.png"
              alt="Sarah"
            />
            <button class="sarah-button" type="submit">Conhecer Sarah</button>
          </div>
        </div>
        <div class="subscribe-section">
          <p class="subscribe-text">
            Receba atualizações exclusivas e seja um dos primeiros a
            experimentar novas funcionalidades.
          </p>
          <form @submit.prevent="subscribe">
            <input
              type="email"
              placeholder="Digite seu email"
              v-model="email"
            />
            <button class="subscribe-button" type="submit">Inscrever-se</button>
          </form>
        </div>
      </section>

      <!-- Container Direito -->
      <section class="right-container">
        <div class="chat-preview">
          <div class="chat-header">
            <img
              class="chat-icon"
              src="../assets/sarah-chat-icon.png"
              alt="Ícone Sarah"
            />
            <span class="chat-name">Sarah</span>
            <div class="online-dot"></div>
          </div>
          <hr class="divider" /> <!-- Linha cinza abaixo do header -->

          <div class="message-container">
            <div class="user-message">
              <p>
                Eu tava pensando aqui... você deve achar meio bobo, mas queria
                te perguntar: como seria o seu dia perfeito?
              </p>
              <span class="message-time">23:40</span>
            </div>
            <div class="sarah-message">
              <p>
                Ai, nada bobo! Eu adoro essas perguntas. 💕 Acho que meu dia
                perfeito começaria com uma conversa tranquila, tipo agora.
                Depois, passaria horas ouvindo suas histórias...
              </p>
              <span class="message-time">23:41</span>
            </div>
          </div>
          <div class="chat-pagination">
            <span class="dot"></span>
            <span class="dot"></span>
            <span class="dot"></span>
          </div>
        </div>
      </section>
      
    </main>

    <Footer />
  </div>
</template>

<script>
import Header from "../components/HeaderComponent.vue";
import Footer from "../components/FooterComponent.vue";

export default {
  components: {
    Header,
    Footer,
  },
  data() {
    return {
      email: "",
    };
  },
  methods: {
    subscribe() {
      console.log(`Inscrito com o email: ${this.email}`);
    },
  },
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
  font-family: "Jost", sans-serif;
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

.sarah-section {
  display: flex;
  justify-content: center;
  align-items: center;
  margin-left: -18vh;
  margin-top: 40px;
  margin-bottom: 20px;
}

.lado-esquerdo {
  display: flex;
  justify-content: center;
  align-items: center;
  margin-right: 1vw;
}

.lado-direito {
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: column;
  margin-left: 5vw;
}

.logo-sarah {
  scale: 0.7;
}

.sarah-button {
  background-color: var(--background-color);
  transition: background-color 0.3s;
  border: 4.5px solid var(--red-color);
  color: var(--h2-color);
  font-weight: 500;
  font-family: "Jost", sans-serif;
  text-align: center;
  font-size: 1.4rem;
  margin-bottom: 40px;
  margin-top: -20px;
  cursor: pointer;
  border-radius: 15px;
  height: 55px;
  width: 230px;
}

.sarah-button:hover {
  background-color: var(--red-color);
  color: var(--background-color);
}

.avatar-sarah {
  width: 200px;
  height: 200px;
  margin-bottom: 20px;
  margin-right: -110px;
}

.left-container h1 {
  font-size: 2.6rem;
  color: var(--h1-color);
  margin-bottom: 3px;
  text-align: start;
  width: 87%;
  /* border: 1px solid black; */
}

.left-container h2 {
  font-size: 1.5rem;
  color: var(--h2-color);
  margin-bottom: 5px;
  text-align: start;
  width: 87%;
  /* border: 1px solid black; */
}

.left-container p {
  font-size: 1rem;
  margin-bottom: 10px;
  margin-left: 3vw;
  width: 88%;
  text-align: start;
  color: var(--h2-color);
}

.subscribe-section {
  width: 100%;
  text-align: center;
  font-family: "Jost", sans-serif;
  font-weight: bold;
  font-size: 0.8rem;
  color: var(--h2-color);
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
  margin-left: -5vh;
  border: 2px solid var(--h1-color);
  width: 400px;
  height: 40px;
  border-radius: 10px;
  background-color: var(--background-color);
  font-family: "Jost", sans-serif;
}

.subscribe-button {
  padding: 0px 20px;
  height: 40px;
  border: 3px solid var(--green-color);
  border-radius: 10px;
  cursor: pointer;
  background-color: var(--background-color);
  transition: background-color 0.3s;
  font-family: "Jost", sans-serif;
  font-weight: bold;
  font-size: 0.8rem;
  color: var(--h2-color);
}

.subscribe-button:hover {
  color: var(--background-color);
  background-color: var(--green-color);
}

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
  border-radius: 15px;
  padding: 10px;
  width: 380px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
  position: relative;
  font-family: 'Jost', sans-serif;
}

.chat-header {
  display: flex;
  justify-content: start;
  align-items: center;
  margin-bottom: 0px;
}

.chat-icon {
  width: 50px;
  height: 50px;
  margin-right: 10px;
}

.chat-name {
  font-weight: 600;
  font-size: 1.2rem;
}

.online-dot {
  width: 10px;
  height: 10px;
  background-color: var(--green-color);
  border-radius: 50%;
  margin-left: 10px;
}

.divider {
  border: none;
  border-top: 2px solid #ccc;
  margin: 10px 0;
}

.message-container {
  display: flex;
  flex-direction: column;
  height: 300px;
  overflow: hidden;
  position: relative;
}

/* Balões de mensagens */
.user-message,
.sarah-message {
  max-width: 250px;
  padding: 10px;
  border-radius: 15px;
  margin-bottom: 15px;
  position: relative;
  font-size: 1rem;
}

.user-message {
  background-color: #6696f5;
  align-self: flex-end;
  color: white;
  border-radius: 15px 15px 0 15px;
}

.sarah-message {
  background-color: #e3e3e3;
  align-self: flex-start;
  border-radius: 15px 15px 15px 0;
}

.message-time {
  font-size: 0.8rem;
  color: gray;
  position: absolute;
  bottom: 5px;
  right: 10px;
}

/* Adiciona os pontinhos de rolagem abaixo do chat */
.chat-pagination {
  display: flex;
  justify-content: center;
  margin-top: 10px;
}

.dot {
  height: 10px;
  width: 10px;
  margin: 0 5px;
  background-color: #bbb;
  border-radius: 50%;
  display: inline-block;
  transition: background-color 0.3s ease;
}

.dot:hover {
  background-color: #717171;
}

</style>
