<template>
    <div class="chat-status">
      <img src="../assets/Mia-Modal.png" alt="Mia" class="status-icon" />
      <div class="status-text">
        <h2 class="name">Mia</h2>
        <p class="status">{{ currentStatus }}</p>
      </div>
      <div class="dots">
        <span :class="{ active: activeDot === 1 }"></span>
        <span :class="{ active: activeDot === 2 }"></span>
        <span :class="{ active: activeDot === 3 }"></span>
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
  .chat-status {
    display: flex;
    align-items: center;
    padding: 10px 20px;
    background: rgba(255, 255, 255, 0.089); /* Fundo semi-transparente */
    backdrop-filter: blur(10px); /* Efeito de blur */
    -webkit-backdrop-filter: blur(10px); /* Compatibilidade com Safari */
    position: sticky;
    top: 0;
    width: 100%;
    z-index: 1000;
    box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1); /* Sutil sombra para destaque */
  }
  
  .status-icon {
    width: 60px;
    margin-right: 15px;
  }
  
  .status-text {
    flex-grow: 1;
  }
  
  .name {
    font-size: 1.2rem;
    margin: 0;
    font-weight: bold;
  }
  
  .status {
    font-size: 0.9rem;
    color: var(--color-preto);
    margin: 0;
  }
  
  .dots {
    display: flex;
    gap: 5px;
  }
  
  .dots span {
    width: 8px;
    height: 8px;
    border-radius: 50%;
    background-color: var(--color-azul);
  }
  
  .dots span.active {
    background-color: var(--color-preto);
  }
  </style>
  