FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

WORKDIR /App

# Copy all to my app
COPY . ./

# Run app/restore as layers

RUN dotnet restore

RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/runtime:8.0
WORKDIR /App
COPY --from=build-env /App/out .
ENTRYPOINT [ "dotnet", "Dotnet.Docker.dll" ]

# Then run in terminal "docker build -t counter-image<name> -f Dockerfile ."

## Create a container
# Then run "docker create --name core-counter counter-image"
# d52b74e62c43ca96431ebb023fad51da45b752ffd481faeed8d070a663e9741a
