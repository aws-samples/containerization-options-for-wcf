FROM mcr.microsoft.com/dotnet/framework/sdk:4.8 AS build
WORKDIR /workspace
COPY ./src/Server .
RUN msbuild /p:Configuration=Release

FROM mcr.microsoft.com/dotnet/framework/runtime:4.8-windowsservercore-ltsc2019 AS runtime
EXPOSE 80
EXPOSE 808
WORKDIR /workspace
COPY --from=build /workspace/bin/Release .
ENTRYPOINT ["powershell.exe", "C:/workspace/Server.exe"]