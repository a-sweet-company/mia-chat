<template>
  <div class="chat-view">
    <HeaderComponent />
    <div class="chat-container">
      <IntroModal :showIntroModal="showIntroModal" @close-intro-modal="closeIntroModal" />
      <MessageList :messages="messages" />
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
    IntroModal
  },
  data() {
    return {
      showIntroModal: true,
      messages: [],
    };
  },
  methods: {
    closeIntroModal() {
      this.showIntroModal = false;
    },
    addPrompt(prompt) {
      this.$emit("fillInput", prompt);
    },
    async sendMessage(message) {
      const date = new Date();
      this.messages.push({ hora: date.getHours(), minutos: date.getMinutes(), text: message, role: 'user' });

      try {
        const response = await fetch('/chat', {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json'
          },
          body: JSON.stringify({ message })
        });
        const data = await response.json();
        this.messages.push({ hora: date.getHours(), minutos: date.getMinutes(), text: data.reply, role: 'ia' });
      } catch (error) {
        console.error('Error:', error);
      }
    },
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

.fade-enter-active, .fade-leave-active {
  transition: opacity 0.5s;
}
.fade-enter, .fade-leave-to {
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
