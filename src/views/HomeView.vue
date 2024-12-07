<template>
  <div class="container">
    <!-- Lado esquerdo: Formulário de login/cadastro -->
    <div class="left-section">
      <div class="logo">
        <img src="../assets/miaLogoBlack.svg" alt="Mindful AI Logo" />
      </div>
      <div class="slogan">
        <h2>
          Cuide da mente, <span class="highlight">converse com Mia.</span>
        </h2>
      </div>
      <div class="subtitulo">
        <p>
          Uma IA pensada para entender você. Com Mia, encontre apoio emocional
          sempre que precisar, com segurança e empatia.
        </p>
      </div>
      <div class="caixa-login">
        <div class="formulario">
          <form @submit.prevent="handleFormSubmit">
            <div class="input-container">
              <input
                :class="{ error: inputErrors.email }"
                type="email"
                placeholder="Email"
                v-model="email"
                required
              />
              <span v-if="inputErrors.email" class="error-text">Por favor, insira um email válido.</span>
            </div>
            <div class="input-container">
              <input
                :class="{ error: inputErrors.password }"
                type="password"
                placeholder="Senha"
                v-model="password"
                required
              />
              <span v-if="inputErrors.password" class="error-text">A senha é obrigatória.</span>
            </div>
            <div v-if="isSignUp" class="input-container">
              <input
                :class="{ error: inputErrors.confirmPassword }"
                type="password"
                placeholder="Confirme sua senha"
                v-model="confirmPassword"
                required
              />
              <span v-if="inputErrors.confirmPassword" class="error-text">As senhas não coincidem.</span>
            </div>
            <button type="submit">
              {{ isSignUp ? "Cadastrar" : "Entrar" }}
            </button>
          </form>
          <p class="toggle-form">
            {{ isSignUp ? "Já tem uma conta?" : "Não tem uma conta?" }}
            <a href="#" @click.prevent="toggleSignUp">{{ isSignUp ? "Entrar" : "Criar conta" }}</a>
          </p>
        </div>
      </div>
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
          <p>
            Conecte-se com Mia para receber apoio gratuito, prático e disponível
            a qualquer hora. Porque cuidar da sua saúde mental não precisa ter
            barreiras.
          </p>
        </div>
        <div class="info-item">
          <h3>2. Conversas Humanizadas e Confortáveis</h3>
          <p>
            A Mia foi criada para falar com você de igual para igual, com uma
            linguagem acolhedora que prioriza a empatia e o respeito.
          </p>
        </div>
        <div class="info-item">
          <h3>3. Fundamentação Psicológica de Confiança</h3>
          <p>
            Cada resposta da Mia é baseada em abordagens psicológicas validadas,
            pensadas para proporcionar reflexões e estratégias saudáveis para o
            seu bem-estar.
          </p>
        </div>
      </div>
    </div>

    <!-- Modal de Mensagens -->
    <div v-if="modal.show" :class="['modal', modal.type]" @click="hideModal">
      <p>{{ modal.message }}</p>
      <button @click="hideModal"></button>
    </div>

  </div>
</template>

<script>
import api from "@/api/api";

export default {
  data() {
    return {
      isSignUp: false,
      email: "",
      password: "",
      confirmPassword: "",
      inputErrors: {
        email: false,
        password: false,
        confirmPassword: false,
      },
      modal: {
        show: false,
        message: "",
        type: "error", 
      },
    };
  },
  methods: {
    toggleSignUp() {
      this.isSignUp = !this.isSignUp;
      this.password = "";
      this.confirmPassword = "";
      this.clearInputErrors();
    },
    clearInputErrors() {
      this.inputErrors = {
        email: false,
        password: false,
        confirmPassword: false,
      };
    },
    showModal(message, type = "error") {
      this.modal.message = message;
      this.modal.type = type;
      this.modal.show = true;

      // Auto fechar o modal após 5 segundos
      setTimeout(() => {
        this.hideModal();
      }, 5000);
    },
    hideModal() {
      this.modal.show = false;
      this.modal.message = "";
      this.modal.type = "error";
    },
    validateEmail(email) {
      const re = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
      return re.test(email);
    },
    async handleFormSubmit() {
      this.clearInputErrors();

      // Validações de formulário
      let hasError = false;

      if (!this.email) {
        this.inputErrors.email = true;
        hasError = true;
      } else if (!this.validateEmail(this.email)) {
        this.inputErrors.email = true;
        hasError = true;
        this.showModal("Por favor, insira um email válido.", "error");
      }

      if (!this.password) {
        this.inputErrors.password = true;
        hasError = true;
      }

      if (this.isSignUp) {
        if (!this.confirmPassword) {
          this.inputErrors.confirmPassword = true;
          hasError = true;
        } else if (this.password !== this.confirmPassword) {
          this.inputErrors.password = true;
          this.inputErrors.confirmPassword = true;
          hasError = true;
          this.showModal("As senhas não coincidem.", "error");
        }
      }

      if (hasError) {
        return;
      }

      try {
        if (this.isSignUp) {
          // Chamada de cadastro via api.js
          const response = await api.auth.register(this.email, this.password);
          this.showModal("Conta criada com sucesso!", "success");
          console.log("Cadastro:", response.data);
          // Opcional: Redirecionar ou limpar campos após o cadastro
          this.email = "";
          this.password = "";
          this.confirmPassword = "";
          this.isSignUp = false;
        } else {
          // Chamada de login via api.js
          const response = await api.auth.login(this.email, this.password);
          this.showModal("Login realizado com sucesso!", "success");
          console.log("Login:", response.data);
          // Opcional: Redirecionar após o login
        }
      } catch (error) {
        if (error.response) {
          const serverMessage = error.response.data.message || "Erro desconhecido no servidor.";
          this.showModal(serverMessage, "error");
          console.error("Erro no servidor:", error.response);
        } else if (error.request) {
          this.showModal("Erro na comunicação com o servidor.", "error");
          console.error("Erro de requisição:", error.request);
        } else {
          this.showModal("Erro inesperado: " + error.message, "error");
          console.error("Erro:", error.message);
        }
      }
    },
  },
};
</script>

<style scoped>
:root {
  margin: 0;
  padding: 0;
  height: 100%;
  overflow: hidden;
}

html,
body {
  margin: 0;
  padding: 0;
  height: 100%;
  overflow: hidden;
}

.input-container input.error {
  border: 0.2vw solid #ff0000;
}

.error-message {
  color: #ff0000;
  font-size: 1vw;
  margin-top: 1vw;
  text-align: center;
}

.container {
  display: flex;
  flex-direction: row;
  min-height: 100vh;
  font-family: "Jost", sans-serif;
  background-color: #ececec;
  width: 100vw;
  max-height: 90vh;
}

.left-section {
  color: #000000;
  width: 50%;
  padding-bottom: 8vh;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  border-radius: 20px;
  height: 120vh;
  max-height: 90vh;
  border: solid 3px black;
  margin: 2vw 1.2vw;
}

.logo {
  display: flex;
  align-items: center;
  justify-content: center;
  width: 100%;
  margin-bottom: -3%;
}

.logo img {
  max-height: 10vw;
}

.slogan {
  text-align: center;
  margin-bottom: 2%;
}

.slogan h2 {
  font-size: 2.3vw;
  color: #1199ce;
}

.subtitulo {
  font-size: 1vw;
  text-align: center;
  line-height: 1.5;
  width: 38vw;
  margin-bottom: 2%;
}

.caixa-login {
  width: 90%;
  display: flex;
  justify-content: center;
  align-items: center;
}

.formulario {
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: column;
  width: 100%;
  border: 0.2vw solid #353535;
  border-radius: 0.8vw;
  padding: 2vw;
  box-sizing: border-box;
}

.input-container {
  width: 100%;
  margin-bottom: 1.5vw;
}

.input-container input {
  width: 100%;
  padding: 0.8vw;
  width: 40vw;
  border-radius: 0.6vw;
  background-color: #dfdfdf;
  border: 0.2vw solid #353535;
  font-size: 1.1vw;
}

button[type="submit"] {
  background-color: #1199ce;
  color: white;
  border: none;
  border-radius: 0.6vw;
  padding: 0.8vw;
  cursor: pointer;
  font-size: 1.1vw;
  width: 100%;
  transition: background-color 0.3s ease;
}

button[type="submit"]:hover {
  background-color: #128cbd;
  transition: background-color 0.3s ease;
}

.toggle-form {
  margin-top: 1vw;
  font-size: 1vw;
}

.toggle-form a {
  color: #1199ce;
  text-decoration: none;
}

.footer {
  font-size: 0.9vw;
  color: #bbbbbb;
  text-align: center;
  margin-top: 2%;
}

.footer a {
  color: #bbbbbb;
  margin: 0 5px;
  text-decoration: none;
}

/* Lado direito: Informações sobre Mia ----------------------------------------------------------------- */
.right-section {
  color: #333333;
  width: 50%;
  padding: 4vw;
  display: flex;
  flex-direction: column;
  justify-content: center;
  background-color: #ececec;
}

.mia-logo img {
  max-width: 27vw;
  margin-bottom: 3%;
  margin-left: 17%;
}

.info-item h3 {
  font-size: 1.5vw;
  font-weight: bold;
  margin-bottom: 0.5vw;
}

.info {
  display: flex;
  flex-direction: column;
  gap: 2vw;
  margin-bottom: 3vw;
}

.info-item p {
  font-size: 1.2vw;
  line-height: 1.5;
  margin-left: 20px;
}

.modal {
  position: fixed;
  bottom: 20px;
  left: 50%;
  transform: translateX(-50%);
  background-color: #ffffff;
  border: 1px solid #cccccc;
  border-radius: 8px;
  padding: 16px 24px;
  box-shadow: 0 2px 8px rgba(0, 0, 0, 0.2);
  z-index: 1000;
  display: flex;
  align-items: center;
  justify-content: space-between;
  min-width: 300px;
}

.modal p {
  margin: 0;
  font-size: 1rem;
}

.modal.success {
  border-left: 5px solid #28a745;
}

.modal.error {
  border-left: 5px solid #dc3545;
}

.modal button {
  background: none;
  border: none;
  font-size: 1rem;
  cursor: pointer;
  color: #007bff;
}

.error-text {
  color: #dc3545;
  font-size: 0.9rem;
  margin-top: 4px;
  display: block;
}

.input-container {
  position: relative;
}

/* Opcional: Animação de entrada para o modal */
.modal-enter-active, .modal-leave-active {
  transition: opacity 0.5s;
}
.modal-enter, .modal-leave-to /* .modal-leave-active em <2.1.8 */ {
  opacity: 0;
}
</style>
