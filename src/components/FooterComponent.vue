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
    color: var(--white-color);
    text-decoration: none;
    font-size: 1.1rem;
    font-weight: 400;
  }
  
  .footer-bar a:hover {
    text-decoration: underline;
    cursor: pointer;
  }
  </style>
  