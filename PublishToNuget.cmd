::::::: Setup:
:: 1. choco install nuget.commandline
:: 2. Get API key from https://www.nuget.org/account/apikeys
:: 3. NuGet.exe setapikey BLAH-BLAH-BLAH
::
:: Remember to update version number in Directory.Build.props before running this script

IF EXIST nuget_packages (
    DEL /S /Q nuget_packages\
    IF ERRORLEVEL 1 exit /b 1
)

"C:\Program Files (x86)\Microsoft Visual Studio\2019\Professional\\MSBuild\Current\Bin\MSBuild.exe" "/target:clean,restore,build
IF ERRORLEVEL 1 exit /b 1

FOR %%f IN (nuget_packages\*.nupkg) DO (
    NuGet push %%f -Source nuget.org
)

pause 

