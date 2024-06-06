<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EventManagementStatistics.aspx.cs" Inherits="EventManagementStatistics" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Event Statistics</title>
    <style>
        body {
            font-family: Arial, sans-serif;
        }
        .stats-container {
            width: 60%;
            margin: 0 auto;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="stats-container">
            <h2>Event Statistics</h2>
            <asp:Label ID="lblStatistics" runat="server" Text="This is the Event Management Statistics page."></asp:Label>
        </div>
    </form>
</body>
</html>
