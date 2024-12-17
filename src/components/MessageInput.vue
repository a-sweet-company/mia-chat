<template>
  <div class="message-input">
    <input type="text" placeholder="Digite sua mensagem..." v-model="message" @keyup.enter="sendMessage" />
    <button @click="sendMessage">Enviar</button>
  </div>
</template>

<script>
export default {
  name: 'MessageInput',
  data() {
    return {
      message: ''
    }
  },
  methods: {
    sendMessage() {
      if (this.message.trim()) {
        this.$emit('send-message', this.message);
        this.message = '';
      }
    }
  }
}
</script>

<style scoped>
.message-input {
  display: flex;
  padding: 10px;
  background-color: var(--color-branco);
  border-top: 1px solid var(--color-cinza-claro);
}
.message-input input {
  flex: 1;
  padding: 10px;
  border: 1px solid var(--color-cinza);
  border-radius: 5px;
}
.message-input button {
  background-color: var(--color-azul);
  color: var(--color-branco);
  border: none;
  padding: 10px 20px;
  margin-left: 10px;
  border-radius: 5px;
  cursor: pointer;
}
</style>
