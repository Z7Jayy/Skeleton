<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TicketManagementDataEntry.aspx.cs" Inherits="_1_DataEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblTicketId" runat="server" style="z-index: 1; left: 10px; top: 23px; position: absolute" Text="Ticket ID" width="73px"></asp:Label>
            <asp:TextBox ID="txtTicketId" runat="server" style="z-index: 1; left: 109px; top: 18px; position: absolute; width: 128px"></asp:TextBox>
        </div>
        <p>
            <asp:TextBox ID="txtDate" runat="server" OnTextChanged="TextBox1_TextChanged" style="z-index: 1; left: 109px; top: 45px; position: absolute; width: 128px"></asp:TextBox>
            <asp:Label ID="lblPrice" runat="server" style="z-index: 1; left: 10px; position: absolute; height: 20px; width: 73px; top: 73px" Text="Price"></asp:Label>
            <asp:TextBox ID="txtPrice" runat="server" OnTextChanged="TextBox1_TextChanged1" style="z-index: 1; left: 109px; top: 74px; position: absolute; height: 18px; width: 128px"></asp:TextBox>
        <asp:Label ID="lblDate" runat="server" style="z-index: 1; left: 10px; top: 48px; position: absolute; " Text="Date" width="73px"></asp:Label>
        </p>
        <p>
            <asp:Label ID="lblVenue" runat="server" style="z-index: 1; left: 10px; top: 102px; position: absolute" Text="Venue" width="73px"></asp:Label>
        </p>
        <p>
            <asp:TextBox ID="txtVenue" runat="server" style="z-index: 1; left: 109px; top: 102px; position: absolute" width="128px"></asp:TextBox>
            <asp:Label ID="lblArtist" runat="server" style="z-index: 1; left: 10px; top: 131px; position: absolute" Text="Artist" width="73px"></asp:Label>
            <asp:TextBox ID="txtArtist" runat="server" style="z-index: 1; left: 109px; top: 132px; position: absolute" width="128px"></asp:TextBox>
        </p>
        <asp:Label ID="lblIsSold" runat="server" style="z-index: 1; left: 10px; top: 163px; position: absolute" Text="Is Sold" width="73px"></asp:Label>
        <asp:TextBox ID="txtIsSold" runat="server" style="z-index: 1; left: 110px; top: 162px; position: absolute" width="128px"></asp:TextBox>
        <asp:Label ID="lblTicketType" runat="server" style="z-index: 1; left: 10px; top: 195px; position: absolute" Text="Ticket Type"></asp:Label>
        <asp:TextBox ID="txtTicketType" runat="server" style="z-index: 1; left: 110px; top: 193px; position: absolute" height="22px" width="128px"></asp:TextBox>
        <p>
            <asp:CheckBox ID="chkIsSold" runat="server" style="z-index: 1; left: 115px; top: 235px; position: absolute" Text="Is Sold" />
            <asp:Button ID="btnCancel" runat="server" style="z-index: 1; left: 118px; top: 309px; position: absolute" Text="Cancel" height="19px" width="56px" />
        </p>
        <asp:Label ID="lblError" runat="server" style="z-index: 1; left: 11px; top: 267px; position: absolute"></asp:Label>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" style="z-index: 1; left: 11px; top: 308px; position: absolute; width: 56px; height: 19px" Text="OK" />
    </form>
</body>
</html>
