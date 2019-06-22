:: nuget_cli\NuGet.exe setapikey e39ea-get-the-full-key-on-nuget.org
:: inc::ent version in Directory.Build.props
:: delete nuget_packages and rebuild
:: choco install nuget.commandline

NuGet push nuget_packages\Pipe.?.?.?.nupkg -Source nuget.org
NuGet push nuget_packages\ApprovalTests.?.?.?.nupkg -Source nuget.org

pause 
