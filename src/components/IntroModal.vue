<template>
    <transition name="fade">
      <div v-if="showIntroModal" class="intro-modal">
        <span class="close" @click="closeIntroModal">&times;</span>
        <div class="modal-header">
          <img src="../assets/teste.png" alt="Generic Photo" class="modal-image">
          <h2>Olá,</h2>
        </div>
        <div class="modal-body">
          <p>Sou a <strong>Mia</strong>, sua assistente de apoio emocional e psicológico. Estou pronta te ouvir e te ajudar, vamos começar?</p>
        </div>
        <div class="modal-footer">
          <button class="btn-primary" @click="closeIntroModal">Claro!</button>
        </div>
      </div>
    </transition>
  </template>
  
  <script>
  export default {
    props: {
      showIntroModal: {
        type: Boolean,
        required: true
      }
    },
    methods: {
      closeIntroModal() {
        this.$emit('close-intro-modal');
      }
    }
  }
  </script>
  
  <style scoped>
  .intro-modal {
    position: fixed;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    background-color: var(--color-branco);
    padding: 20px;
    border-radius: 10px;
    box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
    z-index: 1000;
    border-color: var(--color-preto);
  }
  
  .modal-header {
    display: flex;
    align-items: center;
  }
  
  .modal-image {
    width: 150px;
    height: 150px;
    margin-right: 10px;
  }
  
  .modal-body {
    margin-top: 10px;
  }
  
  .modal-footer {
    margin-top: 20px;
    text-align: right;
  }
  
  .btn-primary {
    background-color: var(--color-azul);
    color: var(--color-branco);
    border: none;
    padding: 10px 20px;
    border-radius: 5px;
    cursor: pointer;
  }
  
  .close {
    position: absolute;
    top: 10px;
    right: 10px;
    font-size: 20px;
    cursor: pointer;
  }
  </style>
  