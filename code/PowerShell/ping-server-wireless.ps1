function global:Ping-Server( $server="59.144.127.16", $logPath="p:\pinglog\pinglog_modem.csv"
{
    .\Get-PingMonitor.ps1 -path logPath -computer $server;
}

