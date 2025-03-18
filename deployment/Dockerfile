FROM mcr.microsoft.com/dotnet/sdk:9.0.201-alpine3.21-amd64@sha256:3b7e4d4acad155ac31494c103b4a4c8b1d60a7848e3206cddb0a05b3eb0fdd73 AS build
WORKDIR /App

COPY components/KafkaSaver/ /App

# Resore first to cache dependencies
RUN dotnet restore
RUN dotnet publish -o out

FROM mcr.microsoft.com/dotnet/runtime:9.0.3-alpine3.21@sha256:6d041316134272c0f375045a0dba0797c1b6236a7aa24089d9c725af60f06a70
WORKDIR /App
COPY --from=build /App/out /App

COPY deployment/entrypoint.sh /App/entrypoint.sh
RUN chmod +x /App/entrypoint.sh