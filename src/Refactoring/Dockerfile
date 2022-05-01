FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /workspace
COPY ./src/Server .
RUN dotnet restore Server.csproj
RUN dotnet publish Server.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS execRuntime
ENV ASPNETCORE_URLS=""
EXPOSE 80
EXPOSE 808
WORKDIR /workspace
COPY --from=build  /workspace/out .
ENTRYPOINT ["dotnet", "Server.dll"]