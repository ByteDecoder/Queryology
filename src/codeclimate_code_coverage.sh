# Download codeclimate test reporter
curl -L https://codeclimate.com/downloads/test-reporter/test-reporter-latest-linux-amd64 > ./codeclimate-test-reporter
chmod +x ./codeclimate-test-reporter

# Install dotnet tools to generate test report
dotnet tool install --global coverlet.console 
#dotnet add package coverlet.msbuild

# Start codeclimate process
./codeclimate-test-reporter before-build

# Running unit tests - 'lcov' output format (and put coverage in correct path)
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=lcov /p:CoverletOutput=../coverage/lcov --no-restore --verbosity normal
#cmkdir coverage && mv ./Queryology.Tests/coverage.info coverage/lcov.info

ls coverage/

# Send test report result to codeclimate
./codeclimate-test-reporter after-build -t lcov -r ${CC_TEST_REPORTER_ID} -p ./ --exit-code $?