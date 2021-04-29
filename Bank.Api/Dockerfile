#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 4002
#EXPOSE 5002

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Bank.Api/Bank.Api.csproj", "Bank.Api/"]
COPY ["Bank.Infrastructure.Bootstrap/Bank.Infrastructure.Bootstrap.csproj", "Bank.Infrastructure.Bootstrap/"]
COPY ["Bank.Application/Bank.Application.csproj", "Bank.Application/"]
COPY ["Bank.Domain/Bank.Domain.csproj", "Bank.Domain/"]
COPY ["Bank.Infrastructure/Bank.Infrastructure.csproj", "Bank.Infrastructure/"]
RUN dotnet restore "Bank.Api/Bank.Api.csproj"
COPY . .
WORKDIR "/src/Bank.Api"
RUN dotnet build "Bank.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Bank.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bank.Api.dll"]
