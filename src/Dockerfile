FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["src/owasp-api.csproj", "owasp-api-src/"]
RUN dotnet restore "owasp-api-src/owasp-topten-api.csproj"
COPY . .
WORKDIR "/src/owasp-api-src"
RUN dotnet build "owasp-topten-api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "owasp-topten-api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "owasp-api.dll"]
