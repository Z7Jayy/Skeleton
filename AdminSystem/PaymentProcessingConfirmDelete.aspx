<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaymentProcessingConfirmDelete.aspx.cs" Inherits="_1_ConfirmDelete" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Confirm Delete</title>
    <style>
        body {
            font-family: sans-serif;
            background-color: ghostwhite;
            display: flex; /* Center the content */
            justify-content: center;
            align-items: center;
            min-height: 100vh;
        }

        .confirm-container {
            background-color: white;
            padding: 30px;
            border-radius: 8px;
            box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
        }

        #lblDeleteConfirmation {
            font-size: 18px; /* Use a more standard font size */
            margin-bottom: 20px;
            text-align: center;
        }

        .button-group {
            display: flex;
            justify-content: center; /* Center buttons */
            gap: 20px;
        }

        .button-group button {
            background-color: #dc3545; /* Red background for delete */
            color: white;
            border: none;
            padding: 10px 20px;
            border-radius: 5px;
            cursor: pointer;
        }

        #btnNo {
            background-color: #007bff; /* Blue background for cancel */
        }

        .button-group button:hover {
            opacity: 0.9; /* Subtle hover effect */
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="confirm-container">
        <asp:Label ID="lblDeleteConfirmation" runat="server" Text="Are you sure you would like to delete this record?"></asp:Label>

        <div class="button-group">
            <asp:Button ID="btnYes" runat="server" Text="Yes" OnClick="btnYes_Click" />
            <asp:Button ID="btnNo" runat="server" Text="No" OnClick="btnNo_Click" />
        </div>
    </form>
</body>
</html>
