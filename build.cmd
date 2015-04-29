GettyImages.Api\nuget.exe restore GettyImages.Api.sln
copy .\specflow.exe.config packages\SpecFlow.1.9.0\tools\
.\packages\SpecFlow.1.9.0\tools\specflow.exe generateall GettyImages.Api.OnlineTests\GettyImages.Api.OnlineTests.csproj
msbuild.exe GettyImages.Api.sln /t:Rebuild /p:Configuration=Debug
GettyImages.Api\nuget.exe pack GettyImages.Api\GettyImages.Api.csproj
