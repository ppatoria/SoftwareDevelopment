<%@ Page language="c#" Codebehind="Calculator2.aspx.cs" AutoEventWireup="false" Inherits="VisualCSharpCorRef.Calculator2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Calculator2</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<font face="verdana" size="xx-small">
			<form id="Form1" method="post" runat="server">
				<asp:textbox id="txtNumber1" style="Z-INDEX: 101; LEFT: 58px; POSITION: absolute; TOP: 47px" runat="server" Width="92px"></asp:textbox><asp:button id="btnDivide" style="Z-INDEX: 105; LEFT: 133px; POSITION: absolute; TOP: 87px" runat="server" Text="/" CommandName="Divide"></asp:button><asp:button id="btnMultiply" style="Z-INDEX: 104; LEFT: 106px; POSITION: absolute; TOP: 87px" runat="server" Text="*" CommandName="Multiply"></asp:button><asp:button id="btnAdd" style="Z-INDEX: 103; LEFT: 58px; POSITION: absolute; TOP: 87px" runat="server" Text="+" CommandName="Add"></asp:button><asp:button id="btnSubtract" style="Z-INDEX: 102; LEFT: 80px; POSITION: absolute; TOP: 87px" runat="server" Text="-" CommandName="Subtract"></asp:button><asp:button id="btnClear" style="Z-INDEX: 106; LEFT: 57px; POSITION: absolute; TOP: 117px" runat="server" Text="Clear" Width="96px"></asp:button></form>
		</font>
	</body>
</HTML>
