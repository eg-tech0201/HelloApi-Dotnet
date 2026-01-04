FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY helloapi-dotnet.sln ./
COPY HelloApi/HelloApi.csproj HelloApi/
COPY HelloApi.Tests/HelloApi.Tests.csproj HelloApi.Tests/


RUN dotnet restore HelloApi/HelloApi.csproj

COPY . ./
RUN dotnet publish HelloApi/HelloApi.csproj -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

COPY --from=build /app/publish ./
ENTRYPOINT [ "dotnet", "HelloApi.dll" ]