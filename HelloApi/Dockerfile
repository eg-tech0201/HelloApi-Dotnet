FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore HelloApi/HelloApi.csproj
RUN dotnet publish HelloApi/HelloApi.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/sdk:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://0.0.0.0:8080
EXPOSE 8080
ENTRYPOINT [ "dotnet", "HelloApi.dll" ]