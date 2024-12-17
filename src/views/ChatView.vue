<template>
  <div class="chat-view">
    <HeaderComponent />
    <IntroModal :showIntroModal="showIntroModal" @close-intro-modal="closeIntroModal" />
    <MessageList :messages="messages" />
    <div class="prompt-suggestions">
      <span v-for="prompt in prompts" :key="prompt" @click="addPrompt(prompt)">
        {{ prompt }}
      </span>
    </div>
    <MessageInput @send-message="sendMessage" />
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
      prompts: [
        "Como está o clima?",
        "Me conte uma piada",
        "Qual a previsão para amanhã?",
      ]
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
      this.messages.push({ id: Date.now(), text: message, sender: "user", avatar: 'path/to/user/avatar.png' });
      
      try {
        const response = await fetch('/chat', {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json'
          },
          body: JSON.stringify({ message })
        });
        const data = await response.json();
        this.messages.push({ id: Date.now() + 1, text: data.reply, sender: "bot", avatar: 'path/to/bot/avatar.png' });
      } catch (error) {
        console.error('Error:', error);
      }
    },
  },
};
</script>

<style scoped>
.chat-view {
  display: flex;
  flex-direction: column;
  height: 100vh;
  background-color: var(--color-branco-claro);
}

.prompt-suggestions {
  display: flex;
  justify-content: space-around;
  background-color: var(--color-marmore-footer);
  padding: 10px;
  border-radius: 5px;
}

.prompt-suggestions span {
  cursor: pointer;
  color: var(--color-azul);
  padding: 5px;
}

.fade-enter-active, .fade-leave-active {
  transition: opacity 0.5s;
}
.fade-enter, .fade-leave-to {
  opacity: 0;
}
</style>
