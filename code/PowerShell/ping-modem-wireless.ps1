function global:Ping-Modem( $server="192.168.1.1", $logPath="p:\pinglog\pinglog_modem.csv")
{
    p:\PowerShell\Get-PingMonitor.ps1 -path $logPath -computer $server;
}