@echo off

rem build the native solution
echo Building the native solution
msbuild Flurry.sln /p:Configuration=Release /t:Build

rem build the native nuget
echo Packaging the native NuGets
nuget pack nuget\Flurry.Analytics.nuspec -Output nuget
nuget pack nuget\Flurry.Ads.nuspec -Output nuget

rem build the native samples
echo Building the native samples solution
msbuild Flurry.Samples.sln /p:Configuration=Release /t:Build

rem build the native ads component
echo Packaging the native Ads Xamarin Component
xamarin-component package component\Flurry.Ads


rem build the portable analytics solution
echo Building the portable analytics solution
msbuild Flurry.Analytics.Portable.sln /p:Configuration=Release /t:Build

rem build the portable analytics nuget
echo Packaging the portable analytics NuGet
nuget pack nuget\Flurry.Analytics.Portable.nuspec

rem build the portable analytics samples
echo Building the portable analytics samples solution
nuget restore Portable\samples\Flurry.Analytics.Portable.Samples.sln
msbuild Portable\samples\Flurry.Analytics.Portable.Samples.sln /p:Configuration=Release /t:Build

rem create the portable analytics component
echo Packaging the Xamarin Components
xamarin-component package component\Flurry.Analytics.Portable -Output nuget