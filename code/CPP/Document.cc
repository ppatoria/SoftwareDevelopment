function Get-UpTime{
     param($computername='localhost')
 
     Get-WmiObject win32_NTLogEvent -Filter 'Logfile="System" and EventCode>6004 and EventCode<6009' -ComputerName $computername | 
     ForEach-Object {
          $rv = $_ | Select-Object EventCode, TimeGenerated switch ($_.EventCode) {
               6006 { $rv.EventCode = 'shutdown' }
               6005 { $rv.EventCode = 'start' }
               6008 { $rv.EventCode = 'crash' }
          }
          $rv.TimeGenerated = $_.ConvertToDateTime($_.TimeGenerated)
          $rv
     }
}


