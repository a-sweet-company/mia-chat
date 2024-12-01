// api.js
import axios from 'axios';

export default axios.create({
  baseURL: 'https://localhost:7013/api', // Atualizado para apontar para o backend correto
  headers: {
    'Content-Type': 'application/json',
  },
});
