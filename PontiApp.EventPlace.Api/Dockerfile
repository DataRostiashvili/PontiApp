#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["PontiApp.EventPlace.Api/PontiApp.EventPlace.Api.csproj", "PontiApp.EventPlace.Api/"]
RUN dotnet restore "PontiApp.EventPlace.Api/PontiApp.EventPlace.Api.csproj"
COPY . .
WORKDIR "/src/PontiApp.EventPlace.Api"
RUN dotnet build "PontiApp.EventPlace.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PontiApp.EventPlace.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PontiApp.EventPlace.Api.dll"]