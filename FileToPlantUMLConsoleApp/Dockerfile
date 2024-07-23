FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["FileToPlantUMLConsoleApp/FileToPlantUMLConsoleApp.csproj", "FileToPlantUMLConsoleApp/"]
RUN dotnet restore "FileToPlantUMLConsoleApp/FileToPlantUMLConsoleApp.csproj"
COPY . .
WORKDIR "/src/FileToPlantUMLConsoleApp"
RUN dotnet build "FileToPlantUMLConsoleApp.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "FileToPlantUMLConsoleApp.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FileToPlantUMLConsoleApp.dll"]
