FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Snappet/Snappet.csproj", "Snappet/"]
RUN dotnet restore "Snappet/Snappet.csproj"
COPY . .
WORKDIR "/src/Snappet"
RUN dotnet build "Snappet.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Snappet.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Snappet.dll"]
