FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

WORKDIR /PvE

# Copy all to my app
COPY . ./

# Run app/restore as layers

RUN dotnet restore

RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/runtime:8.0
WORKDIR /PvE
COPY --from=build-env /PvE/out .
ENTRYPOINT [ "dotnet", "PvE.dll" ]

# Then run in terminal "docker build -t counter-image<name> -f Dockerfile ."

## Create a container
# Then run "docker create --name core-counter counter-image"
# e09c93c797f21be6f994a12fc04e57f0c995481d6f47843389b44e1c761706ef
