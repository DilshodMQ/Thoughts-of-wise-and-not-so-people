#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Systems/Api/DsrProject.Api/DsrProject.Api.csproj", "Systems/Api/DsrProject.Api/"]
COPY ["Data/Migrations/DsrProject.Context.MigrationsPostgreSQL/DsrProject.Context.MigrationsPostgreSQL.csproj", "Data/Migrations/DsrProject.Context.MigrationsPostgreSQL/"]
COPY ["Data/DsrProject.Context.Entities/DsrProject.Context.Entities.csproj", "Data/DsrProject.Context.Entities/"]
COPY ["Data/DsrProject.Context/DsrProject.Context.csproj", "Data/DsrProject.Context/"]
COPY ["Shared/DsrProject.Settings/DsrProject.Settings.csproj", "Shared/DsrProject.Settings/"]
COPY ["Services/DsrProject.Services.Actions/DsrProject.Services.Actions.csproj", "Services/DsrProject.Services.Actions/"]
COPY ["Shared/DsrProject.Consts/DsrProject.Consts.csproj", "Shared/DsrProject.Consts/"]
COPY ["Services/DsrProject.Services.EmailSender/DsrProject.Services.EmailSender.csproj", "Services/DsrProject.Services.EmailSender/"]
COPY ["Shared/DsrProject.Common/DsrProject.Common.csproj", "Shared/DsrProject.Common/"]
COPY ["Services/DsrProject.Services.Settings/DsrProject.Services.Settings.csproj", "Services/DsrProject.Services.Settings/"]
COPY ["Services/DsrProject.Services.RabbitMq/DsrProject.Services.RabbitMq.csproj", "Services/DsrProject.Services.RabbitMq/"]
COPY ["Services/DsrProject.Services.Cache/DsrProject.Services.Cache.csproj", "Services/DsrProject.Services.Cache/"]
COPY ["Services/DsrProject.Services.Categories/DsrProject.Services.Categories.csproj", "Services/DsrProject.Services.Categories/"]
COPY ["Services/DsrProject.Services.Respondents/DsrProject.Services.Respondents.csproj", "Services/DsrProject.Services.Respondents/"]
COPY ["Services/DsrProject.Services.Thoughts/DsrProject.Services.Thoughts.csproj", "Services/DsrProject.Services.Thoughts/"]
COPY ["Services/DsrProject.Services.UserAccount/DsrProject.Services.UserAccount.csproj", "Services/DsrProject.Services.UserAccount/"]
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