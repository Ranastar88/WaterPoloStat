#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["WaterPoloStat.API/WaterPoloStat.API.csproj", "WaterPoloStat.API/"]
COPY ["WaterPoloStat.Domain/WaterPoloStat.Domain.csproj", "WaterPoloStat.Domain/"]
COPY ["WaterPoloStat.Services/WaterPoloStat.Services.csproj", "WaterPoloStat.Services/"]
RUN dotnet restore "WaterPoloStat.API/WaterPoloStat.API.csproj"
COPY . .
WORKDIR "/src/WaterPoloStat.API"
RUN dotnet build "WaterPoloStat.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WaterPoloStat.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WaterPoloStat.API.dll"]