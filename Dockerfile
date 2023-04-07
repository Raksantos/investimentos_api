#Build stage
FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build
WORKDIR /src
COPY . .
RUN dotnet restore "./InvestimentosApi/InvestimentosApi.csproj" --disable-parallel
RUN dotnet publish "./InvestimentosApi/InvestimentosApi.csproj" -c Release -o /app --no-restore

EXPOSE 3001

#Serve stage
FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine AS app
WORKDIR /app
COPY --from=build /app ./

EXPOSE 5000
EXPOSE 5001

ENTRYPOINT ["dotnet", "InvestimentosApi.dll"]