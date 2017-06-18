# restore and builds all projects as release.
echo "DotNet Version:"
dotnet --version

dotnet restore Leoxia.Abstractions.sln

dotnet build Leoxia.Abstractions.sln  --configuration release 

# Note that we don't build packages here because 
# - we should build only once each package
# - we should not build test package
# - we should not push package on Nuget for each build (only done for official release).