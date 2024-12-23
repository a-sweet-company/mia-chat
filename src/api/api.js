import axios from 'axios';

const apiClient = axios.create({
  baseURL: 'https://localhost:7013/api', 
  headers: {
    'Content-Type': 'application/json',
  },
});

const auth = {
  register(email, password) {
    return apiClient.post('/auth/register', { email, password });
  },
  login(email, password) {
    return apiClient.post('/auth/login', { email, password });
  },
};

const chat = {
  sendMessage(message) {
    return apiClient.post('/gemini/sendMessage', { message })
      .then(response => {
        return response.data;
      });
  },
  // Método para obter histórico de mensagens (opcional)
  getHistory() {
    return apiClient.get('/gemini/history');
  }
};

export default {
  auth,
  chat,
};
