..\packages\NUnit.ConsoleRunner.3.6.0\tools\nunit3-console.exe --labels=On --output=%1 --result=%2;format=nunit2 ..\BDDSpecflowDemo\bin\Debug\BDDSpecflowDemo.dll

ConvertNUnit3TxtReportToNUnit2.bat


..\packages\SpecFlow.2.1.0\tools\specflow.exe nunitexecutionreport ..\BDDSpecflowDemo\BDDSpecflowDemo.csproj
