<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EventManagementDataEntry.aspx.cs" Inherits="_1_DataEntry" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Event Management Data Entry</title>
    <style>
        body {
            font-family: Arial, sans-serif;
        }
        .form-container {
            width: 50%;
            margin: 0 auto;
        }
        .form-container h2 {
            text-align: center;
        }
        .form-label {
            display: inline-block;
            width: 120px;
        }
        .form-input {
            display: inline-block;
            width: 200px;
        }
        .form-actions {
            text-align: center;
            margin-top: 20px;
        }
        .form-actions input {
            margin: 5px;
        }
        .error-label {
            color: red;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-container">
            <h2>Event Management Data Entry</h2>
            <div>
                <asp:Label ID="lblEventId" runat="server" CssClass="form-label" Text="Event ID"></asp:Label>
                <asp:TextBox ID="txtEventId" runat="server" CssClass="form-input"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lblEventName" runat="server" CssClass="form-label" Text="Event Name"></asp:Label>
                <asp:TextBox ID="txtEventName" runat="server" CssClass="form-input"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lblEventDescription" runat="server" CssClass="form-label" Text="Event Description"></asp:Label>
                <asp:TextBox ID="txtEventDescription" runat="server" CssClass="form-input"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lblEventDate" runat="server" CssClass="form-label" Text="Event Date"></asp:Label>
                <asp:TextBox ID="txtEventDate" runat="server" CssClass="form-input"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lblVenueId" runat="server" CssClass="form-label" Text="Venue ID"></asp:Label>
                <asp:TextBox ID="txtVenueId" runat="server" CssClass="form-input"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lblCategory" runat="server" CssClass="form-label" Text="Category"></asp:Label>
                <asp:TextBox ID="txtCategory" runat="server" CssClass="form-input"></asp:TextBox>
            </div>
            <div>
                <asp:CheckBox ID="chkIsOnline" runat="server" Text="Is Online" AutoPostBack="true" OnCheckedChanged="CheckBox1_CheckedChanged" />
            </div>
            <div>
                <asp:CheckBox ID="chkActive" runat="server" Text="Active" />
            </div>
            <div class="form-actions">
                <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" Text="OK" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClientClick="javascript:history.back(); return false;" />
            </div>
            <asp:Label ID="lblError" runat="server" CssClass="error-label"></asp:Label>
        </div>
    </form>
</body>
</html>
