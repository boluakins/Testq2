FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS base
WORKDIR /src
COPY *.sln .

# copy and restore all projects
COPY CardDetails.Tests/*.csproj CardDetails.Tests/
COPY CardDetails.API/*.csproj CardDetails.API/

RUN dotnet restore

# Copy everything else
COPY . .

#Testing
FROM base AS testing
WORKDIR /src/CardDetails.API

RUN dotnet build

WORKDIR /src/CardDetails.Tests
RUN dotnet test

#Publishing
FROM base AS publish
WORKDIR /src/CardDetails.API
RUN dotnet publish -c Release -o /src/publish


#Get the runtime into a folder called app
FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=publish /src/publish .

#ENTRYPOINT ["dotnet", "CardDetails.API.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet CardDetails.API.dll