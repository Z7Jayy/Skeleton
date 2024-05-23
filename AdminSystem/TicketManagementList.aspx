<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TicketManagementList.aspx.cs" Inherits="_1_List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:ListBox ID="lstTicketList" runat="server" style="z-index: 1; left: 10px; top: 15px; position: absolute; height: 288px; width: 454px; margin-bottom: 48px"></asp:ListBox>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" style="z-index: 1; left: 15px; top: 335px; position: absolute; height: 32px; width: 58px" Text="Add" />
    </form>
</body>
</html>
