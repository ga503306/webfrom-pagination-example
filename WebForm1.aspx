<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="police.WebForm1" %>

<%@ Register Src="Pagination.ascx" TagName="Pagination" TagPrefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="css/StyleSheet1.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" Height="339px" Width="1024px">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                    <asp:BoundField DataField="cht" HeaderText="中文單位名稱" SortExpression="中文單位名稱" />
                    <asp:BoundField DataField="eng" HeaderText="英文單位名稱" SortExpression="英文單位名稱" />
                    <%--<asp:BoundField DataField="郵遞區號" HeaderText="郵遞區號" SortExpression="郵遞區號" />
                    <asp:BoundField DataField="地址" HeaderText="地址" SortExpression="地址" />
                    <asp:BoundField DataField="電話" HeaderText="電話" SortExpression="電話" />
                    <asp:BoundField DataField="POINT_X" HeaderText="POINT_X" SortExpression="POINT_X" />
                    <asp:BoundField DataField="POINT_Y" HeaderText="POINT_Y" SortExpression="POINT_Y" />--%>
                </Columns>
            </asp:GridView>
            <uc1:Pagination ID="Pagination1" runat="server" />
            <br />
        </div>
    </form>
</body>
</html>
