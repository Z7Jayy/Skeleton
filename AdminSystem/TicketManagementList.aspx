<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TicketManagementList.aspx.cs" Inherits="_1_List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:ListBox ID="lstTicketList" runat="server" style="z-index: 1; left: 10px; top: 15px; position: absolute; height: 288px; width: 454px; margin-bottom: 48px"></asp:ListBox>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" style="z-index: 1; left: 20px; top: 334px; position: absolute; height: 26px; width: 55px" Text="Add" />
        <asp:Button ID="btnEdit" runat="server" OnClick="btnEdit_Click" style="z-index: 1; left: 112px; top: 334px; position: absolute; right: 1208px;" Text="Edit" height="26px" width="55px" />
        <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" style="z-index: 1; left: 213px; top: 334px; position: absolute" Text="Delete" />
        <asp:Label ID="lblEnterArtist" runat="server" style="z-index: 1; left: 20px; top: 396px; position: absolute" Text="Enter an Artist"></asp:Label>
        <p>
        <asp:Label ID="lblError" runat="server" style="z-index: 1; left: 20px; top: 501px; position: absolute"></asp:Label>
        </p>
        <asp:TextBox ID="txtFilter" runat="server" style="z-index: 1; left: 129px; top: 395px; position: absolute"></asp:TextBox>
        <p>
            <asp:Button ID="btnApplyFilter" runat="server" OnClick="btnApplyFilter_Click" style="z-index: 1; left: 20px; top: 457px; position: absolute" Text="Apply Filter" height="26px" width="139px" />
        </p>
        <asp:Button ID="btnClearFilter" runat="server" height="26px" OnClick="btnClearFilter_Click" style="z-index: 1; left: 194px; top: 457px; position: absolute" Text="Clear Filter" width="139px" />
        <asp:Button ID="btnStatisticsPage" runat="server" OnClick="btnStatisticsPage_Click" style="z-index: 1; left: 362px; top: 457px; position: absolute" Text="Statistics Page " />
        <asp:Button ID="btnMainMenu" runat="server" height="26px" OnClick="btnMainMenu_Click" style="z-index: 1; left: 532px; top: 457px; position: absolute" Text="Return to Main Menu" width="139px" />
    </form>
</body>
</html>
