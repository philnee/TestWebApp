FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
# Setup NodeJs
RUN apt-get update && \
    apt-get install -y wget && \
    apt-get install -y gnupg2 && \
    wget -qO- https://deb.nodesource.com/setup_6.x | bash - && \
    apt-get install -y build-essential nodejs
# End setup
WORKDIR /app
EXPOSE 3824
EXPOSE 44305

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY TestWebApp/TestWebApp.csproj TestWebApp/
RUN dotnet restore TestWebApp/TestWebApp.csproj
COPY . .
WORKDIR /src/TestWebApp
RUN dotnet build TestWebApp.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish TestWebApp.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TestWebApp.dll"]
