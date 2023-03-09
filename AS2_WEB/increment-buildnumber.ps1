$buildNumberFile = Join-Path $PSScriptRoot "buildnumber.txt"
$buildNumber = Get-Content $buildNumberFile
$newBuildNumber = [int]$buildNumber + 1
$env:buildNumber=$newBuildNumber
Set-Content $buildNumberFile $newBuildNumber
Write-Output $newBuildNumber
Write-Output $env:buildnumber