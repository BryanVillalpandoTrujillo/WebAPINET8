#Para funcionar necesita tener la compatibilidad con ddocker y visual studio.
#En caso no contar con ella:
#Ir a herramientas -> Adminstrador de paquetes NuGuet-> Consola de paquetes -> Ejecute el siguiente comando.
# NuGet\Install-Package Microsoft.VisualStudio.Azure.Containers.Tools.Targets -Version 1.20.1
# Establece la imagen base para la etapa de base
# Etapa base
# Etapa base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8081/tcp
EXPOSE 8082/tcp

# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia el archivo de proyecto y restaura las dependencias
COPY WebAPINET8.csproj .
RUN dotnet restore "WebAPINET8.csproj"

# Copia el resto del código y construye la aplicación
COPY . .
RUN dotnet build "WebAPINET8.csproj" -c Release -o /app/build

# Etapa de publicación
FROM build AS publish
RUN dotnet publish "WebAPINET8.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Etapa final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Define el punto de entrada para la aplicación
ENTRYPOINT ["dotnet", "WebAPINET8.dll"]


