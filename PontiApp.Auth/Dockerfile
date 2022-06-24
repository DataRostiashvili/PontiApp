#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["PontiApp.Auth/PontiApp.Auth.csproj", "PontiApp.Auth/"]
COPY ["PontiApp.AuthService/PontiApp.AuthService.csproj", "PontiApp.AuthService/"]
COPY ["PontiApp.Models/PontiApp.Models.csproj", "PontiApp.Models/"]
COPY ["PontiApp.Utilities/PontiApp.Utilities.csproj", "PontiApp.Utilities/"]
COPY ["PontiApp.GraphAPICalls/PontiApp.GraphAPICalls.csproj", "PontiApp.GraphAPICalls/"]
RUN dotnet restore "PontiApp.Auth/PontiApp.Auth.csproj"
COPY . .
WORKDIR "/src/PontiApp.Auth"
RUN dotnet build "PontiApp.Auth.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PontiApp.Auth.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PontiApp.Auth.dll"]