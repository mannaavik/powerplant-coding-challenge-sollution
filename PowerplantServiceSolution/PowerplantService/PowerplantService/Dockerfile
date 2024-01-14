#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 8888

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["PowerplantService/PowerplantService.csproj", "PowerplantService/"]
RUN dotnet restore "PowerplantService/PowerplantService.csproj"
COPY . .
WORKDIR "/src/PowerplantService"
RUN dotnet build "PowerplantService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PowerplantService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PowerplantService.dll"]
