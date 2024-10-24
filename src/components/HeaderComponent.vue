<template>
    <header>
      <div class="navbar">
        <!-- <img class="logo" src="../assets/sweet-logo.png" alt="Sarah"> -->
        <a href="#">Home</a>
        <a href="#">Sobre</a>
        <a href="#">Chat</a>
        <a href="#">Login</a>
        <a href="#">Personas</a>
      </div>
      <div class="header-bar">
        <div class="bar-block blue"></div>
        <div class="bar-block green"></div>
        <div class="bar-block red"></div>
        <div class="bar-block pink"></div>
        <div class="bar-block yellow"></div>
      </div>
    </header>
  </template>
  
  <style scoped>
  /* Paleta de cores */
  :root {
    --blue-color: #0055FF;
    --green-color: #26C467;
    --red-color: #FF5454;
    --yellow-color: #FFD400;
    --sarahPink-color: #FFC5DB;
    --background-color: #FFF7E5;
    --h1-color: #000000;
    --header-color: #FFF7E5;
  }
  
  /* Header */
  header {
    width: 100vw;
  }
  
  .navbar {
    display: flex;
    justify-content: space-around;
    padding: 10px;
    background-color: var(--footer-color);
  }
  
  .navbar a {
    color: var(--white-color);
    text-decoration: none;
    font-weight: 500;
    font-size: 1.1rem;
    transition: color 0.3s;
    transition: scale 0.3s;
  }
  
  .navbar a:hover {
    scale: 1.1;
    transition: scale 0.3s;
  }
  
  /* Barra de cores */
  .header-bar {
    display: flex;
    height: 6px;
  }
  
  .bar-block {
    width: 20%;
    height: 100%;
  }
  
  .blue { background-color: var(--blue-color); }
  .green { background-color: var(--green-color); }
  .red { background-color: var(--red-color); }
  .yellow { background-color: var(--yellow-color); }
  .pink { background-color: var(--sarahPink-color); }
  </style>
  