# RUnning the Queryology Test Suite

TBD

## Running tests with coverage

```bash
dotnet test /p:CollectCoverage=true
```

## Example of .Net Test Explorer Configuration file

Install VSCode .Net Test Explorer extension and add this configuration

```json
{
  "dotnet-test-explorer.testProjectPath": "./src/Queryology.Tests/Queryology.Tests.csproj",
  "dotnet-test-explorer.testArguments": "/p:CollectCoverage=true /p:CoverletOutputFormat=lcov /p:CoverletOutput=../coverage/lcov.info"
}
```

## Reference links

<https://mookiefumi.com/2019-10-23-unit-testing-tools-using-your-vscode>

<https://mookiefumi.com/2019-10-20-unit-testing-tools-using-your-MacOS-terminal>
