<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaymentProcessingDataEntry.aspx.cs" Inherits="_1_DataEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 289px">
    <form id="form1" runat="server">
        <div id="paymentID">
        </div>
        <p>
            &nbsp;</p>
        <p>
            <asp:Label ID="txtpaymentID" runat="server" height="19px" style="z-index: 1; left: 9px; top: 35px; position: absolute; bottom: 575px" Text="Payment ID" width="104px"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" style="z-index: 1; left: 155px; top: 34px; position: absolute"></asp:TextBox>
        </p>
        <p>
            <asp:TextBox ID="TextBox2" runat="server" style="z-index: 1; left: 155px; top: 77px; position: absolute"></asp:TextBox>
        </p>
        <asp:Label ID="txttransactionID" runat="server" height="19px" style="z-index: 1; left: 9px; top: 77px; position: absolute; margin-bottom: 0px" Text="Transaction ID" width="104px"></asp:Label>
        <asp:Label ID="txtamount" runat="server" height="19px" style="z-index: 1; left: 9px; top: 117px; position: absolute" Text="Amount" width="104px"></asp:Label>
        <asp:TextBox ID="TextBox3" runat="server" style="z-index: 1; left: 156px; top: 117px; position: absolute"></asp:TextBox>
        <asp:Label ID="paymentDate" runat="server" style="z-index: 1; left: 9px; top: 158px; position: absolute; height: 19px" Text="Date" width="104px"></asp:Label>
        <asp:TextBox ID="TextBox4" runat="server" style="z-index: 1; left: 155px; top: 158px; position: absolute"></asp:TextBox>
        <asp:Label ID="txtticketId" runat="server" height="19px" style="z-index: 1; left: 11px; top: 194px; position: absolute" Text="Ticket ID" width="104px"></asp:Label>
        <asp:TextBox ID="TextBox7" runat="server" style="z-index: 1; left: 157px; top: 195px; position: absolute"></asp:TextBox>
        <p>
        <asp:CheckBox ID="chkisPaymentSuccessful" runat="server" style="z-index: 1; left: 153px; top: 269px; position: absolute" Text="Payment Successful?" Checked="True" />
        </p>
        <asp:Label ID="Label1" runat="server" style="z-index: 1; left: 17px; top: 312px; position: absolute" Text="[lblError]"></asp:Label>
        <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" style="z-index: 1; left: 27px; top: 343px; position: absolute" Text="OK" />
  <asp:DropDownList ID="ddlpaymentMethod" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
    <asp:ListItem Text="Paypal" Value="Paypal"></asp:ListItem>
    <asp:ListItem Text="Debit Card" Value="Debit Card"></asp:ListItem>
    <asp:ListItem Text="Credit Card" Value="Credit Card"></asp:ListItem>
</asp:DropDownList>

                   <div style="height: 19px">
       <asp:Label ID="lblError" runat="server" ForeColor="Red" />
   </div>
        
    </form>
</body>
</html>
