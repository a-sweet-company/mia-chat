<template>
    <div class="message-list">
      <div 
        v-for="(message, index) in messages" 
        :key="index"
        :class="message.sender === 'user' ? 'user-message' : 'mia-message'">
        {{ message.text }}
      </div>
    </div>
  </template>
  
  <script>
  export default {
    props: ['messages']
  }
  </script>
  
  <style scoped>
  .user-message {
    background-color: #1199CE;
    color: white;
    /* estilo adicional */
  }
  
  .mia-message {
    border: 1px solid #000;
    background-color: white;
    color: black;
    /* estilo adicional */
  }
  </style>
  