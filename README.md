# EF Core Power Tools

EF Core Power Tools helps you generate EF Core entity classes and a DbContext from an existing database or SQL Server .dacpac file. It also provides tools to visualize and inspect your DbContext model in Visual Studio.

[![CLI build](https://github.com/ErikEJ/EFCorePowerTools/actions/workflows/cli-tool.yml/badge.svg?branch=master)](https://github.com/ErikEJ/EFCorePowerTools/actions/workflows/cli-tool.yml?query=branch%3Amaster)
[![CLI version including nightly builds](https://img.shields.io/nuget/vpre/ErikEJ.EFCorePowerTools.Cli?label=CLI%20%28incl.%20nightly%29)](src/Core/efcpt.8/readme.md#getting-the-latest-daily-build)
[![Visual Studio Marketplace Rating](https://badgen.net/vs-marketplace/rating/ErikEJ.EFCorePowerTools)](https://marketplace.visualstudio.com/items?itemName=ErikEJ.EFCorePowerTools&ssr=false#review-details)
[![Visual Studio Marketplace Installs](https://badgen.net/vs-marketplace/i/ErikEJ.EFCorePowerTools)](https://marketplace.visualstudio.com/items?itemName=ErikEJ.EFCorePowerTools)
[![Follow ErikEJ on X](https://img.shields.io/badge/Follow-%40ErikEJ-black?logo=x&logoColor=white)](https://x.com/ErikEJ)

## Get started

Start with the **CLI (`efcpt`)** for reverse engineering across a team or in CI. It runs on Windows, Linux and macOS, so developers, coding agents, and build agents can use the same scripted workflow regardless of their editor or operating system.

| Tool | Use it for | Get started |
| --- | --- | --- |
| **Command-line tool (`efcpt`)** | Scripted reverse engineering for local development, shared team workflows and CI on Windows, Linux and macOS. | Follow the [CLI installation and usage guide](https://www.nuget.org/packages/ErikEJ.EFCorePowerTools.Cli#readme-body-tab). |
| **Visual Studio extension** | Model visualization and inspection in Visual Studio 2022, plus a reverse engineering wizard for those who prefer a graphical workflow. | [Install from Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=ErikEJ.EFCorePowerTools). For the reverse engineering wizard, follow the [Quick Start](https://github.com/ErikEJ/EFCorePowerTools/wiki/Reverse-Engineering-Quick-Start), which includes a 10 minute video. |

You can use both tools together: generate and regenerate your code with the CLI, then use the Visual Studio extension to [visualize and inspect the resulting DbContext model](https://github.com/ErikEJ/EFCorePowerTools/wiki/Inspect-your-DbContext-model).

For the **CLI**, see its guide for runtime requirements and choosing a tool version that matches your EF Core version.

For reverse engineering with the **Visual Studio extension**, the .NET 8.0 or .NET 10.0 runtime must be installed. You can also install the extension through the **Extensions > Manage Extensions** dialog in Visual Studio.

### Repeatable reverse engineering for teams and CI

The CLI lets you keep generation choices in source control and run the same command locally and in CI. This makes changes to object selection, naming and code generation settings reviewable alongside your application code. For consistent output across developers and build agents:

- Pin the CLI to an exact version and commit the generation script, `efcpt-config.json`, and any custom renaming files or T4 templates.
- Use the same source database schema or [.dacpac input](https://www.nuget.org/packages/ErikEJ.EFCorePowerTools.Cli#using-a-dacpac-file) for each run.
- Set explicit [line endings and character set](https://www.nuget.org/packages/ErikEJ.EFCorePowerTools.Cli#line-endings-and-character-set) so generated files use the same formatting on Windows, Linux and macOS.

## Documentation

| Task | Guide |
| --- | --- |
| Run and configure `efcpt`. | [CLI guide](https://www.nuget.org/packages/ErikEJ.EFCorePowerTools.Cli#readme-body-tab) |
| Choose database objects and customize generated code, names, templates and stored procedures. | [Reverse Engineering guide](https://github.com/ErikEJ/EFCorePowerTools/wiki/Reverse-Engineering) |
| Visualize and inspect a DbContext model in Visual Studio. | [Model graphing and scripting](https://github.com/ErikEJ/EFCorePowerTools/wiki/Inspect-your-DbContext-model) |
| Explore the Visual Studio extension's database and database project tools. | [User guide and feature index](https://github.com/ErikEJ/EFCorePowerTools/wiki) |
| See what changed in a release. | [Release notes](https://github.com/ErikEJ/EFCorePowerTools/wiki/Release-notes) |

## Daily builds

- **CLI:** Follow [Getting the latest daily build](https://www.nuget.org/packages/ErikEJ.EFCorePowerTools.Cli#getting-the-latest-daily-build).
- **Visual Studio extension:** Download from [Open VSIX Gallery](https://www.vsixgallery.com/extension/f4c4712c-ceae-4803-8e52-0e2049d5de9f). To receive daily build updates automatically, install the [VSIX Gallery extension](https://marketplace.visualstudio.com/items?itemName=MadsKristensen.VSIXGallery-nightlybuilds).

## Videos and presentations

- [Introduction demo](https://youtu.be/uph-AGyOd8c)
- [Advanced features demo](https://youtu.be/3-Izu_qLDqY)
- [EF Core Power Tools presentation](https://erikej.github.io/EFCorePowerTools/index.html)

## Related projects and packages

- [EF Core Power Pack](https://marketplace.visualstudio.com/items?itemName=ErikEJ.EFCorePowerPack) bundles EF Core Power Tools with database connection providers (DDEX) and other tools for Visual Studio.
- [ErikEJ.EntityFrameworkCore.DgmlBuilder](https://www.nuget.org/packages/ErikEJ.EntityFrameworkCore.DgmlBuilder) adds `AsDgml()` to a derived DbContext to generate a model graph for the Visual Studio DGML viewer.
- [ErikEJ.EntityFrameworkCore.SqlServer.Dacpac](https://www.nuget.org/packages/ErikEJ.EntityFrameworkCore.SqlServer.Dacpac) enables reverse engineering a SQL Server .dacpac with the EF Core tooling (`dotnet ef`).
- [Tools and utilities for embedded database development](https://erikej.github.io/SqlCeToolbox/)

## Contributing

If you encounter a bug or have a feature request, please use the [Issue Tracker](https://github.com/ErikEJ/EFCorePowerTools/issues/new). The project is also open for pull requests following [standard pull request guidelines](https://github.com/dotnet/aspnetcore/blob/master/CONTRIBUTING.md).

### Building and debugging

To build and debug the Visual Studio extension, run the latest version of Visual Studio as Administrator with the **Visual Studio extension development** workload installed. Make `EFCorePowerTools` the startup project, and ensure your build configuration is **Debug, AnyCPU**.

You can smoke test changes to reverse engineering. Launch one of the `efreveng` console apps in the debugger using the name of a file in the `TestFiles` folder as a parameter.

In the `ScaffoldingTester` solution there are scripts to populate Northwind and Chinook databases with the required objects.

### Code formatting

The root [`.editorconfig`](.editorconfig) is based on [ATC's DotNet8 coding rules](https://github.com/atc-net/atc-coding-rules/blob/main/distribution/dotnet8/.editorconfig), with project-specific settings for formatting and generated files. The formatter is `dotnet format`, included in the .NET SDK, which reads the checked-in rules. The [ATC coding rules updater](https://github.com/atc-net/atc-coding-rules-updater) is a separate tool for maintaining configuration files; contributors can format code without installing it.

CI build runs a **Verify formatting** step in the **VSIX** workflow to check both solutions against [`.editorconfig`](.editorconfig). If it fails and reports formatting violations, apply fixes from the repository root:

```sh
dotnet format src/EFCorePowerTools.slnx
dotnet format test/ScaffoldingTester/ScaffoldingTester.slnx
```

Some violations may need manual fixes. Rerun the commands with `--verify-no-changes` to see those locally:

```sh
dotnet format src/EFCorePowerTools.slnx --verify-no-changes
dotnet format test/ScaffoldingTester/ScaffoldingTester.slnx --verify-no-changes
```

### Maintaining the ATC rules

The [ATC rule updates workflow](.github/workflows/atc-rules.yml) runs weekly on Mondays at 08:17 UTC and can also be run manually. It checks out this repository and runs ATC's documented ["coding rules are current" check](https://github.com/atc-net/atc-coding-rules-updater#gating-ci-on-coding-rules-are-current):

```sh
atc-coding-rules-updater run -p . -t DotNet8 --dry-run --fail-on-changes
```

The job fails if the updater would create or update any files, including nested `.editorconfig` and `Directory.Build.props` files. `--dry-run` leaves repository files unchanged. Informational drift that the updater reports but would not apply does not trigger `--fail-on-changes`.

The workflow installs updater version `2.1.0` using the .NET 10 SDK. To reproduce the check locally, install the same tool version and run the command above from the repository root:

```sh
dotnet tool install --global atc-coding-rules-updater --version 2.1.0
```

`-t DotNet8` selects the rule distribution used by our `.editorconfig`; the updater itself runs on .NET 10. The updater fetches ATC's current distribution, so a new upstream rule can make the weekly check fail even when this repository has not changed.

When it fails:

1. Review the proposed changes or errors in the job log and reproduce the dry run locally.
2. Keep intentional overrides in `.editorconfig`'s `Custom -` sections and configure the updater's mappings where needed for this repository's layout. Preview those changes again before applying updates.
3. Run `atc-coding-rules-updater run -p . -t DotNet8` locally to apply the updates, review all resulting configuration and package changes, and run the formatting and relevant build checks.
4. Commit the reviewed changes and rerun the dry-run check until it reports no files to create or update.

The weekly configuration check runs separately from PR formatting verification. The existing `dotnet format --verify-no-changes` checks continue to verify source code against the checked-in rules.

## Support and sponsors

The tool and GitHub based support are free. A [rating or review](https://marketplace.visualstudio.com/items?itemName=ErikEJ.EFCorePowerTools&ssr=false#review-details) and [sponsorships](https://github.com/sponsors/ErikEJ) are greatly appreciated.

A massive thanks to [AWS](https://github.com/aws), who sponsored EF Core Power Tools from January 2024 via the [.NET on AWS Open Source Software Fund](https://github.com/aws/dotnet-foss).

<div style="display:inline">
<img src="https://raw.githubusercontent.com/ErikEJ/EFCorePowerTools/master/img/aws-logo-small.png" alt="AWS" width="200" height="200"/>
</div>

And a huge thanks to everyone who sponsors this project through [GitHub Sponsors](https://github.com/sponsors/ErikEJ).
