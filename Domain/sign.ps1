param(
    [Parameter(mandatory=$false)]
    [bool]$dryrun=$false
)

remove-item -path .\signed\*.*    -Force -ErrorAction SilentlyContinue
remove-item -path .\artifacts\*.* -Force -ErrorAction SilentlyContinue

new-item -Path artifacts -ItemType Directory -Force | out-null
new-item -Path signed    -ItemType Directory -Force | out-null

dotnet --version
dotnet clean   .\src\ -c Release -tl
dotnet restore .\src\
dotnet build   .\src\ -c Release -tl
Get-ChildItem  .\src\ -Recurse Wangkanai.*.dll | where { $_.FullName -like "*Release*" } | foreach {
	write-host "Signing" $_.FullName -ForegroundColor Green;
    signtool sign /fd SHA256 /tr http://ts.ssl.com /td sha256 /n "Sarin Na Wangkanai" $_.FullName
	#signtool verify /pa $_.FullName
}
#dotnet pack .\src\ -c Release -tl -o .\artifacts --include-symbols -p:SymbolPackageFormat=snupkg

#dotnet nuget sign .\artifacts\*.nupkg  -v normal --timestamper http://ts.ssl.com --certificate-subject-name "Sarin Na Wangkanai" -o .\signed
#dotnet nuget sign .\artifacts\*.snupkg -v normal --timestamper http://ts.ssl.com --certificate-subject-name "Sarin Na Wangkanai" -o .\signed

if ($dryrun)
{
    write-host "Dryrun: Domain" -ForegroundColor Yellow;
    exit;
}
#dotnet nuget push .\signed\*.nupkg --skip-duplicate -k $env:NUGET_API_KEY  -s https://api.nuget.org/v3/index.json
#dotnet nuget push .\signed\*.nupkg --skip-duplicate -k $env:GITHUB_API_PAT -s https://nuget.pkg.github.com/wangkanai/index.json
