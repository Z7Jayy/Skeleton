<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EventManagementList.aspx.cs" Inherits="_1_List" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Event Management List</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f0f0f0;
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }
        .container {
            background-color: #fff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            text-align: center;
        }
        .container h1 {
            font-size: 24px;
            margin-bottom: 20px;
        }
        .container .buttons {
            display: flex;
            justify-content: center;
            gap: 10px;
        }
        .container .buttons button {
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            font-size: 16px;
        }
        .container .buttons .btn-yes {
            background-color: #d9534f;
            color: #fff;
        }
        .container .buttons .btn-no {
            background-color: #5bc0de;
            color: #fff;
        }
        .container .buttons button:hover {
            opacity: 0.9;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ListBox ID="lstEventList" runat="server"></asp:ListBox>
        <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" />
        <asp:Button ID="btnAddNew" runat="server" Text="Add New" OnClick="btnAddNew_Click" />
        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
    </form>
</body>
</html>
