@ECHO OFF
dotnet test --logger "trx;LogFileName=TestResults.xml" --results-directory ./BuildReports/UnitTests /p:CollectCoverage=true /p:CoverletOutput=BuildReports\Coverage\ /p:CoverletOutputFormat=cobertura /p:Threshold=70 /p:ThresholdStat=total

FOR /F %%D IN ('dir /b /a:d /o:-n %userprofile%\.nuget\packages\reportgenerator\*') DO (
    set directory=%%D
    GOTO report
)

:report
dotnet %userprofile%\.nuget\packages\reportgenerator\%directory%\tools\net8.0\ReportGenerator.dll "-reports:BuildReports\Coverage\coverage.cobertura.xml" "-targetdir:BuildReports\Coverage" -reporttypes:HTML;HTMLSummary
start BuildReports\Coverage\index.htm