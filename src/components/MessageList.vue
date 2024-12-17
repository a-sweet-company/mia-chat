<template>
  <div class="message-list">
    <div class="message" v-for="(message, index) in messages" :key="index">
      <p>{{ message }}</p>
    </div>
  </div>
</template>

<script>
export default {
  name: 'MessageList',
  props: {
    messages: {
      type: Array,
      required: true
    }
  }
}
</script>

<style scoped>
.message-list {
  padding: 10px;
  background-color: var(--color-branco-claro);
  height: calc(100vh - 150px);
  overflow-y: auto;
}
.message {
  background-color: var(--color-branco);
  padding: 10px;
  margin-bottom: 10px;
  border-radius: 5px;
  border: 1px solid var(--color-cinza-claro);
}
</style>
