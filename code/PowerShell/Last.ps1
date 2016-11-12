function global:ForLast($Days=0)
{
    begin{
        Write-Host "List files for last $days days"
        if($Days -gt 0) {
            $Days = $Days * -1
        }                       
        $DateToCompare = (Get-Date -Hour 0 -Minute 0 -Second 0).AddDays($Days)             
    }

    process{ 
        if ($_.lastwritetime –gt $DateToCompare) {
            $_
        } 
    }   
}
