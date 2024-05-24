<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaymentProcessingList.aspx.cs" Inherits="_1_List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblError" runat="server" style="z-index: 1; left: 26px; top: 754px; position: absolute" Text="[lblError]"></asp:Label>
            <asp:ListBox ID="tstPaymentList" runat="server" Height="676px" Width="1040px"></asp:ListBox>
        </div>
        <p>
            <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" style="z-index: 1; left: 23px; top: 706px; position: absolute" Text="Add" />
        </p>
        <asp:Button ID="btnEdit" runat="server" OnClick="btnEdit_Click" style="z-index: 1; left: 114px; top: 707px; position: absolute" Text="Edit" />
    </form>
</body>
</html>
