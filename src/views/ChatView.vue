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
      <MessageInput @send-message="sendMessage" />
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
    };
  },
  methods: {
    closeIntroModal() {
      this.showIntroModal = false;
     this.showSuggestions= true;
    },
    addPrompt(prompt) {
      this.$emit("fillInput", prompt);
    },
    async sendMessage(message) {
      const date = new Date();
      this.messages.push({
        hora: date.getHours(),
        minutos: date.getMinutes(),
        text: message,
        role: "user",
      });

      try {
        const response = await fetch("/chat", {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify({ message }),
        });
        const data = await response.json();
        this.messages.push({
          hora: date.getHours(),
          minutos: date.getMinutes(),
          text: data.reply,
          role: "ia",
        });
      } catch (error) {
        console.error("Error:", error);
      }
    },selectSuggestion(suggestion) { this.sendMessage(suggestion); this.showSuggestions = false; }
  },
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
  max-width: 1200px;
  width: 60%;
  padding: 20px;
  min-width: 320px;
  display: flex;
  flex-direction: column;
  border: 3px solid var(--color-preto);
  border-radius: 15px;
  display: flex;
  flex-direction: column;
  height: 80vh;
  position: relative;
}
</style>
