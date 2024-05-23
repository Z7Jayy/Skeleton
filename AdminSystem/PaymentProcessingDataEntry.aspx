<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaymentProcessingDataEntry.aspx.cs" Inherits="_1_DataEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:TextBox ID="txtPaymentID" runat="server" style="z-index: 1; left: 121px; top: 34px; position: absolute"></asp:TextBox>
        <p>
            <asp:Label ID="lblPaymentID" runat="server" style="z-index: 1; left: 10px; top: 34px; position: absolute" Text="PaymentID"></asp:Label>
        </p>
        <asp:Label ID="lblTransactionID" runat="server" style="z-index: 1; left: 9px; top: 74px; position: absolute" Text="TransactionID"></asp:Label>
        <asp:TextBox ID="txtTransactionID" runat="server" style="z-index: 1; left: 121px; top: 74px; position: absolute"></asp:TextBox>
        <asp:Label ID="lblAmount" runat="server" style="z-index: 1; left: 10px; top: 108px; position: absolute" Text="Amount"></asp:Label>
        <asp:TextBox ID="txtAmount" runat="server" style="z-index: 1; left: 122px; top: 108px; position: absolute"></asp:TextBox>
        <asp:Label ID="lblPaymentDate" runat="server" style="z-index: 1; left: 10px; top: 143px; position: absolute" Text="PaymentDate"></asp:Label>
        <asp:TextBox ID="txtPaymentDate" runat="server" style="z-index: 1; left: 122px; top: 144px; position: absolute"></asp:TextBox>
        <asp:Label ID="lblPaymentMethod" runat="server" style="z-index: 1; left: 11px; top: 179px; position: absolute" Text="PaymentMethod"></asp:Label>
        <asp:TextBox ID="txtPaymentMethod" runat="server" style="z-index: 1; left: 122px; top: 180px; position: absolute"></asp:TextBox>
        <asp:Label ID="lblTicketID" runat="server" style="z-index: 1; left: 11px; top: 209px; position: absolute" Text="TicketID"></asp:Label>
        <asp:TextBox ID="txtTicketID" runat="server" style="z-index: 1; left: 122px; top: 210px; position: absolute"></asp:TextBox>
        <asp:CheckBox ID="CheckBoxIsPaymentSuccessful" runat="server" OnCheckedChanged="CheckBoxIsPaymentSuccessful_CheckedChanged" style="z-index: 1; left: 115px; top: 255px; position: absolute" Text="IsPaymentSuccessful" />
        <asp:Label ID="lblError" runat="server" style="z-index: 1; left: 13px; top: 277px; position: absolute" Text="[lblError]"></asp:Label>
        <p>
            <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" style="z-index: 1; left: 27px; top: 313px; position: absolute" Text="OK" />
        </p>
        <asp:Button ID="btnCancel" runat="server" style="z-index: 1; left: 100px; top: 312px; position: absolute" Text="Cancel" />
        <p>
            &nbsp;</p>
        <asp:Button ID="btnFind" runat="server" OnClick="btnFind_Click" style="z-index: 1; left: 210px; top: 310px; position: absolute" Text="Find" />
    </form>
</body>
</html>
