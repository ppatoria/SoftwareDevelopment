######## Solarized Colors ########
$base03  =   	"#FF002b36"
$base02    	=	"#FF073642"
$base01    	=	"#FF586e75"
$base00    	=	"#FF657b83"
$base0     	=	"#FF839496"
$base1     	=	"#FF93a1a1"
$base2     	=	"#FFeee8d5"
$base3     	=	"#FFfdf6e3"
$yellow    	=	"#FFb58900"
$orange    	=	"#FFcb4b16"
$red       	=	"#FFdc322f"
$magenta 	=	"#FFd33682"
$violet    	=	"#FF6c71c4"
$blue      	=	"#FF268bd2"
$cyan      	=	"#FF2aa198"
$green     	=	"#FF859900"
 
 
 
######## Font ########
$psISE.Options.FontName = 'courier new' 
$psISE.Options.FontSize = 13
 
 
######## Command and Script - Dark ########
$psISE.Options.CommandPaneBackgroundColor = $base03
$psISE.Options.ScriptPaneBackgroundColor = $base03
 
######## Output - Light ########
$psISE.Options.OutputPaneBackgroundColor = $base3 
$psISE.Options.OutputPaneTextBackgroundColor = $base3 
$psISE.Options.OutputPaneForegroundColor = $base00
#Error mesages etc use secondary text background
$psISE.Options.ErrorBackgroundColor = $base2
$psISE.Options.WarningBackgroundColor = $base2
$psISE.Options.VerboseBackgroundColor =  $base2
 $psISE.Options.DebugBackgroundColor = $base2
 #Error messages etc foregrounds
 $psISE.Options.ErrorForegroundColor = $red
 $psISE.Options.WarningForegroundColor = $orange
 $psISE.Options.VerboseForegroundColor = $blue
 $psISE.Options.DebugForegroundColor = $blue
 
 
######## Tokens ########
$psISE.Options.TokenColors.item('Attribute') = $green
$psISE.Options.TokenColors.item('Command') = $red
$psISE.Options.TokenColors.item('CommandArgument') = $base0
$psISE.Options.TokenColors.item('CommandParameter') = $base0
$psISE.Options.TokenColors.item('Comment') = $base01
$psISE.Options.TokenColors.item('GroupEnd') = $base0
$psISE.Options.TokenColors.item('GroupStart') = $base0 
$psISE.Options.TokenColors.item('Keyword') = $yellow
$psISE.Options.TokenColors.item('LineContinuation') = $base0
$psISE.Options.TokenColors.item('LoopLabel') = $base0
$psISE.Options.TokenColors.item('Member') = $base0
$psISE.Options.TokenColors.item('NewLine') = $base0
$psISE.Options.TokenColors.item('Number') = $base01
$psISE.Options.TokenColors.item('Operator') = $base0
$psISE.Options.TokenColors.item('Position') = $base0
$psISE.Options.TokenColors.item('StatementSeparator') = $base0
$psISE.Options.TokenColors.item('String') = "green"#$base01
$psISE.Options.TokenColors.item('Type') = $cyan
$psISE.Options.TokenColors.item('Unknown') = $base01
$psISE.Options.TokenColors.item('Variable') = $blue