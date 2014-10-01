ConnectSDK/nuget.exe restore ConnectSdk.sln
copy .\specflow.exe.config packages\SpecFlow.1.9.0\tools\
.\packages\SpecFlow.1.9.0\tools\specflow.exe generateall ConnectSdk.OnlineTests\ConnectSdk.OnlineTests.csproj
msbuild.exe ConnectSDK.sln /t:Rebuild /p:Configuration=Debug
ConnectSDK\nuget.exe pack ConnectSDK\ConnectSdk.csproj
