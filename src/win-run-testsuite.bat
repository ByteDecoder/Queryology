@ECHO OFF

cls

echo Legion awaits
del /S /Q ..\coverage\ >nul 2>nul

dotnet tool update dotnet-reportgenerator-globaltool

dotnet test Queryology.sln -c Release --logger:trx ^
  --results-directory ../../coverage ^
  /p:CollectCoverage=true ^
  /p:CoverletOutput=../../coverage/ ^
  /p:CoverletOutputFormat=\"lcov,json\" ^
  /p:MergeWith=../../coverage/coverage.json

echo Preparing lcov.info for Coverage Gutters
del ..\coverage\lcov.info >nul 2>nul
ren ..\coverage\coverage.info lcov.info >nul 2>nul

echo Preparing Test Report with reportgenerator
reportgenerator "-reports:..\coverage/lcov.info" "-reporttypes:HTMLInline;Badges" "-targetdir:..\coverage/report"

echo We are Legion...