<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaymentProcessingDataEntry.aspx.cs" Inherits="_1_DataEntry" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Payment Processing Data Entry</title>
    <style>
        body {
            font-family: sans-serif;
            background-color: ghostwhite;
            display: flex;
            justify-content: center;
            align-items: center;
            min-height: 100vh;
        }

        .form-container {
            background-color: white;
            padding: 30px;
            border-radius: 8px;
            box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
            width: 400px; 
        }

        .form-group {
            margin-bottom: 15px;
        }

        .form-group label {
            display: block;
            margin-bottom: 5px;
        }

        .form-group input[type="text"],
        .form-group input[type="date"] {
            width: calc(100% - 12px);
            padding: 8px;
            border: 1px solid #ccc;
            border-radius: 4px;
        }

        .button-group {
            display: flex;
            justify-content: space-between;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-container"> 
            <div class="form-group">
                <asp:Label ID="lblPaymentID" runat="server" Text="PaymentID" AssociatedControlID="txtPaymentID"></asp:Label>
                <asp:TextBox ID="txtPaymentID" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="lblTransactionID" runat="server" Text="TransactionID" AssociatedControlID="txtTransactionID"></asp:Label>
                <asp:TextBox ID="txtTransactionID" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="lblAmount" runat="server" Text="Amount" AssociatedControlID="txtAmount"></asp:Label>
                <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="lblPaymentDate" runat="server" Text="PaymentDate" AssociatedControlID="txtPaymentDate"></asp:Label>
                <asp:TextBox ID="txtPaymentDate" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="lblPaymentMethod" runat="server" Text="PaymentMethod" AssociatedControlID="txtPaymentMethod"></asp:Label>
                <asp:TextBox ID="txtPaymentMethod" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="lblTicketID" runat="server" Text="TicketID" AssociatedControlID="txtTicketID"></asp:Label>
                <asp:TextBox ID="txtTicketID" runat="server"></asp:TextBox>
            </div>

            <div class="form-group checkbox">
                <asp:CheckBox ID="CheckBoxIsPaymentSuccessful" runat="server" Text="IsPaymentSuccessful" OnCheckedChanged="CheckBoxIsPaymentSuccessful_CheckedChanged" />
            </div>
            <asp:Label ID="lblError" runat="server" Text="[lblError]"></asp:Label>

            <div class="form-group button-group">
                <asp:Button ID="btnOK" runat="server" Text="OK" OnClick="btnOK_Click" />
                <asp:Button ID="btnFind" runat="server" Text="Find" OnClick="btnFind_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                <asp:Button ID="btnMainMenu" runat="server" Text="Return to Main Menu" OnClick="btnMainMenu_Click" />
            </div>
        </div>
    </form>
</body>
</html>
