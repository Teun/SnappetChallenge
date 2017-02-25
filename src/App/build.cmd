@echo off
pushd %~dp0

echo.
echo Installing javascript dependencies...
echo.
cmd /C yarn

echo.
echo Building vendor scripts...
echo.
cmd /C webpack --config webpack.config.vendor.js

echo.
echo Building the client...
echo.
cmd /C webpack

echo.
echo Restoring NuGet packages...
echo.
dotnet restore

echo.
echo Building the server...
echo.
dotnet build

popd
