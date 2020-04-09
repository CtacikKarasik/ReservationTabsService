FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Reservation1/Reservation1.csproj", "Reservation1/"]
RUN dotnet restore "Reservation1/Reservation1.csproj"
COPY . .
WORKDIR "/src/Reservation1"
RUN dotnet build "Reservation1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Reservation1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Reservation1.dll"]