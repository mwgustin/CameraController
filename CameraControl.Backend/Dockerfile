FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CameraControl.Backend/CameraControl.Backend.csproj", "CameraControl.Backend/"]
RUN dotnet restore "CameraControl.Backend/CameraControl.Backend.csproj"
COPY . .
WORKDIR "/src/CameraControl.Backend"
RUN dotnet build "CameraControl.Backend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CameraControl.Backend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CameraControl.Backend.dll"]
