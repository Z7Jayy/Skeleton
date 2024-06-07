<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaymentProcessingList.aspx.cs" Inherits="_1_List" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Payment Processing List</title>
    <style>
        body {
            font-family: sans-serif;
            background-color: ghostwhite;
            display: flex; /* Center content */
            justify-content: center;
            align-items: center;
            min-height: 100vh;
        }

        .list-container {
            background-color: white;
            padding: 30px;
            border-radius: 8px;
            box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1); /* Subtle shadow */
            width: 600px; /* Adjust width as needed */
        }

        #tstPaymentList {
            width: 100%; /* Make listbox take full width */
            height: 300px; /* Adjust height as needed */
            border: 1px solid #ccc;
            padding: 10px;
            border-radius: 4px;
        }
        
        .form-group {
            margin-bottom: 15px;
        }

        .form-group label {
            display: block;
            margin-bottom: 5px;
        }

        .form-group input[type="text"] {
            width: calc(100% - 12px);
            padding: 8px;
            border: 1px solid #ccc;
            border-radius: 4px;
        }

        .button-group {
            display: flex;
            justify-content: space-between; /* Evenly space buttons */
            margin-top: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="list-container">
        <h2>Payment Processing List</h2>
        
        <asp:ListBox ID="tstPaymentList" runat="server"></asp:ListBox>

        <div class="form-group">
            <asp:Label ID="lblTransactionID" runat="server" Text="Enter a Transaction ID:" AssociatedControlID="txtTransactionID"></asp:Label>
            <asp:TextBox ID="txtTransactionID" runat="server"></asp:TextBox>
        </div>

        <div class="button-group">
            <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
            <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
        </div>
       
        <div class="button-group">
            <asp:Button ID="btnFilter" runat="server" Text="Apply Filter" OnClick="btnFilter_Click" />
            <asp:Button ID="btnClear" runat="server" Text="Clear Filter" OnClick="btnClear_Click" />
        </div>
        <div class="button-group">
            <asp:Button ID="btnStatisticsPage" runat="server" Text="Statistics Page" OnClick="btnStatisticsPage_Click" UseSubmitBehavior="False" />
            <asp:Button ID="btnMainMenu" runat="server" Text="Return to Main Menu" OnClick="btnMainMenu_Click" />
        </div>
         <asp:Label ID="lblError" runat="server" Text="[lblError]"></asp:Label>
    </form>
</body>
</html>
