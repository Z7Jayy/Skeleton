﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TeamMainMenu.aspx.cs" Inherits="TeamMainMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 503px">
        </div>
        <asp:Label ID="lblTicketWave" runat="server" Font-Size="Larger" style="z-index: 1; left: 257px; top: 41px; position: absolute; height: 35px; width: 249px" Text="Ticket Wave Main Menu"></asp:Label>
        <asp:Button ID="btnPaymentProcessing" runat="server" OnClick="btnPaymentProcessing_Click" style="z-index: 1; left: 339px; top: 175px; position: absolute; height: 31px; width: 101px" Text="Payments" />
    </form>
</body>
</html>
