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


# PowerShell ISE version of the VIM blackboard theme at 
# http://www.vim.org/scripts/script.php?script_id=2280

# fonts
$psISE.Options.FontName                          = 'Courier New'
$psISE.Options.FontSize                          = 13

# output pane
$psISE.Options.OutputPaneBackgroundColor         = '#002b36'
$psISE.Options.OutputPaneTextBackgroundColor     = '#002b36'
$psISE.Options.OutputPaneForegroundColor         = '#93a1a1'

#Error
$psISE.Options.ErrorBackgroundColor              = "#002b36"
$psISE.Options.ErrorForegroundColor              = "pink"

# command pane
$psISE.Options.CommandPaneBackgroundColor        = '#002b36'

# script pane
$psISE.Options.ScriptPaneBackgroundColor         = '#002b36'

# tokens
$psISE.Options.TokenColors['Command']            = '#93a1a1'
$psISE.Options.TokenColors['Unknown']            = '#93a1a1'
$psISE.Options.TokenColors['Member']             = '#93a1a1'
$psISE.Options.TokenColors['Position']           = '#93a1a1'
$psISE.Options.TokenColors['GroupEnd']           = '#93a1a1'
$psISE.Options.TokenColors['GroupStart']         = '#93a1a1'
$psISE.Options.TokenColors['LineContinuation']   = '#93a1a1'
$psISE.Options.TokenColors['NewLine']            = '#93a1a1'
$psISE.Options.TokenColors['StatementSeparator'] = '#93a1a1'
$psISE.Options.TokenColors['Comment']            = '#FFAEAEAE'
$psISE.Options.TokenColors['String']             = $cyan #'#FF00D42D'
$psISE.Options.TokenColors['Keyword']            = $blue#$yellow#'#FFFFDE00'
$psISE.Options.TokenColors['Attribute']          = '#FF84A7C1'
$psISE.Options.TokenColors['Type']               = '#FF84A7C1'
$psISE.Options.TokenColors['Variable']           = $green#'#FF00D42D'
$psISE.Options.TokenColors['CommandParameter']   = $blue#$yellow#'#FFFFDE00'
$psISE.Options.TokenColors['CommandArgument']    = '#93a1a1'
$psISE.Options.TokenColors['Number']             = '#FF98FE1E'


