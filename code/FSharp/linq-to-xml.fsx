
Microsoft (R) F# 2.0 Interactive build 4.0.40219.1
Copyright (c) Microsoft Corporation. All Rights Reserved.

For help type #help;;

> 
--> Referenced 'C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.Xml.Linq.dll'

> > 

linq-to-xml.fsx(7,5): error FS0039: The namespace or module 'XDocument' is not defined
> > > > 
--> Referenced 'C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.dll'

> 
--> Referenced 'C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.Xml.dll'

> 
--> Referenced 'C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.Xml.Linq.dll'

> 

linq-to-xml.fsx(7,5): error FS0039: The namespace or module 'XDocument' is not defined
> #r "System"
;;

--> Referenced 'C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.dll'

> #r "System.Xml";;

--> Referenced 'C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.Xml.dll'

> #r "System.Xml.Linq";;

--> Referenced 'C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.Xml.Linq.dll'

> let weatherXml = "http://weather.yahooapis.com/forecastrss?w=2484280" |> XDocument.Load;;


linq-to-xml.fsx(18,74): error FS0039: The namespace or module 'XDocument' is not defined
> let weatherXml = "http://weather.yahooapis.com/forecastrss?w=2484280" |> XDocuments.Load;;


linq-to-xml.fsx(19,74): error FS0039: The namespace or module 'XDocuments' is not defined
 let weatherXml = "http://weather.yahooapis.com/forecastrss?w=2484280" |> System.Xml.Linq.XDocuments.Load;;let weatherXml = "http://weather.yahooapis.com/forecastrss?w=2484280" |> System.Xml.Linq.XDocuments.Load;;

