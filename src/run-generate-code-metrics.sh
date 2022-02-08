clear
echo "Generating  Code Metrics"
echo
dotnet build ./Queryology/ -c Release /t:Metrics /p:MetricsOutputFile=../.code-metrics/Queryology.Metrics.xml

echo "We are Legion"