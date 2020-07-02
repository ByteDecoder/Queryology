![CI](https://github.com/ByteDecoder/Queryology/workflows/CI/badge.svg)
[![Maintainability](https://api.codeclimate.com/v1/badges/5636af5394315faa7bd8/maintainability)](https://codeclimate.com/github/ByteDecoder/Queryology/maintainability)

# Queryology
Minimalist query engine executor used with Entity Framework Core + LINQ for quick experiments


## Running Example .Net Core Console App

First create the example database and apply the migrations with:

```bash
$ cd ./src
$ dotnet ef database update -p ./Queryology.Example
```

Then run the sample console project:

```bash
$ cd Queryology.Example/   
$ dotnet run
```