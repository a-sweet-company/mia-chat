<template>
  <div class="chat-view">
    <HeaderComponent />
    <div class="chat-container">
      <ChatStatusComponent :status="miaStatus" />
      <IntroModal
        :showIntroModal="showIntroModal"
        @close-intro-modal="closeIntroModal"
      />
      <transition name="fade">
        <div v-if="showWelcomeMessage" class="welcome-message">
          Olá, como posso te ajudar?
        </div>
      </transition>
      <MessageList :messages="messages" />
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
      <transition name="fade">
        <div v-if="errorMessage" class="error-message">
          {{ errorMessage }}
        </div>
      </transition>
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
  overflow-y: auto;
  position: relative;
  min-width: 320px;
  display: flex;
  flex-direction: column;
  border: 3px solid var(--color-preto);
  border-radius: 15px;
  display: flex;
  flex-direction: column;
  position: relative;
  backdrop-filter: blur(0);
}

.welcome-message {
  color: var(--color-preto);
  padding: 10px;
  text-align: center;
  border-radius: 5px;
  margin-top: 9%;
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
