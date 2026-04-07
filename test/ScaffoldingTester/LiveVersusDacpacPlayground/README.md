# SQL database project with MSBuild.Sdk.SqlProj

## Build the project

To build the project, run the following command:

```bash
dotnet build
```

This will get you a dacpac at 'bin/Debug/net10.0/LiveVersusDacpacPlayground.dacpac'

## EFCPT from a dacpac

```bash
efcpt 'bin/Debug/net10.0/LiveVersusDacpacPlayground.dacpac' mssql
```

You will see your Models are generated for TableOne and TableTwo

## Local SQL Server 2022

This folder includes a `docker-compose.yml` for running SQL Server 2022 locally.

1. Start SQL Server:

```bash
docker compose up -d
```

2. Publish this database project to the running container:

```bash
dotnet publish /t:PublishDatabase \
  /p:TargetServerName=localhost \
  /p:TargetPort=1433 \
  /p:TargetDatabaseName=LiveVersusDacpacPlayground \
  /p:TargetUser=sa \
  /p:TargetPassword="Password!"
```

3. Connect to it using SQL authentication:

Connection string:

```text
Server=localhost,1433;Initial Catalog=LiveVersusDacpacPlayground;User ID=sa;Password=Password!;Encrypt=False;TrustServerCertificate=True
```

For tools that expect separate arguments, use:

- Server: `localhost`
- Port: `1433`
- Database: `LiveVersusDacpacPlayground`
- Username: `sa`

## EFCPT from a live database

For `efcpt` CLI commands, run:

```bash
efcpt 'Server=localhost,1433;Initial Catalog=LiveVersusDacpacPlayground;User ID=sa;Password=Password!;Encrypt=False;TrustServerCertificate=True' mssql
```


## Edit efcpt-config.json

Now please update efcpt-config.json
You need to set `"refresh-object-lists": false`

and then please remove the TableTwo from the tables so that only TableOne remains
Make it looks like this
```
"tables": [
  {
    "name": "[dbo].[TableOne]"
  }
],
````

The intention here is that we want to leave TableTwo in the database project, but we want to remove it from the models.

Save the efcpt-config.json file.

Now run this again:
```bash
efcpt 'bin/Debug/net10.0/LiveVersusDacpacPlayground.dacpac' mssql
```

Notice that LiveVersusDacpacPlaygroundContext.cs is updated and TableTwo is removed

However the issue/bug is that the Models/TableTwo.cs is not removed