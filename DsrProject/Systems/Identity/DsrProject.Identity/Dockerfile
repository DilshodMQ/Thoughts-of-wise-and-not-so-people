#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Systems/Identity/DsrProject.Identity/DsrProject.Identity.csproj", "Systems/Identity/DsrProject.Identity/"]
COPY ["Data/DsrProject.Context.Entities/DsrProject.Context.Entities.csproj", "Data/DsrProject.Context.Entities/"]
COPY ["Data/DsrProject.Context/DsrProject.Context.csproj", "Data/DsrProject.Context/"]
COPY ["Shared/DsrProject.Settings/DsrProject.Settings.csproj", "Shared/DsrProject.Settings/"]
COPY ["Shared/DsrProject.Common/DsrProject.Common.csproj", "Shared/DsrProject.Common/"]
RUN dotnet restore "Systems/Identity/DsrProject.Identity/DsrProject.Identity.csproj"
COPY . .
WORKDIR "/src/Systems/Identity/DsrProject.Identity"
RUN dotnet build "DsrProject.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DsrProject.Identity.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DsrProject.Identity.dll"]