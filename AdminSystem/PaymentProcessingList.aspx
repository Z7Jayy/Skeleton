<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaymentProcessingList.aspx.cs" Inherits="_1_List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ListBox ID="tstPaymentList" runat="server" Height="680px" Width="1076px"></asp:ListBox>
        </div>
        <p>
            <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" style="z-index: 1; left: 23px; top: 706px; position: absolute" Text="Add" />
        </p>
    </form>
</body>
</html>
