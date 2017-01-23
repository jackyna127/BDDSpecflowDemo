@echo off

echo "Change Nunit 3 txt report to NUnit 2 txt report"
Set TxtResultFile=%1
Set TempFile=%2
call:DoReplace "=>" "*****" %1 %2

echo "Generate Report"

..\packages\SpecFlow.2.1.0\tools\specflow.exe nunitexecutionreport ..\BDDSpecflowDemo\BDDSpecflowDemo.csproj

IF NOT EXIST TestResult.html GOTO FAIL
EXIT
 
:FAIL
echo ##teamcity[buildStatus status='FAILURE']
exit /b

:DoReplace
echo ^(Get-Content "%3"^) ^| ForEach-Object { $_ -replace %1, %2 } ^| Set-Content %4>Rep.ps1
Powershell.exe -executionpolicy ByPass -File Rep.ps1
if exist Rep.ps1 del Rep.ps1
echo Done

del %TxtResultFile%
rename %TempFile% %TxtResultFile%

