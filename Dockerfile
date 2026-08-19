FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY . .

RUN dotnet restore "RecordShop.Web/RecordShop.Web/RecordShop.Web.csproj"

RUN dotnet publish "RecordShop.Web/RecordShop.Web/RecordShop.Web.csproj" \
    -c Release \
    -o /app/publish \
    /p:UseAppHost=false

FROM base AS final
WORKDIR /app

COPY --from=build /app/publish .

CMD ["sh", "-c", "dotnet RecordShop.Web.dll --urls http://0.0.0.0:${PORT:-8080}"]
