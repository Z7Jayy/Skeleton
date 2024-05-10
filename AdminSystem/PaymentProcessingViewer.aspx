<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaymentProcessingViewer.aspx.cs" Inherits="_1Viewer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <title>Payment Details</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Payment Details</h2>
            <asp:Label ID="lblTransactionID" runat="server" /><br />
            <asp:Label ID="lblAmount" runat="server" /><br />
            <asp:Label ID="lblPaymentDate" runat="server" /><br />
            <asp:Label ID="lblIsPaymentSuccessful" runat="server" /><br />
            <asp:Label ID="lblPaymentMethod" runat="server" /><br />
            <asp:Label ID="lblTicketId" runat="server" /><br />
        </div>
        <div>
            <asp:Label ID="lblError" runat="server" ForeColor="Red" />
        </div>
    </form>
</body>
</html>
