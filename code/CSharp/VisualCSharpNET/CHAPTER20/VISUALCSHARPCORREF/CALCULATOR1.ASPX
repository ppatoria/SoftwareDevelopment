<%@ Page language="c#" Codebehind="Calculator1.aspx.cs" AutoEventWireup="false" Inherits="VisualCSharpCorRef.Calculator1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Calculator1</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Calculator1" method="post" runat="server">
			<asp:TextBox id="Number1TextBox" style="Z-INDEX: 101; LEFT: 64px; POSITION: absolute; TOP: 64px" runat="server" Width="69px"></asp:TextBox>
			<asp:Label id="OpLabel" style="Z-INDEX: 102; LEFT: 144px; POSITION: absolute; TOP: 64px" runat="server" Width="22px"></asp:Label>
			<asp:TextBox id="Number2TextBox" style="Z-INDEX: 103; LEFT: 176px; POSITION: absolute; TOP: 64px" runat="server" Width="69px"></asp:TextBox>
			<asp:Label id="ResultLabel" style="Z-INDEX: 104; LEFT: 280px; POSITION: absolute; TOP: 64px" runat="server" Width="75px"></asp:Label>
			<asp:Button id="AddButton" style="Z-INDEX: 105; LEFT: 256px; POSITION: absolute; TOP: 104px" runat="server" Width="19px" Text="+"></asp:Button>
			<asp:Button id="SubtractButton" style="Z-INDEX: 106; LEFT: 280px; POSITION: absolute; TOP: 104px" runat="server" Width="19" Text="-"></asp:Button>
			<asp:Button id="MultiplyButton" style="Z-INDEX: 107; LEFT: 304px; POSITION: absolute; TOP: 104px" runat="server" Width="19px" Text="*"></asp:Button>
			<asp:Button id="DivideButton" style="Z-INDEX: 108; LEFT: 328px; POSITION: absolute; TOP: 104px" runat="server" Width="19" Text="/"></asp:Button>
			<asp:Button id="ClearButton" style="Z-INDEX: 109; LEFT: 256px; POSITION: absolute; TOP: 136px" runat="server" Width="88px" Text="Clear"></asp:Button>
			<DIV style="DISPLAY: inline; Z-INDEX: 110; LEFT: 64px; WIDTH: 70px; POSITION: absolute; TOP: 40px; HEIGHT: 15px" ms_positioning="FlowLayout">Number 
				1</DIV>
			<DIV style="DISPLAY: inline; Z-INDEX: 111; LEFT: 176px; WIDTH: 70px; POSITION: absolute; TOP: 40px; HEIGHT: 15px" ms_positioning="FlowLayout">Number 
				2</DIV>
			<DIV style="DISPLAY: inline; Z-INDEX: 112; LEFT: 256px; WIDTH: 12px; POSITION: absolute; TOP: 64px; HEIGHT: 19px" ms_positioning="FlowLayout">=</DIV>
		</form>
	</body>
</HTML>
