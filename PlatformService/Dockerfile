# Use the SDK image for the build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app 

# Copy the csproj file and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the application and publish it
COPY . ./
RUN dotnet publish -c Release -o out /app/PlatformService.csproj

# Use the ASP.NET Core runtime image for the runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .

# Set the entry point for the application
ENTRYPOINT ["dotnet", "PlatformService.dll"]





# FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS build-env
# WORKDIR /app 

# COPY *.csproj ./
# RUN dotnet restore

# COPY . ./
# RUN donet publish -c Release -o out

# FROM mcr.microsoft.com/dotnet/aspnet:8.0
# WORKDIR /app
# COPY --from=build-env /app/out .
# ENTRYPOINT ["dotnet", "PlatformService.dll"]