default: build

build:
	dotnet restore --force
	dotnet build

test:
	dotnet test UnitTests