<template>
  <div class="chat-view">
    <HeaderComponent />

    <transition name="fade">
      <div v-if="showIntroModal" class="intro-modal">
        <p>Bem-vindo! Pronto para conversar com a Mia?</p>
        <button @click="closeIntroModal">Claro</button>
      </div>
    </transition>

    <MessageList :messages="messages" />
    <div class="prompt-suggestions">
      <span v-for="prompt in prompts" :key="prompt" @click="addPrompt(prompt)">
        {{ prompt }}
      </span>
    </div>
    <MessageInput @sendMessage="sendMessage" />
  </div>
</template>

<script>
import MessageList from "@/components/MessageList.vue";
import MessageInput from "@/components/MessageInput.vue";
import HeaderComponent from "@/components/HeaderComponent.vue";

export default {
  components: {
    MessageList,
    MessageInput,
    HeaderComponent,
  },
  data() {
    return {
      showIntroModal: true,
      messages: [],
      prompts: [
        "Como está o clima?",
        "Me conte uma piada",
        "Qual a previsão para amanhã?",
      ],
    };
  },
  methods: {
    closeIntroModal() {
      this.showIntroModal = false;
    },
    addPrompt(prompt) {
      this.$emit("fillInput", prompt);
    },
    sendMessage(message) {
      this.messages.push({ text: message, sender: "user" });
      // Lógica para resposta da Mia
    },
  },
};
</script>

<style scoped>
.intro-modal {
  position: fixed;
}
.prompt-suggestions span {
  cursor: pointer;
  color: #1199ce;
  padding: 5px;
}

.fade-enter-active, .fade-leave-active {
  transition: opacity 0.5s;
}
.fade-enter, .fade-leave-to {
  opacity: 0;
}

</style>
