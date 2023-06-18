# Establece la imagen base
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copia los archivos del proyecto y restaura las dependencias
COPY Backend.API/*.csproj ./Backend.API/
COPY Backend.Core/*.csproj ./Backend.Core/
COPY Backend.Infrastructure/*.csproj ./Backend.Infrastructure/
COPY Backend.sln ./
RUN dotnet restore

# Copia el resto de los archivos y construye la aplicación
COPY . ./
RUN dotnet publish Backend.API/Backend.API.csproj -c Release -o out

# Establece la imagen base para la aplicación en tiempo de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .

# Expone el puerto en el que la aplicación escucha
EXPOSE 80

# Establece el comando de inicio de la aplicación
ENTRYPOINT ["dotnet", "Backend.API.dll"]
