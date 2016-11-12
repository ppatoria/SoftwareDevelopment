<%@ Page language="c#" Codebehind="Configuration.aspx.cs" AutoEventWireup="false" Inherits="VisualCSharpCorRef.Configuration" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Configuration</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Configuration" method="post" runat="server">
			<asp:ListBox id="ListBox1" style="Z-INDEX: 101; LEFT: 53px; POSITION: absolute; TOP: 55px" runat="server" AutoPostBack="True">
				<asp:ListItem Value="Verdana">Verdana</asp:ListItem>
				<asp:ListItem Value="Times New Roman">Times New Roman</asp:ListItem>
				<asp:ListItem Value="Comic Sans MS">Comic Sans MS</asp:ListItem>
			</asp:ListBox>
			<asp:RadioButton id="rbSmall" style="Z-INDEX: 102; LEFT: 215px; POSITION: absolute; TOP: 58px" runat="server" Text="Small" GroupName="FontSize" AutoPostBack="True" Font-Size="X-Small" Font-Names="Arial"></asp:RadioButton>
			<asp:RadioButton id="rbMedium" style="Z-INDEX: 103; LEFT: 215px; POSITION: absolute; TOP: 79px" runat="server" Text="Medium" GroupName="FontSize" Checked="True" AutoPostBack="True" Font-Size="X-Small" Font-Names="Arial"></asp:RadioButton>
			<asp:RadioButton id="rbLarge" style="Z-INDEX: 104; LEFT: 215px; POSITION: absolute; TOP: 100px" runat="server" Text="Large" GroupName="FontSize" AutoPostBack="True" Font-Size="X-Small" Font-Names="Arial"></asp:RadioButton>
			<asp:Label id="lblSampleText" style="Z-INDEX: 106; LEFT: 128px; POSITION: absolute; TOP: 186px" runat="server" Font-Names="Verdana" Font-Size="Medium" BackColor="White">Sample text</asp:Label>
			<asp:CheckBox id="CheckBox1" style="Z-INDEX: 107; LEFT: 54px; POSITION: absolute; TOP: 138px" runat="server" Text="Background" AutoPostBack="True" Font-Size="X-Small" Font-Names="Arial"></asp:CheckBox>
		</form>
	</body>
</HTML>
