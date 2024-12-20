<template>
  <div class="message-input">
    <div class="input-container">
      <input
        type="text"
        placeholder="Mensagem"
        v-model="message"
        @keyup.enter="sendMessage"
        class="input-box"
      />
      <button @click="sendMessage" class="send-button">
        <img src="../assets/chat-input-button.png" alt="Enviar" class="send-icon" />
      </button>
    </div>
  </div>
</template>

<script>
export default {
  name: 'MessageInput',
  data() {
    return {
      message: ''
    };
  },
  methods: {
    sendMessage() {
      if (this.message.trim()) {
        this.$emit('send-message', this.message);
        this.message = '';
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
  background: rgba(255, 255, 255, 0.1); 
  backdrop-filter: blur(10px);
  -webkit-backdrop-filter: blur(10px); 
  border-radius: 10px;
  border: 1px solid black;
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
