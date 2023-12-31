#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER app
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["CVGenerator_CSharp/CVGenerator_CSharp.csproj", "CVGenerator_CSharp/"]
RUN dotnet restore "./CVGenerator_CSharp/./CVGenerator_CSharp.csproj"
COPY . .
WORKDIR "/src/CVGenerator_CSharp"
RUN dotnet build "./CVGenerator_CSharp.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CVGenerator_CSharp.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CVGenerator_CSharp.dll"]