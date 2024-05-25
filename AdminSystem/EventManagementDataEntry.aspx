<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EventManagementDataEntry.aspx.cs" Inherits="_1_DataEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Event Management Data Entry</title>
    <style>
        .form-label {
            position: absolute;
            width: 120px;
        }
        .form-input {
            position: absolute;
            width: 200px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblEventId" runat="server" class="form-label" style="left: 15px; top: 22px;" Text="Event ID"></asp:Label>
            <asp:TextBox ID="txtEventId" runat="server" class="form-input" style="left: 140px; top: 18px;"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblEventName" runat="server" class="form-label" style="left: 15px; top: 60px;" Text="Event Name"></asp:Label>
            <asp:TextBox ID="txtEventName" runat="server" class="form-input" style="left: 140px; top: 56px;"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblEventDescription" runat="server" class="form-label" style="left: 15px; top: 98px;" Text="Event Description"></asp:Label>
            <asp:TextBox ID="txtEventDescription" runat="server" class="form-input" style="left: 140px; top: 94px;"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblEventDate" runat="server" class="form-label" style="left: 15px; top: 136px;" Text="Event Date"></asp:Label>
            <asp:TextBox ID="txtEventDate" runat="server" class="form-input" style="left: 140px; top: 132px;"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblVenueId" runat="server" class="form-label" style="left: 15px; top: 174px;" Text="Venue ID"></asp:Label>
            <asp:TextBox ID="txtVenueId" runat="server" class="form-input" style="left: 140px; top: 170px;"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblCategory" runat="server" class="form-label" style="left: 15px; top: 212px;" Text="Category"></asp:Label>
            <asp:TextBox ID="txtCategory" runat="server" class="form-input" style="left: 140px; top: 208px;"></asp:TextBox>
        </div>
        <div>
            <asp:CheckBox ID="chkIsOnline" runat="server" style="position: absolute; left: 140px; top: 246px;" Text="Is Online" OnCheckedChanged="CheckBox1_CheckedChanged" AutoPostBack="true" />
        </div>
        <div>
            <asp:CheckBox ID="chkActive" runat="server" style="position: absolute; left: 140px; top: 274px;" Text="Active" />
        </div>
        <div>
            <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" style="position: absolute; left: 15px; top: 314px; width: 80px; height: 27px" Text="OK" />
            <asp:Button ID="btnCancel" runat="server" style="position: absolute; left: 110px; top: 314px; width: 80px; height: 27px" Text="Cancel" />
        </div>
        <div>
            <asp:Label ID="lblError" runat="server" style="position: absolute; left: 15px; top: 354px; color: red;"></asp:Label>
        </div>
    </form>
</body>
</html>
