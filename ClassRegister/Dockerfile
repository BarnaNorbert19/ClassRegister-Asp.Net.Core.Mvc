#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ClassRegister/ClassRegister.csproj", "ClassRegister/"]
RUN dotnet restore "ClassRegister/ClassRegister.csproj"
COPY . .
WORKDIR "/src/ClassRegister"
RUN dotnet build "ClassRegister.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ClassRegister.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ClassRegister.dll"]