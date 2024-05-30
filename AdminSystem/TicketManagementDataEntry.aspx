<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TicketManagementDataEntry.aspx.cs" Inherits="_1_DataEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblTicketId" runat="server" style="z-index: 1; left: 15px; top: 22px; position: absolute" Text="Ticket ID" width="73px"></asp:Label>
            <asp:TextBox ID="txtTicketId" runat="server" style="z-index: 1; left: 109px; top: 18px; position: absolute; width: 128px"></asp:TextBox>
        </div>
        <p>
            <asp:TextBox ID="txtDate" runat="server" OnTextChanged="TextBox1_TextChanged" style="z-index: 1; left: 109px; top: 45px; position: absolute; width: 128px"></asp:TextBox>
            <asp:Label ID="lblPrice" runat="server" style="z-index: 1; left: 15px; position: absolute; height: 20px; width: 73px; top: 73px" Text="Price"></asp:Label>
            <asp:TextBox ID="txtPrice" runat="server" OnTextChanged="TextBox1_TextChanged1" style="z-index: 1; left: 109px; top: 74px; position: absolute; height: 18px; width: 128px"></asp:TextBox>
        <asp:Label ID="lblDate" runat="server" style="z-index: 1; left: 15px; top: 48px; position: absolute; " Text="Date" width="73px"></asp:Label>
            <asp:Button ID="btnFind" runat="server" OnClick="btnFind_Click" style="z-index: 1; left: 294px; top: 28px; position: absolute; width: 80px; height: 27px" Text="Find" />
        </p>
        <p>
            <asp:Label ID="lblVenue" runat="server" style="z-index: 1; left: 15px; top: 100px; position: absolute" Text="Venue" width="73px"></asp:Label>
        </p>
        <p>
            <asp:TextBox ID="txtVenue" runat="server" style="z-index: 1; left: 109px; top: 102px; position: absolute" width="128px"></asp:TextBox>
            <asp:Label ID="lblArtist" runat="server" style="z-index: 1; left: 15px; top: 131px; position: absolute; bottom: 533px;" Text="Artist" width="73px"></asp:Label>
            <asp:TextBox ID="txtArtist" runat="server" style="z-index: 1; left: 109px; top: 132px; position: absolute" width="128px"></asp:TextBox>
        </p>
        <asp:Label ID="lblTicketType" runat="server" style="z-index: 1; left: 13px; top: 170px; position: absolute" Text="Ticket Type"></asp:Label>
        <asp:TextBox ID="txtTicketType" runat="server" style="z-index: 1; left: 110px; top: 166px; position: absolute; height: 17px;" width="128px" OnTextChanged="txtTicketType_TextChanged"></asp:TextBox>
        <p>
            <asp:CheckBox ID="chkIsSold" runat="server" style="z-index: 1; left: 115px; top: 235px; position: absolute" Text="Is Sold" />
            <asp:Button ID="btnCancel" runat="server" style="z-index: 1; left: 118px; top: 304px; position: absolute" Text="Cancel" height="26px" width="56px" OnClick="btnCancel_Click" />
        </p>
        <asp:Label ID="lblError" runat="server" style="z-index: 1; left: 15px; top: 267px; position: absolute"></asp:Label>
        <p>
            &nbsp;</p>
        <p>
            <asp:Button ID="btnMainMenu" runat="server" OnClick="btnMainMenu_Click" style="z-index: 1; left: 224px; top: 304px; position: absolute" Text="Return to Main Menu" />
        </p>
        <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" style="z-index: 1; left: 11px; top: 304px; position: absolute; width: 56px; height: 26px" Text="OK" />
    </form>
</body>
</html>
