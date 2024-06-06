<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EventManagementConfirmDelete.aspx.cs" Inherits="AdminSystem.EventManagementConfirmDelete" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Confirm Delete</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblEventDetails" runat="server" Text="Event Details"></asp:Label><br />
            <asp:Button ID="btnYes" runat="server" Text="Yes" OnClick="btnYes_Click" />
            <asp:Button ID="btnNo" runat="server" Text="No" OnClick="btnNo_Click" />
        </div>
    </form>
</body>
</html>
