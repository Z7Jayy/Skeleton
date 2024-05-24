<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaymentProcessingConfirmDelete.aspx.cs" Inherits="_1_ConfirmDelete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 554px">
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="lblDeleteConfirmation" runat="server" style="z-index: 1; left: 272px; top: 52px; position: absolute" Text="Are you sure you would like to delte this record?"></asp:Label>
        <asp:Button ID="btnYes" runat="server" OnClick="btnYes_Click" style="z-index: 1; left: 273px; top: 123px; position: absolute; width: 49px" Text="Yes" />
        <asp:Button ID="btnNo" runat="server" OnClick="btnNo_Click" style="z-index: 1; left: 506px; top: 120px; position: absolute; width: 57px" Text="No" />
    </form>
</body>
</html>
