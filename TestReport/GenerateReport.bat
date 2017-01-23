@echo off

echo "Change Nunit 3 txt report to NUnit 2 txt report"

call:DoReplace "=>" "*****" .\BDDSpecflowDemo\bin\DebugTestResult.txt .\BDDSpecflowDemo\bin\Debug\TestResult1.txt

echo "Generate Report"

..\packages\SpecFlow.2.1.0\tools\specflow.exe nunitexecutionreport ..\BDDSpecflowDemo\BDDSpecflowDemo.csproj

exit /b

:DoReplace
echo ^(Get-Content "%3"^) ^| ForEach-Object { $_ -replace %1, %2 } ^| Set-Content %4>Rep.ps1
Powershell.exe -executionpolicy ByPass -File Rep.ps1
if exist Rep.ps1 del Rep.ps1
echo Done

del .\BDDSpecflowDemo\bin\Debug\TestResult.txt
rename .\BDDSpecflowDemo\bin\Debug\TestResult1.txt .\BDDSpecflowDemo\bin\Debug\TestResult.txt

