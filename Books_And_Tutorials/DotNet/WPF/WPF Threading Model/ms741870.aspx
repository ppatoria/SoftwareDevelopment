<!DOCTYPE html>

<html dir="ltr" xmlns="http://www.w3.org/1999/xhtml" lang="en">
    <head><link rel="canonical" href="http://msdn.microsoft.com/en-us/library/ms741870(v=vs.110).aspx" />
        <title>Threading Model</title>




<meta name="DCS.dcsuri" content="/en-us/library/ms741870(d=default,l=en-us,v=vs.110).aspx" />

<meta name="NormalizedUrl" content="http://msdn.microsoft.com/en-us/library/ms741870(d=default,l=en-us,v=vs.110).aspx" />

<meta name="DCSext.ProductFamily" content="LIB_DG" />

<meta name="DCSext.Product" content="NDP_WPF" />

<meta name="DCSext.Title" content="Threading Model" />

<meta name="VotingContextUrl" content="http://msdn.microsoft.com/en-us/library/ms741870(d=default,l=en-us,v=vs.110).aspx" />

<meta name="MN" content="61C41DD6-8:49:51 PM" />

<meta name="Search.ShortId" content="ms741870" />

<meta name="Ms.Locale" content="en-us" />







        
    <link rel="stylesheet" type="text/css" href="http://i3.msdn.microsoft.com/Combined.css?resources=0:Topic,0:CodeSnippet,0:ExpandableCollapsibleArea,0:CommunityContent,0:TopicNotInScope,0:FeedViewerBasic,0:ImageSprite,1:Header,1:ImageSprite,2:LinkList,2:PrintExportButton,3:Toc,3:NavigationResize,4:FeedbackCounter,0:VersionSelector,4:Feedback,3:LibraryMemberFilter,1:Footer,2:Base,5:Msdn;/Areas/Epx/Content/Css:0,/Areas/Centers/Themes/Msdn/Content:1,/Areas/Epx/Themes/Base/Content:2,/Areas/Epx/Library/Content:3,/Areas/Epx/Shared/Content:4,/Areas/Epx/Themes/Msdn/Content:5&amp;amp;hashKey=349E23332D683FE8A497019DA9E079B9" /></head>
    <body class="library">
        <div id="page">
            
            
  
            
    
    <div id="ux-header">
        <header>
            <div class="row">
                <div class="top mobile"></div>
                <div class="left">
                    <div data-fragmentName="SiteLogo" id="Fragment_SiteLogo" xmlns="http://www.w3.org/1999/xhtml">
  <a href="http://msdn.microsoft.com/en-us" id="27762_1" xmlns="http://www.w3.org/1999/xhtml">Developer Network</a>
</div>     
                </div>
                <div id="grip"></div>  
                <div class="right desktop">
                    <div class="auxNav">
                        <div data-fragmentName="Subscriptions" id="Fragment_Subscriptions" xmlns="http://www.w3.org/1999/xhtml">
  <a href="http://msdn.microsoft.com/dn369243" id="27762_5" xmlns="http://www.w3.org/1999/xhtml">MSDN subscriptions</a>
</div>   
                        <div data-fragmentName="GetTools" id="Fragment_GetTools" xmlns="http://www.w3.org/1999/xhtml">
  <a href="http://go.microsoft.com/fwlink/?LinkId=309297&amp;clcid=0x409&amp;slcid=0x409" id="27762_3" xmlns="http://www.w3.org/1999/xhtml">Get tools</a>
</div>   
                        

    <div class="signIn"><a class="scarabLink" href="https://login.live.com/login.srf?wa=wsignin1.0&amp;rpsnv=12&amp;ct=1389502192&amp;rver=6.0.5276.0&amp;wp=MCLBI&amp;wlcxt=MSDN%24MSDN%24MSDN&amp;wreply=http%3a%2f%2fmsdn.microsoft.com%2fen-us%2flibrary%2fms741870.aspx&amp;lc=1033&amp;id=254354&amp;mkt=en-US" title="Sign in">Sign in</a></div>

                    </div>
                    <div data-fragmentName="SearchBox" id="Fragment_SearchBox" xmlns="http://www.w3.org/1999/xhtml">
  
  <div class="SearchBox">
    <form id="HeaderSearchForm" name="HeaderSearchForm" method="get" action="http://social.msdn.microsoft.com/Search" onsubmit="return Epx.Controls.SearchBox.searchBoxOnSubmit(this, this.title);">
      <input id="HeaderSearchTextBox" name="query" type="text" maxlength="200" onfocus="Epx.Controls.SearchBox.watermarkFocus(this, this.title, 'SearchBoxOnFocus')" onblur="Epx.Controls.SearchBox.watermarkBlur(this, this.title, 'SearchBoxOnFocus')" />
      <input id="RefinementId" name="refinement" type="hidden" value="" />
      <button id="HeaderSearchButton" value="" type="submit" class="header-search-button"></button>
    </form>
    
  </div>
</div> 
                </div>
            </div>
       
            <div class="row" id="droor">
                <div class="left">
                            <nav>
            <ul>
                     <li class="inactive">

                         <a href="http://msdn.microsoft.com/dn308572" title="Home">Home</a>

                     </li>
                     <li class="inactive">

                         <a href="http://msdn.microsoft.com/dn271881" title="Opportunity">Opportunity</a>
                                 <div class="area">
                                     <div class="arrow"></div>
                                 </div>
                                 <div class="subNav">
                                     <ul>
                                                 <li><a href="http://msdn.microsoft.com/dn338450" title=".NET">.NET</a></li>
                                                 <li><a href="http://msdn.microsoft.com/dn338159" title="Cloud">Cloud</a></li>
                                                 <li><a href="http://msdn.microsoft.com/dn469160" title="Desktop">Desktop</a></li>
                                                 <li><a href="http://msdn.microsoft.com/dn338268" title="Phone">Phone</a></li>
                                                 <li><a href="http://msdn.microsoft.com/dn308583" title="Tablet &amp; PC">Tablet &amp; PC</a></li>
                                                 <li><a href="http://msdn.microsoft.com/dn338449" title="Web">Web</a></li>
                                     </ul>
                                 </div>

                     </li>
                     <li class="inactive">

                         <a href="http://msdn.microsoft.com/dn271880" title="Platform">Platform</a>

                     </li>
                     <li class="inactive">

                         <a href="http://msdn.microsoft.com/dn338064" title="Connect">Connect</a>
                                 <div class="area">
                                     <div class="arrow"></div>
                                 </div>
                                 <div class="subNav">
                                     <ul>
                                                 <li><a href="http://tech-advisors.msdn.microsoft.com/en-us" title="Tech Advisors">Tech Advisors</a></li>
                                                 <li><a href="http://msdn.microsoft.com/dn338452" title="Perspectives">Perspectives</a></li>
                                                 <li><a href="http://events.msdn.microsoft.com/en-us" title="Events">Events</a></li>
                                                 <li><a href="http://social.msdn.microsoft.com/forums/" title="Forums">Forums</a></li>
                                     </ul>
                                 </div>

                     </li>
                     <li class="inactive">

                         <a href="http://msdn.microsoft.com/dn292944" title="Downloads">Downloads</a>
                                 <div class="area">
                                     <div class="arrow"></div>
                                 </div>
                                 <div class="subNav">
                                     <ul>
                                                 <li><a href="http://msdn.microsoft.com/dn369242" title="Developer tools">Developer tools</a></li>
                                                 <li><a href="http://msdn.microsoft.com/dn369240" title="SDKs">SDKs</a></li>
                                                 <li><a href="http://msdn.microsoft.com/dn369243" title="MSDN subscriptions">MSDN subscriptions</a></li>
                                     </ul>
                                 </div>

                     </li>
                     <li class="active current">

                         <a href="http://msdn.microsoft.com/library" title="Library">Library</a>

                     </li>
                     <li class="inactive">

                         <a href="http://code.msdn.microsoft.com/" title="Samples">Samples</a>

                     </li>
            </ul>
          
        </nav>        
       
                </div>
                <div class="right mobile"></div>
                <div class="right">
                    <div data-fragmentName="SocialLinks" id="Fragment_SocialLinks" xmlns="http://www.w3.org/1999/xhtml">
  
  <div class="LinkList">
    <div class="LinkListTitle">Join us</div>
    <div class="Links">
      <ul class="LinkColumn horizontal">
        <li>
          <a href="http://www.facebook.com/microsoftdeveloper" target="_blank" id="SocialLinks_430_7" class="facebook" xmlns="http://www.w3.org/1999/xhtml">http://www.facebook.com/microsoftdeveloper</a>
        </li>
        <li>
          <a href="https://twitter.com/msdev" target="_blank" id="SocialLinks_430_8" class="twitter" xmlns="http://www.w3.org/1999/xhtml">https://twitter.com/msdev</a>
        </li>
        <li>
          <a href="http://plus.google.com/111221966647232053570/" target="_blank" id="SocialLinks_430_9" class="googlePlus" xmlns="http://www.w3.org/1999/xhtml">http://plus.google.com/111221966647232053570/</a>
        </li>
      </ul>
    </div>
  </div>
</div> 
                </div>
                <span id="singleCol"></span>
                <span id="doubleCol"></span>
            </div>
        </header>
    </div>
    
    

        
    <div class="printExportMenus ltr">
        <a id="isd_printABook" href="/en-us/library/export/help/?returnUrl=%2fen-us%2flibrary%2fms741870.aspx">
            Export (<span class="count">0</span>)
        </a>
        <a id="isd_print" href="http://msdn.microsoft.com/en-us/library/ms741870(d=printer).aspx" rel="nofollow">
            Print 
        </a>
    </div>
    

        <div class="printExportMenus ltr">
        <a id="expandCollapseAll" href="javascript:void(0)">Expand All</a>
    </div>

    

        
            <div id="body">
                





    <div id="leftNav">



<div id="tocnav">
            <div class="toclevel0" data-toclevel="0">
<a data-tochassubtree="true" href="/en-us/library/ms123401.aspx" id="ms310241_MSDN.10_en-us" mtpsaliasid="" mtpsassetid="5DDC0A78-6B2C-43E3-9C56-55F45C0DFFA5_MSDN.10_en-us" mtpsshortid="ms123401_MSDN.10_en-us" title="MSDN Library">MSDN Library</a>            </div>
            <div class="toclevel0" data-toclevel="0">
<a data-tochassubtree="true" href="/en-us/library/ff361664(v=vs.110).aspx" id="aa139615_MSDN.10_en-us" mtpsaliasid="" mtpsassetid="43e22490-fb00-409c-8301-585a03034ae2_MSDN.10_en-us" mtpsshortid="ff361664_VS.110_en-us" title=".NET Development">.NET Development</a>            </div>
            <div class="toclevel0" data-toclevel="0">
<a data-tochassubtree="true" href="/en-us/library/w0x726c2(v=vs.110).aspx" id="aa139616_MSDN.10_en-us" mtpsaliasid="" mtpsassetid="f61f02f2-2f20-483d-8f56-a9c8f3a54986_MSDN.10_en-us" mtpsshortid="w0x726c2_VS.110_en-us" title=".NET Framework 4.5">.NET Framework 4.5</a>            </div>
            <div class="toclevel0" data-toclevel="0">
<a data-tochassubtree="true" href="/en-us/library/hh156542(v=vs.110).aspx" id="hh781599_VS.110_en-us" mtpsaliasid="" mtpsassetid="26e3d285-24c3-435c-a797-9fe5affb8525_VS.110_en-us" mtpsshortid="hh156542_VS.110_en-us" title="Development Guide">Development Guide</a>            </div>
            <div class="toclevel0" data-toclevel="0">
<a data-tochassubtree="true" href="/en-us/library/54xbah2z(v=vs.110).aspx" id="hh570241_VS.110_en-us" mtpsaliasid="" mtpsassetid="2dfb50b7-5af2-4e12-9bbb-c5ade0e39a68_VS.110_en-us" mtpsshortid="54xbah2z_VS.110_en-us" title="Client Applications">Client Applications</a>            </div>
            <div class="toclevel0" data-toclevel="0">
<a data-tochassubtree="true" href="/en-us/library/ms754130(v=vs.110).aspx" id="hh574241_VS.110_en-us" mtpsaliasid="" mtpsassetid="f667bd15-2134-41e9-b4af-5ced6fafab5d_VS.110_en-us" mtpsshortid="ms754130_VS.110_en-us" title="Windows Presentation Foundation">Windows Presentation Foundation</a>            </div>
            <div class="toclevel1" data-toclevel="1">
<a data-tochassubtree="true" href="/en-us/library/ms746927(v=vs.110).aspx" id="hh574196_VS.110_en-us" mtpsaliasid="" mtpsassetid="58843391-b28c-4d32-adf5-87acaf6578a1_VS.110_en-us" mtpsshortid="ms746927_VS.110_en-us" title="Advanced">Advanced</a>            </div>
            <div class="toclevel2" data-toclevel="2">
<a href="/en-us/library/ms750441(v=vs.110).aspx" mtpsaliasid="" mtpsassetid="" mtpsshortid="" title="WPF Architecture">WPF Architecture</a>            </div>
            <div class="toclevel2" data-toclevel="2">
<a data-tochassubtree="true" href="/en-us/library/ms746683(v=vs.110).aspx" id="hh574187_VS.110_en-us" mtpsaliasid="" mtpsassetid="" mtpsshortid="" title="Base Elements">Base Elements</a>            </div>
            <div class="toclevel2" data-toclevel="2">
<a data-tochassubtree="true" href="/en-us/library/ms750605(v=vs.110).aspx" id="hh574198_VS.110_en-us" mtpsaliasid="" mtpsassetid="" mtpsshortid="" title="Element Tree and Serialization">Element Tree and Serialization</a>            </div>
            <div class="toclevel2" data-toclevel="2">
<a data-tochassubtree="true" href="/en-us/library/ms749074(v=vs.110).aspx" id="hh574233_VS.110_en-us" mtpsaliasid="" mtpsassetid="" mtpsshortid="" title="Drag and Drop">Drag and Drop</a>            </div>
            <div class="toclevel2" data-toclevel="2">
<a data-tochassubtree="true" href="/en-us/library/ms749165(v=vs.110).aspx" id="hh574092_VS.110_en-us" mtpsaliasid="" mtpsassetid="" mtpsshortid="" title="Documents">Documents</a>            </div>
            <div class="toclevel2" data-toclevel="2">
<a data-tochassubtree="true" href="/en-us/library/ms753931(v=vs.110).aspx" id="hh574207_VS.110_en-us" mtpsaliasid="" mtpsassetid="" mtpsshortid="" title="Globalization and Localization">Globalization and Localization</a>            </div>
            <div class="toclevel2" data-toclevel="2">
<a data-tochassubtree="true" href="/en-us/library/ms753178(v=vs.110).aspx" id="hh574240_VS.110_en-us" mtpsaliasid="" mtpsassetid="" mtpsshortid="" title="Migration and Interoperability">Migration and Interoperability</a>            </div>
            <div class="toclevel2" data-toclevel="2">
<a data-tochassubtree="true" href="/en-us/library/aa970776(v=vs.110).aspx" id="hh574162_VS.110_en-us" mtpsaliasid="" mtpsassetid="" mtpsshortid="" title="Performance">Performance</a>            </div>
            <div class="toclevel2 current" data-toclevel="2">
<a href="/en-us/library/ms741870(v=vs.110).aspx" mtpsaliasid="" mtpsassetid="" mtpsshortid="" title="Threading Model">Threading Model</a>            </div>
            <div class="toclevel2" data-toclevel="2">
<a data-tochassubtree="true" href="/en-us/library/bb909794(v=vs.110).aspx" id="hh793371_VS.110_en-us" mtpsaliasid="" mtpsassetid="" mtpsshortid="" title="WPF Add-Ins Overview">WPF Add-Ins Overview</a>            </div>
</div>
        

        

        
        
        <div id="toc-resizable-ew" class="toc-resizable-ew"></div>
        

<a id="NavigationResize" href="javascript:void(0)">
    <img class="cl_nav_resize_open" src="http://i3.msdn.microsoft.com/Areas/Epx/Content/Images/ImageSprite.png" title="Expand" alt="Expand" />
    <img class="cl_nav_resize_close" src="http://i3.msdn.microsoft.com/Areas/Epx/Content/Images/ImageSprite.png" title="Minimize" alt="Minimize" />
</a>



    </div>
<div id="content" class="content">







    
    

    <div id="ratingCounterSeperator" class="cl_lw_vs_seperator" style="display: none;"></div>

    <div id="ratingCounter">
        <span id="rcA" class="ratingText">
            14 out of 20 rated this helpful <span id="rateThisPrefix">- </span><a id="rateThisTopic" href="#feedback" title="Rate this topic">Rate this topic</a>
            
        </span>
    </div>

        
<div xmlns="http://www.w3.org/1999/xhtml">
  
  <div class="topic" xmlns="http://www.w3.org/1999/xhtml" xmlns:mtps="http://msdn2.microsoft.com/mtps" xmlns:msxsl="urn:schemas-microsoft-com:xslt" xmlns:cs="http://msdn.microsoft.com/en-us/">
    <h1 class="title">Threading Model</h1>
    
    <div class="lw_vs">
      <div id="curversion">
        <strong>
            .NET Framework 4.5
        </strong>
      </div>
      <div id="versionclick">
        <div id="vsseperator" class="cl_lw_vs_seperator"></div>
        <div>
          <div>
            <a id="vsLink" href="javascript:;">
                        Other Versions
                    </a>
          </div>
          <div class="cl_vs_arrow clip10x10">
            <img class="cl_lw_vs_arrow" id="vsArrow" alt="" src="http://i3.msdn.microsoft.com/Areas/Epx/Content/Images/ImageSprite.png" />
          </div>
        </div>
        <ul id="vsPanel">
          <li>
            <a href="/en-us/library/ms741870(v=vs.100).aspx" title="">.NET Framework 4</a>
          </li>
          <li>
            <a href="/en-us/library/ms741870(v=vs.90).aspx" title="">.NET Framework 3.5</a>
          </li>
          <li>
            <a href="/en-us/library/ms741870(v=vs.85).aspx" title="">.NET Framework 3.0</a>
          </li>
        </ul>
      </div>
    </div>
    <div style="clear:both;"></div>
    
    <div id="mainSection">
      <div id="mainBody">
        <p>
          
        </p>
        <div class="introduction">
          <p>Windows Presentation Foundation (WPF) is designed to save developers from the difficulties of threading. As a result, the majority of WPF developers won't have to write an interface that uses more than one thread. Because multithreaded programs are complex and difficult to debug, they should be avoided when single-threaded solutions exist.</p>
          <p>No matter how well architected, however, no UI framework will ever be able to provide a single-threaded solution for every sort of problem. WPF comes close, but there are still situations where multiple threads improve user interface (UI) responsiveness or application performance. After discussing some background material, this paper explores some of these situations and then concludes with a discussion of some lower-level details.</p>
          <p> This topic contains the following sections. </p>
          <ul>
            <li>
              <a href="#threading_overview">Overview and the Dispatcher</a>
            </li>
            <li>
              <a href="#samples">Threads in Action: The Samples</a>
            </li>
            <li>
              <a href="#stumbling_points">Technical Details and Stumbling Points</a>
            </li>
            <li>
              <a href="#seeAlsoToggle">Related Topics</a>
            </li>
          </ul>
          <div class="alert">
            <table>
              <tr>
                <th align="left">
                  <img id="alert_note" alt="Note" src="http://i.msdn.microsoft.com/areas/global/content/clear.gif" title="Note" xmlns="" class="cl_IC101471" />
                  <strong>Note</strong>
                </th>
              </tr>
              <tr>
                <td>
                  <p>This topic discusses threading by using the <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcher.begininvoke.aspx">BeginInvoke</a></span> method for asynchronous calls. You can also make asynchronous calls by calling the <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcher.invokeasync.aspx">InvokeAsync</a></span> method, which take an <span><a href="http://msdn.microsoft.com/en-us/library/system.action.aspx">Action</a></span> or <span><a href="http://msdn.microsoft.com/en-us/library/bb534960.aspx">Func<span xmlns="">&lt;</span>TResult<span xmlns="">&gt;</span></a></span> as a parameter.  The <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcher.invokeasync.aspx">InvokeAsync</a></span> method returns a <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcheroperation.aspx">DispatcherOperation</a></span> or <span><a href="http://msdn.microsoft.com/en-us/library/hh199415.aspx">DispatcherOperation<span xmlns="">&lt;</span>TResult<span xmlns="">&gt;</span></a></span>, which has a <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcheroperation.task.aspx">Task</a></span> property. You can use the <span><span class="input">await</span></span> keyword with either the <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcheroperation.aspx">DispatcherOperation</a></span> or the associated <span><a href="http://msdn.microsoft.com/en-us/library/system.threading.tasks.task.aspx">Task</a></span>. If you need to wait synchronously for the <span><a href="http://msdn.microsoft.com/en-us/library/system.threading.tasks.task.aspx">Task</a></span> that is returned by a <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcheroperation.aspx">DispatcherOperation</a></span> or <span><a href="http://msdn.microsoft.com/en-us/library/hh199415.aspx">DispatcherOperation<span xmlns="">&lt;</span>TResult<span xmlns="">&gt;</span></a></span>, call the <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.taskextensions.dispatcheroperationwait.aspx">DispatcherOperationWait</a></span> extension method.  Calling <span><a href="http://msdn.microsoft.com/en-us/library/system.threading.tasks.task.wait.aspx">Task<span xmlns="">.</span>Wait</a></span> will result in a deadlock. For more information about using a <span><a href="http://msdn.microsoft.com/en-us/library/system.threading.tasks.task.aspx">Task</a></span> to perform asynchronous operations, see Task Parallelism.  The <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcher.invoke.aspx">Invoke</a></span> method also has overloads that take an <span><a href="http://msdn.microsoft.com/en-us/library/system.action.aspx">Action</a></span> or <span><a href="http://msdn.microsoft.com/en-us/library/bb534960.aspx">Func<span xmlns="">&lt;</span>TResult<span xmlns="">&gt;</span></a></span> as a parameter.  You can use the <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcher.invoke.aspx">Invoke</a></span> method to make synchronous calls by passing in a delegate, <span><a href="http://msdn.microsoft.com/en-us/library/system.action.aspx">Action</a></span> or <span><a href="http://msdn.microsoft.com/en-us/library/bb534960.aspx">Func<span xmlns="">&lt;</span>TResult<span xmlns="">&gt;</span></a></span>.</p>
                </td>
              </tr>
            </table>
          </div>
        </div>
        <a id="threading_overview">
          
        </a>
        <div>
          
          <div class="LW_CollapsibleArea_TitleDiv">
            <div>
              <a href="javascript:void(0)" class="LW_CollapsibleArea_TitleAhref" title="Collapse">
                <span class="cl_CollapsibleArea_expanding LW_CollapsibleArea_Img"></span>
                <span class="LW_CollapsibleArea_Title">Overview and the Dispatcher</span>
              </a>
              <div class="LW_CollapsibleArea_HrDiv">
                <hr class="LW_CollapsibleArea_Hr" />
              </div>
            </div>
          </div>
          <div class="sectionblock">
            <a id="sectionToggle0">
              
            </a>
            <p>Typically, WPF applications start with two threads: one for handling rendering and another for managing the UI. The rendering thread effectively runs hidden in the background while the UI thread receives input, handles events, paints the screen, and runs application code. Most applications use a single UI thread, although in some situations it is best to use several. We’ll discuss this with an example later.</p>
            <p>The UI thread queues work items inside an object called a <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcher.aspx">Dispatcher</a></span>. The <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcher.aspx">Dispatcher</a></span> selects work items on a priority basis and runs each one to completion.  Every UI thread must have at least one <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcher.aspx">Dispatcher</a></span>, and each <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcher.aspx">Dispatcher</a></span> can execute work items in exactly one thread.</p>
            <p>The trick to building responsive, user-friendly applications is to maximize the <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcher.aspx">Dispatcher</a></span> throughput by keeping the work items small. This way items never get stale sitting in the <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcher.aspx">Dispatcher</a></span> queue waiting for processing. Any perceivable delay between input and response can frustrate a user.</p>
            <p>How then are WPF applications supposed to handle big operations? What if your code involves a large calculation or needs to query a database on some remote server? Usually, the answer is to handle the big operation in a separate thread, leaving the UI thread free to tend to items in the <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcher.aspx">Dispatcher</a></span> queue. When the big operation is complete, it can report its result back to the UI thread for display.</p>
            <p>Historically, Windows allows UI elements to be accessed only by the thread that created them. This means that a background thread in charge of some long-running task cannot update a text box when it is finished. Windows does this to ensure the integrity of UI components. A list box could look strange if its contents were updated by a background thread during painting.</p>
            <p>WPF has a built-in mutual exclusion mechanism that enforces this coordination. Most classes in WPF derive from <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcherobject.aspx">DispatcherObject</a></span>. At construction, a <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcherobject.aspx">DispatcherObject</a></span> stores a reference to the <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcher.aspx">Dispatcher</a></span> linked to the currently running thread. In effect, the <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcherobject.aspx">DispatcherObject</a></span> associates with the thread that creates it. During program execution, a <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcherobject.aspx">DispatcherObject</a></span> can call its public <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcherobject.verifyaccess.aspx">VerifyAccess</a></span> method. <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcherobject.verifyaccess.aspx">VerifyAccess</a></span> examines the <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcher.aspx">Dispatcher</a></span> associated with the current thread and compares it to the <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcher.aspx">Dispatcher</a></span> reference stored during construction. If they don’t match, <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcherobject.verifyaccess.aspx">VerifyAccess</a></span> throws an exception. <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcherobject.verifyaccess.aspx">VerifyAccess</a></span> is intended to be called at the beginning of every method belonging to a <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcherobject.aspx">DispatcherObject</a></span>.</p>
            <p>If only one thread can modify the UI, how do background threads interact with the user? A background thread can ask the UI thread to perform an operation on its behalf. It does this by registering a work item with the <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcher.aspx">Dispatcher</a></span> of the UI thread. The <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcher.aspx">Dispatcher</a></span> class provides two methods for registering work items: <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcher.invoke.aspx">Invoke</a></span> and <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcher.begininvoke.aspx">BeginInvoke</a></span>. Both methods schedule a delegate for execution. <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcher.invoke.aspx">Invoke</a></span> is a synchronous call – that is, it doesn’t return until the UI thread actually finishes executing the delegate. <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcher.begininvoke.aspx">BeginInvoke</a></span> is asynchronous and returns immediately.</p>
            <p>The <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcher.aspx">Dispatcher</a></span> orders the elements in its queue by priority. There are ten levels that may be specified when adding an element to the <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcher.aspx">Dispatcher</a></span> queue. These priorities are maintained in the <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcherpriority.aspx">DispatcherPriority</a></span> enumeration. Detailed information about <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcherpriority.aspx">DispatcherPriority</a></span> levels can be found in the Windows SDK documentation.</p>
          </div>
        </div>
        <a id="samples">
          
        </a>
        <div>
          <div class="LW_CollapsibleArea_TitleDiv">
            <div>
              <a href="javascript:void(0)" class="LW_CollapsibleArea_TitleAhref" title="Collapse">
                <span class="cl_CollapsibleArea_expanding LW_CollapsibleArea_Img"></span>
                <span class="LW_CollapsibleArea_Title">Threads in Action: The Samples</span>
              </a>
              <div class="LW_CollapsibleArea_HrDiv">
                <hr class="LW_CollapsibleArea_Hr" />
              </div>
            </div>
          </div>
          <div class="sectionblock">
            <a id="sectionToggle1">
              
            </a>
            <a id="prime_number">
              
            </a>
            <div>
              
              <div class="LW_CollapsibleArea_TitleDiv">
                <div>
                  <a href="javascript:void(0)" class="LW_CollapsibleArea_TitleAhref" title="Collapse">
                    <span class="cl_CollapsibleArea_expanding LW_CollapsibleArea_Img"></span>
                    <span class="LW_CollapsibleArea_Title">A Single-Threaded Application with a Long-Running Calculation</span>
                  </a>
                  <div class="LW_CollapsibleArea_HrDiv">
                    <hr class="LW_CollapsibleArea_Hr" />
                  </div>
                </div>
              </div>
              <div class="sectionblock">
                <a id="sectionToggle2">
                  
                </a>
                <p>Most graphical user interfaces (GUIs) spend a large portion of their time idle while waiting for events that are generated in response to user interactions. With careful programming this idle time can be used constructively, without affecting the responsiveness of the UI. The WPF threading model doesn’t allow input to interrupt an operation happening in the UI thread. This means you must be sure to return to the <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcher.aspx">Dispatcher</a></span> periodically to process pending input events before they get stale.</p>
                <p>Consider the following example:</p>
                <img id="ThreadingPrimeNumberScreenShot" alt="Prime numbers screen shot" src="http://i.msdn.microsoft.com/dynimg/IC17077.png" title="Prime numbers screen shot" xmlns="" />
                <p>This simple application counts upwards from three, searching for prime numbers. When the user clicks the <span class="label">Start</span> button, the search begins. When the program finds a prime, it updates the user interface with its discovery. At any point, the user can stop the search.</p>
                <p>Although simple enough, the prime number search could go on forever, which presents some difficulties.  If we handled the entire search inside of the click event handler of the button, we would never give the UI thread a chance to handle other events. The UI would be unable to respond to input or process messages. It would never repaint and never respond to button clicks.</p>
                <p>We could conduct the prime number search in a separate thread, but then we would need to deal with synchronization issues. With a single-threaded approach, we can directly update the label that lists the largest prime found.</p>
                <p>If we break up the task of calculation into manageable chunks, we can periodically return to the <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcher.aspx">Dispatcher</a></span> and process events. We can give WPF an opportunity to repaint and process input.</p>
                <p>The best way to split processing time between calculation and event handling is to manage calculation from the <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcher.aspx">Dispatcher</a></span>. By using the <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcher.begininvoke.aspx">BeginInvoke</a></span> method, we can schedule prime number checks in the same queue that UI events are drawn from. In our example, we schedule only a single prime number check at a time. After the prime number check is complete, we schedule the next check immediately. This check proceeds only after pending UI events have been handled.</p>
                <img id="ThreadingDispatcherQueue" alt="Dispatcher queue illustration" src="http://i.msdn.microsoft.com/dynimg/IC123441.png" title="Dispatcher queue illustration" xmlns="" />
                <p>Microsoft Word accomplishes spell checking using this mechanism. Spell checking is done in the background using the idle time of the UI thread. Let's take a look at the code. </p>
                <p>The following example shows the XAML that creates the user interface.</p>
                <div>
<div id="code-snippet-1" class="codeSnippetContainer" xmlns="">
    <div class="codeSnippetContainerTabs">
        <div class="codeSnippetContainerTabSingle" dir="ltr"><a>XAML</a></div>
    </div>
    <div class="codeSnippetContainerCodeContainer">
        <div class="codeSnippetToolBar">
            <div class="codeSnippetToolBarText">
                <a name="CodeSnippetCopyLink" style="display: none;" title="Copy to clipboard." href="javascript:if (window.epx.codeSnippet)window.epx.codeSnippet.copyCode('CodeSnippetContainerCode_4b54883c-c7b6-4599-842a-39a004272bbe');">Copy</a>
            </div>
        </div>
        <div id="CodeSnippetContainerCode_4b54883c-c7b6-4599-842a-39a004272bbe" class="codeSnippetContainerCode" dir="ltr">
            <div style="color:Black;"><pre>
<span style="color:Blue;">&lt;</span><span style="color:#A31515;">Window</span> <span style="color:Red;">x:Class</span><span style="color:Blue;">=</span><span style="color:Black;">"</span><span style="color:Blue;">SDKSamples.Window1</span><span style="color:Black;">"</span>
    <span style="color:Red;">xmlns</span><span style="color:Blue;">=</span><span style="color:Black;">"</span><span style="color:Blue;">http://schemas.microsoft.com/winfx/2006/xaml/presentation</span><span style="color:Black;">"</span>
    <span style="color:Red;">xmlns:x</span><span style="color:Blue;">=</span><span style="color:Black;">"</span><span style="color:Blue;">http://schemas.microsoft.com/winfx/2006/xaml</span><span style="color:Black;">"</span>
    <span style="color:Red;">Title</span><span style="color:Blue;">=</span><span style="color:Black;">"</span><span style="color:Blue;">Prime Numbers</span><span style="color:Black;">"</span> <span style="color:Red;">Width</span><span style="color:Blue;">=</span><span style="color:Black;">"</span><span style="color:Blue;">260</span><span style="color:Black;">"</span> <span style="color:Red;">Height</span><span style="color:Blue;">=</span><span style="color:Black;">"</span><span style="color:Blue;">75</span><span style="color:Black;">"</span>
    <span style="color:Blue;">&gt;</span>
  <span style="color:Blue;">&lt;</span><span style="color:#A31515;">StackPanel</span> <span style="color:Red;">Orientation</span><span style="color:Blue;">=</span><span style="color:Black;">"</span><span style="color:Blue;">Horizontal</span><span style="color:Black;">"</span> <span style="color:Red;">VerticalAlignment</span><span style="color:Blue;">=</span><span style="color:Black;">"</span><span style="color:Blue;">Center</span><span style="color:Black;">"</span> <span style="color:Blue;">&gt;</span>
    <span style="color:Blue;">&lt;</span><span style="color:#A31515;">Button</span> <span style="color:Red;">Content</span><span style="color:Blue;">=</span><span style="color:Black;">"</span><span style="color:Blue;">Start</span><span style="color:Black;">"</span>  
            <span style="color:Red;">Click</span><span style="color:Blue;">=</span><span style="color:Black;">"</span><span style="color:Blue;">StartOrStop</span><span style="color:Black;">"</span>
            <span style="color:Red;">Name</span><span style="color:Blue;">=</span><span style="color:Black;">"</span><span style="color:Blue;">startStopButton</span><span style="color:Black;">"</span>
            <span style="color:Red;">Margin</span><span style="color:Blue;">=</span><span style="color:Black;">"</span><span style="color:Blue;">5,0,5,0</span><span style="color:Black;">"</span>
            <span style="color:Blue;">/&gt;</span>
    <span style="color:Blue;">&lt;</span><span style="color:#A31515;">TextBlock</span> <span style="color:Red;">Margin</span><span style="color:Blue;">=</span><span style="color:Black;">"</span><span style="color:Blue;">10,5,0,0</span><span style="color:Black;">"</span><span style="color:Blue;">&gt;</span>Biggest Prime Found:<span style="color:Blue;">&lt;/</span><span style="color:#A31515;">TextBlock</span><span style="color:Blue;">&gt;</span>
    <span style="color:Blue;">&lt;</span><span style="color:#A31515;">TextBlock</span> <span style="color:Red;">Name</span><span style="color:Blue;">=</span><span style="color:Black;">"</span><span style="color:Blue;">bigPrime</span><span style="color:Black;">"</span> <span style="color:Red;">Margin</span><span style="color:Blue;">=</span><span style="color:Black;">"</span><span style="color:Blue;">4,5,0,0</span><span style="color:Black;">"</span><span style="color:Blue;">&gt;</span>3<span style="color:Blue;">&lt;/</span><span style="color:#A31515;">TextBlock</span><span style="color:Blue;">&gt;</span>
  <span style="color:Blue;">&lt;/</span><span style="color:#A31515;">StackPanel</span><span style="color:Blue;">&gt;</span>
<span style="color:Blue;">&lt;/</span><span style="color:#A31515;">Window</span><span style="color:Blue;">&gt;</span>
</pre></div>
            
        </div>
    </div>
</div>

<div id="code-snippet-2" class="codeSnippetContainer" xmlns="">
    <div class="codeSnippetContainerTabs">
        <div class="codeSnippetContainerTabSingle" dir="ltr"><a>XAML</a></div>
    </div>
    <div class="codeSnippetContainerCodeContainer">
        <div class="codeSnippetToolBar">
            <div class="codeSnippetToolBarText">
                <a name="CodeSnippetCopyLink" style="display: none;" title="Copy to clipboard." href="javascript:if (window.epx.codeSnippet)window.epx.codeSnippet.copyCode('CodeSnippetContainerCode_0a331e7a-f5ce-421d-8cca-20b22c2d2d10');">Copy</a>
            </div>
        </div>
        <div id="CodeSnippetContainerCode_0a331e7a-f5ce-421d-8cca-20b22c2d2d10" class="codeSnippetContainerCode" dir="ltr">
            <div style="color:Black;"><pre>
<span style="color:Blue;">&lt;</span><span style="color:#A31515;">Window</span> <span style="color:Red;">x:Class</span><span style="color:Blue;">=</span><span style="color:Black;">"</span><span style="color:Blue;">SDKSamples.MainWindow</span><span style="color:Black;">"</span>
    <span style="color:Red;">xmlns</span><span style="color:Blue;">=</span><span style="color:Black;">"</span><span style="color:Blue;">http://schemas.microsoft.com/winfx/2006/xaml/presentation</span><span style="color:Black;">"</span>
    <span style="color:Red;">xmlns:x</span><span style="color:Blue;">=</span><span style="color:Black;">"</span><span style="color:Blue;">http://schemas.microsoft.com/winfx/2006/xaml</span><span style="color:Black;">"</span>
    <span style="color:Red;">Title</span><span style="color:Blue;">=</span><span style="color:Black;">"</span><span style="color:Blue;">Prime Numbers</span><span style="color:Black;">"</span> <span style="color:Red;">Width</span><span style="color:Blue;">=</span><span style="color:Black;">"</span><span style="color:Blue;">260</span><span style="color:Black;">"</span> <span style="color:Red;">Height</span><span style="color:Blue;">=</span><span style="color:Black;">"</span><span style="color:Blue;">75</span><span style="color:Black;">"</span>
    <span style="color:Blue;">&gt;</span>
    <span style="color:Blue;">&lt;</span><span style="color:#A31515;">StackPanel</span> <span style="color:Red;">Orientation</span><span style="color:Blue;">=</span><span style="color:Black;">"</span><span style="color:Blue;">Horizontal</span><span style="color:Black;">"</span> <span style="color:Red;">VerticalAlignment</span><span style="color:Blue;">=</span><span style="color:Black;">"</span><span style="color:Blue;">Center</span><span style="color:Black;">"</span> <span style="color:Blue;">&gt;</span>
        <span style="color:Blue;">&lt;</span><span style="color:#A31515;">Button</span> <span style="color:Red;">Content</span><span style="color:Blue;">=</span><span style="color:Black;">"</span><span style="color:Blue;">Start</span><span style="color:Black;">"</span>  
            <span style="color:Red;">Click</span><span style="color:Blue;">=</span><span style="color:Black;">"</span><span style="color:Blue;">StartOrStop</span><span style="color:Black;">"</span>
            <span style="color:Red;">Name</span><span style="color:Blue;">=</span><span style="color:Black;">"</span><span style="color:Blue;">startStopButton</span><span style="color:Black;">"</span>
            <span style="color:Red;">Margin</span><span style="color:Blue;">=</span><span style="color:Black;">"</span><span style="color:Blue;">5,0,5,0</span><span style="color:Black;">"</span>
            <span style="color:Blue;">/&gt;</span>
        <span style="color:Blue;">&lt;</span><span style="color:#A31515;">TextBlock</span> <span style="color:Red;">Margin</span><span style="color:Blue;">=</span><span style="color:Black;">"</span><span style="color:Blue;">10,5,0,0</span><span style="color:Black;">"</span><span style="color:Blue;">&gt;</span>Biggest Prime Found:<span style="color:Blue;">&lt;/</span><span style="color:#A31515;">TextBlock</span><span style="color:Blue;">&gt;</span>
        <span style="color:Blue;">&lt;</span><span style="color:#A31515;">TextBlock</span> <span style="color:Red;">Name</span><span style="color:Blue;">=</span><span style="color:Black;">"</span><span style="color:Blue;">bigPrime</span><span style="color:Black;">"</span> <span style="color:Red;">Margin</span><span style="color:Blue;">=</span><span style="color:Black;">"</span><span style="color:Blue;">4,5,0,0</span><span style="color:Black;">"</span><span style="color:Blue;">&gt;</span>3<span style="color:Blue;">&lt;/</span><span style="color:#A31515;">TextBlock</span><span style="color:Blue;">&gt;</span>
    <span style="color:Blue;">&lt;/</span><span style="color:#A31515;">StackPanel</span><span style="color:Blue;">&gt;</span>
<span style="color:Blue;">&lt;/</span><span style="color:#A31515;">Window</span><span style="color:Blue;">&gt;</span>
</pre></div>
            
        </div>
    </div>
</div>
</div>
                <p>The following example shows the code-behind.</p>
                <div>
<div id="code-snippet-3" class="codeSnippetContainer" xmlns="">
    <div class="codeSnippetContainerTabs">
        <div class="codeSnippetContainerTabActive" dir="ltr"><a>C#</a></div><div class="codeSnippetContainerTab" dir="ltr"><a href="http://msdn.microsoft.com/en-us/library/ms741870.aspx?cs-save-lang=1&amp;cs-lang=vb#code-snippet-3">VB</a></div>
    </div>
    <div class="codeSnippetContainerCodeContainer">
        <div class="codeSnippetToolBar">
            <div class="codeSnippetToolBarText">
                <a name="CodeSnippetCopyLink" style="display: none;" title="Copy to clipboard." href="javascript:if (window.epx.codeSnippet)window.epx.codeSnippet.copyCode('CodeSnippetContainerCode_eae46cd7-78ff-476a-aa24-7efe5cce06d6');">Copy</a>
            </div>
        </div>
        <div id="CodeSnippetContainerCode_eae46cd7-78ff-476a-aa24-7efe5cce06d6" class="codeSnippetContainerCode" dir="ltr">
            <div style="color:Black;"><pre>
<span style="color:Blue;">using</span> System;
<span style="color:Blue;">using</span> System.Windows;
<span style="color:Blue;">using</span> System.Windows.Controls;
<span style="color:Blue;">using</span> System.Windows.Threading;
<span style="color:Blue;">using</span> System.Threading;

<span style="color:Blue;">namespace</span> SDKSamples
{
    <span style="color:Blue;">public</span> <span style="color:Blue;">partial</span> <span style="color:Blue;">class</span> Window1 : Window
    {
        <span style="color:Blue;">public</span> <span style="color:Blue;">delegate</span> <span style="color:Blue;">void</span> NextPrimeDelegate();

        <span style="color:Green;">//Current number to check  </span>
        <span style="color:Blue;">private</span> <span style="color:Blue;">long</span> num = 3;   

        <span style="color:Blue;">private</span> <span style="color:Blue;">bool</span> continueCalculating = <span style="color:Blue;">false</span>;

        <span style="color:Blue;">public</span> Window1() : <span style="color:Blue;">base</span>()
        {
            InitializeComponent();
        }

        <span style="color:Blue;">private</span> <span style="color:Blue;">void</span> StartOrStop(<span style="color:Blue;">object</span> sender, EventArgs e)
        {
            <span style="color:Blue;">if</span> (continueCalculating)
            {
                continueCalculating = <span style="color:Blue;">false</span>;
                startStopButton.Content = <span style="color:#A31515;">"Resume"</span>;
            }
            <span style="color:Blue;">else</span>
            {
                continueCalculating = <span style="color:Blue;">true</span>;
                startStopButton.Content = <span style="color:#A31515;">"Stop"</span>;
                startStopButton.Dispatcher.BeginInvoke(
                    DispatcherPriority.Normal,
                    <span style="color:Blue;">new</span> NextPrimeDelegate(CheckNextNumber));
            }
        }

        <span style="color:Blue;">public</span> <span style="color:Blue;">void</span> CheckNextNumber()
        {
            <span style="color:Green;">// Reset flag.</span>
            NotAPrime = <span style="color:Blue;">false</span>;

            <span style="color:Blue;">for</span> (<span style="color:Blue;">long</span> i = 3; i &lt;= Math.Sqrt(num); i++)
            {
                <span style="color:Blue;">if</span> (num % i == 0)
                {
                    <span style="color:Green;">// Set not a prime flag to true.</span>
                    NotAPrime = <span style="color:Blue;">true</span>;
                    <span style="color:Blue;">break</span>;
                }
            }

            <span style="color:Green;">// If a prime number. </span>
            <span style="color:Blue;">if</span> (!NotAPrime)
            {
                bigPrime.Text = num.ToString();
            }

            num += 2;
            <span style="color:Blue;">if</span> (continueCalculating)
            {
                startStopButton.Dispatcher.BeginInvoke(
                    System.Windows.Threading.DispatcherPriority.SystemIdle, 
                    <span style="color:Blue;">new</span> NextPrimeDelegate(<span style="color:Blue;">this</span>.CheckNextNumber));
            }
        }

        <span style="color:Blue;">private</span> <span style="color:Blue;">bool</span> NotAPrime = <span style="color:Blue;">false</span>;
    }
}
</pre></div>
            
        </div>
    </div>
</div>
</div>
                <p>The following example shows the event handler for the <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.controls.button.aspx">Button</a></span>. </p>
                <div>
<div id="code-snippet-4" class="codeSnippetContainer" xmlns="">
    <div class="codeSnippetContainerTabs">
        <div class="codeSnippetContainerTabActive" dir="ltr"><a>C#</a></div><div class="codeSnippetContainerTab" dir="ltr"><a href="http://msdn.microsoft.com/en-us/library/ms741870.aspx?cs-save-lang=1&amp;cs-lang=vb#code-snippet-4">VB</a></div>
    </div>
    <div class="codeSnippetContainerCodeContainer">
        <div class="codeSnippetToolBar">
            <div class="codeSnippetToolBarText">
                <a name="CodeSnippetCopyLink" style="display: none;" title="Copy to clipboard." href="javascript:if (window.epx.codeSnippet)window.epx.codeSnippet.copyCode('CodeSnippetContainerCode_314cdb90-4acb-4a86-8494-d4938db07fd0');">Copy</a>
            </div>
        </div>
        <div id="CodeSnippetContainerCode_314cdb90-4acb-4a86-8494-d4938db07fd0" class="codeSnippetContainerCode" dir="ltr">
            <div style="color:Black;"><pre>
<span style="color:Blue;">private</span> <span style="color:Blue;">void</span> StartOrStop(<span style="color:Blue;">object</span> sender, EventArgs e)
{
    <span style="color:Blue;">if</span> (continueCalculating)
    {
        continueCalculating = <span style="color:Blue;">false</span>;
        startStopButton.Content = <span style="color:#A31515;">"Resume"</span>;
    }
    <span style="color:Blue;">else</span>
    {
        continueCalculating = <span style="color:Blue;">true</span>;
        startStopButton.Content = <span style="color:#A31515;">"Stop"</span>;
        startStopButton.Dispatcher.BeginInvoke(
            DispatcherPriority.Normal,
            <span style="color:Blue;">new</span> NextPrimeDelegate(CheckNextNumber));
    }
}
</pre></div>
            
        </div>
    </div>
</div>
</div>
                <p>Besides updating the text on the <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.controls.button.aspx">Button</a></span>, this handler is responsible for scheduling the first prime number check by adding a delegate to the <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcher.aspx">Dispatcher</a></span> queue. Sometime after this event handler has completed its work, the <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcher.aspx">Dispatcher</a></span> will select this delegate for execution.</p>
                <p>As we mentioned earlier, <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcher.begininvoke.aspx">BeginInvoke</a></span> is the <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcher.aspx">Dispatcher</a></span> member used to schedule a delegate for execution. In this case, we choose the <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcherpriority.aspx">SystemIdle</a></span> priority. The <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcher.aspx">Dispatcher</a></span> will execute this delegate only when there are no important events to process. UI responsiveness is more important than number checking. We also pass a new delegate representing the number-checking routine.</p>
                <div>
<div id="code-snippet-5" class="codeSnippetContainer" xmlns="">
    <div class="codeSnippetContainerTabs">
        <div class="codeSnippetContainerTabActive" dir="ltr"><a>C#</a></div><div class="codeSnippetContainerTab" dir="ltr"><a href="http://msdn.microsoft.com/en-us/library/ms741870.aspx?cs-save-lang=1&amp;cs-lang=vb#code-snippet-5">VB</a></div>
    </div>
    <div class="codeSnippetContainerCodeContainer">
        <div class="codeSnippetToolBar">
            <div class="codeSnippetToolBarText">
                <a name="CodeSnippetCopyLink" style="display: none;" title="Copy to clipboard." href="javascript:if (window.epx.codeSnippet)window.epx.codeSnippet.copyCode('CodeSnippetContainerCode_6147aea4-a4e0-4dc6-80fe-657a781098a9');">Copy</a>
            </div>
        </div>
        <div id="CodeSnippetContainerCode_6147aea4-a4e0-4dc6-80fe-657a781098a9" class="codeSnippetContainerCode" dir="ltr">
            <div style="color:Black;"><pre>
<span style="color:Blue;">public</span> <span style="color:Blue;">void</span> CheckNextNumber()
{
    <span style="color:Green;">// Reset flag.</span>
    NotAPrime = <span style="color:Blue;">false</span>;

    <span style="color:Blue;">for</span> (<span style="color:Blue;">long</span> i = 3; i &lt;= Math.Sqrt(num); i++)
    {
        <span style="color:Blue;">if</span> (num % i == 0)
        {
            <span style="color:Green;">// Set not a prime flag to true.</span>
            NotAPrime = <span style="color:Blue;">true</span>;
            <span style="color:Blue;">break</span>;
        }
    }

    <span style="color:Green;">// If a prime number. </span>
    <span style="color:Blue;">if</span> (!NotAPrime)
    {
        bigPrime.Text = num.ToString();
    }

    num += 2;
    <span style="color:Blue;">if</span> (continueCalculating)
    {
        startStopButton.Dispatcher.BeginInvoke(
            System.Windows.Threading.DispatcherPriority.SystemIdle, 
            <span style="color:Blue;">new</span> NextPrimeDelegate(<span style="color:Blue;">this</span>.CheckNextNumber));
    }
}

<span style="color:Blue;">private</span> <span style="color:Blue;">bool</span> NotAPrime = <span style="color:Blue;">false</span>;
</pre></div>
            
        </div>
    </div>
</div>
</div>
                <p>This method checks if the next odd number is prime. If it is prime, the method directly updates the <span class="code">bigPrime</span> <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.controls.textblock.aspx">TextBlock</a></span> to reflect its discovery. We can do this because the calculation is occurring in the same thread that was used to create the component. Had we chosen to use a separate thread for the calculation, we would have to use a more complicated synchronization mechanism and execute the update in the UI thread. We’ll demonstrate this situation next.</p>
                <p>For the complete source code for this sample, see the <a href="http://go.microsoft.com/fwlink/?LinkID=160038" target="_blank">Single-Threaded Application with Long-Running Calculation Sample</a></p>
              </div>
            </div>
            <a id="weather_sim">
              
            </a>
            <div>
              <div class="LW_CollapsibleArea_TitleDiv">
                <div>
                  <a href="javascript:void(0)" class="LW_CollapsibleArea_TitleAhref" title="Collapse">
                    <span class="cl_CollapsibleArea_expanding LW_CollapsibleArea_Img"></span>
                    <span class="LW_CollapsibleArea_Title">Handling a Blocking Operation with a Background Thread</span>
                  </a>
                  <div class="LW_CollapsibleArea_HrDiv">
                    <hr class="LW_CollapsibleArea_Hr" />
                  </div>
                </div>
              </div>
              <div class="sectionblock">
                <a id="sectionToggle3">
                  
                </a>
                <p>Handling blocking operations in a graphical application can be difficult. We don’t want to call blocking methods from event handlers because the application will appear to freeze up. We can use a separate thread to handle these operations, but when we’re done, we have to synchronize with the UI thread because we can’t directly modify the GUI from our worker thread. We can use <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcher.invoke.aspx">Invoke</a></span> or <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcher.begininvoke.aspx">BeginInvoke</a></span> to insert delegates into the <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcher.aspx">Dispatcher</a></span> of the UI thread. Eventually, these delegates will be executed with permission to modify UI elements.</p>
                <p>In this example, we mimic a remote procedure call that retrieves a weather forecast. We use a separate worker thread to execute this call, and we schedule an update method in the <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcher.aspx">Dispatcher</a></span> of the UI thread when we’re finished.</p>
                <img id="ThreadingWeatherUIScreenShot" alt="Weather UI screen shot" src="http://i.msdn.microsoft.com/dynimg/IC79081.png" title="Weather UI screen shot" xmlns="" />
                <div>
<div id="code-snippet-6" class="codeSnippetContainer" xmlns="">
    <div class="codeSnippetContainerTabs">
        <div class="codeSnippetContainerTabActive" dir="ltr"><a>C#</a></div><div class="codeSnippetContainerTab" dir="ltr"><a href="http://msdn.microsoft.com/en-us/library/ms741870.aspx?cs-save-lang=1&amp;cs-lang=vb#code-snippet-6">VB</a></div>
    </div>
    <div class="codeSnippetContainerCodeContainer">
        <div class="codeSnippetToolBar">
            <div class="codeSnippetToolBarText">
                <a name="CodeSnippetCopyLink" style="display: none;" title="Copy to clipboard." href="javascript:if (window.epx.codeSnippet)window.epx.codeSnippet.copyCode('CodeSnippetContainerCode_83ab3186-ed39-4605-804e-dd2993425614');">Copy</a>
            </div>
        </div>
        <div id="CodeSnippetContainerCode_83ab3186-ed39-4605-804e-dd2993425614" class="codeSnippetContainerCode" dir="ltr">
            <div style="color:Black;"><pre>
<span style="color:Blue;">using</span> System;
<span style="color:Blue;">using</span> System.Windows;
<span style="color:Blue;">using</span> System.Windows.Controls;
<span style="color:Blue;">using</span> System.Windows.Media;
<span style="color:Blue;">using</span> System.Windows.Media.Animation;
<span style="color:Blue;">using</span> System.Windows.Media.Imaging;
<span style="color:Blue;">using</span> System.Windows.Shapes;
<span style="color:Blue;">using</span> System.Windows.Threading;
<span style="color:Blue;">using</span> System.Threading;

<span style="color:Blue;">namespace</span> SDKSamples
{
    <span style="color:Blue;">public</span> <span style="color:Blue;">partial</span> <span style="color:Blue;">class</span> Window1 : Window
    {
        <span style="color:Green;">// Delegates to be used in placking jobs onto the Dispatcher. </span>
        <span style="color:Blue;">private</span> <span style="color:Blue;">delegate</span> <span style="color:Blue;">void</span> NoArgDelegate();
        <span style="color:Blue;">private</span> <span style="color:Blue;">delegate</span> <span style="color:Blue;">void</span> OneArgDelegate(String arg);

        <span style="color:Green;">// Storyboards for the animations. </span>
        <span style="color:Blue;">private</span> Storyboard showClockFaceStoryboard;
        <span style="color:Blue;">private</span> Storyboard hideClockFaceStoryboard;
        <span style="color:Blue;">private</span> Storyboard showWeatherImageStoryboard;
        <span style="color:Blue;">private</span> Storyboard hideWeatherImageStoryboard;

        <span style="color:Blue;">public</span> Window1(): <span style="color:Blue;">base</span>()
        {
            InitializeComponent();
        }  

        <span style="color:Blue;">private</span> <span style="color:Blue;">void</span> Window_Loaded(<span style="color:Blue;">object</span> sender, RoutedEventArgs e)
        {
            <span style="color:Green;">// Load the storyboard resources.</span>
            showClockFaceStoryboard = 
                (Storyboard)<span style="color:Blue;">this</span>.Resources[<span style="color:#A31515;">"ShowClockFaceStoryboard"</span>];
            hideClockFaceStoryboard = 
                (Storyboard)<span style="color:Blue;">this</span>.Resources[<span style="color:#A31515;">"HideClockFaceStoryboard"</span>];
            showWeatherImageStoryboard = 
                (Storyboard)<span style="color:Blue;">this</span>.Resources[<span style="color:#A31515;">"ShowWeatherImageStoryboard"</span>];
            hideWeatherImageStoryboard = 
                (Storyboard)<span style="color:Blue;">this</span>.Resources[<span style="color:#A31515;">"HideWeatherImageStoryboard"</span>];   
        }

        <span style="color:Blue;">private</span> <span style="color:Blue;">void</span> ForecastButtonHandler(<span style="color:Blue;">object</span> sender, RoutedEventArgs e)
        {
            <span style="color:Green;">// Change the status image and start the rotation animation.</span>
            fetchButton.IsEnabled = <span style="color:Blue;">false</span>;
            fetchButton.Content = <span style="color:#A31515;">"Contacting Server"</span>;
            weatherText.Text = <span style="color:#A31515;">""</span>;
            hideWeatherImageStoryboard.Begin(<span style="color:Blue;">this</span>);

            <span style="color:Green;">// Start fetching the weather forecast asynchronously.</span>
            NoArgDelegate fetcher = <span style="color:Blue;">new</span> NoArgDelegate(
                <span style="color:Blue;">this</span>.FetchWeatherFromServer);

            fetcher.BeginInvoke(<span style="color:Blue;">null</span>, <span style="color:Blue;">null</span>);
        }

        <span style="color:Blue;">private</span> <span style="color:Blue;">void</span> FetchWeatherFromServer()
        {
            <span style="color:Green;">// Simulate the delay from network access.</span>
            Thread.Sleep(4000);              

            <span style="color:Green;">// Tried and true method for weather forecasting - random numbers.</span>
            Random rand = <span style="color:Blue;">new</span> Random();
            String weather;

            <span style="color:Blue;">if</span> (rand.Next(2) == 0)
            {
                weather = <span style="color:#A31515;">"rainy"</span>;
            }
            <span style="color:Blue;">else</span>
            {
                weather = <span style="color:#A31515;">"sunny"</span>;
            }

            <span style="color:Green;">// Schedule the update function in the UI thread.</span>
            tomorrowsWeather.Dispatcher.BeginInvoke(
                System.Windows.Threading.DispatcherPriority.Normal,
                <span style="color:Blue;">new</span> OneArgDelegate(UpdateUserInterface), 
                weather);
        }

        <span style="color:Blue;">private</span> <span style="color:Blue;">void</span> UpdateUserInterface(String weather)
        {    
            <span style="color:Green;">//Set the weather image </span>
            <span style="color:Blue;">if</span> (weather == <span style="color:#A31515;">"sunny"</span>)
            {       
                weatherIndicatorImage.Source = (ImageSource)<span style="color:Blue;">this</span>.Resources[
                    <span style="color:#A31515;">"SunnyImageSource"</span>];
            }
            <span style="color:Blue;">else</span> <span style="color:Blue;">if</span> (weather == <span style="color:#A31515;">"rainy"</span>)
            {
                weatherIndicatorImage.Source = (ImageSource)<span style="color:Blue;">this</span>.Resources[
                    <span style="color:#A31515;">"RainingImageSource"</span>];
            }

            <span style="color:Green;">//Stop clock animation</span>
            showClockFaceStoryboard.Stop(<span style="color:Blue;">this</span>);
            hideClockFaceStoryboard.Begin(<span style="color:Blue;">this</span>);

            <span style="color:Green;">//Update UI text</span>
            fetchButton.IsEnabled = <span style="color:Blue;">true</span>;
            fetchButton.Content = <span style="color:#A31515;">"Fetch Forecast"</span>;
            weatherText.Text = weather;     
        }

        <span style="color:Blue;">private</span> <span style="color:Blue;">void</span> HideClockFaceStoryboard_Completed(<span style="color:Blue;">object</span> sender,
            EventArgs args)
        {         
            showWeatherImageStoryboard.Begin(<span style="color:Blue;">this</span>);
        }

        <span style="color:Blue;">private</span> <span style="color:Blue;">void</span> HideWeatherImageStoryboard_Completed(<span style="color:Blue;">object</span> sender,
            EventArgs args)
        {           
            showClockFaceStoryboard.Begin(<span style="color:Blue;">this</span>, <span style="color:Blue;">true</span>);
        }        
    }
}
</pre></div>
            
        </div>
    </div>
</div>
</div>
                <p>The following are some of the details to be noted.</p>
                <ul>
                  <li>
                    <p>Creating the Button Handler</p>
                    <div>
<div id="code-snippet-7" class="codeSnippetContainer" xmlns="">
    <div class="codeSnippetContainerTabs">
        <div class="codeSnippetContainerTabActive" dir="ltr"><a>C#</a></div><div class="codeSnippetContainerTab" dir="ltr"><a href="http://msdn.microsoft.com/en-us/library/ms741870.aspx?cs-save-lang=1&amp;cs-lang=vb#code-snippet-7">VB</a></div>
    </div>
    <div class="codeSnippetContainerCodeContainer">
        <div class="codeSnippetToolBar">
            <div class="codeSnippetToolBarText">
                <a name="CodeSnippetCopyLink" style="display: none;" title="Copy to clipboard." href="javascript:if (window.epx.codeSnippet)window.epx.codeSnippet.copyCode('CodeSnippetContainerCode_f9d5741a-953f-4837-a4bd-8cc01d56ac70');">Copy</a>
            </div>
        </div>
        <div id="CodeSnippetContainerCode_f9d5741a-953f-4837-a4bd-8cc01d56ac70" class="codeSnippetContainerCode" dir="ltr">
            <div style="color:Black;"><pre>
<span style="color:Blue;">private</span> <span style="color:Blue;">void</span> ForecastButtonHandler(<span style="color:Blue;">object</span> sender, RoutedEventArgs e)
{
    <span style="color:Green;">// Change the status image and start the rotation animation.</span>
    fetchButton.IsEnabled = <span style="color:Blue;">false</span>;
    fetchButton.Content = <span style="color:#A31515;">"Contacting Server"</span>;
    weatherText.Text = <span style="color:#A31515;">""</span>;
    hideWeatherImageStoryboard.Begin(<span style="color:Blue;">this</span>);

    <span style="color:Green;">// Start fetching the weather forecast asynchronously.</span>
    NoArgDelegate fetcher = <span style="color:Blue;">new</span> NoArgDelegate(
        <span style="color:Blue;">this</span>.FetchWeatherFromServer);

    fetcher.BeginInvoke(<span style="color:Blue;">null</span>, <span style="color:Blue;">null</span>);
}
</pre></div>
            
        </div>
    </div>
</div>
</div>
                  </li>
                </ul>
                <p>When the button is clicked, we display the clock drawing and start animating it. We disable the button. We invoke the <span class="code">FetchWeatherFromServer</span> method in a new thread, and then we return, allowing the <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcher.aspx">Dispatcher</a></span> to process events while we wait to collect the weather forecast.</p>
                <ul>
                  <li>
                    <p>Fetching the Weather</p>
                    <div>
<div id="code-snippet-8" class="codeSnippetContainer" xmlns="">
    <div class="codeSnippetContainerTabs">
        <div class="codeSnippetContainerTabActive" dir="ltr"><a>C#</a></div><div class="codeSnippetContainerTab" dir="ltr"><a href="http://msdn.microsoft.com/en-us/library/ms741870.aspx?cs-save-lang=1&amp;cs-lang=vb#code-snippet-8">VB</a></div>
    </div>
    <div class="codeSnippetContainerCodeContainer">
        <div class="codeSnippetToolBar">
            <div class="codeSnippetToolBarText">
                <a name="CodeSnippetCopyLink" style="display: none;" title="Copy to clipboard." href="javascript:if (window.epx.codeSnippet)window.epx.codeSnippet.copyCode('CodeSnippetContainerCode_6273366f-ffe5-46f7-9284-c879a8e3f5b5');">Copy</a>
            </div>
        </div>
        <div id="CodeSnippetContainerCode_6273366f-ffe5-46f7-9284-c879a8e3f5b5" class="codeSnippetContainerCode" dir="ltr">
            <div style="color:Black;"><pre>
<span style="color:Blue;">private</span> <span style="color:Blue;">void</span> FetchWeatherFromServer()
{
    <span style="color:Green;">// Simulate the delay from network access.</span>
    Thread.Sleep(4000);              

    <span style="color:Green;">// Tried and true method for weather forecasting - random numbers.</span>
    Random rand = <span style="color:Blue;">new</span> Random();
    String weather;

    <span style="color:Blue;">if</span> (rand.Next(2) == 0)
    {
        weather = <span style="color:#A31515;">"rainy"</span>;
    }
    <span style="color:Blue;">else</span>
    {
        weather = <span style="color:#A31515;">"sunny"</span>;
    }

    <span style="color:Green;">// Schedule the update function in the UI thread.</span>
    tomorrowsWeather.Dispatcher.BeginInvoke(
        System.Windows.Threading.DispatcherPriority.Normal,
        <span style="color:Blue;">new</span> OneArgDelegate(UpdateUserInterface), 
        weather);
}
</pre></div>
            
        </div>
    </div>
</div>
</div>
                  </li>
                </ul>
                <p>To keep things simple, we don’t actually have any networking code in this example. Instead, we simulate the delay of network access by putting our new thread to sleep for four seconds. In this time, the original UI thread is still running and responding to events. To show this, we’ve left an animation running, and the minimize and maximize buttons also continue to work.</p>
                <p>When the delay is finished, and we’ve randomly selected our weather forecast, it’s time to report back to the UI thread. We do this by scheduling a call to <span class="code">UpdateUserInterface</span> in the UI thread using that thread’s <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcher.aspx">Dispatcher</a></span>. We pass a string describing the weather to this scheduled method call.</p>
                <ul>
                  <li>
                    <p>Updating the UI</p>
                    <div>
<div id="code-snippet-9" class="codeSnippetContainer" xmlns="">
    <div class="codeSnippetContainerTabs">
        <div class="codeSnippetContainerTabActive" dir="ltr"><a>C#</a></div><div class="codeSnippetContainerTab" dir="ltr"><a href="http://msdn.microsoft.com/en-us/library/ms741870.aspx?cs-save-lang=1&amp;cs-lang=vb#code-snippet-9">VB</a></div>
    </div>
    <div class="codeSnippetContainerCodeContainer">
        <div class="codeSnippetToolBar">
            <div class="codeSnippetToolBarText">
                <a name="CodeSnippetCopyLink" style="display: none;" title="Copy to clipboard." href="javascript:if (window.epx.codeSnippet)window.epx.codeSnippet.copyCode('CodeSnippetContainerCode_3cd7b9c5-8d78-49e1-9fe8-1160d5ff0aec');">Copy</a>
            </div>
        </div>
        <div id="CodeSnippetContainerCode_3cd7b9c5-8d78-49e1-9fe8-1160d5ff0aec" class="codeSnippetContainerCode" dir="ltr">
            <div style="color:Black;"><pre>
<span style="color:Blue;">private</span> <span style="color:Blue;">void</span> UpdateUserInterface(String weather)
{    
    <span style="color:Green;">//Set the weather image </span>
    <span style="color:Blue;">if</span> (weather == <span style="color:#A31515;">"sunny"</span>)
    {       
        weatherIndicatorImage.Source = (ImageSource)<span style="color:Blue;">this</span>.Resources[
            <span style="color:#A31515;">"SunnyImageSource"</span>];
    }
    <span style="color:Blue;">else</span> <span style="color:Blue;">if</span> (weather == <span style="color:#A31515;">"rainy"</span>)
    {
        weatherIndicatorImage.Source = (ImageSource)<span style="color:Blue;">this</span>.Resources[
            <span style="color:#A31515;">"RainingImageSource"</span>];
    }

    <span style="color:Green;">//Stop clock animation</span>
    showClockFaceStoryboard.Stop(<span style="color:Blue;">this</span>);
    hideClockFaceStoryboard.Begin(<span style="color:Blue;">this</span>);

    <span style="color:Green;">//Update UI text</span>
    fetchButton.IsEnabled = <span style="color:Blue;">true</span>;
    fetchButton.Content = <span style="color:#A31515;">"Fetch Forecast"</span>;
    weatherText.Text = weather;     
}
</pre></div>
            
        </div>
    </div>
</div>
</div>
                  </li>
                </ul>
                <p>When the <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcher.aspx">Dispatcher</a></span> in the UI thread has time, it executes the scheduled call to <span class="code">UpdateUserInterface</span>. This method stops the clock animation and chooses an image to describe the weather. It displays this image and restores the "fetch forecast" button.</p>
              </div>
            </div>
            <a id="multi_browser">
              
            </a>
            <div>
              <div class="LW_CollapsibleArea_TitleDiv">
                <div>
                  <a href="javascript:void(0)" class="LW_CollapsibleArea_TitleAhref" title="Collapse">
                    <span class="cl_CollapsibleArea_expanding LW_CollapsibleArea_Img"></span>
                    <span class="LW_CollapsibleArea_Title">Multiple Windows, Multiple Threads</span>
                  </a>
                  <div class="LW_CollapsibleArea_HrDiv">
                    <hr class="LW_CollapsibleArea_Hr" />
                  </div>
                </div>
              </div>
              <div class="sectionblock">
                <a id="sectionToggle4">
                  
                </a>
                <p>Some WPF applications require multiple top-level windows. It is perfectly acceptable for one Thread/<span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcher.aspx">Dispatcher</a></span> combination to manage multiple windows, but sometimes several threads do a better job. This is especially true if there is any chance that one of the windows will monopolize the thread.</p>
                <p>Windows Explorer works in this fashion. Each new Explorer window belongs to the original process, but it is created under the control of an independent thread.</p>
                <p>By using a WPF <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.controls.frame.aspx">Frame</a></span> control, we can display Web pages. We can easily create a simple Internet Explorer substitute. We start with an important feature: the ability to open a new explorer window. When the user clicks the "new window" button, we launch a copy of our window in a separate thread. This way, long-running or blocking operations in one of the windows won’t lock all the other windows.</p>
                <p>In reality, the Web browser model has its own complicated threading model. We’ve chosen it because it should be familiar to most readers.</p>
                <p>The following example shows the code.</p>
                <div>
<div id="code-snippet-10" class="codeSnippetContainer" xmlns="">
    <div class="codeSnippetContainerTabs">
        <div class="codeSnippetContainerTabSingle" dir="ltr"><a>XAML</a></div>
    </div>
    <div class="codeSnippetContainerCodeContainer">
        <div class="codeSnippetToolBar">
            <div class="codeSnippetToolBarText">
                <a name="CodeSnippetCopyLink" style="display: none;" title="Copy to clipboard." href="javascript:if (window.epx.codeSnippet)window.epx.codeSnippet.copyCode('CodeSnippetContainerCode_982f71ea-efcb-4f50-b642-67266bc7340b');">Copy</a>
            </div>
        </div>
        <div id="CodeSnippetContainerCode_982f71ea-efcb-4f50-b642-67266bc7340b" class="codeSnippetContainerCode" dir="ltr">
            <div style="color:Black;"><pre>
<span style="color:Blue;">&lt;</span><span style="color:#A31515;">Window</span> <span style="color:Red;">x:Class</span><span style="color:Blue;">=</span><span style="color:Black;">"</span><span style="color:Blue;">SDKSamples.Window1</span><span style="color:Black;">"</span>
    <span style="color:Red;">xmlns</span><span style="color:Blue;">=</span><span style="color:Black;">"</span><span style="color:Blue;">http://schemas.microsoft.com/winfx/2006/xaml/presentation</span><span style="color:Black;">"</span>
    <span style="color:Red;">xmlns:x</span><span style="color:Blue;">=</span><span style="color:Black;">"</span><span style="color:Blue;">http://schemas.microsoft.com/winfx/2006/xaml</span><span style="color:Black;">"</span>
    <span style="color:Red;">Title</span><span style="color:Blue;">=</span><span style="color:Black;">"</span><span style="color:Blue;">MultiBrowse</span><span style="color:Black;">"</span>
    <span style="color:Red;">Height</span><span style="color:Blue;">=</span><span style="color:Black;">"</span><span style="color:Blue;">600</span><span style="color:Black;">"</span> 
    <span style="color:Red;">Width</span><span style="color:Blue;">=</span><span style="color:Black;">"</span><span style="color:Blue;">800</span><span style="color:Black;">"</span>
    <span style="color:Red;">Loaded</span><span style="color:Blue;">=</span><span style="color:Black;">"</span><span style="color:Blue;">OnLoaded</span><span style="color:Black;">"</span>
    <span style="color:Blue;">&gt;</span>
  <span style="color:Blue;">&lt;</span><span style="color:#A31515;">StackPanel</span> <span style="color:Red;">Name</span><span style="color:Blue;">=</span><span style="color:Black;">"</span><span style="color:Blue;">Stack</span><span style="color:Black;">"</span> <span style="color:Red;">Orientation</span><span style="color:Blue;">=</span><span style="color:Black;">"</span><span style="color:Blue;">Vertical</span><span style="color:Black;">"</span><span style="color:Blue;">&gt;</span>
    <span style="color:Blue;">&lt;</span><span style="color:#A31515;">StackPanel</span> <span style="color:Red;">Orientation</span><span style="color:Blue;">=</span><span style="color:Black;">"</span><span style="color:Blue;">Horizontal</span><span style="color:Black;">"</span><span style="color:Blue;">&gt;</span>
      <span style="color:Blue;">&lt;</span><span style="color:#A31515;">Button</span> <span style="color:Red;">Content</span><span style="color:Blue;">=</span><span style="color:Black;">"</span><span style="color:Blue;">New Window</span><span style="color:Black;">"</span>
              <span style="color:Red;">Click</span><span style="color:Blue;">=</span><span style="color:Black;">"</span><span style="color:Blue;">NewWindowHandler</span><span style="color:Black;">"</span> <span style="color:Blue;">/&gt;</span>
      <span style="color:Blue;">&lt;</span><span style="color:#A31515;">TextBox</span> <span style="color:Red;">Name</span><span style="color:Blue;">=</span><span style="color:Black;">"</span><span style="color:Blue;">newLocation</span><span style="color:Black;">"</span>
               <span style="color:Red;">Width</span><span style="color:Blue;">=</span><span style="color:Black;">"</span><span style="color:Blue;">500</span><span style="color:Black;">"</span> <span style="color:Blue;">/&gt;</span>
      <span style="color:Blue;">&lt;</span><span style="color:#A31515;">Button</span> <span style="color:Red;">Content</span><span style="color:Blue;">=</span><span style="color:Black;">"</span><span style="color:Blue;">GO!</span><span style="color:Black;">"</span>
              <span style="color:Red;">Click</span><span style="color:Blue;">=</span><span style="color:Black;">"</span><span style="color:Blue;">Browse</span><span style="color:Black;">"</span> <span style="color:Blue;">/&gt;</span>
    <span style="color:Blue;">&lt;/</span><span style="color:#A31515;">StackPanel</span><span style="color:Blue;">&gt;</span>

    <span style="color:Blue;">&lt;</span><span style="color:#A31515;">Frame</span> <span style="color:Red;">Name</span><span style="color:Blue;">=</span><span style="color:Black;">"</span><span style="color:Blue;">placeHolder</span><span style="color:Black;">"</span>
            <span style="color:Red;">Width</span><span style="color:Blue;">=</span><span style="color:Black;">"</span><span style="color:Blue;">800</span><span style="color:Black;">"</span>
            <span style="color:Red;">Height</span><span style="color:Blue;">=</span><span style="color:Black;">"</span><span style="color:Blue;">550</span><span style="color:Black;">"</span><span style="color:Blue;">&gt;</span><span style="color:Blue;">&lt;/</span><span style="color:#A31515;">Frame</span><span style="color:Blue;">&gt;</span>
  <span style="color:Blue;">&lt;/</span><span style="color:#A31515;">StackPanel</span><span style="color:Blue;">&gt;</span>
<span style="color:Blue;">&lt;/</span><span style="color:#A31515;">Window</span><span style="color:Blue;">&gt;</span>
</pre></div>
            
        </div>
    </div>
</div>
</div>
                <div>
<div id="code-snippet-11" class="codeSnippetContainer" xmlns="">
    <div class="codeSnippetContainerTabs">
        <div class="codeSnippetContainerTabActive" dir="ltr"><a>C#</a></div><div class="codeSnippetContainerTab" dir="ltr"><a href="http://msdn.microsoft.com/en-us/library/ms741870.aspx?cs-save-lang=1&amp;cs-lang=vb#code-snippet-11">VB</a></div>
    </div>
    <div class="codeSnippetContainerCodeContainer">
        <div class="codeSnippetToolBar">
            <div class="codeSnippetToolBarText">
                <a name="CodeSnippetCopyLink" style="display: none;" title="Copy to clipboard." href="javascript:if (window.epx.codeSnippet)window.epx.codeSnippet.copyCode('CodeSnippetContainerCode_749d5dd4-617b-4ab6-a444-f691c935582d');">Copy</a>
            </div>
        </div>
        <div id="CodeSnippetContainerCode_749d5dd4-617b-4ab6-a444-f691c935582d" class="codeSnippetContainerCode" dir="ltr">
            <div style="color:Black;"><pre>
<span style="color:Blue;">using</span> System;
<span style="color:Blue;">using</span> System.Windows;
<span style="color:Blue;">using</span> System.Windows.Controls;
<span style="color:Blue;">using</span> System.Windows.Data;
<span style="color:Blue;">using</span> System.Windows.Threading;
<span style="color:Blue;">using</span> System.Threading;


<span style="color:Blue;">namespace</span> SDKSamples
{
    <span style="color:Blue;">public</span> <span style="color:Blue;">partial</span> <span style="color:Blue;">class</span> Window1 : Window
    {

        <span style="color:Blue;">public</span> Window1() : <span style="color:Blue;">base</span>()
        {
            InitializeComponent();
        }

        <span style="color:Blue;">private</span> <span style="color:Blue;">void</span> OnLoaded(<span style="color:Blue;">object</span> sender, RoutedEventArgs e)
        {
           placeHolder.Source = <span style="color:Blue;">new</span> Uri(<span style="color:#A31515;">"http://www.msn.com"</span>);
        }

        <span style="color:Blue;">private</span> <span style="color:Blue;">void</span> Browse(<span style="color:Blue;">object</span> sender, RoutedEventArgs e)
        {
            placeHolder.Source = <span style="color:Blue;">new</span> Uri(newLocation.Text);
        }

        <span style="color:Blue;">private</span> <span style="color:Blue;">void</span> NewWindowHandler(<span style="color:Blue;">object</span> sender, RoutedEventArgs e)
        {       
            Thread newWindowThread = <span style="color:Blue;">new</span> Thread(<span style="color:Blue;">new</span> ThreadStart(ThreadStartingPoint));
            newWindowThread.SetApartmentState(ApartmentState.STA);
            newWindowThread.IsBackground = <span style="color:Blue;">true</span>;
            newWindowThread.Start();
        }

        <span style="color:Blue;">private</span> <span style="color:Blue;">void</span> ThreadStartingPoint()
        {
            Window1 tempWindow = <span style="color:Blue;">new</span> Window1();
            tempWindow.Show();       
            System.Windows.Threading.Dispatcher.Run();
        }
    }
}
</pre></div>
            
        </div>
    </div>
</div>
</div>
                <p>The following threading segments of this code are the most interesting to us in this context:</p>
                <div>
<div id="code-snippet-12" class="codeSnippetContainer" xmlns="">
    <div class="codeSnippetContainerTabs">
        <div class="codeSnippetContainerTabActive" dir="ltr"><a>C#</a></div><div class="codeSnippetContainerTab" dir="ltr"><a href="http://msdn.microsoft.com/en-us/library/ms741870.aspx?cs-save-lang=1&amp;cs-lang=vb#code-snippet-12">VB</a></div>
    </div>
    <div class="codeSnippetContainerCodeContainer">
        <div class="codeSnippetToolBar">
            <div class="codeSnippetToolBarText">
                <a name="CodeSnippetCopyLink" style="display: none;" title="Copy to clipboard." href="javascript:if (window.epx.codeSnippet)window.epx.codeSnippet.copyCode('CodeSnippetContainerCode_2333a38d-e6ab-4e96-ad32-9b702601dccf');">Copy</a>
            </div>
        </div>
        <div id="CodeSnippetContainerCode_2333a38d-e6ab-4e96-ad32-9b702601dccf" class="codeSnippetContainerCode" dir="ltr">
            <div style="color:Black;"><pre>
<span style="color:Blue;">private</span> <span style="color:Blue;">void</span> NewWindowHandler(<span style="color:Blue;">object</span> sender, RoutedEventArgs e)
{       
    Thread newWindowThread = <span style="color:Blue;">new</span> Thread(<span style="color:Blue;">new</span> ThreadStart(ThreadStartingPoint));
    newWindowThread.SetApartmentState(ApartmentState.STA);
    newWindowThread.IsBackground = <span style="color:Blue;">true</span>;
    newWindowThread.Start();
}
</pre></div>
            
        </div>
    </div>
</div>
</div>
                <p>This method is called when the "new window" button is clicked. It creates a new thread and starts it asynchronously.</p>
                <div>
<div id="code-snippet-13" class="codeSnippetContainer" xmlns="">
    <div class="codeSnippetContainerTabs">
        <div class="codeSnippetContainerTabActive" dir="ltr"><a>C#</a></div><div class="codeSnippetContainerTab" dir="ltr"><a href="http://msdn.microsoft.com/en-us/library/ms741870.aspx?cs-save-lang=1&amp;cs-lang=vb#code-snippet-13">VB</a></div>
    </div>
    <div class="codeSnippetContainerCodeContainer">
        <div class="codeSnippetToolBar">
            <div class="codeSnippetToolBarText">
                <a name="CodeSnippetCopyLink" style="display: none;" title="Copy to clipboard." href="javascript:if (window.epx.codeSnippet)window.epx.codeSnippet.copyCode('CodeSnippetContainerCode_0a83e4ce-cebe-43b6-b294-aa52cc8db3f6');">Copy</a>
            </div>
        </div>
        <div id="CodeSnippetContainerCode_0a83e4ce-cebe-43b6-b294-aa52cc8db3f6" class="codeSnippetContainerCode" dir="ltr">
            <div style="color:Black;"><pre>
<span style="color:Blue;">private</span> <span style="color:Blue;">void</span> ThreadStartingPoint()
{
    Window1 tempWindow = <span style="color:Blue;">new</span> Window1();
    tempWindow.Show();       
    System.Windows.Threading.Dispatcher.Run();
}
</pre></div>
            
        </div>
    </div>
</div>
</div>
                <p>This method is the starting point for the new thread. We create a new window under the control of this thread. WPF automatically creates a new <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcher.aspx">Dispatcher</a></span> to manage the new thread. All we have to do to make the window functional is to start the <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcher.aspx">Dispatcher</a></span>.</p>
              </div>
            </div>
          </div>
        </div>
        <a id="stumbling_points">
          
        </a>
        <div>
          <div class="LW_CollapsibleArea_TitleDiv">
            <div>
              <a href="javascript:void(0)" class="LW_CollapsibleArea_TitleAhref" title="Collapse">
                <span class="cl_CollapsibleArea_expanding LW_CollapsibleArea_Img"></span>
                <span class="LW_CollapsibleArea_Title">Technical Details and Stumbling Points</span>
              </a>
              <div class="LW_CollapsibleArea_HrDiv">
                <hr class="LW_CollapsibleArea_Hr" />
              </div>
            </div>
          </div>
          <div class="sectionblock">
            <a id="sectionToggle5">
              
            </a>
            <div>
              <div class="LW_CollapsibleArea_TitleDiv">
                <div>
                  <a href="javascript:void(0)" class="LW_CollapsibleArea_TitleAhref" title="Collapse">
                    <span class="cl_CollapsibleArea_expanding LW_CollapsibleArea_Img"></span>
                    <span class="LW_CollapsibleArea_Title">Writing Components Using Threading</span>
                  </a>
                  <div class="LW_CollapsibleArea_HrDiv">
                    <hr class="LW_CollapsibleArea_Hr" />
                  </div>
                </div>
              </div>
              <div class="sectionblock">
                <a id="sectionToggle6">
                  
                </a>
                <p>The Microsoft .NET Framework Developer's Guide describes a pattern for how a component can expose asynchronous behavior to its clients (see <span><a href="http://msdn.microsoft.com/en-us/library/wewwczdw.aspx">Event-based Asynchronous Pattern Overview</a></span>). For instance, suppose we wanted to package the <span class="code">FetchWeatherFromServer</span> method into a reusable, nongraphical component. Following the standard Microsoft .NET Framework pattern, this would look something like the following.</p>
                <div>
<div id="code-snippet-14" class="codeSnippetContainer" xmlns="">
    <div class="codeSnippetContainerTabs">
        <div class="codeSnippetContainerTabActive" dir="ltr"><a>C#</a></div><div class="codeSnippetContainerTab" dir="ltr"><a href="http://msdn.microsoft.com/en-us/library/ms741870.aspx?cs-save-lang=1&amp;cs-lang=vb#code-snippet-14">VB</a></div>
    </div>
    <div class="codeSnippetContainerCodeContainer">
        <div class="codeSnippetToolBar">
            <div class="codeSnippetToolBarText">
                <a name="CodeSnippetCopyLink" style="display: none;" title="Copy to clipboard." href="javascript:if (window.epx.codeSnippet)window.epx.codeSnippet.copyCode('CodeSnippetContainerCode_44c75266-6e0e-41a1-882f-08967ae7ca7f');">Copy</a>
            </div>
        </div>
        <div id="CodeSnippetContainerCode_44c75266-6e0e-41a1-882f-08967ae7ca7f" class="codeSnippetContainerCode" dir="ltr">
            <div style="color:Black;"><pre>
<span style="color:Blue;">public</span> <span style="color:Blue;">class</span> WeatherComponent : Component
{
    <span style="color:Green;">//gets weather: Synchronous  </span>
    <span style="color:Blue;">public</span> <span style="color:Blue;">string</span> GetWeather()
    {
        <span style="color:Blue;">string</span> weather = <span style="color:#A31515;">""</span>;

        <span style="color:Green;">//predict the weather </span>

        <span style="color:Blue;">return</span> weather;
    }

    <span style="color:Green;">//get weather: Asynchronous  </span>
    <span style="color:Blue;">public</span> <span style="color:Blue;">void</span> GetWeatherAsync()
    {
        <span style="color:Green;">//get the weather</span>
    }

    <span style="color:Blue;">public</span> <span style="color:Blue;">event</span> GetWeatherCompletedEventHandler GetWeatherCompleted;
}

<span style="color:Blue;">public</span> <span style="color:Blue;">class</span> GetWeatherCompletedEventArgs : AsyncCompletedEventArgs
{
    <span style="color:Blue;">public</span> GetWeatherCompletedEventArgs(Exception error, <span style="color:Blue;">bool</span> canceled,
        <span style="color:Blue;">object</span> userState, <span style="color:Blue;">string</span> weather)
        :
        <span style="color:Blue;">base</span>(error, canceled, userState)
    {
        _weather = weather;
    }

    <span style="color:Blue;">public</span> <span style="color:Blue;">string</span> Weather
    {
        <span style="color:Blue;">get</span> { <span style="color:Blue;">return</span> _weather; }
    }
    <span style="color:Blue;">private</span> <span style="color:Blue;">string</span> _weather;
}

<span style="color:Blue;">public</span> <span style="color:Blue;">delegate</span> <span style="color:Blue;">void</span> GetWeatherCompletedEventHandler(<span style="color:Blue;">object</span> sender,
    GetWeatherCompletedEventArgs e);
</pre></div>
            
        </div>
    </div>
</div>
</div>
                <p>
                  <span class="code">GetWeatherAsync</span> would use one of the techniques described earlier, such as creating a background thread, to do the work asynchronously, not blocking the calling thread. </p>
                <p>One of the most important parts of this pattern is calling the <span class="parameter">MethodName</span><span class="code">Completed</span> method on the same thread that called the <span class="parameter">MethodName</span><span class="code">Async</span> method to begin with. You could do this using WPF fairly easily, by storing <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcher.currentdispatcher.aspx">CurrentDispatcher</a></span>—but then the nongraphical component could only be used in WPF applications, not in Windows Forms or ASP.NET programs. </p>
                <p>The <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatchersynchronizationcontext.aspx">DispatcherSynchronizationContext</a></span> class addresses this need—think of it as a simplified version of <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcher.aspx">Dispatcher</a></span> that works with other UI frameworks as well.</p>
                <div>
<div id="code-snippet-15" class="codeSnippetContainer" xmlns="">
    <div class="codeSnippetContainerTabs">
        <div class="codeSnippetContainerTabActive" dir="ltr"><a>C#</a></div><div class="codeSnippetContainerTab" dir="ltr"><a href="http://msdn.microsoft.com/en-us/library/ms741870.aspx?cs-save-lang=1&amp;cs-lang=vb#code-snippet-15">VB</a></div>
    </div>
    <div class="codeSnippetContainerCodeContainer">
        <div class="codeSnippetToolBar">
            <div class="codeSnippetToolBarText">
                <a name="CodeSnippetCopyLink" style="display: none;" title="Copy to clipboard." href="javascript:if (window.epx.codeSnippet)window.epx.codeSnippet.copyCode('CodeSnippetContainerCode_d9e68619-9fb0-41da-96d7-a092ef35a87e');">Copy</a>
            </div>
        </div>
        <div id="CodeSnippetContainerCode_d9e68619-9fb0-41da-96d7-a092ef35a87e" class="codeSnippetContainerCode" dir="ltr">
            <div style="color:Black;"><pre>
<span style="color:Blue;">public</span> <span style="color:Blue;">class</span> WeatherComponent2 : Component
{
    <span style="color:Blue;">public</span> <span style="color:Blue;">string</span> GetWeather()
    {
        <span style="color:Blue;">return</span> fetchWeatherFromServer();
    }

    <span style="color:Blue;">private</span> DispatcherSynchronizationContext requestingContext = <span style="color:Blue;">null</span>;

    <span style="color:Blue;">public</span> <span style="color:Blue;">void</span> GetWeatherAsync()
    {
        <span style="color:Blue;">if</span> (requestingContext != <span style="color:Blue;">null</span>)
            <span style="color:Blue;">throw</span> <span style="color:Blue;">new</span> InvalidOperationException(<span style="color:#A31515;">"This component can only handle 1 async request at a time"</span>);

        requestingContext = (DispatcherSynchronizationContext)DispatcherSynchronizationContext.Current;

        NoArgDelegate fetcher = <span style="color:Blue;">new</span> NoArgDelegate(<span style="color:Blue;">this</span>.fetchWeatherFromServer);

        <span style="color:Green;">// Launch thread</span>
        fetcher.BeginInvoke(<span style="color:Blue;">null</span>, <span style="color:Blue;">null</span>);
    }

    <span style="color:Blue;">private</span> <span style="color:Blue;">void</span> RaiseEvent(GetWeatherCompletedEventArgs e)
    {
        <span style="color:Blue;">if</span> (GetWeatherCompleted != <span style="color:Blue;">null</span>)
            GetWeatherCompleted(<span style="color:Blue;">this</span>, e);
    }

    <span style="color:Blue;">private</span> <span style="color:Blue;">string</span> fetchWeatherFromServer()
    {
        <span style="color:Green;">// do stuff </span>
        <span style="color:Blue;">string</span> weather = <span style="color:#A31515;">""</span>;

        GetWeatherCompletedEventArgs e =
            <span style="color:Blue;">new</span> GetWeatherCompletedEventArgs(<span style="color:Blue;">null</span>, <span style="color:Blue;">false</span>, <span style="color:Blue;">null</span>, weather);

        SendOrPostCallback callback = <span style="color:Blue;">new</span> SendOrPostCallback(DoEvent);
        requestingContext.Post(callback, e);
        requestingContext = <span style="color:Blue;">null</span>;

        <span style="color:Blue;">return</span> e.Weather;
    }

    <span style="color:Blue;">private</span> <span style="color:Blue;">void</span> DoEvent(<span style="color:Blue;">object</span> e)
    {
        <span style="color:Green;">//do stuff</span>
    }

    <span style="color:Blue;">public</span> <span style="color:Blue;">event</span> GetWeatherCompletedEventHandler GetWeatherCompleted;
    <span style="color:Blue;">public</span> <span style="color:Blue;">delegate</span> <span style="color:Blue;">string</span> NoArgDelegate();
}
</pre></div>
            
        </div>
    </div>
</div>
</div>
              </div>
            </div>
            <div>
              <div class="LW_CollapsibleArea_TitleDiv">
                <div>
                  <a href="javascript:void(0)" class="LW_CollapsibleArea_TitleAhref" title="Collapse">
                    <span class="cl_CollapsibleArea_expanding LW_CollapsibleArea_Img"></span>
                    <span class="LW_CollapsibleArea_Title">Nested Pumping</span>
                  </a>
                  <div class="LW_CollapsibleArea_HrDiv">
                    <hr class="LW_CollapsibleArea_Hr" />
                  </div>
                </div>
              </div>
              <div class="sectionblock">
                <a id="sectionToggle7">
                  
                </a>
                <p>Sometimes it is not feasible to completely lock up the UI thread. Let’s consider the <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.messagebox.show.aspx">Show</a></span> method of the <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.messagebox.aspx">MessageBox</a></span> class. <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.messagebox.show.aspx">Show</a></span> doesn’t return until the user clicks the OK button. It does, however, create a window that must have a message loop in order to be interactive. While we are waiting for the user to click OK, the original application window does not respond to user input. It does, however, continue to process paint messages. The original window redraws itself when covered and revealed. </p>
                <img id="ThreadingNestedPumping" alt="MessageBox with an &quot;OK&quot; button" src="http://i.msdn.microsoft.com/dynimg/IC133011.png" title="MessageBox with an &quot;OK&quot; button" xmlns="" />
                <p>Some thread must be in charge of the message box window. WPF could create a new thread just for the message box window, but this thread would be unable to paint the disabled elements in the original window (remember the earlier discussion of mutual exclusion). Instead, WPF uses a nested message processing system. The <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcher.aspx">Dispatcher</a></span> class includes a special method called <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcher.pushframe.aspx">PushFrame</a></span>, which stores an application’s current execution point then begins a new message loop. When the nested message loop finishes, execution resumes after the original <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcher.pushframe.aspx">PushFrame</a></span> call.</p>
                <p>In this case, <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcher.pushframe.aspx">PushFrame</a></span> maintains the program context at the call to <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.messagebox.aspx">MessageBox</a></span>.<span><a href="http://msdn.microsoft.com/en-us/library/system.windows.messagebox.show.aspx">Show</a></span>, and it starts a new message loop to repaint the background window and handle input to the message box window. When the user clicks OK and clears the pop-up window, the nested loop exits and control resumes after the call to <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.messagebox.show.aspx">Show</a></span>.</p>
              </div>
            </div>
            <div>
              <div class="LW_CollapsibleArea_TitleDiv">
                <div>
                  <a href="javascript:void(0)" class="LW_CollapsibleArea_TitleAhref" title="Collapse">
                    <span class="cl_CollapsibleArea_expanding LW_CollapsibleArea_Img"></span>
                    <span class="LW_CollapsibleArea_Title">Stale Routed Events</span>
                  </a>
                  <div class="LW_CollapsibleArea_HrDiv">
                    <hr class="LW_CollapsibleArea_Hr" />
                  </div>
                </div>
              </div>
              <div class="sectionblock">
                <a id="sectionToggle8">
                  
                </a>
                <p>The routed event system in WPF notifies entire trees when events are raised.</p>
                <div>
<div id="code-snippet-16" class="codeSnippetContainer" xmlns="">
    <div class="codeSnippetContainerTabs">
        <div class="codeSnippetContainerTabSingle" dir="ltr"><a>XAML</a></div>
    </div>
    <div class="codeSnippetContainerCodeContainer">
        <div class="codeSnippetToolBar">
            <div class="codeSnippetToolBarText">
                <a name="CodeSnippetCopyLink" style="display: none;" title="Copy to clipboard." href="javascript:if (window.epx.codeSnippet)window.epx.codeSnippet.copyCode('CodeSnippetContainerCode_1cd8c78b-9cf5-411c-b70d-b427e0010e12');">Copy</a>
            </div>
        </div>
        <div id="CodeSnippetContainerCode_1cd8c78b-9cf5-411c-b70d-b427e0010e12" class="codeSnippetContainerCode" dir="ltr">
            <div style="color:Black;"><pre>
<span style="color:Blue;">&lt;</span><span style="color:#A31515;">Canvas</span> <span style="color:Red;">MouseLeftButtonDown</span><span style="color:Blue;">=</span><span style="color:Black;">"</span><span style="color:Blue;">handler1</span><span style="color:Black;">"</span> 
        <span style="color:Red;">Width</span><span style="color:Blue;">=</span><span style="color:Black;">"</span><span style="color:Blue;">100</span><span style="color:Black;">"</span>
        <span style="color:Red;">Height</span><span style="color:Blue;">=</span><span style="color:Black;">"</span><span style="color:Blue;">100</span><span style="color:Black;">"</span>
        <span style="color:Blue;">&gt;</span>
  <span style="color:Blue;">&lt;</span><span style="color:#A31515;">Ellipse</span> <span style="color:Red;">Width</span><span style="color:Blue;">=</span><span style="color:Black;">"</span><span style="color:Blue;">50</span><span style="color:Black;">"</span>
           <span style="color:Red;">Height</span><span style="color:Blue;">=</span><span style="color:Black;">"</span><span style="color:Blue;">50</span><span style="color:Black;">"</span>
           <span style="color:Red;">Fill</span><span style="color:Blue;">=</span><span style="color:Black;">"</span><span style="color:Blue;">Blue</span><span style="color:Black;">"</span> 
           <span style="color:Red;">Canvas.Left</span><span style="color:Blue;">=</span><span style="color:Black;">"</span><span style="color:Blue;">30</span><span style="color:Black;">"</span>
           <span style="color:Red;">Canvas.Top</span><span style="color:Blue;">=</span><span style="color:Black;">"</span><span style="color:Blue;">50</span><span style="color:Black;">"</span> 
           <span style="color:Red;">MouseLeftButtonDown</span><span style="color:Blue;">=</span><span style="color:Black;">"</span><span style="color:Blue;">handler2</span><span style="color:Black;">"</span>
           <span style="color:Blue;">/&gt;</span>
<span style="color:Blue;">&lt;/</span><span style="color:#A31515;">Canvas</span><span style="color:Blue;">&gt;</span>
</pre></div>
            
        </div>
    </div>
</div>
</div>
                <p>When the left mouse button is pressed over the ellipse, <span class="code">handler2</span> is executed. After <span class="code">handler2</span> finishes, the event is passed along to the <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.controls.canvas.aspx">Canvas</a></span> object, which uses <span class="code">handler1</span> to process it. This happens only if <span class="code">handler2</span> does not explicitly mark the event object as handled.</p>
                <p>It’s possible that <span class="code">handler2</span> will take a great deal of time processing this event. <span class="code">handler2</span> might use <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcher.pushframe.aspx">PushFrame</a></span> to begin a nested message loop that doesn’t return for hours. If <span class="code">handler2</span> does not mark the event as handled when this message loop is complete, the event is passed up the tree even though it is very old.</p>
              </div>
            </div>
            <div>
              <div class="LW_CollapsibleArea_TitleDiv">
                <div>
                  <a href="javascript:void(0)" class="LW_CollapsibleArea_TitleAhref" title="Collapse">
                    <span class="cl_CollapsibleArea_expanding LW_CollapsibleArea_Img"></span>
                    <span class="LW_CollapsibleArea_Title">Reentrancy and Locking</span>
                  </a>
                  <div class="LW_CollapsibleArea_HrDiv">
                    <hr class="LW_CollapsibleArea_Hr" />
                  </div>
                </div>
              </div>
              <div class="sectionblock">
                <a id="sectionToggle9">
                  
                </a>
                <p>The locking mechanism of the common language runtime (CLR) doesn’t behave exactly as one might imagine; one might expect a thread to cease operation completely when requesting a lock. In actuality, the thread continues to receive and process high-priority messages. This helps prevent deadlocks and make interfaces minimally responsive, but it introduces the possibility for subtle bugs.  The vast majority of the time you don’t need to know anything about this, but under rare circumstances (usually involving Win32 window messages or COM STA components) this can be worth knowing.</p>
                <p>Most interfaces are not built with thread safety in mind because developers work under the assumption that a UI is never accessed by more than one thread. In this case, that single thread may make environmental changes at unexpected times, causing those ill effects that the <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcherobject.aspx">DispatcherObject</a></span> mutual exclusion mechanism is supposed to solve. Consider the following pseudocode:</p>
                <img id="ThreadingReentrancy" alt="Threading reentrancy diagram" src="http://i.msdn.microsoft.com/dynimg/IC48486.png" title="Threading reentrancy diagram" xmlns="" />
                <p>Most of the time that’s the right thing, but there are times in WPF where such unexpected reentrancy can really cause problems. So, at certain key times, WPF calls <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcher.disableprocessing.aspx">DisableProcessing</a></span>, which changes the lock instruction for that thread to use the WPF reentrancy-free lock, instead of the usual CLR lock. </p>
                <p>So why did the CLR team choose this behavior? It had to do with COM STA objects and the finalization thread. When an object is garbage collected, its <span><span class="input">Finalize</span></span> method is run on the dedicated finalizer thread, not the UI thread. And therein lies the problem, because a COM STA object that was created on the UI thread can only be disposed on the UI thread. The CLR does the equivalent of a <span><a href="http://msdn.microsoft.com/en-us/library/system.windows.threading.dispatcher.begininvoke.aspx">BeginInvoke</a></span> (in this case using Win32’s <strong>SendMessage</strong>). But if the UI thread is busy, the finalizer thread is stalled and the COM STA object can’t be disposed, which creates a serious memory leak. So the CLR team made the tough call to make locks work the way they do.  </p>
                <p>The task for WPF is to avoid unexpected reentrancy without reintroducing the memory leak, which is why we don’t block reentrancy everywhere.</p>
              </div>
            </div>
          </div>
        </div>
        <div>
          <div class="LW_CollapsibleArea_TitleDiv">
            <div>
              <a href="javascript:void(0)" class="LW_CollapsibleArea_TitleAhref" title="Collapse">
                <span class="cl_CollapsibleArea_expanding LW_CollapsibleArea_Img"></span>
                <span class="LW_CollapsibleArea_Title">See Also</span>
              </a>
              <div class="LW_CollapsibleArea_HrDiv">
                <hr class="LW_CollapsibleArea_Hr" />
              </div>
            </div>
          </div>
          <div class="sectionblock">
            <a id="seeAlsoToggle">
              
            </a>
            <h4 class="subHeading">Other Resources</h4>
            <div class="seeAlsoStyle">
              <a href="http://go.microsoft.com/fwlink/?LinkID=160038" target="_blank">Single-Threaded Application with Long-Running Calculation Sample</a>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</div>





<div id="contentFeedback">
    <form method="post" action="/en-us/library/feedback/add/ms741870.aspx">
        <input name="__RequestVerificationToken" type="hidden" value="hZYuD-kLxUT6S_5sspYiQ0EW17anAr47M_TCoJM6j91cxkxlADO9djkUdxOdBGosNinBxSc7aaM2dgC6ef9fztCnoVrPEtjXs2vjcF2gpwPpQWPPESjkPlS7k9tJDAKLou-lkA2" />
    <div id="contentFeedbackContainer">
        <div class="FeedbackTitleContainer">
            <a name="feedback"></a>
        Did you find this helpful?
            <input id="rdIsUsefulYes" name="rdIsUseful" type="radio" value="1" onclick="toggleContentFeedback('Yes');" /><label for="rdIsUsefulYes">Yes</label>
            <input id="rdIsUsefulNo" name="rdIsUseful" type="radio" value="0" onclick="toggleContentFeedback('No');" /><label for="rdIsUsefulNo">No</label>
        
        </div>
        
            <div id="contentFeedbackQAContainer">
                
                    <div id="feedbackListNoContainer" class="FeedbackListContainer">
                        
                            <div>
                                <input id="chkbxNo201" name="chkbxNo" type="checkbox" value="201" />
                                <label for="chkbxNo201">Not accurate</label>
                            </div>
                        
                            <div>
                                <input id="chkbxNo202" name="chkbxNo" type="checkbox" value="202" />
                                <label for="chkbxNo202">Not enough depth</label>
                            </div>
                        
                            <div>
                                <input id="chkbxNo203" name="chkbxNo" type="checkbox" value="203" />
                                <label for="chkbxNo203">Need more code examples</label>
                            </div>
                        
                    </div>
                
                <div class="FeedbackTellUsMoreContainer">
                    <input type="hidden" id="feedbackSiteName" name="feedbackSiteName" value="" />
                    <input type="hidden" id="feedbackPriority" name="feedbackPriority" value="" />
                    <input type="hidden" id="feedbackSourceUrl" name="feedbackSourceUrl" value="" />
                    <input type="hidden" id="ClientIP" name="ClientIP" value="" />
                    <input type="hidden" id="ClientOS" name="ClientOS" value="" />
                    <input type="hidden" id="ClientBrowser" name="ClientBrowser" value="" />
                    <input type="hidden" id="ClientTime" name="ClientTime" value="" />
                    <input type="hidden" id="ClientDate" name="ClientDate" value="" />
                    <textarea id="feedbackText" name="feedbackText" class="TellUsMoreTextBoxSearchLoaded" onfocus="WatermarkFocus(this, 'Tell us more...', 'TellUsMoreTextBoxSearch')" onblur="WatermarkBlur(this, 'Tell us more...', 'TellUsMoreTextBoxSearchLoaded')" onmouseover="TextBoxCharactersCounter(this, document.getElementById('feedbackTextCounter'), 1500)" onkeydown="TextBoxCharactersCounter(this, document.getElementById('feedbackTextCounter'), 1500)" onkeyup="TextBoxCharactersCounter(this, document.getElementById('feedbackTextCounter'), 1500)">Tell us more...</textarea>
                </div>
                <span class="counter">(<span id="feedbackTextCounter">1500</span> characters remaining)</span>
                <input type="hidden" id="returnUrl" name="returnUrl" value="http://msdn.microsoft.com/en-us/library/ms741870.aspx" />
                <input type="submit" id="submit" value="Submit" title="Click to Submit Feedback" onclick="WatermarkOnSubmit(document.getElementById('feedbackText'), 'Tell us more...', 'TellUsMoreTextBoxSearch')" />
                <div style="clear: both;"></div>
            </div>  
        
    </div>
    </form>
</div>
    




<div class="libraryMemberFilter">
    <div class="filterContainer">
        <span>Show:</span>
        <label>
            <input type="checkbox" class="libraryFilterInherited" checked="checked" value="Inherit" />Inherited
        </label>
        <label>
            <input type="checkbox" class="libraryFilterProtected" checked="checked" value="Protected" />Protected
        </label>
    </div>
</div>
    
<input type="hidden" id="libraryMemberFilterEmptyWarning" value="There are no members available with your current filter settings." />


 
</div>



            </div>
            <div class="clear"></div>
        
            
    
<input name="__RequestVerificationToken" type="hidden" value="tjtdnx843hr3plrgIQ7n-lNpYYTE0hZ9Gccp9EK3SuBnutTkmsRDTPzs73kw1UM0fBcUerD_3V7pvef-WJWDBmaWK-PvpGmjSISPO4lAhXtN-Gk-49G7DH7RTKCPE_u5iO286g2" />
<input id="ratingSubmitUrl" type="hidden" value="http://msdn.microsoft.com/en-us/library/feedback/add/ms741870.aspx" />
<input id="isTopicRated" type="hidden" value="false" />




    <div id="ux-footer" class="" style="">
    <footer class="top">
        <div data-fragmentName="LeftLinks" id="Fragment_LeftLinks" xmlns="http://www.w3.org/1999/xhtml">
  
  <div class="LinkList">
    <div class="LinkListTitle">Dev centers</div>
    <div class="Links">
      <ul class="LinkColumn" style="width: 100%">
        <li>
          <a href="http://msdn.microsoft.com/windows" id="27861_1" class="windowsBlue" xmlns="http://www.w3.org/1999/xhtml">Windows</a>
        </li>
        <li>
          <a href="http://dev.windowsphone.com/" id="27861_2" class="windowsPurple" xmlns="http://www.w3.org/1999/xhtml">Windows Phone</a>
        </li>
        <li>
          <a href="http://msdn.microsoft.com/office" id="27861_3" class="office" xmlns="http://www.w3.org/1999/xhtml">Office</a>
        </li>
        <li>
          <a href="http://www.windowsazure.com/en-us/documentation/" id="27861_4" class="windowsBlue" xmlns="http://www.w3.org/1999/xhtml">Windows Azure</a>
        </li>
        <li>
          <a href="http://msdn.microsoft.com/vstudio" id="27861_5" class="visualStudio" xmlns="http://www.w3.org/1999/xhtml">Visual Studio</a>
        </li>
        <li>
          <a href="http://msdn.microsoft.com/aa937802" id="27861_6" xmlns="http://www.w3.org/1999/xhtml">More...</a>
        </li>
      </ul>
    </div>
  </div>
</div>    
        <div id="rightLinks">
            <div data-fragmentName="CenterLinks1" id="Fragment_CenterLinks1" xmlns="http://www.w3.org/1999/xhtml">
  
  <div class="LinkList">
    <div class="LinkListTitle">Learning resources</div>
    <div class="LinkListDescription"></div>
    <div class="Links">
      <ul class="LinkColumn" style="width: 100%">
        <li>
          <a href="http://www.microsoftvirtualacademy.com/" id="27861_14" xmlns="http://www.w3.org/1999/xhtml">Microsoft Virtual Academy</a>
        </li>
        <li>
          <a href="http://channel9.msdn.com/" id="27861_16" xmlns="http://www.w3.org/1999/xhtml">Channel 9</a>
        </li>
        <li>
          <a href="http://www.interoperabilitybridges.com/" id="27861_17" xmlns="http://www.w3.org/1999/xhtml">Interoperability Bridges</a>
        </li>
        <li>
          <a href="http://msdn.microsoft.com/magazine/" id="CenterLinks1_427_33" xmlns="http://www.w3.org/1999/xhtml">MSDN Magazine</a>
        </li>
      </ul>
    </div>
  </div>
</div>
            <div data-fragmentName="CenterLinks2" id="Fragment_CenterLinks2" xmlns="http://www.w3.org/1999/xhtml">
  
  <div class="LinkList">
    <div class="LinkListTitle">Community</div>
    <div class="LinkListDescription"></div>
    <div class="Links">
      <ul class="LinkColumn" style="width: 100%">
        <li>
          <a href="http://social.msdn.microsoft.com/forums/en-us/home" id="27861_19" xmlns="http://www.w3.org/1999/xhtml">Forums</a>
        </li>
        <li>
          <a href="http://blogs.msdn.com/b/developer-tools/" id="27861_20" xmlns="http://www.w3.org/1999/xhtml">Blogs</a>
        </li>
        <li>
          <a href="http://www.codeplex.com" id="27861_22" xmlns="http://www.w3.org/1999/xhtml">Codeplex</a>
        </li>
      </ul>
    </div>
  </div>
</div>
            <div data-fragmentName="CenterLinks3" id="Fragment_CenterLinks3" xmlns="http://www.w3.org/1999/xhtml">
  
  <div class="LinkList">
    <div class="LinkListTitle">Support</div>
    <div class="LinkListDescription"></div>
    <div class="Links">
      <ul class="LinkColumn" style="width: 100%">
        <li>
          <a href="http://msdn.microsoft.com/hh361695" id="CenterLinks3_427_34" xmlns="http://www.w3.org/1999/xhtml">Self support</a>
        </li>
        <li>
          <a href="http://support.microsoft.com/" id="27861_24" xmlns="http://www.w3.org/1999/xhtml">Other support options</a>
        </li>
      </ul>
    </div>
  </div>
</div>
            <div data-fragmentName="CenterLinks4" id="Fragment_CenterLinks4" xmlns="http://www.w3.org/1999/xhtml">
  
  <div class="LinkList">
    <div class="LinkListTitle">Programs</div>
    <div class="LinkListDescription"></div>
    <div class="Links">
      <ul class="LinkColumn" style="width: 100%">
        <li>
          <a href="http://www.microsoft.com/bizspark/" id="27861_27" xmlns="http://www.w3.org/1999/xhtml">BizSpark (for startups)</a>
        </li>
        <li>
          <a href="https://www.dreamspark.com/" id="27861_28" xmlns="http://www.w3.org/1999/xhtml">DreamSpark</a>
        </li>
        <li>
          <a href="https://www.microsoft.com/faculty" id="27861_29" xmlns="http://www.w3.org/1999/xhtml">Faculty Connection</a>
        </li>
        <li>
          <a href="http://www.microsoft.com/student/" id="CenterLinks4_427_32" xmlns="http://www.w3.org/1999/xhtml">Microsoft Student</a>
        </li>
      </ul>
    </div>
  </div>
</div>
    <div class="feedbackContainer">
        <div id="feedbackSection1" class="clear">
            <div class="left">Did you find this helpful?</div>
            <div class="left">
                <div class="left">
                    <input type="radio" name="feedback" id="feedbackYes" value="1" class="feedbackYesClick" data-enhance="false" /><label class="feedbackYesClick" for="feedbackYes"> Yes</label>
                </div>
                <div class="left">
                    <input type="radio" name="feedback" id="feedbackNo" value="0" class="feedbackNoClick" data-enhance="false" /><label class="feedbackNoClick" for="feedbackNo"> No</label>
                </div>
            </div>
            <a class="rateThisAnchor" name="feedback"></a>
        </div>
        <div id="feedbackSection2" class="clear">
        </div>
        <div id="feedbackSection3" class="clear">
                    <div>
                        <input id="checkboxNo201" name="chkbxNo" type="checkbox" value="201" data-enhance="false" />
                        <label for="checkboxNo201">Not accurate</label>
                    </div>
                    <div>
                        <input id="checkboxNo202" name="chkbxNo" type="checkbox" value="202" data-enhance="false" />
                        <label for="checkboxNo202">Not enough depth</label>
                    </div>
                    <div>
                        <input id="checkboxNo203" name="chkbxNo" type="checkbox" value="203" data-enhance="false" />
                        <label for="checkboxNo203">Need more code examples</label>
                    </div>
        </div>
        <div id="feedbackSection4" class="clear">
            <div>
                <textarea id="feedbackTextArea" name="feedbackText" class="TellUsMoreTextBoxSearchLoaded" data-enhance="false">Tell us more...</textarea>
            </div>
            <div class="left"><span class="counter">(<span id="feedbackTextCounter">1500</span> characters remaining)</span></div>
            <div class="right">
                <button type="button" id="feedbackSubmit" title="Click to Submit Feedback" data-enhance="false">Submit</button>
            </div>
        </div>
        <div id="feedbackSection5">Thank you for your feedback</div>
        <input id="feedbackValue" type="hidden" value="" />
        <input id="tellUsMoreText" type="hidden" value="Tell us more..." />
        <input id="maxTextBoxCharacters" type="hidden" value="1500" />
        <input type="hidden" id="feedbackSiteName" name="feedbackSiteName" value="" />
        <input type="hidden" id="feedbackPriority" name="feedbackPriority" value="" />
        <input type="hidden" id="feedbackSourceUrl" name="feedbackSourceUrl" value="" />
        <input type="hidden" id="ClientIP" name="ClientIP" value="" />
        <input type="hidden" id="ClientOS" name="ClientOS" value="" />
        <input type="hidden" id="ClientBrowser" name="ClientBrowser" value="" />
        <input type="hidden" id="ClientTime" name="ClientTime" value="" />
        <input type="hidden" id="ClientDate" name="ClientDate" value="" />
    </div>
    
        </div>
    </footer>
    
    <footer class="bottom">
        <span class="localeContainer">
                <form class="selectLocale" id="selectLocaleForm" action="http://msdn.microsoft.com/en-us/selectlocale-dmc">
        <input type="hidden" name="fromPage" value="http%3a%2f%2fmsdn.microsoft.com%2fen-us%2flibrary%2fms741870.aspx" />
        <a href="#" onclick="$('#selectLocaleForm').submit();return false;" title="Change your language">United States (English)</a>
    </form>    


        </span>
        
        <div data-fragmentName="BottomLinks" id="Fragment_BottomLinks" xmlns="http://www.w3.org/1999/xhtml">
  
  <div class="LinkList">
    <div class="LinkListDescription"></div>
    <div class="Links">
      <ul class="LinkColumn horizontal">
        <li>
          <a href="http://msdn.microsoft.com/newsletter.aspx" id="27861_8" xmlns="http://www.w3.org/1999/xhtml">Newsletter</a>
        </li>
        <li>
          <a href="http://msdn.microsoft.com/dn529288" id="27861_10" xmlns="http://www.w3.org/1999/xhtml">Privacy &amp; cookies</a>
        </li>
        <li>
          <a href="http://msdn.microsoft.com/cc300389.aspx" id="27861_11" xmlns="http://www.w3.org/1999/xhtml">Terms of Use</a>
        </li>
        <li>
          <a href="http://www.microsoft.com/en-us/legal/intellectualproperty/Trademarks/EN-US.aspx" id="27861_12" xmlns="http://www.w3.org/1999/xhtml">Trademarks</a>
        </li>
      </ul>
    </div>
  </div>
</div>    
        <span class="logoLegal">
            <span class="logo"></span>
            <span class="copyright">© 2014 Microsoft</span>
        </span>
    </footer>
</div>
    


            <div class="footerPrintView">
                <div class="footerCopyrightPrintView">© 2014 Microsoft. All rights reserved.</div>
            </div>

            
            
    
    
    <input id="tocPaddingPerLevel" type="hidden" value="17" />


        
            <input id="MtpsDevice" type="hidden" value="Default" />


<![CDATA[ Third party scripts and code linked to or referenced from this website are licensed to you by the parties that own such code, not by Microsoft.  See ASP.NET Ajax CDN Terms of Use – http://www.asp.net/ajaxlibrary/CDN.ashx. ]]>
        
            
            
            
            
            
        





<noscript><div><img alt="DCSIMG" id="Img1" width="1" height="1" src="http://m.webtrends.com/dcsmgru7m99k7mqmgrhudo0k8_8c6m/njs.gif?dcsuri=/nojavascript&amp;WT.js=No" /></div></noscript>









<noscript>
  <a href="http://www.omniture.com" title="Web Analytics">
    <img src="//msstonojsmsdn.112.2o7.net/b/ss/msstonojsmsdn/1/H.20.2--NS/0" height="1" width="1" border="0" alt="" />
  </a>
</noscript>




<div id="globalRequestVerification">
    <input name="__RequestVerificationToken" type="hidden" value="0GcL1bp9vbNeVAhi8JjZ_nxrRTX5uPzDiDSk-qYeqaNJuvZ5pbXl3H9N_zuXtrJYb5HZ3WQbgW8Rw4WLBqc7OrqpQRYhynozAds2Wzai6f5owOx5axXYD_-DxcSVbZm8YT3Z3w2" />
</div>


        </div>
    <script type="text/javascript" class="mtps-injected">
/*<![CDATA[*/
(function(window,document){"use strict";function preload(scripts){for(var result=[],script,e,i=0;i<scripts.length;i++)script=scripts[i],script.hasOwnProperty("url")&&(e=document.createElement("script"),e.src=script.url,script.throwaway=e),result.push(script);return result}function inject(scripts,index){var script,elem;if(index>=scripts.length){delete mtps.injectScripts;return}script=scripts[index];elem=document.createElement("script");elem.className="mtps-injected";elem.async=!1;var isLoaded=!1,timeoutId=0,injectNextFnName="",injectNext=elem.onerror=function(){isLoaded||(isLoaded=!0,inject(scripts,index+1),window.clearTimeout(timeoutId),elem.onload=elem.onerror=elem.onreadystatechange=null,injectNextFnName&&delete mtps[injectNextFnName],elem.removeEventListener&&elem.removeEventListener("load",injectNext,!1))};elem.addEventListener?elem.addEventListener("load",injectNext,!1):elem.readyState==="uninitialized"?elem.onreadystatechange=function(){(this.readyState==="loaded"||this.readyState==="complete")&&injectNext()}:elem.onload=injectNext;script.hasOwnProperty("url")?(timeoutId=window.setTimeout(injectNext,12e4),elem.src=script.url):(injectNextFnName="_injectNextScript_"+index,mtps[injectNextFnName]=injectNext,timeoutId=window.setTimeout(injectNext,2e3),elem.text="try {\n"+script.txt+"\n} finally { MTPS."+injectNextFnName+" && MTPS."+injectNextFnName+"(); }");parent.appendChild(elem)}var mtps=window.MTPS||(window.MTPS={}),parent=document.getElementsByTagName("head")[0];mtps.injectScripts=function(scripts){inject(preload(scripts),0)}})(window,document);
MTPS.injectScripts([
	{ txt: "/**/\r\n(window.MTPS || (window.MTPS = {})).cdnDomains || (window.MTPS.cdnDomains = { \r\n\t\"image\": \"http://i.msdn.microsoft.com\", \r\n\t\"js\": \"http://i2.msdn.microsoft.com\", \r\n\t\"css\": \"http://i3.msdn.microsoft.com\"\r\n});\r\n/**/" },
	{ url: "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.2.min.js" },
	{ txt: "//\n  var literalNormalizedUrl = \u0027/en-us/library/ms741870(d=default,l=en-us,v=vs.110).aspx\u0027;\n  var wt_nvr_ru = \u0027WT_NVR_RU\u0027;\n  var wt_fpcdom = \u0027.microsoft.com\u0027;\n  var wt_domlist = \u0027msdn.microsoft.com\u0027;\n  var wt_pathlist = \u0027\u0027;\n  var wt_paramlist = \u0027DCSext.mtps_devcenter\u0027;\n  var wt_siteid = \u0027MSDN\u0027;\n  var gDomain = \u0027m.webtrends.com\u0027;\n  var gDcsId = \u0027dcsmgru7m99k7mqmgrhudo0k8_8c6m\u0027;\n  var gFpc = \u0027WT_FPC\u0027;\n\n\n\n  if (document.cookie.indexOf(gFpc + \"=\") == -1) {\n    var wtidJs = document.createElement(\"script\");\n    wtidJs.src = \"//\" + gDomain + \"/\" + gDcsId + \"/wtid.js\";\n    document.getElementsByTagName(\"head\")[0].appendChild(wtidJs);\n  }\n\n\n\n  var detectedLocale = \u0027en-us\u0027;\n  var wtsp = \u0027msdnlib_dotnet\u0027;\n  var gTrackEvents = \u00270\u0027;\n/**/" },
	{ txt: "/**/\n  var omni_guid = \"db8f557e-808a-4b02-8bcf-f664bbf52457\";\n/**/" },
	{ url: "http://i2.msdn.microsoft.com/Combined.js?resources=0:Utilities,1:Layout,2:Header,2:Rating,2:Footer,0:Topic,3:webtrendsscript,4:omni_rsid_MSDN,5:SearchBox;/Areas/Epx/Content/Scripts:0,/Areas/Centers/Themes/Base/Content:1,/Areas/Centers/Themes/Msdn/Content:2,/Areas/Global/Content/Webtrends/resources:3,/Areas/Global/Content/Omniture/resources/MSDN:4,/Areas/Epx/Themes/Base/Content:5\u0026amp;hashKey=61C207377CBE579E8408FDB19B9E9D57" },
	{ url: "http://i3.services.social.microsoft.com/search/Widgets/SearchBox.jss?boxid=HeaderSearchTextBox\u0026btnid=HeaderSearchButton\u0026brand=MSDN\u0026loc=en-us\u0026focusOnInit=false\u0026emptyWatermark=true\u0026searchButtonTooltip=Search MSDN" },
	{ url: "http://i2.msdn.microsoft.com/Combined.js?resources=0:PrintExportButton,1:Toc,1:NavigationResize,2:FeedbackCounter;/Areas/Epx/Themes/Base/Content:0,/Areas/Epx/Library/Content:1,/Areas/Epx/Shared/Content:2\u0026amp;hashKey=3CBB3597E1EDC9C3905C43D24C420E54" },
	{ txt: "MTPS = window.MTPS || {}; MTPS.LocalizedStrings = window.MTPS.LocalizedStrings || {}; MTPS.LocalizedStrings.ExpandButtonTooltip = \u0027Expand\u0027; MTPS.LocalizedStrings.CollapseButtonTooltip = \u0027Collapse\u0027; MTPS.LocalizedStrings.EnhancedExpandTooltip = \u0027Click to expand. Double-click to expand all.\u0027; MTPS.LocalizedStrings.EnhancedCollapseTooltip = \u0027Click to collapse. Double-click to collapse all.\u0027; MTPS.LocalizedStrings.ExpandAllButtonTooltip = \u0027Expand All\u0027; MTPS.LocalizedStrings.CollapseAllButtonTooltip = \u0027Collapse All\u0027;" },
	{ txt: "MTPS = window.MTPS || {}; MTPS.LocalizedStrings = window.MTPS.LocalizedStrings || {}; MTPS.LocalizedStrings.ExpandButtonTooltip = \u0027Expand\u0027; MTPS.LocalizedStrings.CollapseButtonTooltip = \u0027Collapse\u0027; MTPS.LocalizedStrings.EnhancedExpandTooltip = \u0027Click to expand. Double-click to expand all.\u0027; MTPS.LocalizedStrings.EnhancedCollapseTooltip = \u0027Click to collapse. Double-click to collapse all.\u0027; MTPS.LocalizedStrings.ExpandAllButtonTooltip = \u0027Expand All\u0027; MTPS.LocalizedStrings.CollapseAllButtonTooltip = \u0027Collapse All\u0027;" },
	{ url: "http://i2.msdn.microsoft.com/Combined.js?resources=0:Feedback,1:LibraryMemberFilter,1:Toc_Fixed,2:CodeSnippet,2:TopicNotInScope,2:CollapsibleArea,2:VersionSelector,2:SurveyBroker;/Areas/Epx/Shared/Content:0,/Areas/Epx/Library/Content:1,/Areas/Epx/Content/Scripts:2\u0026amp;hashKey=BC363F8CF445107706028553F8295909" },
	{ txt: "$(document).ready(function() {\n        try {\n            var token = $(\"#globalRequestVerification input[name=\u0027__RequestVerificationToken\u0027]\").clone();\n            $(\"#siteFeedbackForm\").append(token);\n        } catch(err) {\n            \n        }\n    });" }
]);

/*]]>*/
</script></body>
</html>