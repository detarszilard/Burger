#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Services/Restaurants/Burger.Services.Restaurants.Web/Burger.Services.Restaurants.Web.csproj", "src/Services/Restaurants/Burger.Services.Restaurants.Web/"]
COPY ["src/Services/Restaurants/Burger.Services.Restaurants.Infrastructure/Burger.Services.Restaurants.Infrastructure.csproj", "src/Services/Restaurants/Burger.Services.Restaurants.Infrastructure/"]
COPY ["src/Services/Restaurants/Burger.Services.Restaurants.Domain/Burger.Services.Restaurants.Domain.csproj", "src/Services/Restaurants/Burger.Services.Restaurants.Domain/"]
COPY ["src/Common/Burger.Common/Burger.Common.csproj", "src/Common/Burger.Common/"]
COPY ["src/Common/Burger.Common.EntityFrameworkCore/Burger.Common.EntityFrameworkCore.csproj", "src/Common/Burger.Common.EntityFrameworkCore/"]
COPY ["src/Services/Restaurants/Burger.Services.Restaurants.Application/Burger.Services.Restaurants.Application.csproj", "src/Services/Restaurants/Burger.Services.Restaurants.Application/"]
COPY ["src/Common/Burger.Common.Web/Burger.Common.Web.csproj", "src/Common/Burger.Common.Web/"]
RUN dotnet restore "src/Services/Restaurants/Burger.Services.Restaurants.Web/Burger.Services.Restaurants.Web.csproj"
COPY . .
WORKDIR "/src/src/Services/Restaurants/Burger.Services.Restaurants.Web"
RUN dotnet build "Burger.Services.Restaurants.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Burger.Services.Restaurants.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Burger.Services.Restaurants.Web.dll"]