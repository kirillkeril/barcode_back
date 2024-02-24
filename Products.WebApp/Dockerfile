FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Products.WebApp/Products.WebApp.csproj", "Products.WebApp/"]
RUN dotnet restore "Products.WebApp/Products.WebApp.csproj"
COPY . .
WORKDIR "/src/Products.WebApp"
RUN dotnet build "Products.WebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Products.WebApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Products.WebApp.dll"]
