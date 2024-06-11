<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SeatSelectionDataEntry.aspx.cs" Inherits="_1_DataEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            height: 5px;
        }
    </style>
</head>
<body style="height: 9px">
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:TextBox ID="txtBookingID" runat="server" style="z-index: 1; left: 255px; top: 37px; position: absolute"></asp:TextBox>
        <asp:Label ID="iblSeatId" runat="server" style="z-index: 1; left: 5px; top: 60px; position: absolute; width: 162px;" Text="Seat ID"></asp:Label>
        <asp:TextBox ID="txtSeatID" runat="server" style="z-index: 1; left: 255px; top: 67px; position: absolute"></asp:TextBox>
        <asp:Label ID="iblSeatType" runat="server" style="z-index: 1; left: 5px; top: 101px; position: absolute; width: 192px;" Text="Seat Type"></asp:Label>
        <asp:TextBox ID="txtSeatType" runat="server" style="z-index: 1; left: 255px; top: 102px; position: absolute"></asp:TextBox>
        <asp:Label ID="iblNumberOfSeats" runat="server" style="z-index: 1; left: 5px; top: 136px; position: absolute; width: 234px;" Text="Number Of Seats"></asp:Label>
        <asp:TextBox ID="txtNumberOfSeats" runat="server" style="z-index: 1; left: 255px; top: 129px; position: absolute"></asp:TextBox>
        <asp:TextBox ID="txtSection" runat="server" style="z-index: 1; top: 161px; position: absolute; left: 255px"></asp:TextBox>
        <asp:Label ID="iblBookingDate" runat="server" style="z-index: 1; left: 5px; top: 197px; position: absolute; width: 238px;" Text="Booking Date"></asp:Label>
        <asp:TextBox ID="txtBookingDate" runat="server" style="z-index: 1; left: 255px; top: 198px; position: absolute"></asp:TextBox>
        <asp:CheckBox ID="chkAvailability" runat="server" style="z-index: 1; left: 152px; top: 240px; position: absolute" Text="Availabilty"/>
        <asp:Label ID="iblError" runat="server" style="z-index: 1; left: 167px; top: 363px; position: absolute"></asp:Label>
        <asp:Button ID="btnOk" runat="server" OnClick="btnOk_Click" style="z-index: 1; left: 114px; top: 316px; position: absolute; height: 27px; width: 55px;" Text="OK" />
        <asp:Button ID="btnCancel" runat="server" Style="z-index: 1; top: 316px; position: absolute; right: 1252px; height: 27px; width: 55px;" Text="Cancel"/>
        <asp:Label ID="lblsection" runat="server" style="z-index: 1; left: 5px; top: 166px; position: absolute" Text="Section"></asp:Label>
        <p>
        <asp:Label ID="iblBookingId" runat="server" style="z-index: 1; left: 5px; top: 28px; position: absolute; bottom: 2206px; width: 232px; margin-right: 106px;" Text="Booking ID" height="36px"></asp:Label>
        <asp:Button ID="btnFind" runat="server" OnClick="btnFind_Click" style="z-index: 1; left: 554px; top: 42px; position: absolute" Text="Find" height="27px" width="55px" />
        </p>
    </form><br class="Apple-interchange-newline"><div id="outer-top" style="background-image: linear-gradient(to right top, black 10%, white 10%, white 40%, black 40%, black 60%, white 60%, white 90%, black 90%); background-size: 5px 5px; cursor: move; pointer-events: all; grid-area: 1 / 1 / 2 / 3; color: rgb(0, 0, 0); font-family: &quot;Times New Roman&quot;; font-size: medium; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; white-space: normal; text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial;"></div><div id="outer-left" style="background-image: linear-gradient(to right top, black 10%, white 10%, white 40%, black 40%, black 60%, white 60%, white 90%, black 90%); background-size: 5px 5px; cursor: move; pointer-events: all; grid-area: 2 / 1 / 4 / 2; color: rgb(0, 0, 0); font-family: &quot;Times New Roman&quot;; font-size: medium; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; white-space: normal; text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial;"></div><div id="outer-right" style="background-image: linear-gradient(to right top, black 10%, white 10%, white 40%, black 40%, black 60%, white 60%, white 90%, black 90%); background-size: 5px 5px; cursor: move; pointer-events: all; grid-area: 1 / 3 / 3 / 4; color: rgb(0, 0, 0); font-family: &quot;Times New Roman&quot;; font-size: medium; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; white-space: normal; text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial;"></div><br class="Apple-interchange-newline">
</body>
</html>
