#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["FS.Todo.Api/FS.Todo.Api.csproj", "FS.Todo.Api/"]
COPY ["FS.Todo.Core/FS.Todo.Core.csproj", "FS.Todo.Core/"]
COPY ["FS.Todo.Data/FS.Todo.Data.csproj", "FS.Todo.Data/"]
RUN dotnet restore "FS.Todo.Api/FS.Todo.Api.csproj"
COPY . .
WORKDIR "/src/FS.Todo.Api"
RUN dotnet build "FS.Todo.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FS.Todo.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FS.Todo.Api.dll"]