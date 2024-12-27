<template>
  <div class="message-input">
    <div class="input-container">
      <input
        type="text"
        placeholder="Mensagem"
        v-model="message"
        @keyup.enter="handleSendMessage"
        class="input-box"
        :disabled="isLoading"
      />
      <button @click="handleSendMessage" class="send-button" :disabled="isLoading">
        <img src="../assets/chat-input-button.png" alt="Enviar" class="send-icon" />
      </button>
    </div>
  </div>
</template>

<script>
import api from '@/api/api';

export default {
  name: 'MessageInput',
  data() {
    return {
      message: '',
      isLoading: false
    };
  },
  methods: {
    async handleSendMessage() {
      await this.sendMessage(this.message);
    },
    async sendMessage(text) {
      if ((text || this.message.trim()) && !this.isLoading) {
        try {
          this.isLoading = true;
          const messageText = text || this.message;
          this.message = '';
          
          // Emitir mensagem para atualizar UI imediatamente
          this.$emit('send-message', {
            text: messageText,
            role: 'user',
            hora: new Date().getHours(),
            minutos: new Date().getMinutes()
          });

          // Enviar para a API
          const response = await api.chat.sendMessage(messageText);
          
          // Emitir resposta da IA
          this.$emit('receive-message', {
            text: response.text,
            role: 'ia',
            hora: new Date().getHours(),
            minutos: new Date().getMinutes()
          });
        } catch (error) {
          console.error('Erro ao enviar mensagem:', error);
          this.$emit('error', 'Erro ao enviar mensagem. Por favor, tente novamente.');
        } finally {
          this.isLoading = false;
        }
      }
    }
  }
};
</script>

<style scoped>
.message-input {
  display: flex;
  justify-content: center;
  padding: 20px 0;
  background-color: transparent;
  bottom: 0;
  left: 0;
  width: 100%;
  z-index: 1000;
}

.input-container {
  display: flex;
  align-items: center;
  background: rgba(230, 230, 230, 0.1); 
  backdrop-filter: blur(10px);
  -webkit-backdrop-filter: blur(10px); 
  border-radius: 10px;
  border: 1px solid var(--color-preto);
  box-shadow: 0px 4px 10px rgba(0, 0, 0, 0.1); 
  padding: 10px 15px;
  width: 80%;
  max-width: 600px;
}

.input-box {
  flex: 1;
  border: none;
  outline: none;
  font-size: 14px;
  color: var(--color-preto);
  background: transparent;
  padding: 3px 10px;
  
}

.send-button {
  background: none;
  border: none;
  cursor: pointer;
  display: flex;
  align-items: center;
}

.send-icon {
  width: 24px;
  height: 24px;
  transition: transform 0.3s ease;
}

.send-button:hover .send-icon {
  transform: scale(1.2);
}
</style>
