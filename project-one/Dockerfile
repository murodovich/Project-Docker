#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["project-one/project-one.csproj", "project-one/"]
COPY ["project-four-Application/project-four-Application.csproj", "project-four-Application/"]
COPY ["project-four-Domain/project-four-Domain.csproj", "project-four-Domain/"]
COPY ["project-four-Infrastructure/project-four-Infrastructure.csproj", "project-four-Infrastructure/"]
COPY ["Project-one-Application/Project-one-Application.csproj", "Project-one-Application/"]
COPY ["Project-one-Domain/Project-one-Domain.csproj", "Project-one-Domain/"]
COPY ["Project-one-Infrastructure/Project-one-Infrastructure.csproj", "Project-one-Infrastructure/"]
RUN dotnet restore "./project-one/./project-one.csproj"
COPY . .
WORKDIR "/src/project-one"
RUN dotnet build "./project-one.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./project-one.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "project-one.dll"]