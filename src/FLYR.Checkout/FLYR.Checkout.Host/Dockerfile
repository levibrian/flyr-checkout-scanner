FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["FLYR.Checkout.Host/FLYR.Checkout.Host.csproj", "FLYR.Checkout.Host/"]
RUN dotnet restore "FLYR.Checkout.Host/FLYR.Checkout.Host.csproj"
COPY . .
WORKDIR "/src/FLYR.Checkout.Host"
RUN dotnet build "FLYR.Checkout.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FLYR.Checkout.Host.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FLYR.Checkout.Host.dll"]
