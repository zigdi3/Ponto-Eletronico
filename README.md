
# PontoEletronico - Projeto Backend

Este o projeto backend para um sistema de ponto eletronio utilizando ASP.NET Core. Ele utiliza várias bibliotecas e pacotes para lidar com autenticação, armazenamento de dados e documentação da API.

## Pacotes utilizados neste projeto:

[Microsoft.AspNetCore.Authentication.JwtBearer](https://docs.microsoft.com/pt-br/dotnet/api/microsoft.aspnetcore.authentication.jwtbearer?view=aspnetcore-6.0) - Middleware para autenticar solicitações HTTP com tokens JWT (JSON Web Tokens).

[Microsoft.AspNetCore.Identity](https://docs.microsoft.com/pt-br/aspnet/core/security/authentication/identity?view=aspnetcore-5.0&tabs=visual-studio) - Serviços de autenticação do usuário.

[Microsoft.AspNetCore.Identity.EntityFrameworkCore](https://docs.microsoft.com/pt-br/ef/core/saved-data/entity-framework-core-identity?tabs=visual-studio) - Integração do ASP.NET Core Identity com Entity Framework Core.

[Microsoft.EntityFrameworkCore](https://docs.microsoft.com/pt-br/ef/core/index?view=aspnetcore-6.0) - Um framework leve e extensível de mapeamento relacional para .NET.

[Microsoft.EntityFrameworkCore.SqlServer](https://docs.microsoft.com/pt-br/ef/core/providers/sql-server/index?view=aspnetcore-6.0) - Classes necessárias para trabalhar com o SQL Server usando Entity Framework Core.

[Microsoft.EntityFrameworkCore.Tools](https://docs.microsoft.com/pt-br/ef/core/miscellaneous/cli/dotnet?view=aspnetcore-6.0) - Ferramentas para trabalhar com modelos do Entity Framework Core, como scaffolding e migrações.

[Swashbuckle.AspNetCore](https://github.com/domaindrivendev/Swashbuckle.AspNetCore) - Um framework que simplifica o processo de criação de documentação Swagger/OpenAPI para APIs ASP.NET Core Web.

[System.IdentityModel.Tokens.Jwt](https://docs.microsoft.com/pt-br/dotnet/api/system.identitymodel.tokens.jwt?view=dotnet-6.0) - Classes para suporte a identidades baseadas em declarações, incluindo JWTs.

## Estrutura do Projeto

A estrutura do projeto está organizada da seguinte forma:

```

- `PontoEletronico.csproj`: O arquivo do projeto contendo todas as configurações e dependências necessárias.
- `Migrations/`: Diretório para migrações do Entity Framework Core.
- `Program.cs`: Ponto de entrada da aplicação, onde o host web é configurado.
- `Startup.cs`: Classe de configuração para definir serviços e middleware.

## Iniciando

### Pré-requisitos

Certifique-se de ter instalados:

- .NET SDK 6.0 ou posterior
- SQL Server (para operações de banco de dados)

### Instalação

1. Clone este repositório:
   ```sh
   git clone https://github.com/your-repo/PontoEletronico.git
   cd PontoEletronico
```

2. Restaure as dependências:

   ```sh
   dotnet restore
   ```
3. Execute o aplicativo:

   ```sh
   dotnet run
   ```

### Configuração

Atualize o arquivo `appsettings.json` com sua string de conexão do banco de dados e outras configurações necessárias.

## Documentação da API

A documentação da API pode ser acessada via Swagger em:

```
http://localhost:5858/swagger
```

## Licença

Este projeto está licenciado sob a [MIT License](LICENSE). SInta-se à vontade ao fazer uso dele.
