<template>
  <transition name="fade">
    <div v-if="showIntroModal || errorMessage" class="intro-modal" @click.self="closeIntroModal">
      <span class="close" @click="closeIntroModal">&times;</span>
      <div class="modal-content">
        <img v-if="!errorMessage" src="../assets/Mia-Modal.png" alt="Mia-Modal" class="modal-image">
        <div class="modal-text">
          <h1 class="modal-greeting"><strong v-if="!errorMessage">Olá,</strong></h1>
          <p class="modal-description">
            <template v-if="errorMessage">
              {{ errorMessage }}
            </template>
            <template v-else>
              Sou a <strong>Mia</strong>, sua assistente de apoio emocional e psicológico.
              Estou pronta para te ouvir e te ajudar. Vamos começar?
            </template>
          </p>
        </div>
      </div>
      <div class="modal-footer" v-if="!errorMessage">
        <button class="btn-primary" @click="closeIntroModal">Claro!</button>
      </div>
    </div>
  </transition>
</template>

<script>
export default {
  props: {
    showIntroModal: Boolean,
    errorMessage: String,
  },  
  methods: {
    closeIntroModal() {
      this.$emit("close-intro-modal");
    }
  }
};
</script>

<style scoped>
.intro-modal {
  position: fixed;
  top: 53%;
  left: 50%;
  transform: translate(-50%, -50%);
  background-color: none;
  padding: 10px;
  border-radius: 10px;
  box-shadow: 0 4px 20px rgba(0, 0, 0, 0.15);
  z-index: 1000;
  width: 500px;
  height: 258px;
  border: 2px solid var(--color-preto);
  display: flex;
  flex-direction: column;
}

.modal-content {
  display: flex;
  align-items: center;
  height: 70%;
}

.modal-image {
  width: 190px;
  height: auto;
  margin-right: 10px;
  margin-top: 110px;
}

.modal-text {
  text-align: left;
  flex: 1;
}

.modal-greeting {
  font-size: 34px;
  margin: 0;
}

.modal-description {
  font-size: 16px;
  margin: 10px 0 0 0;
}

.modal-footer {
  display: flex;
  justify-content: flex-end;
  align-items: center;
  height: 20%;
}

.btn-primary {
  background-color: var(--color-azul);
  color: var(--color-branco);
  border: none;
  padding: 10px 50px;
  border-radius: 10px;
  cursor: pointer;
  font-size: 16px;
  transition: background-color 0.3s ease;
}

.btn-primary:hover {
  background-color: var(--color-azul-escuro);
}

.close {
  position: absolute;
  top: 10px;
  right: 10px;
  font-size: 18px;
  cursor: pointer;
  color: var(--color-preto);
}
</style>
