<template>
  <div class="form-container">
    <form @submit.prevent="submitForm">
      <header>
        <h1>Formulário de Cadastro</h1>
        <p>Preencha suas informações abaixo.</p>
      </header>

      <div class="centralizador">
        <div class="objetoCentralizador">
          <!-- Nome -->
          <div :class="['form-group', { error: errors.nome }]">
            <label for="nome">Nome</label>
            <input
              type="text"
              v-model="formData.nome"
              placeholder="Insira seu nome aqui"
              required
            />
            <label v-if="errors.nome">{{ errors.nome }}</label>
          </div>

          <!-- Telefone -->
          <div :class="['form-group', { error: errors.telefone }]">
            <label for="telefone">Telefone</label>
            <input
              type="text"
              v-model="formData.telefone"
              placeholder="(XX) XXXX-XXXX"
              required
            />
            <label v-if="errors.telefone">{{ errors.telefone }}</label>
          </div>

          <!-- E-mail -->
          <div :class="['form-group', { error: errors.email }]">
            <label for="email">E-mail</label>
            <input
              type="email"
              v-model="formData.email"
              placeholder="Insira seu e-mail"
              required
            />
            <label v-if="errors.email">{{ errors.email }}</label>
          </div>

          <!-- LinkedIn -->
          <div :class="['form-group', { error: errors.linkedin }]">
            <label for="linkedin">LinkedIn</label>
            <input
              type="url"
              v-model="formData.linkedin"
              placeholder="https://www.linkedin.com/in/seuperfil"
            />
            <label v-if="errors.linkedin">{{ errors.linkedin }}</label>
          </div>

          <!-- Profissão -->
          <div class="form-group">
            <label for="profissao">Profissão</label>
            <input
              type="text"
              v-model="formData.profissao"
              placeholder="Sua profissão"
            />
          </div>

          <!-- CEP -->
          <div :class="['form-group', { error: errors.cep }]">
            <label for="cep">CEP</label>
            <input
              type="text"
              v-model="formData.cep"
              placeholder="Insira seu CEP aqui"
              @blur="fetchAddress"
            />
            <label v-if="errors.cep">{{ errors.cep }}</label>
            <span v-if="loading">Carregando...</span>
          </div>

          <!-- Endereço -->
          <div class="form-group">
            <label for="endereco">Endereço</label>
            <input
              type="text"
              v-model="formData.endereco"
              placeholder="Endereço será preenchido automaticamente"
            />
          </div>

          <!-- Bairro -->
          <div class="form-group">
            <label for="bairro">Bairro</label>
            <input
              type="text"
              v-model="formData.bairro"
              placeholder="Seu bairro"
            />
          </div>

          <!-- Cidade -->
          <div class="form-group">
            <label for="cidade">Cidade</label>
            <input
              type="text"
              v-model="formData.cidade"
              placeholder="Sua cidade"
            />
          </div>

          <!-- Estado -->
          <div class="form-group">
            <label for="estado">Estado</label>
            <select v-model="formData.estado">
              <option value="" disabled>Selecione seu estado</option>
              <option value="SP">SP</option>
              <option value="RJ">RJ</option>
              <option value="MG">MG</option>
              <option value="ES">ES</option>
              <option value="BA">BA</option>
              <option value="PR">PR</option>
              <option value="GO">GO</option>
              <option value="MS">MS</option>
              <option value="MT">MT</option>
              <option value="PA">PA</option>
              <option value="AM">AM</option>
            </select>
          </div>

          <!-- Faculdade -->
          <div class="form-group">
            <label for="faculdade">Faculdade</label>
            <input
              type="text"
              v-model="formData.faculdade"
              placeholder="Nome da faculdade"
            />
          </div>

          <!-- Curso -->
          <div class="form-group">
            <label for="curso">Curso</label>
            <input
              type="text"
              v-model="formData.curso"
              placeholder="Nome do curso"
            />
          </div>

          <!-- Última Empresa -->
          <div class="form-group">
            <label for="empresa">Última empresa que trabalhou</label>
            <input
              type="text"
              v-model="formData.empresa"
              placeholder="Nome da empresa"
            />
          </div>

          <!-- Descrição do perfil -->
          <div class="form-group">
            <label for="perfil">Descrição do perfil profissional</label>
            <textarea
              v-model="formData.perfil"
              placeholder="Fale sobre você"
              maxlength="500"
            ></textarea>
            <small>{{ formData.perfil.length }}/500</small>
          </div>

          <!-- Descrição do que fez na última empresa -->
          <div class="form-group">
            <label for="descricaoEmpresa">O que fez na última empresa?</label>
            <textarea
              v-model="formData.descricaoEmpresa"
              placeholder="Descreva suas atividades"
              maxlength="500"
            ></textarea>
            <small>{{ formData.descricaoEmpresa.length }}/500</small>
          </div>

          <!-- Período da faculdade -->
          <div class="form-group">
            <label for="faculdadeInicio">Início da Faculdade</label>
            <input type="date" v-model="formData.faculdadeInicio" />
          </div>
          <div class="form-group">
            <label for="faculdadeFim">Fim da Faculdade</label>
            <input type="date" v-model="formData.faculdadeFim" />
          </div>

          <!-- Período de tempo na empresa -->
          <div class="form-group">
            <label for="empresaInicio">Início na Empresa</label>
            <input type="date" v-model="formData.empresaInicio" />
          </div>
          <div class="form-group">
            <label for="empresaFim">Fim na Empresa</label>
            <input type="date" v-model="formData.empresaFim" />
          </div>

          <!-- Skills -->
          <div class="form-group">
            <label>Skills</label>
            <div>
              <label>
                <input
                  class="classcheckbox"
                  type="checkbox"
                  v-model="formData.skills"
                  value="HTML"
                />
                HTML
              </label>
              <label>
                <input
                  class="classcheckbox"
                  type="checkbox"
                  v-model="formData.skills"
                  value="CSS"
                />
                CSS
              </label>
              <label>
                <input
                  class="classcheckbox"
                  type="checkbox"
                  v-model="formData.skills"
                  value="JavaScript"
                />
                JavaScript
              </label>
              <label>
                <input
                  class="classcheckbox"
                  type="checkbox"
                  v-model="formData.skills"
                  value="React"
                />
                React
              </label>
              <label>
                <input
                  class="classcheckbox"
                  type="checkbox"
                  v-model="formData.skills"
                  value="Vue.js"
                />
                Vue.js
              </label>
              <label>
                <input
                  class="classcheckbox"
                  type="checkbox"
                  v-model="formData.skills"
                  value="Node.js"
                />
                Node.js
              </label>
              <label>
                <input
                  class="classcheckbox"
                  type="checkbox"
                  v-model="formData.skills"
                  value="TypeScript"
                />
                TypeScript
              </label>
              <label>
                <input
                  class="classcheckbox"
                  type="checkbox"
                  v-model="formData.skills"
                  value="GraphQL"
                />
                GraphQL
              </label>
              <label>
                <input
                  class="classcheckbox"
                  type="checkbox"
                  v-model="formData.skills"
                  value="Python"
                />
                Python
              </label>
              <label>
                <input
                  class="classcheckbox"
                  type="checkbox"
                  v-model="formData.skills"
                  value="Django"
                />
                Django
              </label>
            </div>
          </div>

          <!-- Sexo -->
          <div class="form-group">
            <label>Sexo</label>
            <div>
              <label>
                <input type="radio" v-model="formData.sexo" value="Masculino" />
                Masculino
              </label>
              <label>
                <input type="radio" v-model="formData.sexo" value="Feminino" />
                Feminino
              </label>
              <label>
                <input type="radio" v-model="formData.sexo" value="Outro" />
                Outro
              </label>
            </div>
          </div>

          <!-- Upload da Foto -->
          <div class="form-group">
            <label for="foto">Upload da Foto</label>
            <input type="file" @change="handleFileUpload" />
            <img
              v-if="formData.foto"
              :src="formData.foto"
              alt="Preview da foto"
            />
          </div>

          <!-- Botões -->
          <div class="form-group">
            <button type="submit" class="cadastrar">Cadastrar</button>
          </div>
        </div>
      </div>
    </form>
  </div>
</template>

<script>
export default {
  data() {
    return {
      formData: {
        nome: "",
        telefone: "",
        email: "",
        linkedin: "",
        profissao: "",
        cep: "",
        endereco: "",
        bairro: "",
        cidade: "",
        estado: "",
        faculdade: "",
        curso: "",
        empresa: "",
        perfil: "",
        descricaoEmpresa: "",
        faculdadeInicio: "",
        faculdadeFim: "",
        empresaInicio: "",
        empresaFim: "",
        skills: [],
        sexo: "",
        foto: null,
      },
      loading: false,
      errors: {
        nome: null,
        telefone: null,
        email: null,
        linkedin: null,
        cep: null,
      },
    };
  },
  methods: {
    async fetchAddress() {
      this.loading = true;
      const response = await fetch(
        `https://viacep.com.br/ws/${this.formData.cep}/json/`
      );
      const data = await response.json();
      this.formData.endereco = data.logradouro;
      this.formData.bairro = data.bairro;
      this.formData.cidade = data.localidade;
      this.formData.estado = data.uf;
      this.loading = false;
    },
    handleFileUpload(event) {
      const file = event.target.files[0];
      const reader = new FileReader();
      reader.onload = (e) => {
        this.formData.foto = e.target.result;
      };
      reader.readAsDataURL(file);
    },
    validateForm() {
      this.errors = {
        nome: null,
        telefone: null,
        email: null,
        linkedin: null,
        cep: null,
      };

      let isValid = true;

      // Validação do nome
      if (!this.formData.nome) {
        this.errors.nome = "O nome é obrigatório.";
        isValid = false;
      }

      // Validação do telefone
      const onlyNumbers = this.formData.telefone.replace(/\D/g, ""); // Remove tudo que não for número
      if (onlyNumbers.length < 10 || onlyNumbers.length > 11) {
        this.errors.telefone = "O telefone deve ter 10 ou 11 dígitos.";
        isValid = false;
      } else if (/\D/.test(this.formData.telefone)) {
        this.errors.telefone = "O telefone deve conter apenas números.";
        isValid = false;
      }

      // Validação do e-mail
      const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
      if (!this.formData.email.match(emailPattern)) {
        this.errors.email = "Formato de e-mail inválido.";
        isValid = false;
      }

      // Validação do CEP
      const cepPattern = /^\d{5}-?\d{3}$/;
      if (!this.formData.cep.match(cepPattern)) {
        this.errors.cep = "CEP inválido. Deve ter 8 dígitos.";
        isValid = false;
      }

      return isValid;
    },
    submitForm() {
      if (this.validateForm()) {
        console.log("Formulário validado com sucesso!", this.formData);
        this.$router.push({
          name: "Resume",
          params: { formData: this.formData },
        });
        // Salvar o formulário no localStorage
        localStorage.setItem("formData", JSON.stringify(this.formData));
      } else {
        console.error("Formulário inválido.");
      }
    },
  },
};
</script>

<style scoped>
.centralizador {
  /* border: 1px solid black; */
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  width: 100%;
  max-width: 600px;
  margin: 0 auto;
  margin-top: 20px;
}

.form-group.error input,
.form-group.error select,
.form-group.error textarea {
  border-color: red;
}

.form-group span {
  color: red;
  position: absolute;
  bottom: -20px;
  left: 0;
  font-size: 0.9rem;
}

button {
  background-color: var(--accent-color);
  color: #fff;
  border: none;
  padding: 10px 20px;
  cursor: pointer;
  border-radius: 10px;
}

button:hover {
  background-color: var(--hover-color);
}

form {
  display: flex;
  flex-direction: column;
  gap: 15px;
  margin-bottom: 30px;
}

/* Específico para checkboxes */
.form-group .classcheckbox {
  margin-right: 10px;
  width: 20px;
  height: 20px;
  cursor: pointer;
  accent-color: var(--accent-color); /* Cor de destaque para as checkboxes */
}

.form-group label {
  display: flex;
  align-items: center;
  margin-bottom: 10px;
}

/* Grupo de checkboxes */
.form-group .checkbox-group {
  display: flex;
  flex-wrap: wrap;
  gap: 10px;
}

.checkbox-group label {
  font-weight: normal;
  font-size: 14px;
  background-color: var(--secondary-color);
  padding: 5px;
  border-radius: 5px;
  cursor: pointer;
}

/* Específico para radios */
.form-group input[type="radio"] {
  margin-right: 10px;
  width: 18px;
  height: 18px;
  cursor: pointer;
}

img {
  max-width: 100px;
  max-height: 100px;
  margin-top: 10px;
}
</style>
