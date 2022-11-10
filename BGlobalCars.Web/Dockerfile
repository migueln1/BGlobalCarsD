#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BGlobalCars.Web/BGlobalCars.Web.csproj", "BGlobalCars.Web/"]
COPY ["BGlobalCars.Application/BGlobalCars.Application.csproj", "BGlobalCars.Application/"]
COPY ["BGlobalCars.Core/BGlobalCars.Core.csproj", "BGlobalCars.Core/"]
COPY ["BGlobalCars.Infrastructure/BGlobalCars.Infrastructure.csproj", "BGlobalCars.Infrastructure/"]
RUN dotnet restore "BGlobalCars.Web/BGlobalCars.Web.csproj"
COPY . .
WORKDIR "/src/BGlobalCars.Web"
RUN dotnet build "BGlobalCars.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BGlobalCars.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BGlobalCars.Web.dll"]