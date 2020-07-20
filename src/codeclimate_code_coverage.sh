# Download codeclimate test reporter
curl -L https://codeclimate.com/downloads/test-reporter/test-reporter-latest-linux-amd64 > ./codeclimate-test-reporter
chmod +x ./codeclimate-test-reporter

# Install dotnet tools to generate test report
dotnet tool install --global coverlet.console 
dotnet add package coverlet.msbuild

# Start codeclimate process
./codeclimate-test-reporter before-build

# Build solution
dotnet restore
dotnet build ./Queryology.sln

# Running unit tests - 'lcov' output format (and put coverage in correct path)
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=lcov /p:CoverletOutput=coverage /p:Exclude=[xunit.*]* ./Queryology.sln
mkdir coverage && mv ./Queryology.Tests/coverage.info coverage/lcov.info

# Send test report result to codeclimate
./codeclimate-test-reporter after-build -t lcov -r ${4756e012cbc04ec5e5138b27e2f8800832fd6645c1e59ff0e6baed170f92242e} -p ./ --exit-code $?