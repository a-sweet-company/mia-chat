<template>
  <div class="container">
    <!-- Lado esquerdo: Formulário de login/cadastro -->
    <div class="left-section">
      <div class="logo">
        <img
          :src="require('@/assets/miaLogoBlack.svg')"
          alt="Mindful AI Logo"
        />
      </div>
      <div class="slogan">
        <h2>
          Fale com quem entende você, sempre.
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
              <span v-if="inputErrors.email" class="error-text"
                >Por favor, insira um email válido.</span
              >
            </div>
            <div class="input-container">
              <input
                :class="{ error: inputErrors.password }"
                type="password"
                placeholder="Senha"
                v-model="password"
                required
              />
              <span v-if="inputErrors.password" class="error-text"
                >A senha é obrigatória.</span
              >
            </div>
            <div v-if="isSignUp" class="input-container">
              <input
                :class="{ error: inputErrors.confirmPassword }"
                type="password"
                placeholder="Confirme sua senha"
                v-model="confirmPassword"
                required
              />
              <span v-if="inputErrors.confirmPassword" class="error-text"
                >As senhas não coincidem.</span
              >
            </div>
            <button type="submit">
              {{ isSignUp ? "Cadastrar" : "Entrar" }}
            </button>
          </form>
          <p class="toggle-form">
            {{ isSignUp ? "Já tem uma conta?" : "Não tem uma conta?" }}
            <a href="#" @click.prevent="toggleSignUp">{{
              isSignUp ? "Entrar" : "Criar conta"
            }}</a>
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
  name: 'Login',
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
  created() {
    const isAuthenticated = sessionStorage.getItem('isAuthenticated');
    if (isAuthenticated === 'true') {
      //this.$router.push('/chat');
    }
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
    async validateDomain(email) {
      const domain = email.split("@")[1];
      try {
        const response = await fetch(
          `https://dns.google/resolve?name=${domain}&type=MX`
        );
        if (!response.ok) throw new Error("Falha ao validar domínio.");
        const data = await response.json();
        return data.Answer && data.Answer.length > 0;
      } catch (error) {
        console.error("Erro ao validar domínio:", error);
        return false;
      }
    },
    async validateForm() {
      this.clearInputErrors();
      let hasError = false;

      if (!this.email) {
        this.inputErrors.email = true;
        hasError = true;
      } else if (!this.validateEmail(this.email)) {
        this.inputErrors.email = true;
        hasError = true;
        this.showModal("Por favor, insira um email válido.", "error");
      } else if (!(await this.validateDomain(this.email))) {
        this.inputErrors.email = true;
        hasError = true;
        this.showModal("Domínio de email inválido.", "error");
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

      return !hasError;
    },
    async handleFormSubmit() {
      if (!(await this.validateForm())) {
        return;
      }

      try {
        if (this.isSignUp) {
          await this.registerUser();
        } else {
          await this.loginUser();
        }
      } catch (error) {
        this.handleError(error);
      }
    },
    async registerUser() {
      const response = await api.auth.register(this.email, this.password);
      this.showModal("Conta criada com sucesso!", "success");
      console.log("Cadastro:", response.data);
      this.resetForm();
    },
    async loginUser() {
      try {
        const response = await api.auth.login(this.email, this.password);
        
        // Store authentication state
        sessionStorage.setItem('isAuthenticated', 'true');
        sessionStorage.setItem('userEmail', this.email);
        
        // Store token if available
        if (response.data && response.data.token) {
          sessionStorage.setItem('token', response.data.token);
        }

        this.showModal("Login realizado com sucesso!", "success");
        
        // Navigate to chat after successful login
        setTimeout(() => {
          this.$router.push("/loading");
        }, 1000);
      } catch (error) {
        if (error.response && error.response.status === 400) {
          this.showModal("Credenciais inválidas. Tente novamente.", "error");
        } else {
          this.showModal("Ocorreu um erro ao tentar fazer login.", "error");
        }
        console.error("Erro no login:", error.response?.data || error.message);
      }
    },
    handleError(error) {
      if (error.response) {
        const serverMessage =
          error.response.data.message || "Erro desconhecido no servidor.";
        this.showModal(serverMessage, "error");
        console.error("Erro no servidor:", error.response);
      } else if (error.request) {
        this.showModal("Erro na comunicação com o servidor.", "error");
        console.error("Erro de requisição:", error.request);
      } else {
        this.showModal("Erro inesperado: " + error.message, "error");
        console.error("Erro:", error.message);
      }
    },
    resetForm() {
      this.email = "";
      this.password = "";
      this.confirmPassword = "";
      this.isSignUp = false;
      sessionStorage.clear();
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
  border: 0.2vw solid var(--color-vermelho-erro);
}

.error-message {
  color: var(--color-vermelho-erro);
  font-size: 1vw;
  margin-top: 1vw;
  text-align: center;
}

.container {
  display: flex;
  flex-direction: row;
  min-height: 100vh;
  font-family: "Jost", sans-serif;
  background-color: var(--color-branco-claro);
  width: 100vw;
  max-height: 90vh;
}

.left-section {
  color: var(--color-preto);
  width: 50%;
  padding-bottom: 8vh;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  border-radius: 20px;
  height: 120vh;
  max-height: 90vh;
  border: solid 3px var(--color-preto);
  margin: 2vw 1.2vw;
}

.logo {
  display: flex;
  align-items: center;
  justify-content: center;
  width: 100%;
  margin-top: 5%;
  margin-bottom: -5%;
}

.logo img {
  max-height: 10vw;
}

.slogan {
  text-align: center;
  margin-bottom: 1%;
}

.slogan h2 {
  font-size: 2.3vw;
  color: var(--color-azul);
}

.subtitulo {
  font-size: 1.1vw;
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
  border: 0.2vw solid var(--color-cinza);
  border-radius: 0.8vw;
  padding: 2vw;
  box-sizing: border-box;
}

.input-container {
  width: 100%;
  margin-bottom: 1.5vw;
  font-family: "Jost", sans-serif;
}

.input-container input {
  width: 100%;
  padding: 0.8vw;
  width: 40vw;
  border-radius: 0.6vw;
  background-color: var(--color-branco);
  border: 0.2vw solid var(--color-cinza);
  font-size: 1.1vw;
}

button[type="submit"] {
  background-color: var(--color-azul);
  color: var(--color-branco);
  border: none;
  border-radius: 0.6vw;
  padding: 0.8vw;
  cursor: pointer;
  font-size: 1.1vw;
  width: 100%;
  transition: background-color 0.3s ease;
}

button[type="submit"]:hover {
  background-color: var(--color-azul-escuro);
  transition: background-color 0.3s ease;
}

.toggle-form {
  margin-top: 1vw;
  font-size: 1vw;
}

.toggle-form a {
  color: var(--color-azul);
  text-decoration: none;
}

.footer {
  font-size: 0.9vw;
  color: var(--color-marmore-footer);
  text-align: center;
  margin-top: 2%;
}

.footer a {
  color: var(--color-marmore-footer);
  margin: 0 5px;
  text-decoration: none;
}

/* Lado direito: Informações sobre Mia ----------------------------------------------------------------- */
.right-section {
  color: var(--color-cinza);
  width: 50%;
  padding: 4vw;
  display: flex;
  flex-direction: column;
  justify-content: center;
  background-color: var(--color-branco-claro);
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
  background-color: var(--color-branco);
  border: 1px solid var(--color-marmore-modal);
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
  border-left: 5px solid var(--color-verde-sucesso);
}

.modal.error {
  border-left: 5px solid var(--color-vermelho-erro);
}

.modal button {
  background: none;
  border: none;
  font-size: 1rem;
  cursor: pointer;
  color: var(--color-azul);
}

.error-text {
  color: var(--color-vermelho-erro);
  font-size: 0.9rem;
  margin-top: 4px;
  display: block;
}

.input-container {
  position: relative;
}

.modal-enter-active,
.modal-leave-active {
  transition: opacity 0.5s;
}
.modal-enter,
.modal-leave-to {
  opacity: 0;
}
</style>
