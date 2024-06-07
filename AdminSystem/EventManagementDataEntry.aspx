<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EventManagementDataEntry.aspx.cs" Inherits="_1_DataEntry" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Event Management Data Entry</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f9;
            margin: 0;
            padding: 0;
        }
        .container {
            max-width: 800px;
            margin: 50px auto;
            padding: 20px;
            background-color: #fff;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            border-radius: 8px;
        }
        h2 {
            text-align: center;
            margin-bottom: 20px;
            color: #333;
        }
        .form-group {
            margin-bottom: 15px;
        }
        .form-label {
            display: block;
            margin-bottom: 5px;
            font-weight: bold;
        }
        .form-input {
            width: 100%;
            padding: 8px;
            box-sizing: border-box;
            border: 1px solid #ccc;
            border-radius: 4px;
        }
        .btn-group {
            text-align: center;
            margin-top: 20px;
        }
        .btn {
            padding: 10px 20px;
            font-size: 16px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            margin-right: 10px;
            margin-bottom: 10px;
        }
        .btn-primary {
            background-color: #007bff;
            color: #fff;
        }
        .btn-primary:hover {
            background-color: #0056b3;
        }
        .btn-secondary {
            background-color: #6c757d;
            color: #fff;
        }
        .btn-secondary:hover {
            background-color: #5a6268;
        }
        .error-message {
            color: red;
            margin-top: 20px;
            text-align: center;
        }
    </style>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.min.js"></script>
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <script>
        $(function () {
            $("#<%= txtEventDate.ClientID %>").datepicker({
                dateFormat: "dd-mm-yy"
            });
        });
    </script>
</head>
<body>
    <div class="container">
        <h2>Event Management Data Entry</h2>
        <form id="form1" runat="server">
            <div class="form-group">
                <label for="txtEventId" class="form-label">Event ID</label>
                <asp:TextBox ID="txtEventId" runat="server" CssClass="form-input"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtEventName" class="form-label">Event Name</label>
                <asp:TextBox ID="txtEventName" runat="server" CssClass="form-input"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtEventDescription" class="form-label">Event Description</label>
                <asp:TextBox ID="txtEventDescription" runat="server" CssClass="form-input"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtEventDate" class="form-label">Event Date</label>
                <asp:TextBox ID="txtEventDate" runat="server" CssClass="form-input"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtVenueId" class="form-label">Venue ID</label>
                <asp:TextBox ID="txtVenueId" runat="server" CssClass="form-input"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtCategory" class="form-label">Category</label>
                <asp:TextBox ID="txtCategory" runat="server" CssClass="form-input"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:CheckBox ID="chkIsOnline" runat="server" Text="Is Online" CssClass="form-label" />
            </div>
            <div class="form-group">
                <asp:CheckBox ID="chkActive" runat="server" Text="Active" CssClass="form-label" />
            </div>
            <div class="btn-group">
                <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" CssClass="btn btn-primary" Text="OK" />
                <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" CssClass="btn btn-secondary" Text="Cancel" />
                <asp:Button ID="btnMainMenu" runat="server" OnClick="btnMainMenu_Click" CssClass="btn btn-secondary" Text="Return to Main Menu" />
            </div>
            <div class="error-message">
                <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
            </div>
        </form>
    </div>
</body>
</html>
