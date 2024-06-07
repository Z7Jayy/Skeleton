<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EventManagementConfirmDelete.aspx.cs" Inherits="_1_ConfirmDelete" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Confirm Delete</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f9;
            margin: 0;
            padding: 0;
        }
        .container {
            max-width: 600px;
            margin: 50px auto;
            padding: 20px;
            background-color: #fff;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            border-radius: 8px;
            text-align: center;
        }
        h2 {
            color: #333;
            margin-bottom: 20px;
        }
        .btn {
            display: inline-block;
            padding: 10px 20px;
            font-size: 16px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            margin-right: 10px;
            margin-bottom: 10px;
        }
        .btn-confirm {
            background-color: #ff4d4d;
            color: white;
        }
        .btn-confirm:hover {
            background-color: #d32f2f;
        }
        .btn-cancel {
            background-color: #f0f0f0;
            color: black;
            border: 1px solid #ccc;
        }
        .btn-cancel:hover {
            background-color: #ccc;
        }
        .error-message {
            color: red;
            margin-top: 20px;
        }
    </style>
</head>
<body>
    <div class="container">
        <form id="form1" runat="server">
            <h2>Are you sure you want to delete this event?</h2>
            <asp:Button ID="btnConfirmDelete" runat="server" Text="Yes, Delete" OnClick="btnConfirmDelete_Click" CssClass="btn btn-confirm" />
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CssClass="btn btn-cancel" />
            <div class="error-message">
                <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
            </div>
        </form>
    </div>
</body>
</html>
