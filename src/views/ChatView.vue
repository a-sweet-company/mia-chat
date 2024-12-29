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
      miaStatus: "Online",
    };
  },
  mounted() {
  },
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
      this.errorMessage = error;
      setTimeout(() => {
        this.errorMessage = null;
      }, 5000);
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
</style>
