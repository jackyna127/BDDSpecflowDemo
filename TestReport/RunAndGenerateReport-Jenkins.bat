@echo off
Set path=%1
Set powershell=%2
Set oldstring="=>"
Set replacestring="*****"
Set oldtxtfile=%1\TestReport\TestResult.txt
Set newtxtfile=%1\TestReport\TestResult1.txt

echo "Execute test from Nunit.Console"
%path%\packages\NUnit.ConsoleRunner.3.6.0\tools\nunit3-console.exe --labels=On --output=%path%\TestReport\TestResult.txt --result=%path%\TestReport\TestResult.xml;format=nunit2 %path%\BDDSpecflowDemo\bin\Debug\BDDSpecflowDemo.dll

echo "Change Nunit 3 txt report to NUnit 2 txt report"

echo ^(Get-Content %oldtxtfile%^) ^| ForEach-Object { $_ -replace %oldstring%, %replacestring% } ^| Set-Content %newtxtfile%>Rep.ps1
%powershell% -executionpolicy ByPass -File Rep.ps1
if exist Rep.ps1 del Rep.ps1
echo "Change Nunit 3 txt report to NUnit 2 txt report Done" 


del %path%\TestReport\TestResult.txt
rename %path%\TestReport\TestResult1.txt %path%\TestReport\TestResult.txt

echo "Generate Report"
%path%\packages\SpecFlow.2.1.0\tools\specflow.exe nunitexecutionreport %path%\BDDSpecflowDemo\BDDSpecflowDemo.csproj /out:%path%\TestReport\TestResult.html
echo "Generate Report Done"



