// api.js
import axios from 'axios';
export default axios.create({
  baseURL: 'https://localhost:7134/api', // ou 'http://localhost:5114/api' se precisar usar HTTP
  headers: {
    'Content-Type': 'application/json',
  }
});
