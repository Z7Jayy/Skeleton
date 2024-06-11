<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SeatSelectionConfirmDelete.aspx.cs" Inherits="_1_ConfirmDelete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <p>
            Are you sure you want to delete this record?</p>
        <asp:Button ID="btnYes" runat="server" OnClick="btnYes_Click" style="z-index: 1; left: 53px; top: 91px; position: absolute; width: 55px" Text="Yes" />
        <asp:Button ID="btnNo" runat="server" OnClick="btnNo_Click" style="z-index: 1; left: 141px; top: 90px; position: absolute; width: 53px" Text="No" />
    </form>
</body>
</html>
