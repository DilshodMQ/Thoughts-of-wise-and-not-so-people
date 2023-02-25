#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Systems/Api/DsrProject.Api/DsrProject.Api.csproj", "Systems/Api/DsrProject.Api/"]
COPY ["Services/DsrProject.Services.Settings/DsrProject.Services.Settings.csproj", "Services/DsrProject.Services.Settings/"]
COPY ["Shared/DsrProject.Settings/DsrProject.Settings.csproj", "Shared/DsrProject.Settings/"]
COPY ["Shared/DsrProject.Common/DsrProject.Common.csproj", "Shared/DsrProject.Common/"]
COPY ["Systems/Api/DsrProject.Api.Settings/DsrProject.Api.Settings.csproj", "Systems/Api/DsrProject.Api.Settings/"]
RUN dotnet restore "Systems/Api/DsrProject.Api/DsrProject.Api.csproj"
COPY . .
WORKDIR "/src/Systems/Api/DsrProject.Api"
RUN dotnet build "DsrProject.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DsrProject.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DsrProject.Api.dll"]