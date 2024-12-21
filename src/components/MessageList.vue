<template>
  <div class="message-list">
    <div
      class="message"
      :class="{
        'user-message': message.role === 'user',
        'ia-message': message.role === 'ia',
      }"
      v-for="(message, index) in messages"
      :key="index"
    >
      <p>{{ message.text }}</p>
      <div class="timestamp-container">
        <span class="timestamp">{{ message.hora }}:{{ message.minutos }}</span>
        <img
          v-if="message.role === 'ia'"
          src="../assets/image 17.png"
          alt="IA"
          class="enviado-icon-ia" 
          width="16px"
          height="16px"
        />
        <img
          v-if="message.role === 'user'"
          src="../assets/read 1.png"
          alt="USER"
          class="enviado-icon-user"
          width="16px"
          height="16px"
        />
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "MessageList",
  props: {
    messages: {
      type: Array,
      required: true,
    },
  },
};
</script>

<style scoped>
.message-list {
  padding: 10px;
  background-color: var(--color-branco-claro);
  height: calc(100vh - 150px);
  overflow-y: auto;
}

.message {
  padding: 10px;
  margin-bottom: 10px;
  border-radius: 5px;
  max-width: 60%;
  position: relative;
  word-wrap: break-word;
}

.user-message {
  color: var(--color-branco);
  background-color: var(--color-azul);
  align-self: flex-start;
  border: 1px solid var(--color-preto);
  margin-left: auto;
}

.ia-message {
  color: var(--color-branco);
  background-color: var(--color-azul);
  align-self: flex-end;
  border: 1px solid var(--color-preto);
  margin-right: auto;
}
.timestamp-container {
  display: flex;
  align-items: center;
  position: absolute;
  bottom: 5px;
  right: 10px;
}
.timestamp {
  font-size: 0.8em;
  color: var(--color-branco);
  position: absolute;
  margin-left: auto;
  bottom: 0px;
  right: 25px;
  
};

</style>
