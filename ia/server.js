const express = require('express');
const { GoogleGenerativeAI } = require('@google/generative-ai');
require('dotenv').config();

const app = express();
const port = 8080;

const genAI = new GoogleGenerativeAI(process.env.API_KEY);

app.use(express.static('public'));
app.use(express.json());

app.post('/chat', async (req, res) => {
    const { message } = req.body;

    try {
        const model = genAI.getGenerativeModel({ model: 'gemini-1.5-flash' });

        const chat = model.startChat({
            history: [
                {
                    role: 'user',
                    parts: [{ text: 'Hello, I have 2 dogs in my house.' }],
                },
                {
                    role: 'model',
                    parts: [{ text: 'Great to meet you. What would you like to know?' }],
                },
            ],
            generationConfig: {
                maxOutputTokens: 100,
            },
        });

        const result = await chat.sendMessage(message);
        const response = await result.response;
        const text = response.text();

        res.json({ reply: text });
    } catch (error) {
        console.error(error);
        res.status(500).json({ error: 'Something went wrong' });
    }
});

app.listen(port, () => {
    console.log(`Server is running on http://localhost:${port}`);
});
