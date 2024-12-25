const { GoogleGenerativeAI } = require('@google/generative-ai');
require('dotenv').config();

(async () => {
    const genAI = new GoogleGenerativeAI(process.env.API_KEY);

    try {
        const model = genAI.getGenerativeModel({ model: 'gemini-1.5-flash' });
        const response = await model.generateText({
            text: 'Explique como a IA funciona.',
            temperature: 0.7,
            maxOutputTokens: 100,
        });

        console.log('Resposta:', response.text());
    } catch (error) {
        console.error('Erro:', error.message, error.stack);
    }
})();
