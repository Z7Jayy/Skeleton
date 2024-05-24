<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaymentProcessingList.aspx.cs" Inherits="_1_List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            height: 832px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblError" runat="server" style="z-index: 1; left: 30px; top: 783px; position: absolute" Text="[lblError]"></asp:Label>
            <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" style="z-index: 1; left: 182px; top: 645px; position: absolute" Text="Delete" />
            <asp:Button ID="btnFilter" runat="server" OnClick="btnFilter_Click" style="z-index: 1; left: 41px; top: 736px; position: absolute" Text="Apply Filter" />
            <asp:ListBox ID="tstPaymentList" runat="server" Height="585px" Width="805px"></asp:ListBox>
            <asp:Label ID="lblTransactionID" runat="server" style="z-index: 1; left: 22px; top: 699px; position: absolute" Text="Enter a Transaction ID"></asp:Label>
        </div>
        <p>
            <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" style="z-index: 1; left: 22px; top: 646px; position: absolute" Text="Add" />
            <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" style="z-index: 1; left: 187px; top: 735px; position: absolute" Text="Clear Filter" />
        </p>
        <asp:Button ID="btnEdit" runat="server" OnClick="btnEdit_Click" style="z-index: 1; left: 106px; top: 647px; position: absolute" Text="Edit" />
        <asp:TextBox ID="txtTransactionID" runat="server" style="z-index: 1; left: 185px; top: 698px; position: absolute"></asp:TextBox>
    </form>
</body>
</html>
