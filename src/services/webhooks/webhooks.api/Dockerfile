FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ./webhooks.api.csproj webhooks.api/
RUN dotnet restore webhooks.api/webhooks.api.csproj

# Copy everything else and build
COPY . .
RUN dotnet publish webhooks.api/webhooks.api.csproj -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "webhooks.api.dll"]