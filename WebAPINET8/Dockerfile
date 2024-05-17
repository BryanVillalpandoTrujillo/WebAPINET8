#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Para funcionar necesita tener la compatibilidad con ddocker y visual studio.
#En caso no contar con ella:
#Ir a herramientas -> Adminstrador de paquetes NuGuet-> Consola de paquetes -> Ejecute el siguiente comando.
# NuGet\Install-Package Microsoft.VisualStudio.Azure.Containers.Tools.Targets -Version 1.20.1
# Establece la imagen base para la etapa de base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

# Establece el usuario y el directorio de trabajo en la aplicación
USER app
WORKDIR /app

# Expone los puertos en los que la aplicación escucha
EXPOSE 8081/tcp
EXPOSE 8082/tcp

# Establece la imagen base para la etapa de compilación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Argumento para la configuración de compilación (predeterminado: Release)
ARG BUILD_CONFIGURATION=Release

# Establece el directorio de trabajo en la fuente
WORKDIR /src

# Copia el proyecto csproj y restaura las dependencias
COPY ["WebAPINET8.csproj", "WebAPINET8/"]
RUN dotnet restore "./WebAPINET8/WebAPINET8.csproj"

# Copia el resto del código y construye la aplicación
COPY . .
WORKDIR "/src/WebAPINET8"
RUN dotnet build "WebAPINET8.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Establece la imagen base para la etapa de publicación
FROM build AS publish

# Copia y publica la aplicación
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "WebAPINET8.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Establece la imagen final
FROM base AS final

# Establece el directorio de trabajo en la aplicación
WORKDIR /app

# Copia los archivos publicados desde la etapa de publicación
COPY --from=publish /app/publish .

# Define el punto de entrada para la aplicación
ENTRYPOINT ["dotnet", "WebAPINET8.dll"]
