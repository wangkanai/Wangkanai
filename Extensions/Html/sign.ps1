remove-item -path .\signed\*.*

dotnet --version
dotnet clean .\src\
dotnet restore .\src\
dotnet build .\src\ -c Release
Get-ChildItem .\src\ -Recurse Wangkanai.*.dll  | foreach {
    signtool sign /fd SHA256 /n "Sarin Na Wangkanai" $_.FullName
}

Remove-Item .\artifacts\*.*

dotnet pack .\src\ -c Release -o .\artifacts --include-symbols -p:SymbolPackageFormat = snupkg

dotnet nuget sign .\artifacts\*.nupkg -v diag --timestamper http://timestamp.digicert.com --certificate-subject-name "Sarin Na Wangkanai" -o .\signed
dotnet nuget sign .\artifacts\*.snupkg -v diag --timestamper http://timestamp.digicert.com --certificate-subject-name "Sarin Na Wangkanai" -o .\signed

dotnet nuget push .\signed\*.nupkg -k $env:NUGET_API_KEY -s https://api.nuget.org/v3/index.json --skip-duplicate
# dotnet nuget push .\signed\*.snupkg -k $env:NUGET_API_KEY -s https://api.nuget.org/v3/index.json --skip-duplicate
