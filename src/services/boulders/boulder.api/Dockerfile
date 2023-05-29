FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

# Step 2: Copy project file to the ./ container folder
COPY *.csproj ./
# Step 3: Run a restore to download dependencies
RUN dotnet restore

# Step 4: Copy app code to the container
COPY . .
# Step 5: Build the app in Release mode
# Step 6: Publish the application
RUN dotnet publish -c Release -r linux-musl-x64 --self-contained true /p:PublishTrimmed=true -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "boulder.api.dll"]