# Build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build 
WORKDIR /src

# Copy
COPY . .
WORKDIR /src/WebApi

# Restore Dependencies
RUN dotnet restore CleanArch.WebApi.csproj

# Compiles and publish
RUN dotnet publish CleanArch.WebApi.csproj -c Release -o /out

# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /out .

ENTRYPOINT ["dotnet", "CleanArch.WebApi.dll"]