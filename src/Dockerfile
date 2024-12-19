# Use the ASP.NET Core runtime as base image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Copy already published application from src/publish
COPY publish .

# Final stage: Create runtime image
FROM base AS final
WORKDIR /app
ENTRYPOINT ["dotnet", "Catalog.API.dll"]
