msbuild.exe GettyImages.Api.sln /t:Rebuild /p:Configuration=Release
.nuget\nuget.exe pack GettyImages.Api\GettyImages.Api.csproj -Prop Configuration=Release
