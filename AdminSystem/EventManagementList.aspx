<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EventManagementList.aspx.cs" Inherits="_1_List" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Event Management List</title>
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
        .list {
            margin-bottom: 20px;
        }
        .btn {
            display: inline-block;
            padding: 10px 20px;
            font-size: 16px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            text-align: center;
            margin-right: 10px;
            margin-bottom: 10px;
        }
        .btn-edit {
            background-color: #007bff;
            color: #fff;
        }
        .btn-edit:hover {
            background-color: #0056b3;
        }
        .btn-delete {
            background-color: #ff4d4d;
            color: #fff;
        }
        .btn-delete:hover {
            background-color: #d32f2f;
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
            <h2>Event Management List</h2>
            <div class="list">
                <asp:ListBox ID="lstEventList" runat="server" Width="100%" Height="200px"></asp:ListBox>
            </div>
            <div>
                <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" CssClass="btn" />
                <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" CssClass="btn btn-edit" />
                <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" CssClass="btn btn-delete" />
            </div>
            <div>
                <asp:TextBox ID="txtEventName" runat="server" CssClass="form-control" Placeholder="Event Name" />
                <asp:Button ID="btnFilter" runat="server" Text="Apply Filter" OnClick="btnFilter_Click" CssClass="btn" />
                <asp:Button ID="btnClear" runat="server" Text="Clear Filter" OnClick="btnClear_Click" CssClass="btn" />
            </div>
            <div>
                <asp:Button ID="btnStatisticsPage" runat="server" Text="Statistics Page" OnClick="btnStatisticsPage_Click" CssClass="btn" />
                <asp:Button ID="btnMainMenu" runat="server" Text="Return to Main Menu" OnClick="btnMainMenu_Click" CssClass="btn" />
            </div>
            <div class="error-message">
                <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
            </div>
        </form>
    </div>
</body>
</html>
