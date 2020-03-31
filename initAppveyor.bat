@echo off

SET projName=%1

if "%projName"=="" (
  echo specify project name
) else (
  (echo image: Visual Studio 2019& echo.& echo.before_build:& echo.  - nuget restore %projName%/%projName%.sln& echo.  - choco install opencover.portable& echo.  - choco install codecov& echo.& echo.build:& echo.  project: %projName%/%projName%.sln& echo.& echo.test_script:& echo.  - dotnet test %projName%/%projName%.sln& echo.  - OpenCover.Console.exe -register -target:"C:/Program Files/dotnet/dotnet.exe" -targetargs:"test --logger:trx;LogFileName=results.trx /p:DebugType=full C:\projects\hw\%projName%\%projName%.Test\%projName%.Test.csproj" -filter:"+[%projName%*]* -[%projName%.Test*]*" -output:".\my_app_coverage.xml"& echo.  - codecov -f .\my_app_coverage.xml -t 5382e166-51cc-44e6-bf48-6a45c18b6ebd) >".\appveyor.yml"
)