# Dashboard Treinamento Lyncas

## Descrição
Este é um projeto de uma aplicação web completa, composta por um cliente elaborado em Vue.js 3 e um servidor em C#, utilizando banco de dados SQL Server.
A aplicação possui um layout responsivo e apresenta as seguintes telas: Login, Dashboard (página inicial), Clientes, Vendas, Cadastro de Clientes, Cadastro de Vendas, Edição de Clientes e Edição de Vendas.

## Funcionalidades

- **Login**: Página de login para acesso à aplicação.
- **Dashboard**: Página inicial com visão geral do sistema.
- **Clientes**: Lista de clientes cadastrados no sistema (que são exibidos no momento do Cadastro de Vendas).
- **Cadastro de Clientes**: Formulário para adicionar novos clientes.
- **Edição de Clientes**: Formulário para editar informações de clientes existentes.
- **Vendas**: Lista de vendas registradas no sistema.
- **Cadastro de Vendas**: Formulário para registrar novas vendas.
- **Edição de Vendas**: Formulário para editar informações de vendas existentes.

## Principais Tecnologias e Estruturas Utilizadas

### Frontend
- Vue.js 3
- Bootstrap
- Axios
- V-Mask (para máscaras de componentes personalizados)

### Backend
- C#
- SQL Server
- Estrutura Onion
- Classes Genéricas
- Inversão de Dependências
- AutoMapper
- Migrations
- DTOs e Viewmodels
- Autenticação JWT
- Requisições utilizando de filtros e paginação

## Instalação e Execução

### Frontend
1. Navegue até o diretório `client`.
2. Execute o comando `npm install` para instalar as dependências.
3. Execute o comando `npm run serve` para iniciar a aplicação.

### Backend
1. Navegue até o diretório `server`.
2. Configure o banco de dados SQL Server de acordo com as configurações do arquivo `appsettings.json`, ou altere o arquivo de acordo com seu ambiente local.
3. Execute o comando `dotnet ef database update` para aplicar as migrações ao banco de dados.
4. Execute o comando `dotnet run` para iniciar o servidor backend.
