function global:Ping-Both
{
    "192.168.1.1","59.144.127.16"; | 
    .\Get-PingMonitor.ps1 -path c:\pinglog\pinglogBoth.csv
}