// src/api/api.js
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

export default {
  auth,
};