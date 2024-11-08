![Auto Assign](https://github.com/a-sweet-company/demo-repository/actions/workflows/auto-assign.yml/badge.svg)

![Proof HTML](https://github.com/a-sweet-company/demo-repository/actions/workflows/proof-html.yml/badge.svg)

# @ Mindful AI

---

## Sobre o Projeto

**Mindful AI** é uma plataforma de suporte psicológico por meio de uma assistente virtual chamada **Mia**. O objetivo é oferecer uma experiência de conversa empática, focada em saúde mental, por meio de uma interface intuitiva. O projeto é desenvolvido utilizando **Vue.js** para o front-end, com **ASP.NET** e **C#** para o back-end, e utiliza **SQLite** para armazenamento de dados.

Este README explica como configurar o projeto localmente, incluindo o fluxo de trabalho com **GitHub Actions** para CI/CD, a estrutura dos templates para issues e PRs, e a documentação geral do sistema.
## Índice

1. [Badges do Projeto](#badges-do-projeto)
2. [Pré-requisitos](#pré-requisitos)
3. [Instalação](#instalação)
4. [Execução do Projeto](#execução-do-projeto)
5. [Estrutura do Projeto](#estrutura-do-projeto)
6. [Documentação Completa](#documentação-completa)

---

### Badges do Projeto

Os badges abaixo são indicadores do status de workflows automatizados do GitHub Actions:

- **Auto Assign**: Designa automaticamente revisores para PRs abertos no projeto.
- **Proof HTML**: Verifica o HTML gerado no front-end, assegurando conformidade e validação de tags.

Esses badges permitem acompanhar rapidamente o status e qualidade do código.

---
## Pré-requisitos

Certifique-se de ter as seguintes ferramentas e versões instaladas no seu ambiente:

- **Node.js** (14.x ou superior): [Download Node.js](https://nodejs.org/)
- **Vue.js CLI**: [Guia de Instalação do Vue.js](https://cli.vuejs.org/)
- **Axios**: Para comunicação HTTP entre front-end e back-end.
- **.NET SDK** (7.0 ou superior): [Download .NET SDK](https://dotnet.microsoft.com/download/dotnet)
- **SQLite**: Para gerenciamento de banco de dados no back-end.

---

## Instalação

Siga os passos abaixo para configurar o projeto localmente:

1. **Clonar o repositório**

2. **Instalar dependências do front-end**:

   ```bash
   npm install
   npm install -g @fortawesome/fontawesome-free@6.6.0
   npm install -g @vue/cli-plugin-babel@5.0.8
   npm install -g @vue/cli-plugin-router@5.0.8
   npm install -g @vue/cli-service@5.0.8
   npm install -g core-js@3.38.1
   npm install -g vue-router@3.6.5
   npm install -g vue-template-compiler@2.7.16
   npm install -g vue@2.7.16
   npm install axios
   
## 3. Configuração do Back-end

Abra o arquivo .sln da solução no Visual Studio ou em qualquer outro editor C# que preferir. Instale as dependências do .NET e configure o projeto com os seguintes passos:

### Efetue a Migração para o Banco de Dados:

Configure e aplique as migrações do banco de dados para o SQLite:

```bash
dotnet ef database update
```
---

## Execução do Projeto

Para rodar a aplicação, siga os passos:

### Back-end (ASP.NET)
Execute o back-end no Visual Studio (ou rode o projeto pela linha de comando):

```bash
dotnet run
````

### Front-end (Vue.js)
No terminal do vscode, use o comando:
```bash
npm run serve
````

---

## Estrutura do Projeto

**Uma visão geral da organização do projeto, detalhando as responsabilidades de cada pasta e arquivo.**

### Backend (ASP.NET)

* **Controllers:**
   * Contêm os endpoints da API RESTful que serão consumidos pelo frontend.
   * Exemplos: `AuthController` para autenticação de usuários, `ChatHistoryController` para gerenciar o histórico de chat.
* **Models:**
   * Definem as classes que representam as entidades do domínio, ou seja, os dados que serão persistidos no banco de dados.
   * Exemplos: `User` (com propriedades como `Id`, `Username`, `Password`), `ChatHistory` (com propriedades como `Id`, `UserId`, `Message`, `Timestamp`).
* **Repositories:**
   * Abstraem o acesso ao banco de dados, permitindo que a lógica de negócios nos services se concentre nas regras de negócio e não nos detalhes de implementação do banco de dados.
   * Exemplo: `UserRepository` com métodos como `GetUserById`, `CreateUser`, `UpdateUser`.
* **Services:**
   * Implementam a lógica de negócio da aplicação.
   * Exemplos: `AuthService` para lidar com a autenticação de usuários, `ChatHistoryService` para gerenciar o histórico de conversas, incluindo regras de validação e permissões.
* **Data:**
   * Contém a classe `ApplicationDbContext` que herda de `DbContext` do Entity Framework Core, configurando a conexão com o banco de dados SQLite e mapeando as entidades definidas nos models.

### Frontend (Vue.js)
* **Client:**
   * Contém os componentes Vue.js que compõem a interface do usuário.
   * Realiza chamadas para a API do backend utilizando um cliente HTTP (e.g., Axios) para obter e enviar dados.

**Explicações adicionais:**

* **Separação de responsabilidades:** Essa estrutura promove a separação de responsabilidades, facilitando a manutenção e o teste do código.
* **Reusabilidade:** Os repositórios permitem que a lógica de acesso ao banco de dados seja reutilizada em diferentes partes da aplicação.
* **Testes:** É mais fácil escrever testes unitários para os services, pois eles dependem apenas das interfaces dos repositórios e não dos detalhes de implementação do banco de dados.
* **Escalabilidade:** Essa arquitetura pode ser facilmente escalada para projetos maiores, adicionando novas funcionalidades e módulos.

## **Documentação Completa**
Para mais detalhes sobre a arquitetura, fluxo de trabalho e integrações, consulte a Documentação Completa na pasta "documents" no projeto.


