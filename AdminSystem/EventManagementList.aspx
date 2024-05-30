<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EventManagementList.aspx.cs" Inherits="_1_List" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Event Management List</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ListBox ID="lstEventList" runat="server"></asp:ListBox>
        <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" />
        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
    </form>
</body>
</html>
