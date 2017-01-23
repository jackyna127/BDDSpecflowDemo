..\packages\NUnit.ConsoleRunner.3.6.0\tools\nunit3-console.exe --labels=On --output=TestResult.txt --result="TestResult.xml";format=nunit2 ..\BDDSpecflowDemo\bin\Debug\BDDSpecflowDemo.dll

@echo off

call:DoReplace "=>" "*****" .\TestReport\TestResult.txt .\TestReport\TestResult1.txt
exit /b

:DoReplace
echo ^(Get-Content "%3"^) ^| ForEach-Object { $_ -replace %1, %2 } ^| Set-Content %4>Rep.ps1
Powershell.exe -executionpolicy ByPass -File Rep.ps1
if exist Rep.ps1 del Rep.ps1
echo Done

del .\TestReport\TestResult.txt
rename .\TestReport\TestResult1.txt .\TestReport\TestResult.txt

..\packages\SpecFlow.2.1.0\tools\specflow.exe nunitexecutionreport ..\BDDSpecflowDemo\BDDSpecflowDemo.csproj
