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

"C:\Program Files (x86)\Microsoft Visual Studio\2019\Professional\MSBuild\Current\Bin\MSBuild.exe" /target:clean,restore,build
IF ERRORLEVEL 1 exit /b 1

FOR %%f IN (nuget_packages\*.nupkg) DO (
    NuGet push %%f -Source nuget.org -Verbosity detailed
    IF ERRORLEVEL 1 exit /b 1
)

pause 
