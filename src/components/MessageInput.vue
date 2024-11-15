<template>
    <div class="message-input">
      <input 
        v-model="message" 
        type="text" 
        placeholder="Digite sua mensagem..."
        @keyup.enter="send" />
      <button @click="send">Enviar</button>
    </div>
  </template>
  
  <script>
  export default {
    data() {
      return {
        message: ''
      };
    },
    methods: {
      send() {
        if (this.message.trim()) {
          this.$emit('sendMessage', this.message);
          this.message = '';
        }
      }
    }
  }
  </script>
  
  <style scoped>
  .message-input {
    display: flex;
    /* estilo responsivo */
  }
  .message-input input {
    flex: 1;
    /* estilo adicional */
  }
  </style>
  