:: 1. choco install nuget.commandline
:: 2. NuGet.exe setapikey e39ea-get-the-full-key-on-nuget.org
:: 3. increment version in Directory.Build.props
:: 4. delete nuget_packages\
:: 5. rebuild

NuGet push nuget_packages\Refactoring.Pipelines.?.?.?.nupkg -Source nuget.org
NuGet push nuget_packages\Refactoring.Pipelines.Approvals.?.?.?.nupkg -Source nuget.org
NuGet push nuget_packages\Refactoring.Pipelines.DotGraph.?.?.?.nupkg -Source nuget.org

pause 
