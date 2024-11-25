# Consulte https://aka.ms/customizecontainer para aprender a personalizar su contenedor de depuración y cómo Visual Studio usa este Dockerfile para compilar sus imágenes para una depuración más rápida.

# Esta fase se usa cuando se ejecuta desde VS en modo rápido (valor predeterminado para la configuración de depuración)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Esta fase se usa para compilar el proyecto de servicio
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/TechNovaLab.Irrigo.Api/TechNovaLab.Irrigo.Api.csproj", "src/TechNovaLab.Irrigo.Api/"]
COPY ["src/TechNovaLab.Irrigo.Infrastructure/TechNovaLab.Irrigo.Infrastructure.csproj", "src/TechNovaLab.Irrigo.Infrastructure/"]
COPY ["src/TechNovaLab.Irrigo.Application/TechNovaLab.Irrigo.Application.csproj", "src/TechNovaLab.Irrigo.Application/"]
COPY ["src/TechNovaLab.Irrigo.Domain/TechNovaLab.Irrigo.Domain.csproj", "src/TechNovaLab.Irrigo.Domain/"]
COPY ["src/TechNovaLab.Irrigo.SharedKernel/TechNovaLab.Irrigo.SharedKernel.csproj", "src/TechNovaLab.Irrigo.SharedKernel/"]
RUN dotnet restore "./src/TechNovaLab.Irrigo.Api/TechNovaLab.Irrigo.Api.csproj"
COPY . .
WORKDIR "/src/src/TechNovaLab.Irrigo.Api"
RUN dotnet build "./TechNovaLab.Irrigo.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Esta fase se usa para publicar el proyecto de servicio que se copiará en la fase final.
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TechNovaLab.Irrigo.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Esta fase se usa en producción o cuando se ejecuta desde VS en modo normal (valor predeterminado cuando no se usa la configuración de depuración)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TechNovaLab.Irrigo.Api.dll"]