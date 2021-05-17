#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["FinalProject-WebAPI/FinalProject-WebAPI.csproj", "FinalProject-WebAPI/"]
RUN dotnet restore "FinalProject-WebAPI/FinalProject-WebAPI.csproj"
COPY . .
WORKDIR "/src/FinalProject-WebAPI"
RUN dotnet build "FinalProject-WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FinalProject-WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FinalProject-WebAPI.dll"]