<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TicketManagementConfirmDelete.aspx.cs" Inherits="_1_ConfirmDelete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Button ID="btnYes" runat="server" OnClick="btnYes_Click" style="z-index: 1; left: 174px; top: 222px; position: absolute; height: 26px; width: 64px" Text="Yes" />
        <asp:Button ID="btnNo" runat="server" OnClick="btnNo_Click" style="z-index: 1; left: 283px; top: 222px; position: absolute; height: 26px; width: 64px" Text="No" />
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <asp:Label ID="lblConfirmDelete" runat="server" style="z-index: 1; left: 126px; top: 157px; position: absolute" Text="Are you sure you want to delete this record ?"></asp:Label>
    </form>
</body>
</html>
