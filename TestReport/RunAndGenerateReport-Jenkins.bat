@echo off
echo "Execute test from Nunit.Console"

%1\packages\NUnit.ConsoleRunner.3.6.0\tools\nunit3-console.exe --labels=On --output=%1\TestReport\TestResult.txt --result=%1\TestReport\TestResult.xml;format=%1\BDDSpecflowDemo\bin\Debug\BDDSpecflowDemo.dll

echo "Change Nunit 3 txt report to NUnit 2 txt report"

echo ^(Get-Content "%3"^) ^| ForEach-Object { $_ -replace %1, %2 } ^| Set-Content %4>Rep.ps1
Powershell.exe -executionpolicy ByPass -File Rep.ps1
if exist Rep.ps1 del Rep.ps1
echo Done


del %1\TestReport\TestResult.txt
rename %1\TestReport\TestResult1.txt %1\TestReport\TestResult.txt

echo "Generate Report"

%1\packages\SpecFlow.2.1.0\tools\specflow.exe nunitexecutionreport %1\BDDSpecflowDemo\BDDSpecflowDemo.csproj





