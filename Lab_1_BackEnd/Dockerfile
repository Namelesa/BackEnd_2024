FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Lab_1_BackEnd/Lab_1_BackEnd.csproj", "Lab_1_BackEnd/"]
RUN dotnet restore "Lab_1_BackEnd/Lab_1_BackEnd.csproj"
COPY . .
WORKDIR "/src/Lab_1_BackEnd"
RUN dotnet build "Lab_1_BackEnd.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Lab_1_BackEnd.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Lab_1_BackEnd.dll"]
