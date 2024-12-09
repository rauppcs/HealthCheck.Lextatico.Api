FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8000
EXPOSE 8001

ENV ASPNETCORE_URLS=http://+:8000;https://+:8001

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
# RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
# USER appuser

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/Health.Lextatico.Api/Health.Lextatico.Api.csproj", "src/Health.Lextatico.Api/"]
RUN dotnet restore "src/Health.Lextatico.Api/Health.Lextatico.Api.csproj"
COPY . .
WORKDIR "/src/src/Health.Lextatico.Api"
RUN dotnet build "Health.Lextatico.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Health.Lextatico.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Health.Lextatico.Api.dll"]
