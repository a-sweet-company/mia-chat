<template>
  <div class="chat-view">
    <HeaderComponent />
    <div class="chat-container">
      <ChatStatusComponent 
        :status="miaStatus" 
        style="position: absolute; top: 0; left: 0; right: 0; z-index: 10;" 
      />
      <MessageList 
        :messages="messages" 
        style="padding-top: 60px; padding-bottom: 60px;" 
      />
      <IntroModal
        :showIntroModal="showIntroModal"
        @close-intro-modal="closeIntroModal"
      />
      <transition name="fade">
        <div v-if="showWelcomeMessage" class="welcome-message">
          Olá, como posso te ajudar?
        </div>
      </transition>
      <!-- Modal de Erro -->
      <transition name="fade">
        <div v-if="errorDetails" class="error-modal">
          <div class="modal-content">
            <h3>Erro {{ errorDetails.code }} - {{ errorDetails.name }}</h3>
            <p>{{ errorDetails.description }}</p>
            <button @click="errorMessage = null; errorDetails = null;">Fechar</button>
          </div>
        </div>
      </transition>
      <transition name="fade">
        <div class="error-message" v-if="errorMessage">
          {{ errorMessage }}
        </div>
      </transition>
      <transition name="fade">
        <div class="suggestions-container" v-if="showSuggestions">
          <div
            class="suggestion"
            v-for="(suggestion, index) in suggestions"
            :key="index"
            @click="selectSuggestion(suggestion)"
          >
            {{ suggestion }}
          </div>
        </div>
      </transition>
      <MessageInput
        v-if="showInput"
        ref="messageInput"
        @send-message="handleSendMessage"
        @receive-message="handleReceiveMessage"
        @error="handleError"
      />
    </div>
  </div>
</template>


<script>
import MessageList from "@/components/MessageList.vue";
import MessageInput from "@/components/MessageInput.vue";
import HeaderComponent from "@/components/HeaderComponent.vue";
import IntroModal from "@/components/IntroModal.vue";
import ChatStatusComponent from "@/components/ChatStatusComponent.vue";

export default {
  components: {
    MessageList,
    MessageInput,
    HeaderComponent,
    IntroModal,
    ChatStatusComponent,
  },
  data() {
    return {
      showIntroModal: true,
      showWelcomeMessage: false,
      showInput: false,
      messages: [],
      suggestions: [
        "Você pode me ajudar a entender melhor como estou me sentindo?",
        "Pode sugerir uma técnica para me ajudar a relaxar?",
        "Como lidar com pensamentos negativos?",
      ],
      showSuggestions: false,
      errorMessage: null,  
      errorDetails: null, 
      miaStatus: "Online",
    };
  },
  mounted() {
}
,
  methods: {
    closeIntroModal() {
      this.showIntroModal = false;
      this.showSuggestions = true;
      this.showWelcomeMessage = true;
      this.showInput = true;
    },
    handleSendMessage(message) {
      this.messages.push(message);
      this.showSuggestions = false;
      this.showWelcomeMessage = false;
      this.miaStatus = "Digitando...";
    },
    handleReceiveMessage(message) {
      this.messages.push(message);
      this.miaStatus = "Online";
    },
    handleError(error) {
    // Defina os detalhes do erro
    this.errorDetails = {
      code: error.code || "000",  // Número do erro, caso exista
      name: error.name || "Erro desconhecido",
      description: error.message || "Ocorreu um erro inesperado. Tente novamente.",

    };      
    this.showIntroModal = false,
    this.showSuggestions = false,
    this.errorMessage = "Houve um erro!";  // Mensagem simples para exibir ao usuário
    setTimeout(() => {
      this.errorMessage = null;  // Fecha a mensagem após 5 segundos
      this.errorDetails = null;
    }, 10000);
  },
    async selectSuggestion(suggestion) {
      await this.$refs.messageInput.sendMessage(suggestion);
      this.showSuggestions = false;
    }
  }
};
</script>

<style scoped>
.chat-view {
  background-color: var(--color-branco-claro);
}

.prompt-suggestions span {
  cursor: pointer;
  color: var(--color-azul);
  padding: 5px;
  display: flex;
}

.suggestions-container {
  display: flex;
  flex-direction: column;
  margin-bottom: 10%;
}

.suggestion {
  background-color: #f1f1f1;
  padding: 10px;
  margin-bottom: 5px;
  border-radius: 5px;
  cursor: pointer;
  transition: background-color 0.3s;
  color: var(--color-preto);
  text-align: center;
}

.suggestion:hover {
  background-color: #e0e0e0;
}

.fade-enter-active,
.fade-leave-active {
  transition: opacity 0.5s;
}

.fade-enter,
.fade-leave-to {
  opacity: 0;
}

.chat-container {
  margin: 0 auto;
  margin-top: 8px;
  width: 70%;
  height: 85vh;
  padding: 20px;
  padding-top: 73px; /* Espaço para o ChatStatus */
  position: relative;
  min-width: 320px;
  display: flex;
  flex-direction: column;
  border: 3px solid var(--color-preto);
  border-radius: 15px;
  background-color: var(--color-branco-claro);
  backdrop-filter: blur(10px);
  overflow: hidden; /* Garante que nada saia do container */
}

.welcome-message {
  color: var(--color-preto);
  padding: 10px;
  text-align: center;
  border-radius: 5px;
  margin-top: 4%;
  font-size: 1.6rem;
  animation: fadeIn 1s;
  animation-timing-function: ease-in-out;
}

@keyframes fadeIn {
  from {
    opacity: 0;
  }
  to {
    opacity: 1;
  }
}
.error-modal {
  position: fixed;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  background-color: var(--color-vermelho-erro);
  color: var(--color-branco);
  padding: 20px;
  border-radius: 10px;
  box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
  z-index: 100;
  width: 80%;
  max-width: 400px;
}

.modal-content {
  text-align: center;
}

.error-modal h3 {
  font-size: 1.4rem;
  font-weight: bold;
  margin-bottom: 10px;
}

.error-modal p {
  font-size: 1rem;
  margin-bottom: 20px;
}

.error-modal button {
  padding: 8px 16px;
  background-color: var(--color-preto);
  color: var(--color-branco);
  border: none;
  border-radius: 5px;
  cursor: pointer;
  transition: background-color 0.3s;
}

.error-modal button:hover {
  background-color: var(--color-azul);
}

.error-message {
  color: var(--color-branco);
  padding: 10px;
  text-align: center;
  font-size: 1.2rem;
  background-color: var(--color-vermelho-erro);
  margin: 10px;
  border-radius: 5px;
}
</style>
