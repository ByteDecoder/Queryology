
#!/bin/sh
set -e

dotnet tool update security-scan
dotnet security-scan ./Queryology.sln