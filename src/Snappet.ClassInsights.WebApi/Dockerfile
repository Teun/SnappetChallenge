FROM microsoft/dotnet:2.2-aspnetcore-runtime-nanoserver-sac2016 AS base
WORKDIR /app
EXPOSE 50746
EXPOSE 44352

FROM microsoft/dotnet:2.2-sdk-nanoserver-sac2016 AS build
WORKDIR /src
COPY Snappet.ClassInsights.WebApi/Snappet.ClassInsights.WebApi.csproj Snappet.ClassInsights.WebApi/
RUN dotnet restore Snappet.ClassInsights.WebApi/Snappet.ClassInsights.WebApi.csproj
COPY . .
WORKDIR /src/Snappet.ClassInsights.WebApi
RUN dotnet build Snappet.ClassInsights.WebApi.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Snappet.ClassInsights.WebApi.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Snappet.ClassInsights.WebApi.dll"]
