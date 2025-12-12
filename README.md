<h1 align="center">Livraria APP</h1>


<img width="1379" height="878" alt="image" src="https://github.com/user-attachments/assets/0af4a873-8f83-4ce8-967e-6ca61d168739" />


 ## Cadastro é um projeto full-stack para cadastro de livros.

## 🔥 Introdução

APP foi criação com .net versão 8 e React versão 19

### ⚙️ Pré-requisitos
* .Net Core versão 8.0 [.Net Core 8.0 Download](https://dotnet.microsoft.com/pt-br/download/dotnet/8.0)
* Entity Framework Core versão 8.0 [Documentação](https://learn.microsoft.com/pt-br/ef/)
* Visual studio 2022, ou IDE que tenha suporte ao .Net 8.0 [Visual Studio 2022 Download](https://visualstudio.microsoft.com/pt-br/downloads/)
* Sql Server versão 2022 [Sql Server Download](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)
* Sql Server Management Studio (SSMS) [SSMS Download](https://learn.microsoft.com/pt-br/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16)
* Angular v14 [Documentação] ([Learn React](https://v14.angular.io/docs))
* Swagger [Documentação] ([Swagger](https://swagger.io/))


### 🔨 Guia de instalação

Para utilizar este projeto, necessário instalar o Entity Framework, e configurar o banco de dados no arquivo appsettings.Development.json, e instalar as migrations para conexão com o banco de dados

Etapas para instalar:

```bash
dotnet tool install --global dotnet-ef
```
Passo 2:
```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```
Passo 3:
```bash
Install-Package Microsoft.EntityFrameworkCore.Design
```
Passo 4:
```bash
dotnet-ef migrations add (Nome da migration do projeto)
```

Passo 5:
```bash
dotnet-ef database update
```

# Executando a Aplicação 🌐

Para executar a aplicação App, digite o seguinte comando

```bash
ng serve
```
Acessar o link http://localhost:4200 (Caso o navegador não abra automáticamente)

Para executar a aplicação back-end, digite o seguinte comando

```bash
dotnet run
```

# Criação de Autor e genero via back-end 🚨

Por conta de melhor agilidade, os controllers para ler, criar, editar e  excluir autores e gêneros.
Os mesmos foram criados diretamente no back-end, utilizando Seeders com as declarações dos mesmos



