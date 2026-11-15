# Httping

[![MIT licensed](https://img.shields.io/badge/license-MIT-blue.svg)](https://github.com/AiursoftWeb/httping/blob/master/LICENSE)
[![Pipeline stat](https://badge-proxy.aiursoft.com/aiursoft/httping/badges/master/pipeline.svg)](https://gitlab.aiursoft.com/aiursoft/httping/-/pipelines)
[![Test Coverage](https://badge-proxy.aiursoft.com/aiursoft/httping/badges/master/coverage.svg)](https://gitlab.aiursoft.com/aiursoft/httping/-/pipelines)
[![S360 compliance](https://s360.aiursoft.com/badge.svg?project=aiursoft%2Fhttping)](https://s360.aiursoft.com/SupplyChain?tab=projects&project=aiursoft%2Fhttping&scope=baseline&ecosystem=all)
[![NuGet version (Aiursoft.Httping)](https://img.shields.io/nuget/v/Aiursoft.Httping.svg)](https://www.nuget.org/packages/Aiursoft.Httping/)
[![Man hours](https://manhours.aiursoft.com/r/github.com/aiursoftweb/httping.svg)](https://manhours.aiursoft.com/r/github.com/aiursoftweb/httping.html)

Httping is a simple HTTP ping tool. It can ping a website and get the response time.

## Overview

Send a bounded series of HTTP requests and inspect each response time, then read the request-count and round-trip summary. Httping runs locally and does not require a Controller or an API key.

## Installation

Install the CLI with the [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0):

```bash
dotnet tool install --global Aiursoft.Httping
```

Update an existing installation:

```bash
dotnet tool update --global Aiursoft.Httping
```

Remove the CLI:

```bash
dotnet tool uninstall --global Aiursoft.Httping
```

## Usage

Run the command to see available options:

```bash
httping --help
```

```bash
httping --server https://example.com --count 4
```

This sends four requests and prints per-response timings followed by a summary.

See [the CLI guide](https://github.com/AiursoftWeb/httping/blob/master/docs/usage.md) for commands and examples.

## Configuration

Configuration is supplied through command-line options. URLs without a scheme use HTTP; specify `https://` for HTTPS. Httping uses the system proxy by default; `--no-proxy` bypasses it. See [the option reference](https://github.com/AiursoftWeb/httping/blob/master/docs/usage.md#options) for timeouts, intervals, redirects and output controls.

## Development

Install the [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0).

From the repository root, restore and build:

```bash
dotnet restore Aiursoft.Httping.sln
dotnet build Aiursoft.Httping.sln --no-restore
```

Run the tool from source:

```bash
dotnet run --project src/Aiursoft.Httping/Aiursoft.Httping.csproj -- --help
```

Run the existing tests:

```bash
dotnet test Aiursoft.Httping.sln --no-restore
```

## Documentation

- [Requests, results and options](https://github.com/AiursoftWeb/httping/blob/master/docs/usage.md)
- [Probing a local HTTP server](https://github.com/AiursoftWeb/httping/blob/master/docs/usage.md#local-checks)
- <a name="run-locally"></a>[Build and run from source](#development)
- <a name="run-in-microsoft-visual-studio"></a>[Visual Studio: open Aiursoft.Httping.sln and run the tool project](#development)

## How to contribute

Report bugs and feature requests through the [issue tracker](https://github.com/AiursoftWeb/httping/issues). Create a feature branch or fork and submit a merge request or pull request for review.

Follow the [development guide](#development) to build and run the existing checks before submitting changes.

## License

Licensed under the [MIT License](https://github.com/AiursoftWeb/httping/blob/master/LICENSE).
