@echo off
pushd %~dp0

echo.
echo Building CsvImport...
echo.
dotnet restore
dotnet build

if ERRORLEVEL 1 exit /b %ERRORLEVEL%

echo.
echo Populating the DB...
echo.
dotnet run ..\..\Data\work.csv

popd
