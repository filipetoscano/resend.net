@echo off

rmdir /q /s TestResults

dotnet test --collect:"XPlat Code Coverage"

scp TestResults\**\*.xml TestResults

reportgenerator -reports:"TestResults\coverage.cobertura.xml" -targetdir:"TestReport" -reporttypes:Html

