<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SeatSelectionList.aspx.cs" Inherits="_1_List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" style="z-index: 1; left: 178px; top: 348px; position: absolute" Text="Delete" />
            <asp:ListBox ID="lstBookingList" runat="server" style="z-index: 1; left: 2px; top: 58px; position: absolute; height: 265px; width: 291px"></asp:ListBox>
        </div>
        <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" style="z-index: 1; left: 25px; top: 349px; position: absolute" Text="Add" />
        <asp:Button ID="btnEdit" runat="server" OnClick="btnEdit_Click" style="z-index: 1; left: 98px; top: 349px; position: absolute" Text="Edit" />
        <p>
            <asp:Label ID="lblError" runat="server" style="z-index: 1; left: 22px; top: 608px; position: absolute"></asp:Label>
        </p>
</body>
</html>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <asp:TextBox ID="txtfilter" runat="server" style="z-index: 1; left: 175px; top: 471px; position: absolute"></asp:TextBox>
    <p>
        &nbsp;</p>
    <p>
        <asp:Label ID="lblSectionInput" runat="server" style="z-index: 1; left: 33px; top: 472px; position: absolute" Text="Enter a Section"></asp:Label>
    </p>
    <asp:Button ID="btnApply" runat="server" OnClick="btnApply_Click" style="z-index: 1; left: 28px; top: 528px; position: absolute; width: 89px; right: 1176px" Text="Apply Filter" />
    <asp:Button ID="btnClear" runat="server" height="26px" OnClick="btnClear_Click" style="z-index: 1; left: 196px; top: 528px; position: absolute" Text="Clear Filter" width="89px" />
    </form>

