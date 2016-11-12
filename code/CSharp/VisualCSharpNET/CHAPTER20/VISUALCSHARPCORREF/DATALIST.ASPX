<%@ Page language="c#" Codebehind="DataList.aspx.cs" AutoEventWireup="false" Inherits="VisualCSharpCorRef.DataList" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DataList</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="DataList" method="post" runat="server">
			<asp:DataList id=DataList1 style="Z-INDEX: 101; LEFT: 59px; POSITION: absolute; TOP: 80px" runat="server" DataSource="<%# dsCategories1 %>" DataMember="Categories" BorderColor="#999999" BorderStyle="None" BackColor="White" CellPadding="3" GridLines="Vertical" BorderWidth="1px" RepeatColumns="2">
				<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#DCDCDC"></AlternatingItemStyle>
				<ItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
				<ItemTemplate>
					<asp:Label id=Label1 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CategoryName") %>'>
					</asp:Label>&nbsp;(
					<asp:Label id=Label2 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CategoryID") %>'>
					</asp:Label>)
				</ItemTemplate>
				<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084"></HeaderStyle>
			</asp:DataList>
		</form>
	</body>
</HTML>
