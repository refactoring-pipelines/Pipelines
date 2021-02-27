::::::: A: Setup:
:: 1. Get API key from https://www.nuget.org/account/apikeys
:: 2. NuGet.exe setapikey BLAH-BLAH-BLAH
::
:::::: B: Execute
:: 1. Update version number in `Directory.Build.props`
:: 2. Run this script
:: 3. Commit all changes to Git
:: 4. `git tag nuget-v9.9.9.9`
:: 5. `git push`
::::::

IF EXIST nuget_packages (
    DEL /S /Q nuget_packages\
    IF ERRORLEVEL 1 exit /b 1
)

MSBuild.exe /target:clean
MSBuild.exe /target:restore
MSBuild.exe /target:build
IF ERRORLEVEL 1 exit /b 1

FOR %%f IN (nuget_packages\*.nupkg) DO (
    dotnet nuget push %%f -Source nuget.org -Verbosity detailed -k %NUGET_API_KEY%
    IF ERRORLEVEL 1 exit /b 1
)

pause 
