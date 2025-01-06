<template>
  <div class="loading-overlay" v-if="show">
    <div class="loading-content">
      <transition name="fade" mode="out-in">
        <h2 :key="currentMessage">{{ currentMessage }}</h2>
      </transition>
    </div>
  </div>
</template>

<script>
export default {
  name: 'LoadingComponent',
  props: {
    show: {
      type: Boolean,
      default: false
    }
  },
  data() {
    return {
      currentMessage: 'Carregando...',
      messages: [
        'Carregando...',
        'Login Efetuado com Sucesso!',
      ]
    }
  },
  watch: {
    show(newVal) {
      if (newVal) {
        this.startMessageSequence();
      }
    }
  },
  methods: {
    startMessageSequence() {
      setTimeout(() => {
        this.currentMessage = this.messages[1];
      }, 2000);
    }
  }
}
</script>

<style scoped>
.loading-overlay {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color:var(--color-branco);
  display: flex;
  justify-content: center;
  align-items: center;
  z-index: 9999;
  cursor: progress;
}

.loading-content {
  text-align: center;
}

.fade-enter-active,
.fade-leave-active {
  transition: opacity 0.5s;
}

.fade-enter-from,
.fade-leave-to {
  opacity: 0;
}
</style>