# SQL database project with MSBuild.Sdk.SqlProj

## Build the project

To build the project, run the following command:

```bash
dotnet build
```

This will get you a dacpac at 'bin/Debug/net10.0/DatabaseBuildTestHarness.dacpac.dacpac'

## Reverse engineer with the dacpac

You can run

```bash
efcpt 'bin/Debug/net10.0/DatabaseBuildTestHarness.dacpac' mssql
```

## Reverse engineer with live database

### Local SQL Server 2022

This folder includes a `docker-compose.yml` for running SQL Server 2022 locally.

1. Start SQL Server:

```bash
docker compose up -d
```

2. Publish this database project to the running container:

```bash
dotnet publish -t:PublishDatabase \
    -p:TargetServerName=localhost \
    -p:TargetPort=1433 \
    -p:TargetDatabaseName=DatabaseBuildTestHarness \
    -p:TargetUser=sa \
    -p:TargetPassword="Password!"
```

For `efcpt` CLI commands, run:

```bash
efcpt 'Server=localhost,1433;Initial Catalog=DatabaseBuildTestHarness;User ID=sa;Password=Password!;Encrypt=False;TrustServerCertificate=True' mssql
```