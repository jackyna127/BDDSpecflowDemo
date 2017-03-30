@echo off
Set path=%1
Set powershell=%2
echo "path is"
echo %path%
echo "Execute test from Nunit.Console"
%path%\packages\NUnit.ConsoleRunner.3.6.0\tools\nunit3-console.exe --labels=On --output=%path%\TestReport\TestResult.txt --result=%path%\TestReport\TestResult.xml;format=nunit2 %path%\BDDSpecflowDemo\bin\Debug\BDDSpecflowDemo.dll

echo "Change Nunit 3 txt report to NUnit 2 txt report"

call:DoReplace "=>" "*****" %path%\TestReport\TestResult.txt %path%\TestReport\TestResult1.txt %powershell%

del %path%\TestReport\TestResult.txt
rename %path%\TestReport\TestResult1.txt %path%\TestReport\TestResult.txt

echo "Generate Report"

%path%\packages\SpecFlow.2.1.0\tools\specflow.exe nunitexecutionreport %path%\BDDSpecflowDemo\BDDSpecflowDemo.csproj /out:%path%\TestReport\TestResult.html
echo "Generate Report Done"

:DoReplace
echo ^(Get-Content "%3"^) ^| ForEach-Object { $_ -replace %1, %2 } ^| Set-Content %4>Rep.ps1
%5 -executionpolicy ByPass -File Rep.ps1
if exist Rep.ps1 del Rep.ps1
echo Done


