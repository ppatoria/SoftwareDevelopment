Function global:Search-Msdn {
   param(
        [Parameter(Mandatory=$true)]
        [string[]]$SearchQuery,
        [System.Globalization.Cultureinfo]$Culture = 'en-US'
    )
    #$u="http://social.msdn.microsoft.com/Search/$($Culture.Name)?query=$Query"
    $r="http://social.msdn.microsoft.com/Search/$($Culture.Name)?query=" + $SearchQuery
        
    $r
    foreach ($Query in $SearchQuery) {
        start $r              
    }
}