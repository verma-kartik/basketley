#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Customer/Customer.API/Customer.API.csproj", "Customer/Customer.API/"]
COPY ["Customer/LoggerService/LoggerService.csproj", "Customer/LoggerService/"]
COPY ["Customer/Contracts/Contracts.csproj", "Customer/Contracts/"]
COPY ["Customer/Entities/Entities.csproj", "Customer/Entities/"]
COPY ["Customer/Repository/Repository.csproj", "Customer/Repository/"]
COPY ["Customer/Services/Services.csproj", "Customer/Services/"]
COPY ["Customer/Services.Contracts/Services.Contracts.csproj", "Customer/Services.Contracts/"]
COPY ["Customer/Presentation/Presentation.csproj", "Customer/Presentation/"]
RUN dotnet restore "Customer/Customer.API/Customer.API.csproj"
COPY . .
WORKDIR "/src/Customer/Customer.API"
RUN dotnet build "Customer.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Customer.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Customer.API.dll"]