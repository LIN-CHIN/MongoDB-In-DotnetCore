#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["MongoDB-In-DotnetCoreAPI/MongoDB-In-DotnetCoreAPI.csproj", "MongoDB-In-DotnetCoreAPI/"]
COPY ["Service/Service.csproj", "Service/"]
COPY ["Model/Model.csproj", "Model/"]
COPY ["Common/Common.csproj", "Common/"]
COPY ["DAO/DAO.csproj", "DAO/"]
RUN dotnet restore "MongoDB-In-DotnetCoreAPI/MongoDB-In-DotnetCoreAPI.csproj"
COPY . .
WORKDIR "/src/MongoDB-In-DotnetCoreAPI"
RUN dotnet build "MongoDB-In-DotnetCoreAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MongoDB-In-DotnetCoreAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MongoDB-In-DotnetCoreAPI.dll"]