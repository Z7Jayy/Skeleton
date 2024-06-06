<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaymentProcessingDataEntry.aspx.cs" Inherits="_1_DataEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
    <body style="background-color:ghostwhite;">

    <form id="form1" runat="server">
        <div>
        </div>
        <asp:TextBox ID="txtPaymentID" runat="server" style="z-index: 1; left: 1019px; top: 45px; position: absolute; width: 128px;" height="22px"></asp:TextBox>
        <p>
            <asp:Label ID="lblPaymentID" runat="server" style="z-index: 1; left: 787px; top: 50px; position: absolute; height: 18px; width: 73px;" Text="PaymentID"></asp:Label>
        </p>
        <asp:Label ID="lblTransactionID" runat="server" style="z-index: 1; left: 787px; top: 87px; position: absolute" Text="TransactionID" height="19px" width="73px"></asp:Label>
        <asp:TextBox ID="txtTransactionID" runat="server" style="z-index: 1; left: 1019px; top: 84px; position: absolute" height="22px" width="128px"></asp:TextBox>
        <asp:Label ID="lblAmount" runat="server" style="z-index: 1; left: 787px; top: 126px; position: absolute" Text="Amount" height="19px" width="73px"></asp:Label>
        <asp:TextBox ID="txtAmount" runat="server" style="z-index: 1; left: 1019px; top: 122px; position: absolute" height="22px" width="128px"></asp:TextBox>
        <asp:Label ID="lblPaymentDate" runat="server" style="z-index: 1; left: 787px; top: 162px; position: absolute" Text="PaymentDate" height="19px" width="73px"></asp:Label>
        <asp:TextBox ID="txtPaymentDate" runat="server" style="z-index: 1; left: 1019px; top: 160px; position: absolute" height="22px" width="128px"></asp:TextBox>
        <asp:Label ID="lblPaymentMethod" runat="server" style="z-index: 1; left: 787px; top: 195px; position: absolute" Text="PaymentMethod" height="19px" width="73px"></asp:Label>
        <asp:TextBox ID="txtPaymentMethod" runat="server" style="z-index: 1; left: 1019px; top: 192px; position: absolute" height="22px" width="128px"></asp:TextBox>
        <asp:TextBox ID="txtTicketID" runat="server" style="z-index: 1; left: 1019px; top: 225px; position: absolute" height="22px" width="128px"></asp:TextBox>
        <asp:CheckBox ID="CheckBoxIsPaymentSuccessful" runat="server" OnCheckedChanged="CheckBoxIsPaymentSuccessful_CheckedChanged" style="z-index: 1; left: 1008px; top: 277px; position: absolute" Text="IsPaymentSuccessful" />
        <asp:Label ID="lblError" runat="server" style="z-index: 1; left: 924px; top: 305px; position: absolute" Text="[lblError]"></asp:Label>
        <p>
            <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" style="z-index: 1; left: 801px; top: 352px; position: absolute; height: 28px; width: 62px;" Text="OK" />
        </p>
        <asp:Button ID="btnCancel" runat="server" style="z-index: 1; left: 967px; top: 351px; position: absolute; height: 28px; width: 62px;" Text="Cancel" OnClick="btnCancel_Click" />
        <asp:Button ID="btnMainMenu" runat="server" OnClick="btnMainMenu_Click" style="z-index: 1; left: 929px; top: 415px; position: absolute; width: 149px" Text="Return to Main Menu" />
        <p>
            &nbsp;</p>
        <asp:Button ID="btnFind" runat="server" OnClick="btnFind_Click" style="z-index: 1; left: 1123px; top: 351px; position: absolute; height: 28px; width: 62px;" Text="Find" />
        <p>
        <asp:Label ID="lblTicketID" runat="server" style="z-index: 1; left: 787px; top: 231px; position: absolute" Text="TicketID" height="19px" width="73px"></asp:Label>
        </p>
    </form>
</body>
</html>
