-- Criar banco de dados
CREATE DATABASE sarah_assistant_db;
USE sarah_assistant_db;

-- Criar tabela de usuários
CREATE TABLE users (
    user_id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(50) NOT NULL UNIQUE,
    email VARCHAR(100) NOT NULL UNIQUE,
    password_hash VARCHAR(255) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    CONSTRAINT chk_email_format CHECK (email LIKE '%_@__%.__%')
);

-- Criar tabela de perfis de personalidade (Personas)
CREATE TABLE personas (
    persona_id INT AUTO_INCREMENT PRIMARY KEY,
    persona_name VARCHAR(50) NOT NULL,
    description TEXT NOT NULL,
    personality_traits JSON NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Inserindo a primeira personalidade (Sarah)
INSERT INTO personas (persona_name, description, personality_traits)
VALUES ('Sarah', 'Sarah é uma assistente empática e amigável, com uma abordagem tranquila e respostas carinhosas.', 
'{"friendly": true, "empathy_level": 5, "writing_style": "casual"}');

-- Criar tabela de conversas (Chats)
CREATE TABLE chats (
    chat_id INT AUTO_INCREMENT PRIMARY KEY,
    user_id INT NOT NULL,
    persona_id INT NOT NULL,
    started_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    ended_at TIMESTAMP NULL,
    FOREIGN KEY (user_id) REFERENCES users(user_id) ON DELETE CASCADE,
    FOREIGN KEY (persona_id) REFERENCES personas(persona_id)
);

-- Criar tabela de mensagens (Messages)
CREATE TABLE messages (
    message_id INT AUTO_INCREMENT PRIMARY KEY,
    chat_id INT NOT NULL,
    sender ENUM('user', 'persona') NOT NULL,
    content TEXT NOT NULL,
    sent_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (chat_id) REFERENCES chats(chat_id) ON DELETE CASCADE
);

-- Criar tabela de interações para análise de sentimentos (Sentiment Analysis)
CREATE TABLE sentiment_analysis (
    analysis_id INT AUTO_INCREMENT PRIMARY KEY,
    message_id INT NOT NULL,
    sentiment ENUM('positive', 'neutral', 'negative') NOT NULL,
    confidence_level DECIMAL(5, 2) CHECK (confidence_level >= 0 AND confidence_level <= 100),
    analyzed_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (message_id) REFERENCES messages(message_id) ON DELETE CASCADE
);

-- Criar tabela de feedback do usuário
CREATE TABLE feedback (
    feedback_id INT AUTO_INCREMENT PRIMARY KEY,
    user_id INT NOT NULL,
    persona_id INT NOT NULL,
    feedback_text TEXT NOT NULL,
    rating INT CHECK (rating BETWEEN 1 AND 5),
    submitted_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (user_id) REFERENCES users(user_id) ON DELETE CASCADE,
    FOREIGN KEY (persona_id) REFERENCES personas(persona_id)
);

-- Criar tabela de logs de acesso (para segurança e auditoria)
CREATE TABLE access_logs (
    log_id INT AUTO_INCREMENT PRIMARY KEY,
    user_id INT NOT NULL,
    action VARCHAR(255) NOT NULL,
    ip_address VARCHAR(45),
    accessed_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (user_id) REFERENCES users(user_id) ON DELETE CASCADE
);