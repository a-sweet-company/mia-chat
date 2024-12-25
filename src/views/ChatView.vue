<template>
  <div class="chat-view">
    <HeaderComponent />
    <div class="chat-container">
      <IntroModal
        :showIntroModal="showIntroModal"
        @close-intro-modal="closeIntroModal"
      />
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

export default {
  components: {
    MessageList,
    MessageInput,
    HeaderComponent,
    IntroModal,
  },
  data() {
    return {
      showIntroModal: true,
      messages: [],
      suggestions: [
        "Qual é a previsão do tempo para hoje?",
        "Me conte uma curiosidade interessante.",
        "Você pode me ajudar com uma receita fácil?",
      ],
      showSuggestions: false,
      errorMessage: null
    };
  },
  methods: {
    closeIntroModal() {
      this.showIntroModal = false;
      this.showSuggestions = true;
    },
    handleSendMessage(message) {
      this.messages.push(message);
      // Esconde as sugestões quando uma mensagem é enviada
      this.showSuggestions = false;
    },
    handleReceiveMessage(message) {
      this.messages.push(message);
    },
    handleError(error) {
      this.errorMessage = error;
      setTimeout(() => {
        this.errorMessage = null;
      }, 5000);
    },
    async selectSuggestion(suggestion) {
      // Simula o envio direto da mensagem
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
  margin-top: 10px;
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
  min-width: 320px;
  display: flex;
  flex-direction: column;
  border: 3px solid var(--color-preto);
  border-radius: 15px;
  display: flex;
  flex-direction: column;
  position: relative;
}
</style>
