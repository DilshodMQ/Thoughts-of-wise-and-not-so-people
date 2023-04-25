#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Systems/Workers/DsrProject.Worker/DsrProject.Worker.csproj", "Systems/Workers/DsrProject.Worker/"]
COPY ["Data/DsrProject.Context/DsrProject.Context.csproj", "Data/DsrProject.Context/"]
COPY ["Shared/DsrProject.Settings/DsrProject.Settings.csproj", "Shared/DsrProject.Settings/"]
COPY ["Data/DsrProject.Context.Entities/DsrProject.Context.Entities.csproj", "Data/DsrProject.Context.Entities/"]
COPY ["Services/DsrProject.Services.Actions/DsrProject.Services.Actions.csproj", "Services/DsrProject.Services.Actions/"]
COPY ["Shared/DsrProject.Consts/DsrProject.Consts.csproj", "Shared/DsrProject.Consts/"]
COPY ["Services/DsrProject.Services.EmailSender/DsrProject.Services.EmailSender.csproj", "Services/DsrProject.Services.EmailSender/"]
COPY ["Shared/DsrProject.Common/DsrProject.Common.csproj", "Shared/DsrProject.Common/"]
COPY ["Services/DsrProject.Services.Settings/DsrProject.Services.Settings.csproj", "Services/DsrProject.Services.Settings/"]
COPY ["Services/DsrProject.Services.RabbitMq/DsrProject.Services.RabbitMq.csproj", "Services/DsrProject.Services.RabbitMq/"]
RUN dotnet restore "Systems/Workers/DsrProject.Worker/DsrProject.Worker.csproj"
COPY . .
WORKDIR "/src/Systems/Workers/DsrProject.Worker"
RUN dotnet build "DsrProject.Worker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DsrProject.Worker.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DsrProject.Worker.dll"]