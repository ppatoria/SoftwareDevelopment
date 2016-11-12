<%@ Page language="c#" Codebehind="DataBinding_StoringDatasetsSession.aspx.cs" AutoEventWireup="false" Inherits="VisualCSharpCorRef.DataBinding_StoringDatasetsSession" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DataBinding_StoringDatasetsSession</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="DataBinding_StoringDatasetsSession" method="post" runat="server">
			<asp:ListBox id=ListBox1 style="Z-INDEX: 101; LEFT: 97px; POSITION: absolute; TOP: 76px" runat="server" Height="101px" Width="133px" DataSource="<%# dsCategories1 %>" DataMember="Categories" DataTextField="CategoryName" DataValueField="CategoryID">
			</asp:ListBox>
			<asp:Button id="SubmitButton" style="Z-INDEX: 102; LEFT: 98px; POSITION: absolute; TOP: 183px" runat="server" Width="74px" Text="Submit"></asp:Button>
		</form>
	</body>
</HTML>
