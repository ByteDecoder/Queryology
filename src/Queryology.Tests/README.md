# Running the Queryology Test Suite

The test suite is using **xUnit** as testing framework and for *Code Coverage* the test suite uses **Corvelet**, **Corvelet.MSBuild**

Required VSCode extensions for code coverage and line coverage

- Coverage Gutters
- .Net Test Explorer

**Note** Dont forget to activate the *Coverage Glutter Watch* in the bottom option line in VSCode to see line coverage colors in the code.

## Running tests with coverage

```bash
dotnet test /p:CollectCoverage=true
```

## Installing globally the ReportGenerator tool

```bash
dotnet tool install -g dotnet-reportgenerator-globaltool
```

## Generating a Coverage Report

Inside .src/ directory execute:

```bash
reportgenerator "-reports:coverage/lcov.info" "-reporttypes:HTMLInline;Badges" "-targetdir:coverage/report"
```

Then Press **F1** in *VSCode* and choose *Coverage Gutters: Preview Report Coverage*

## Example of .Net Test Explorer Configuration file

Install VSCode .Net Test Explorer extension and add this configuration

```json
{
  "dotnet-test-explorer.testProjectPath": "./src/Queryology.Tests/Queryology.Tests.csproj",
  "dotnet-test-explorer.testArguments": "/p:CollectCoverage=true /p:CoverletOutputFormat=lcov /p:CoverletOutput=../coverage/lcov.info"
}
```

## Coverage Gutters

In the Nuget palette you can choose the next options to be displayed:

- Coverage Gutters: Display Coverage
- Coverage Gutters: Preview Report Coverage

## Reference links

<https://mookiefumi.com/2019-10-23-unit-testing-tools-using-your-vscode>

<https://mookiefumi.com/2019-10-20-unit-testing-tools-using-your-MacOS-terminal>
