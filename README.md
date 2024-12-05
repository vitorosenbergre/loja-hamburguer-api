# Loja Hamburgueria API

A **Loja Hamburgueria API** é uma API RESTful que foi desenvolvida para gerenciar o funcionamento de uma hamburgueria, permitindo o cadastro de categorias, produtos e pedidos. A API foi construída utilizando o framework .NET, com o uso do Entity Framework Core para interagir com o banco de dados MySQL.

## Tecnologias Utilizadas

- **.NET 8**: Framework para o desenvolvimento da API.
- **Entity Framework Core**: ORM para acesso ao banco de dados.
- **MySQL**: Banco de dados relacional utilizado para persistência de dados.
- **Swagger**: Utilizado para documentação da API.
- **JWT**: Implementação de autenticação e autorização usando JSON Web Tokens.

## Endpoints

Abaixo estão os principais endpoints disponíveis na API. Os exemplos de Requisição e Resposta podem ser vistos no Swagger ou Postman.

### 1. **Categorias**

- **GET /api/categories**  
  Retorna uma lista de todas as categorias.

- **GET /api/categories/{id}**  
  Retorna uma categoria específica pelo ID.

- **POST /api/categories**  
  Cria uma nova categoria.

- **PUT /api/categories/{id}**  
  Atualiza uma categoria existente.

- **DELETE /api/categories/{id}**  
  Remove uma categoria existente.

### 2. **Produtos**

- **GET /api/products**  
  Retorna uma lista de todos os produtos.

- **GET /api/products/{id}**  
  Retorna detalhes de um produto específico pelo ID.

- **POST /api/products**  
  Cria um novo produto.

- **PUT /api/products/{id}**  
  Atualiza um produto existente.

- **DELETE /api/products/{id}**  
  Remove um produto existente.

### 3. **Pedidos**

- **GET /api/orders**  
  Retorna uma lista de todos os pedidos.

- **GET /api/orders/{id}**  
  Retorna detalhes de um pedido específico.

- **POST /api/orders**  
  Cria um novo pedido.

- **PUT /api/orders/{id}**  
  Atualiza o status de um pedido.

- **DELETE /api/orders/{id}**  
  Remove um pedido existente.

### 4. **Usuários (Users)**

- **GET /api/users**  
  Retorna uma lista de todos os usuários cadastrados na plataforma.

- **GET /api/users/{id}**  
  Retorna os detalhes de um usuário específico, identificado pelo seu ID.

- **POST /api/users**  
  Cria um novo usuário no sistema. Os dados do novo usuário devem ser enviados no corpo da requisição.

- **PUT /api/users/{id}**  
  Atualiza as informações de um usuário específico. Apenas os dados enviados serão alterados.

- **DELETE /api/users/{id}**  
  Remove um usuário do sistema, identificando-o pelo seu ID.

### 5. Status

- **GET /api/status**
  Retorna todos os status disponíveis no sistema. Pode ser útil para saber todos os tipos de status (ex: "Em preparação", "Concluído", "Cancelado").

- **GET /api/status/{id}**
  Retorna o status específico identificado pelo seu ID.

- **POST /api/status**
  Cria um novo status. Os dados do status devem ser passados no corpo da requisição.

- **PUT /api/status/{id}**
  Atualiza o nome ou descrição de um status existente.

- **DELETE /api/status/{id}**
  Remove um status do sistema.


## Como Rodar a API Localmente

### Requisitos

- **.NET SDK 8.0**
- **MySQL**
- **Visual Studio ou VSCode** (Opcional)

### Passos

1. Clone o repositório:
   ```bash
   git clone https://github.com/vitorosenbergre/loja-hamburguer-api.git

2. Navegue até o diretório do projeto:
   ```bash
   cd loja-hamburguer-api

3. Restaure as dependências do projeto:
   ```bash
   dotnet restore

4. Crie e migre o banco de dados (garanta que o MySQL está rodando):
   ```bash
   dotnet ef migrations add MigracaoInicial
   dotnet ef database update

5. Inicie a aplicação:
   ```bash
   dotnet run

6.  API estará disponível em http://localhost:5000 (ou na porta que você configurou).

### Explicação das Seções:

- **Tecnologias Utilizadas**: Descreve as principais tecnologias usadas na construção da API.
- **Endpoints**: Lista os principais endpoints da API e seus métodos HTTP (GET, POST, PUT, DELETE), incluindo uma descrição de suas funcionalidades.
- **Como Rodar a API Localmente**: Passos para rodar o projeto localmente, incluindo a instalação de dependências e a configuração do banco de dados.

### O que adicionar ou modificar:
- **Personalizar o conteúdo**: Altere a descrição e os detalhes conforme necessário, dependendo do que a sua API realmente faz.
- **Incluir exemplos de payloads e respostas**: Se necessário, adicione exemplos de como os dados são passados nas requisições e retornados nas respostas.



