<template>
  <div class="resume-container">
    <!-- Header com Avatar e Título -->
    <div class="header">
      <img :src="formData.foto" alt="Profile Picture" class="profile-image" />
      <div class="header-text">
        <h1>{{ formData.nome }}</h1>
        <h2>{{ formData.profissao }}</h2>
      </div>
    </div>

    <div class="resume-body">
      <!-- Coluna 1 - Esquerda -->
      <div class="left-column">
        <div class="profile">
          <h3>Profile</h3>
          <p>{{ formData.perfil }}</p>
        </div>

        <div class="main-skills">
          <h3>Main Skills</h3>
          <ul>
            <li v-for="skill in formData.skills" :key="skill">{{ skill }}</li>
          </ul>
        </div>

        <div class="contact-information">
          <h3>Contact Information</h3>
          <p><b>Tel:</b> {{ formData.telefone }}</p>
          <p><b>Email:</b> {{ formData.email }}</p>
          <p><b>Location:</b> {{ formData.cidade }}, {{ formData.estado }}</p>
          <p><b>LinkedIn:</b> <a :href="formData.linkedin" target="_blank">{{ formData.linkedin }}</a></p>
        </div>
      </div>

      <!-- Coluna 2 - Direita -->
      <div class="right-column">
        <div class="employment">
          <h3>Employment</h3>
          <div class="job">
            <h4>{{ formData.empresa }}</h4>
            <h5>{{ formData.empresaInicio }}   {{ formData.empresaFim }}</h5>
            <p>{{ formData. descricaoEmpresa }}</p>
          </div>
        </div>

        <div class="education">
          <h3>Education</h3>
          <div class="education-item">
            <h4>{{ formData.faculdade }}</h4>
            <h5>{{ formData.faculdadeInicio }}   {{ formData.faculdadeFim }}</h5>
            <p>{{ formData.curso }}</p>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    formData: Object,
  },
};
</script>

<style scoped>
.resume-container {
  max-width: 900px;
  margin: 0 auto;
  font-family: 'Arial', sans-serif;
  color: #333;
  line-height: 1.6;
  padding: 20px;
}

.header {
  display: flex;
  align-items: center;
  justify-content: start;
  margin-bottom: 60px;
}

.profile-image {  
  width: 160px;
  height: 160px;
  border-radius: 50%;
  margin-right: 20px;
  object-fit: cover;
}

.header-text h1 {
  font-size: 2.8em;
  margin: 0;
}

.header-text h2 {
  font-size: 1.1em;
  margin: 5px 0 0;
  color: #555;
}

.resume-body {
  display: flex;
  gap: 100px;
}

.left-column, .right-column {
  flex: 1;
}

h3 {
  font-size: 1.2em;
  border-bottom: 0px solid #333;
  padding-bottom: 5px;
  margin-bottom: 10px;
}

h4{
  font-size: 1.2em;
  margin: 0;
  color: #353535;  
}

h5 {
  font-size: 0.8em;
  margin: 0;
  color: #353535;
}

ul {
  list-style-type: disc;
  padding: 0;
}

ul li {
  background-color: #f4f4f4;
  padding: 5px;
  margin: 5px 0;
  border-radius: 5px;
}

.contact-information p, .education p, .employment p {
  margin: 5px 0;
}

</style>
