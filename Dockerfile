FROM microsoft/aspnetcore-build:2.0.6-2.1.101 AS build-env
WORKDIR /app

COPY *.sln ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM microsoft/aspnetcore:2.0.6
WORKDIR /app
COPY  --from=build-env /app .
ENTRYPOINT [ "dotnet", "apresentacao/GerenciadorDeEmprestimoDeJogos.Mvc/out/GerenciadorDeEmprestimoDeJogos.Mvc.dll" ]