#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Ideam.Sirlab.WebApi.Solicitud/Ideam.Sirlab.WebApi.Solicitud.csproj", "Ideam.Sirlab.WebApi.Solicitud/"]
RUN dotnet restore "Ideam.Sirlab.WebApi.Solicitud/Ideam.Sirlab.WebApi.Solicitud.csproj"
COPY . .
WORKDIR "/src/Ideam.Sirlab.WebApi.Solicitud"
RUN dotnet build "Ideam.Sirlab.WebApi.Solicitud.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ideam.Sirlab.WebApi.Solicitud.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ideam.Sirlab.WebApi.Solicitud.dll"]