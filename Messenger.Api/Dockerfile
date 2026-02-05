FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /source

COPY ["Messenger.Api.csproj", "Messenger.Api/"]
WORKDIR /source/Messenger.Api
RUN dotnet restore "Messenger.Api.csproj"

COPY . .
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:10.0

RUN apt-get update && apt-get install -y \
    libkrb5-3 \
    libgssapi-krb5-2 \
    && rm -rf /var/lib/apt/lists/*

WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "Messenger.Api.dll"]
