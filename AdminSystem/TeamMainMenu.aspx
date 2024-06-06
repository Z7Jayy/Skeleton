<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TeamMainMenu.aspx.cs" Inherits="TeamMainMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 632px">

            <asp:Button ID="btnTickets" runat="server" OnClick="btnTickets_Click" style="z-index: 1; left: 1029px; top: 371px; position: absolute; height: 37px; width: 122px;" Text="Tickets" />
            <asp:Image ID="Image1" runat="server" src="https://i.ibb.co/g7N7XBd/Picture1.png" style="z-index: 1; left: 735px; top: 93px; position: absolute; height: 254px; width: 384px" />
        </div>
        <asp:Label ID="lblTicketWave" runat="server" Font-Size="Larger" style="z-index: 1; left: 765px; top: 30px; position: absolute; height: 56px; width: 325px; bottom: 752px; font-size: xx-large;" Text="Ticket Wave Main Menu"></asp:Label>
        <asp:Button ID="btnPaymentProcessing" runat="server" OnClick="btnPaymentProcessing_Click" style="z-index: 1; left: 717px; top: 371px; position: absolute; height: 37px; width: 115px" Text="Payments" />

    </form>
</body>
</html>
