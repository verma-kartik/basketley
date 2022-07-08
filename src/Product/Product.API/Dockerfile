#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Product/Product.API/Product.API.csproj", "Product/Product.API/"]
COPY ["Product/LoggerService/LoggerService.csproj", "Product/LoggerService/"]
COPY ["Product/Contracts/Contracts.csproj", "Product/Contracts/"]
COPY ["Product/Repository/Repository.csproj", "Product/Repository/"]
COPY ["Product/Shared/Shared.csproj", "Product/Shared/"]
COPY ["Product/Entities/Entities.csproj", "Product/Entities/"]
COPY ["Product/Services/Services.csproj", "Product/Services/"]
COPY ["Product/Services.Contracts/Services.Contracts.csproj", "Product/Services.Contracts/"]
COPY ["Product/Presentation/Presentation.csproj", "Product/Presentation/"]
RUN dotnet restore "Product/Product.API/Product.API.csproj"
COPY . .
WORKDIR "/src/Product/Product.API"
RUN dotnet build "Product.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Product.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Product.API.dll"]