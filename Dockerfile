FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /App
COPY . ./
RUN dotnet restore BadgerClan.gRPC/BadgerClan.gRPC.csproj
RUN dotnet publish BadgerClan.gRPC/BadgerClan.gRPC.csproj -c Release -o publish
 
RUN dotnet restore BadgerClan.gRPC/BadgerClan.gRPC.csproj
RUN dotnet publish BadgerClan.gRPC/BadgerClan.gRPC.csproj -c Release -o publish

# Build the image
FROM mcr.microsoft.com/dotnet/aspnet:9.0
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /App
COPY --from=build /App/publish .
ENTRYPOINT ["dotnet", "BadgerClan.gRPC.dll"]