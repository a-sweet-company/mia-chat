<template>
  <div class="chat-input-container">
    <!-- Loading dots animation -->
    <div v-if="isLoading" class="loading-message">
      <div class="chat-status-dots">
        <span :class="{ active: activeDot === 1 }"></span>
        <span :class="{ active: activeDot === 2 }"></span>
        <span :class="{ active: activeDot === 3 }"></span>
      </div>
    </div>
    
    <div class="input-content-wrapper">
      <!-- Message input field -->
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
      activeDot: 1,
    };
  },
  methods: {
    async handleSendMessage() {
      await this.sendMessage(this.message);
    },
    scrollToBottom() {
      // Wait for DOM update
      this.$nextTick(() => {
        const chatContainer = document.querySelector('.message-list'); // Make sure this matches your chat container class
        if (chatContainer) {
          chatContainer.scrollTop = chatContainer.scrollHeight;
        }
      });
    },
    async sendMessage(text) {
      if ((text || this.message.trim()) && !this.isLoading) {
        try {
          this.isLoading = true;
          this.startDotAnimation();
          const messageText = text || this.message;
          this.message = "";

          // Emit user message and scroll
          this.$emit("send-message", {
            text: messageText,
            role: "user",
            hora: new Date().getHours(),
            minutos: new Date().getMinutes(),
          });
          this.scrollToBottom();

          setTimeout(async () => {
            const response = await api.chat.sendMessage(messageText);
            
            // Emit AI response and scroll
            this.$emit("receive-message", {
              text: response.text,
              role: "ia",
              hora: new Date().getHours(),
              minutos: new Date().getMinutes(),
            });
            this.scrollToBottom();

            this.isLoading = false;
          }, 2000);
        } catch (error) {
          console.error("Erro ao enviar mensagem:", error);
          this.$emit(
            "error",
            "Erro ao enviar mensagem. Por favor, tente novamente."
          );
          this.isLoading = false;
        }
      }
    },
    startDotAnimation() {
      setInterval(() => {
        this.activeDot = (this.activeDot % 3) + 1;
      }, 500);
    },
  },
  mounted() {
    // Initial scroll to bottom when component mounts
    this.scrollToBottom();
  },
};
</script>


<style scoped>
.chat-input-container {
  position: fixed;
  bottom: 0;
  left: 0;
  width: 100%;
  z-index: 1000;
  padding: 20px 0;
  height: 17%;
  display: flex;
  flex-direction: column;
  align-items: center;
  gap: 10px;
}

.loading-message {
  position: absolute;
  top: -40px;
  left: 5%;
  padding: 8px 16px;
  border-radius: 20px;
  background: var(--color-branco);
  backdrop-filter: blur(10px);
  -webkit-backdrop-filter: blur(10px);
  box-shadow: 0px 4px 10px rgba(0, 0, 0, 0.2);
}

.chat-status-dots {
  display: flex;
  gap: 5px;
}

.chat-status-dots span {
  width: 8px;
  height: 8px;
  border-radius: 50%;
  background-color: #ccc;
  display: inline-block;
  transition: background-color 0.3s;
}

.chat-status-dots span.active {
  background-color: var(--color-azul);
}

.input-content-wrapper {
  width: 90%;
  max-width: 600px;
}

.chat-input-wrapper {
  display: flex;
  align-items: center;
  background: rgba(236, 236, 236, 0.336);
  backdrop-filter: blur(10px);
  -webkit-backdrop-filter: blur(10px);
  border-radius: 10px;
  border: 1px solid var(--color-preto);
  box-shadow: 0px 4px 10px rgba(0, 0, 0, 0.2);
  padding: 10px 15px;
  width: 100%;
}

.chat-input-box {
  flex: 1;
  border: none;
  outline: none;
  font-size: 14px;
  color: var(--color-preto);
  background: transparent;
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