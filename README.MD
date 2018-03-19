# Processo Seletivo - .Net/C# - S2it

## Autor: Raphael Pinto da Silva Panta Leão

### Tecnologias utilizadas

#### Back-end: 
- .NET Core 2.0
- SQL Server 2017
- MVC 6
- C#
- EF Core 2.0

##### Testes
- XUnit 
- FluentAssertions

#### Front-end:
- Javascript
- JQuery
- BootStrap

#### Ambiente
- Ubuntu 17.04
- Visual Studio Code

### Como subir a aplicação

```bash 
dotnet run --project apresentacao/GerenciadorDeEmprestimoDeJogos.Mvc
```

### Como executar os testes

```bash
dotnet test
```

// TODO corrigir debitos técnicos

### EF Core migrations

```bash
cd infrastrutura/GerenciadorDeEmprestimoDeJogos.EntityFramework
dotnet ef migration update --startup-project ../../apresentacao/GerenciadorDeEmprestimoDeJogos.Mvc

```