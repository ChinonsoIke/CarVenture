#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["CarVenture/CarVenture.csproj", "CarVenture/"]
COPY ["CarVenture.Utilities/CarVenture.Utilities.csproj", "CarVenture.Utilities/"]
COPY ["CarVenture.Dtos/CarVenture.Dtos.csproj", "CarVenture.Dtos/"]
COPY ["CarVenture.Models/CarVenture.Models.csproj", "CarVenture.Models/"]
COPY ["CarVenture.Data/CarVenture.Data.csproj", "CarVenture.Data/"]
COPY ["CarVenture.Helpers/CarVenture.Helpers.csproj", "CarVenture.Helpers/"]
COPY ["CarVenture.Core/CarVenture.Core.csproj", "CarVenture.Core/"]
RUN dotnet restore "CarVenture/CarVenture.csproj"
COPY . .
WORKDIR "/src/CarVenture"
RUN dotnet build "CarVenture.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CarVenture.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CarVenture.dll"]