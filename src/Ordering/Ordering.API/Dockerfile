FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Ordering/Ordering.API/Ordering.API.csproj", "Ordering.API/"]
COPY ["Ordering/Repository/Repository.csproj", "Repository/"]
COPY ["Ordering/Contracts/Contracts.csproj", "Contracts/"]
COPY ["Ordering/Entities/Entities.csproj", "Entities/"]
RUN dotnet restore "Ordering/Ordering.API/Ordering.API.csproj"
COPY . .
WORKDIR "/src/Ordering.API"
RUN dotnet build "Ordering.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ordering.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ordering.API.dll"]
