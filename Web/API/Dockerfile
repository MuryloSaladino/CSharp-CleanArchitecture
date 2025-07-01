FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["Web/API/", "Web/API/"]
COPY ["Infrastructure/", "Infrastructure/"]
COPY ["Application/", "Application/"]
COPY ["Domain/", "Domain/"]

WORKDIR "/src/Web/API"

RUN dotnet restore "Web.API.csproj"
RUN dotnet build "Web.API.csproj" -c Debug -o /app/build


FROM build AS publish

RUN dotnet publish "Web.API.csproj" -c Debug -o /app/publish


FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Web.API.dll"]