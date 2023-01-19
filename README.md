<h1 align="center">UserApp</h1>

## Setup do projeto
 - C#
 - SQL Server
 - Entity Framework
 - Xunit
 - Moq

 ## Instale as dependências 
 
 ### **UserApi project**
```
dotnet add package Microsoft.EntityFrameworkCore --version 7.0.2
```
```
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 7.0.2
```
```
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 7.0.2
```
```
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 7.0.0-preview.2.22153.1
```

### **UserTest project**
```
dotnet add package Moq --version 4.18.4
```

### Para criar o banco de dados utilize:
```
dotnet ef database update
```
### Rode o projeto com:
```
cd .\UserApi\
```

``` 
dotnet watch run
```

## Endpoints

### **Criar usuário**
Para criar um usuário, acesse o endpoint abaixo: 
<br>

_POST /user/create_
``` json
{
	"name": "Teste",
	"email": "teste@teste.com",
	"password": "flamengo"
}
```

### **Pegar usuário**
Para pegar os dados de um usuário, basta acessar:
<br>

_GET /user/get/{id}_

### **Atualizar usuário**
Para atualizar os dados de algum usuário, acesse:
<br>

_POST /user/update/{id}_
``` json
{
	"name": "Teste 123",
	"email": "teste@teste.com",
	"password": "flamengo"
}
```
### **Remover usuário**
Para remover um usuário do sistema, acesse:
<br>

_DELETE /user/delete/{id}_

## Testes
### Rode os testes com: 
```
cd .\UserTest\
```
```
dotnet test
```
