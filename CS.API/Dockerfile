FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["CS.API/CS.API.csproj", "CS.API/"]
RUN dotnet restore "CS.API/CS.API.csproj"
COPY . .
WORKDIR "/src/CS.API"
RUN dotnet build "CS.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CS.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CS.API.dll"]