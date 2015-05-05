echo off

rem build the solution
echo Building the solution
msbuild Flurry.Analytics.Portable.sln /p:Configuration=Release /t:Rebuild

rem build the nuget
echo Packaging the NuGet
nuget pack Flurry.Analytics.nuspec
echo Packaging the NuGet
nuget pack Flurry.Analytics.Portable.nuspec
