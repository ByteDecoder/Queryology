![CI](https://github.com/ByteDecoder/Queryology/workflows/CI/badge.svg)
[![Maintainability](https://api.codeclimate.com/v1/badges/5636af5394315faa7bd8/maintainability)](https://codeclimate.com/github/ByteDecoder/Queryology/maintainability)

# Queryology
Minimalist query engine executor used with Entity Framework Core + LINQ for quick experiments

Targeted to .Net Core 3.1

## Installation

Install the [Queryology NuGet Package](https://www.nuget.org/packages/ByteDecoder.Queryology).

### Package Manager Console

```
Install-Package ByteDecoder.Queryology
```

### .NET Core CLI

```
dotnet add package ByteDecoder.Queryology
```

## Running Example .Net Core Console App

First create the example database and apply the migrations with:

```bash
$ cd ./src
$ dotnet ef database update -p ./Queryology.Example
```

Then run the example console project:

```bash
$ cd Queryology.Example/   
$ dotnet run
```

## Contributing

Bug reports and pull requests are welcome on GitHub at https://github.com/ByteDecoder/Queryology.


Copyright (c) 2020 [Rodrigo Reyes](https://twitter.com/bytedecoder) released under the MIT license