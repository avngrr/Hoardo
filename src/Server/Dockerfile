#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Server/Server.csproj", "src/Server/"]
COPY ["Domain/Domain.csproj", "src/Domain/"]
COPY ["Application/Application.csproj", "src/Application/"]
COPY ["Shared/Shared.csproj", "Shared/"]
COPY ["Client/Client.csproj", "src/Client/"]
RUN dotnet restore "src/Server/Server.csproj"
COPY . .
WORKDIR "Server"
RUN dotnet build "Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Server.dll"]