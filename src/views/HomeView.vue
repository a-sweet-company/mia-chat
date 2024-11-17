<template>
  <div class="container">
    <!-- Lado esquerdo: Formulário de login -->
    <div class="left-section">
      <div class="logo">
        <img src="../assets/miaLogoBlack.svg" alt="Mindful AI Logo" />
      </div>
      <div class="slogam">
      <h2>Cuide da mente, <span class="highlight">converse com Mia.</span></h2>
    </div>
    <div class="subtitulo">
      <p>Uma IA pensada para entender você. Com Mia, encontre apoio emocional sempre que precisar, com segurança e empatia.</p>
    </div>
    <div class="caixa_login"> 
    <div class="formulario">
      <form @submit.prevent="handleLogin">
      <div class="div_email">
        <input type="email" placeholder="Email" v-model="email" required />
      </div>
      <div class="div_senha">
        <input type="password" placeholder="Senha" v-model="password" required />
      </div>
        
        <button type="submit">Entrar</button>
      </form>

      <p class="create-account">ou <a href="#">Criar conta</a></p>
    </div>
  </div>
      <button class="care-button">Use Mia Care+</button>

      <div class="footer">
        <a href="#">Termos de Uso</a> | <a href="#">Política de Privacidade</a>
      </div>
    
    </div>

    <!-- Lado direito: Informações sobre Mia -->
    <div class="right-section">
      <div class="mia-logo">
        <img src="../assets/mia+gemini.png" alt="Mia Logo" />
      </div>

      <div class="info">
        <div class="info-item">
          <h3>1. Apoio Emocional Sempre ao Seu Alcance</h3>
          <p>Conecte-se com Mia para receber apoio gratuito, prático e disponível a qualquer hora. Porque cuidar da sua saúde mental não precisa ter barreiras.</p>
        </div>
        <div class="info-item">
          <h3>2. Conversas Humanizadas e Confortáveis</h3>
          <p>A Mia foi criada para falar com você de igual para igual, com uma linguagem acolhedora que prioriza a empatia e o respeito.</p>
        </div>
        <div class="info-item">
          <h3>3. Fundamentação Psicológica de Confiança</h3>
          <p>Cada resposta da Mia é baseada em abordagens psicológicas validadas, pensadas para proporcionar reflexões e estratégias saudáveis para o seu bem-estar.</p>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      email: "",
      password: "",
    };
  },
  methods: {
    handleLogin() {
      console.log(`Login with ${this.email} and ${this.password}`);
    },
  },
};
</script>

<style scoped>
/* Layout geral */

:root {
  margin: 0;
  padding: 0;
}


.container {
  display: flex;
  min-height: 100vh;
  font-family: "Jost", sans-serif;
  background-color: #ECECEC;
  width: 100vw;
  height: 100vh;
}

/* Lado esquerdo: Formulário de login */
.left-section {
  /* background-color:white; */
  /* color: white; */
  /* color: white;
  margin: 10px;
  flex: 1;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  /* max-width: 80vw; */
  border-radius: 1.3vw;
  width: 50%;
  margin-left: 1.2vw;
  margin-top: 1vw;
  margin-bottom: 1vw;
  height: 96.7%;
  border: solid 0.5vh black;
  color: black;
  

}

.logo {
  display: flex;
  align-items: center;
  width: 100%;
  justify-content: center;
  align-items: center;
  height: 15%;
  color: black;
  /* background-color: #0ab4f4; */
}
.logo img {
height: 200%;
margin-top: 8%;
}

.slogam{
  width: 100%;
 /* background-color: red; */
  display: flex;
  align-items: center;
  justify-content: center;
  height: 5%;
  margin-top: 3%;  
}
.subtitulo{
  margin-top: 3.5%;
  width: 80%;
  /* background-color: blue;  */
  display: flex;
  align-items: center;
  justify-content: center;
  height: 5%;
  text-align:center;
  margin-left: 10%;
  font-size: 1.3vw;
  line-height: 150%;
}
/* h2 {
  font-size: 1.6rem;
  font-weight: 600;
  margin-bottom: 15px;
  text-align: center;
} */
.caixa_login{
  /* background-color: blue; */
  width: 100%;
  display: flex;
  justify-content: center;
  align-items: center;
  height: 55%;
}

.formulario{
  /* background-color: purple; */
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: column;
  width: 88%;
  border: 0.39vh solid #353535;
  height: 93%;
  border-radius: 1.3vw;
  margin-top: 1%;
}
.div_email {
/* background-color: black; */
width: 100%;
display: flex;
justify-content: center;
align-items: center; 
margin-top: 3%;
height:19%;
}

.div_senha {
/* background-color: black; */
width: 100%;
display: flex;
justify-content: center;
align-items: center; 
margin-top: 3%;
height:19%;
}
.div_email  input{
  width: 87%;
  height: 90%;
  border-radius: 0.6vw;
  background-color: #ECECEC ;
  opacity:90%;
  border: 0.29vh solid #353535;
}

.div_senha  input{
  width: 87%;
  height: 90%;
  border-radius: 0.6vw;
  background-color: #ECECEC ;
  opacity:90%;
  border: 0.29vh solid #353535;
}
.slogam h2 {
  font-size: 2.3vw;
  text-align: center;
}

.highlight {
  color: #0ab4f4;
}

.subtitle {
  font-size: 0.9rem;
  text-align: center;
  margin-bottom: 30px;
}

form {
  display: flex;
  flex-direction: column;
  width: 100%;
  height: 90%;
}

input {
  /* background-color: #222222; */
  color: white;
  border: 0.29vh solid #353535;
  border-radius: 5px;
  padding: 10px;
  margin-bottom: 10px;
  font-size: 1rem;
}

button[type="submit"] {
  background-color: #0ab4f4;
  color: white;
  border: none;
  border-radius: 5px;
  padding: 10px;
  cursor: pointer;
  font-size: 1rem;
}

.create-account {
  color: white;
  margin-top: 10px;
  font-size: 0.9rem;
  text-align: center;
  text-decoration: none;
}

.care-button {
  background: linear-gradient(to rigght, #ffffff, #0ab4f4);
  color: black;
  border: none;
  padding: 10px 20px;
  border-radius: 5px;
  cursor: pointer;
  margin-top: 15px;
  font-size: 1.2rem;
  font-weight: bold;
  
}

.footer {
  font-size: 0.8rem;
  color: #bbbbbb;
  margin-top: 20px;
}

.footer a {
  color: #bbbbbb;
  margin: 0 5px;
}

/* Lado direito: Informações sobre Mia */
.right-section {
  color: #333333;
  flex: 2;
  padding: 50px;
  background-color: #ECECEC;
  /* border: 1px solid black; */
}

.mia-logo img {
  margin-left: 1vw;
  scale: 0.8;
}

.info {
  display: flex;
  flex-direction: column;
  gap: 30px;
  /* border: 1px solid black; */
}

.info-item h3 {
  font-size: 1.2rem;
  font-weight: bold;
  margin-bottom: 4px;
}

.info-item p {
  font-size: 1rem;
  line-height: 1.6;
  margin-left: 1.5vw;
}
</style>
