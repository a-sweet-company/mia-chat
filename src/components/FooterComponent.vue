<template>
    <footer class="footer">
      <div class="footer-bar">
        <a href="#">Termos de Uso</a>
        <a href="#">Política de Privacidade</a>
      </div>
    </footer>
  </template>
  
  <style scoped>
  .footer-bar {
    margin-top: 10px;
    display: flex;
    justify-content: center;
    gap: 20px;
    background-color: var(--footer-color);
    padding: 10px;
  }
  
  .footer-bar a {
    color: var(--h1-color);
    text-decoration: none;
    font-size: 1.1rem;
    font-weight: bold;
  }
  
  .footer-bar a:hover {
    text-decoration: underline;
  }
  </style>
  