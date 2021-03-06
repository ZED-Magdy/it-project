#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build

RUN curl --silent --location https://deb.nodesource.com/setup_14.x | bash -
RUN apt-get install --yes nodejs

WORKDIR /src
COPY ["ITProject.csproj", "./"]
RUN dotnet restore "ITProject.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "ITProject.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ITProject.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ITProject.dll"]
