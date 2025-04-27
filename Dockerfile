# Stage 1: Build the Blazor App
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app
COPY StorageDemo/*.csproj ./
RUN dotnet restore
COPY StorageDemo/. ./
RUN dotnet publish -c Release -o out

# Stage 2: Combine and Serve
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

# Copy the Blazor build output
COPY --from=build /app/out ./

# Copy the SQLite database file
COPY StorageDemo/Components/Data/database.sqlite ./Components/Data/

# Expose ports for HTTP and HTTPS
EXPOSE 80
EXPOSE 443

# Run the Blazor Server app
ENTRYPOINT ["dotnet", "StorageDemo.dll"]