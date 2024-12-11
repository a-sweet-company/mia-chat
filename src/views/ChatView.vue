<template>
  <div class="chat-view">
    <!-- Cabeçalho -->
    <HeaderComponent />

    <div v-if="showIntroModal" class="intro-modal">
      <p>Bem-vindo! Pronto para conversar com a Mia?</p>
      <button @click="closeIntroModal">Claro</button>
    </div>

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
import MessageList from '@/components/MessageList.vue';
import MessageInput from '@/components/MessageInput.vue';

import HeaderComponent from '@/components/HeaderComponent.vue'; // Importação do componente Header

export default {
  components: {
    MessageList,
    MessageInput,
    HeaderComponent, // Registro do HeaderComponent
  },
  data() {
    return {
      showIntroModal: true,
      messages: [],
      prompts: ["Como está o clima?", "Me conte uma piada", "Qual a previsão para amanhã?"],
    };
  },
  methods: {
    closeIntroModal() {
      this.showIntroModal = false;
    },
    addPrompt(prompt) {
      this.$emit('fillInput', prompt);
    },
    sendMessage(message) {
      this.messages.push({ text: message, sender: 'user' });
      // Lógica para resposta da Mia
    },
  },
};
</script>

<style scoped>
.intro-modal {
  position: fixed;
  /* Estilize o modal como desejado */
}
.prompt-suggestions span {
  cursor: pointer;
  color: #1199CE;
  padding: 5px;
  /* Adicione mais estilo */
}
</style>
