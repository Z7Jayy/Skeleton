<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TeamMainMenu.aspx.cs" Inherits="TeamMainMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ticket Wave Main Menu</title>
    <style>
        body {
            font-family: Arial, sans-serif;
        }
        .main-container {
            position: relative;
            height: 632px;
        }
        .title {
            position: absolute;
            left: 765px;
            top: 30px;
            font-size: xx-large;
            height: 56px;
            width: 325px;
            text-align: center;
        }
        .image {
            position: absolute;
            left: 735px;
            top: 93px;
            height: 254px;
            width: 384px;
        }
        .button {
            position: absolute;
            height: 37px;
            width: 122px;
        }
        .btn-payment {
            left: 717px;
            top: 371px;
        }
        .btn-events {
            left: 873px;
            top: 371px;
        }
        .btn-tickets {
            left: 1029px;
            top: 371px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="main-container">
            <asp:Label ID="lblTicketWave" runat="server" CssClass="title" Text="Ticket Wave Main Menu"></asp:Label>
            <asp:Image ID="Image1" runat="server" ImageUrl="https://i.ibb.co/g7N7XBd/Picture1.png" CssClass="image" />
            <asp:Button ID="btnPaymentProcessing" runat="server" CssClass="button btn-payment" Text="Payments" OnClick="btnPaymentProcessing_Click" />
            <asp:Button ID="btnEvents" runat="server" CssClass="button btn-events" Text="Events" OnClick="btnEvents_Click" />
            <asp:Button ID="btnTickets" runat="server" CssClass="button btn-tickets" Text="Tickets" OnClick="btnTickets_Click" />
        </div>
    </form>
</body>
</html>
