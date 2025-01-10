<template>
    <div class="chat-status-container">
      <img src="../assets/Mia-Modal.png" alt="Mia" class="chat-status-icon" />
      <div class="chat-status-text">
        <h2 class="chat-status-name">Mia</h2>
        <p class="chat-status-indicator">{{ currentStatus }}</p>
      </div>
    </div>
</template>  

<script>
export default {
  props: {
    status: {
      type: String,
      default: "Online",
    },
  },
  data() {
    return {
      currentStatus: this.status,
      activeDot: 1,
    };
  },
  watch: {
    status(newStatus) {
      this.currentStatus = newStatus;
    },
  },
  mounted() {
    this.startDotAnimation();
  },
  methods: {
    startDotAnimation() {
      setInterval(() => {
        this.activeDot = (this.activeDot % 3) + 1;
      }, 500);
    },
  },
};
</script>

<style scoped>
.chat-status-container {
  display: flex;
  align-items: center;
  padding: 10px 20px;
  background: rgba(255, 255, 255, 0.2) !important; 
  backdrop-filter: blur(10px) !important; 
  -webkit-backdrop-filter: blur(10px); 
  position: sticky;
  top: 0;
  width: 100%; 
  z-index: 1000;
  border-bottom: 2px solid var(--color-cinza);
}

.chat-status-icon {
  width: 60px;
  margin-bottom: -10px;
  margin-right: 15px;
  object-fit: cover;
}

.chat-status-text {
  flex-grow: 1;
}

.chat-status-name {
  font-size: 1.3rem;
  margin: 0;
  font-weight: bold;
}

.chat-status-indicator {
  font-size: 0.8rem;
  color: var(--color-preto);
  margin: 0;
}
</style>

