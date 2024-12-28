# Use the .NET 8 SDK for building the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o /publish

# Copy SQLite Db into container
COPY dabibraincell.db /app/dabibraincell.db

# Use the .NET 8 runtime for running the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /publish .
ENV ASPNETCORE_URLS=http://0.0.0.0:5000
ENV DATABASE_PATH=/app/dabibraincell.db
EXPOSE 5000
ENTRYPOINT ["dotnet", "DabisBraincellFixer.dll"]
