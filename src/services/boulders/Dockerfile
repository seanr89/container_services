FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ./boulder.api/boulder.api.csproj boulder.api/
RUN dotnet restore boulder.api/boulder.api.csproj

# Copy everything else and build
COPY . .
RUN dotnet publish boulder.api/boulder.api.csproj -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "boulder.api.dll"]