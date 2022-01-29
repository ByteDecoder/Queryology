#!/bin/bash

clear

rm -r ../coverage/*

dotnet tool update dotnet-reportgenerator-globaltool

dotnet test Queryology.sln -c Release --logger:trx \
   --results-directory ../../coverage \
   /p:CollectCoverage=true \
   /p:CoverletOutput=../../coverage/ \
   /p:CoverletOutputFormat=\"lcov,json\" \
   /p:MergeWith=../../coverage/coverage.json

echo "Preparing lcov.info for Coverage Gutters"
rm ../coverage/lcov.info
mv ../coverage/coverage.info ../coverage/lcov.info

echo Preparing Test Report with reportgenerator
reportgenerator "-reports:../coverage/lcov.info" "-reporttypes:HTMLInline;Badges" "-targetdir:../coverage/report"

echo "We are Legion..."