<template>
  <div class="message-list">
    <div
      class="message"
      :class="{
        'user-message': message.role === 'user',
        'ia-message': message.role === 'ia',
      }"
      v-for="(message, index) in messages"
      :key="index"
    >
      <p v-if="message.role === 'user'">{{ message.text }}</p>
      <div
        v-if="message.role === 'ia'"
        v-html="renderMarkdown(message.text)"
        class="markdown-content"
      ></div>

      <div class="timestamp-container">
        <span
          class="timestamp"
          :class="{ 'ia-timestamp': message.role === 'ia' }"
        >
          {{ formatTime(message.hora, message.minutos) }}
        </span>
        <img
          v-if="message.role === 'ia'"
          src="../assets/image 17.png"
          alt="IA"
          class="enviado-icon-ia"
          width="16px"
          height="16px"
        />
        <img
          v-if="message.role === 'user'"
          src="../assets/read 1.png"
          alt="USER"
          class="enviado-icon-user"
          width="16px"
          height="16px"
        />
      </div>
    </div>
  </div>
</template>

<script>
import { marked } from "marked";

export default {
  name: "MessageList",
  props: {
    messages: {
      type: Array,
      required: true,
    },
  },
  methods: {
    renderMarkdown(text) {
      return marked(text);
    },
    formatTime(hora, minutos) {
      const formatNumber = (num) => (num < 10 ? `0${num}` : num);
      return `${formatNumber(hora)}:${formatNumber(minutos)}`;
    },
  },
};
</script>

<style scoped>
.message-list {
  padding: 10px;
  background-color: var(--color-branco-claro);
  height: calc(100vh - 150px);
  overflow-y: auto;
  display: flex;
  flex-direction: column; /* Garante que as mensagens sejam empilhadas */
  align-items: flex-start; /* Alinha mensagens no início */
}

.message {
  display: block; /* Corrige o layout para evitar lado a lado */
  padding: 10px;
  margin-bottom: 10px;
  border-radius: 5px;
  max-width: 60%;
  min-width: 50px; /* Largura mínima do balão */
  position: relative;
  word-wrap: break-word;
  padding-bottom: 23px; /* Cria espaço para o horário */
}

.user-message {
  color: var(--color-branco);
  background-color: var(--color-azul);
  border-radius: 10px;
  align-self: flex-start;
  margin-left: auto;
  min-width: 50px; /* Largura mínima do balão */
  max-width: 60%; /* Largura máxima do balão */
}

.ia-message {
  color: var(--color-preto);
  background-color: none;
  align-self: flex-end;
  border: 2px solid var(--color-preto);
  border-radius: 10px;
  margin-right: auto;
  min-width: 50px; /* Largura mínima do balão */
  max-width: 60%; /* Largura máxima do balão */
}

.markdown-content {
  color: var(--color-preto);
  background-color: none;
  word-wrap: break-word;
}

.timestamp-container {
  display: flex;
  align-items: center;
  position: absolute;
  bottom: 5px;
  right: 10px;
}

.timestamp {
  font-size: 0.8em;
  color: var(--color-branco);
}

.ia-timestamp {
  color: var(--color-preto); /* Cor preta para horários da IA */
}

.enviado-icon-ia,
.enviado-icon-user {
  margin-left: 5px;
}
</style>
