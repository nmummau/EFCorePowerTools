# SQL database project with MSBuild.Sdk.SqlProj

## Build the project

To build the project, run the following command:

```bash
dotnet build
```

This will get you a dacpac at 'bin/Debug/net10.0/Issue3341.dacpac'

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
  /p:TargetDatabaseName=Issue3341 \
  /p:TargetUser=sa \
  /p:TargetPassword="Password!"
```

3. Connect to it using SQL authentication:

Connection string:

```text
Server=localhost,1433;Initial Catalog=Issue3341;User ID=sa;Password=Password!;Encrypt=False;TrustServerCertificate=True
```

For tools that expect separate arguments, use:

- Server: `localhost`
- Port: `1433`
- Database: `Issue3341`
- Username: `sa`

## EFCPT from a live database

For `efcpt` CLI commands, run:

```bash
efcpt 'Server=localhost,1433;Initial Catalog=Issue3341;User ID=sa;Password=Password!;Encrypt=False;TrustServerCertificate=True' mssql
```

## EFCPT from a dacpac, see the Issue 3341!

This will fail!

```bash
efcpt 'bin/Debug/net10.0/Issue3341.dacpac' mssql
```

```txt
EF Core Power Tools CLI 10.1.1168 for EF Core 10
https://github.com/ErikEJ/EFCorePowerTools

config file: /home/nmummau/Code/EFCorePowerTools-Fork/test/ScaffoldingTester/Issue3341/efcpt-config.json

System.InvalidOperationException: Sequence contains no matching element
  at void System.Linq.ThrowHelper.ThrowNoMatchException()
  at TSource System.Linq.Enumerable.Single<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
  at void ErikEJ.EntityFrameworkCore.SqlServer.Scaffolding.SqlServerDacpacDatabaseModelFactory.GetForeignKeys(TSqlTable table, DatabaseModel dbModel) in
     SqlServerDacpacDatabaseModelFactory.cs:268
  at DatabaseModel ErikEJ.EntityFrameworkCore.SqlServer.Scaffolding.SqlServerDacpacDatabaseModelFactory.Create(string connectionString,
     DatabaseModelFactoryOptions options) in SqlServerDacpacDatabaseModelFactory.cs:154
  at DatabaseModel RevEng.Core.TableListBuilder.GetDatabaseModel() in TableListBuilder.cs:132
  at List<TableModel> RevEng.Core.TableListBuilder.GetTableModels() in TableListBuilder.cs:43
  at void ErikEJ.EFCorePowerTools.Services.DisplayService.<>c__DisplayClass7_0`1.<Wait>b__0(StatusContext ctx) in DisplayService.cs:63
  at Task Spectre.Console.Status.<>c__DisplayClass14_0.<Start>b__0(StatusContext ctx) in Status.cs:44
  at void Spectre.Console.Status.<>c__DisplayClass16_0.<<StartAsync>b__0>d.MoveNext() in Status.cs:79
  at void Spectre.Console.Status.<>c__DisplayClass17_0`1.<<StartAsync>b__0>d.MoveNext() in Status.cs:120
  at void Spectre.Console.Progress.<>c__DisplayClass32_0`1.<<StartAsync>b__0>d.MoveNext() in Progress.cs:138
  at async Task<T> Spectre.Console.Internal.DefaultExclusivityMode.RunAsync<T>(Func<Task<T>> func) in DefaultExclusivityMode.cs:40
  at async Task<T> Spectre.Console.Progress.StartAsync<T>(Func<ProgressContext, Task<T>> action) in Progress.cs:121
  at async Task<T> Spectre.Console.Status.StartAsync<T>(string status, Func<StatusContext, Task<T>> func) in Status.cs:117
  at async Task Spectre.Console.Status.StartAsync(string status, Func<StatusContext, Task> action) in Status.cs:77
  at void Spectre.Console.Status.Start(string status, Action<StatusContext> action) in Status.cs:48
  at T ErikEJ.EFCorePowerTools.Services.DisplayService.Wait<T>(string message, Func<T> doFunc) in DisplayService.cs:58
  at List<TableModel> ErikEJ.EFCorePowerTools.HostedServices.ScaffoldHostedService.GetTablesAndViews() in ScaffoldHostedService.cs:207
  at async Task ErikEJ.EFCorePowerTools.HostedServices.ScaffoldHostedService.ExecuteAsync(CancellationToken stoppingToken) in ScaffoldHostedService.cs:43
  at async Task Microsoft.Extensions.Hosting.Internal.Host.<StartAsync>b__14_1(IHostedService service, CancellationToken token)
  at async Task Microsoft.Extensions.Hosting.Internal.Host.ForeachService<T>(IEnumerable<T> services, CancellationToken token, bool concurrent, bool
     abortOnFirstException, List<Exception> exceptions, Func<T, CancellationToken, Task> operation)
  at void Microsoft.Extensions.Hosting.Internal.Host.<StartAsync>g__LogAndRethrow|14_3(ref <>c__DisplayClass14_0 )
  at async Task Microsoft.Extensions.Hosting.Internal.Host.StartAsync(CancellationToken cancellationToken)
  at async Task<IHost> Microsoft.Extensions.Hosting.HostingAbstractionsHostBuilderExtensions.StartAsync(IHostBuilder hostBuilder, CancellationToken
     cancellationToken)
  at void ErikEJ.EFCorePowerTools.Program.<>c.<<MainAsync>b__1_1>d.MoveNext() in Program.cs:56
  at async Task<int> ErikEJ.EFCorePowerTools.Program.MainAsync(string[] args) in Program.cs:66
  at async Task<int> ErikEJ.EFCorePowerTools.Program.Main(string[] args) in Program.cs:22
```