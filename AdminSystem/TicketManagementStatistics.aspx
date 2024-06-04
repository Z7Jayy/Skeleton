<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TicketManagementStatistics.aspx.cs" Inherits="TicketManagementStatistics" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <div> <h1> Statistics Page </h1> </div>

        <div>
            <h3> Ticket List - Grouped by Ticket Type </h3>
        <asp:GridView ID="GridViewStGroupByTicketType" runat="server"></asp:GridView>
        </div>

        <div>
            <h3> Ticket List - Grouped by Date </h3>
        <asp:GridView ID="GridViewStGroupByDate" runat="server"></asp:GridView>
            </div>

        </div>
        <p>
            <asp:Button ID="btnPreviousPage" runat="server" OnClick="btnPreviousPage_Click" style="z-index: 1; left: 11px; top: 531px; position: absolute" Text="Back to Previous Page " />
        </p>
    </form>
</body>
</html>
