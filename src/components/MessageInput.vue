<template>
  <div class="chat-input-container">
    <div class="chat-input-wrapper">
      <input
        type="text"
        placeholder="Digite sua Mensagem..."
        v-model="message"
        @keyup.enter="handleSendMessage"
        class="chat-input-box"
        :disabled="isLoading"
        aria-label="Digite sua mensagem"
      />
      <button
        @click="handleSendMessage"
        class="chat-send-button"
        :disabled="isLoading"
        aria-label="Enviar mensagem"
      >
        <img
          src="../assets/chat-input-button.png"
          alt="Enviar"
          class="chat-send-icon"
        />
      </button>
    </div>
  </div>
</template>


<script>
import api from "@/api/api";

export default {
  name: "ChatInput",
  data() {
    return {
      message: "",
      isLoading: false,
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
          this.message = "";

          // Atualiza a UI com a mensagem do usuário
          this.$emit("send-message", {
            text: messageText,
            role: "user",
            hora: new Date().getHours(),
            minutos: new Date().getMinutes(),
          });

          // Envia mensagem para a API
          const response = await api.chat.sendMessage(messageText);

          // Atualiza a UI com a resposta da IA
          this.$emit("receive-message", {
            text: response.text,
            role: "ia",
            hora: new Date().getHours(),
            minutos: new Date().getMinutes(),
          });
        } catch (error) {
          console.error("Erro ao enviar mensagem:", error);
          this.$emit(
            "error",
            "Erro ao enviar mensagem. Por favor, tente novamente."
          );
        } finally {
          this.isLoading = false;
        }
      }
    },
  },
};
</script>


<style scoped>
.chat-input-container {
  display: flex;
  justify-content: center;
  background: none;
  position: fixed;
  bottom: 0;
  left: 0;
  width: 100%;
  z-index: 1000;
  padding: 20px 0;
}

.chat-input-wrapper {
  display: flex;
  align-items: center;
  background: rgba(236, 236, 236, 0.336); /* Fundo semi-transparente */
  backdrop-filter: blur(10px);
  -webkit-backdrop-filter: blur(10px); /* Suporte Safari */
  border-radius: 15px;
  border: 2px solid var(--color-preto);
  box-shadow: 0px 4px 10px rgba(0, 0, 0, 0.2); /* Sutil sombra */
  padding: 10px 15px;
  width: 90%;
  max-width: 600px;
}

.chat-input-box {
  flex: 1;
  border: none;
  outline: none;
  font-size: 14px;
  color: var(--color-preto);
  background: transparent; /* Transparência para reforçar o blur */
  padding: 5px 10px;
}

.chat-send-button {
  background: none;
  border: none;
  cursor: pointer;
  display: flex;
  align-items: center;
}

.chat-send-icon {
  width: 24px;
  height: 24px;
  transition: transform 0.3s ease;
}

.chat-send-button:hover .chat-send-icon {
  transform: scale(1.2);
}
</style>

