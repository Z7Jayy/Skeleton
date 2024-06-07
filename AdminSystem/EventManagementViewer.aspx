<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EventManagementViewer.aspx.cs" Inherits="_1Viewer" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Event Management Viewer</title>
    <style>
        body {
            font-family: Arial, sans-serif;
        }
        .container {
            max-width: 600px;
            margin: 50px auto;
            padding: 20px;
            background-color: #f4f4f9;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            border-radius: 8px;
        }
        h2 {
            text-align: center;
            color: #333;
        }
        .event-detail {
            margin: 10px 0;
        }
        .label {
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Event Details</h2>
            <div class="event-detail">
                <span class="label">Event ID: </span>
                <asp:Label ID="lblEventId" runat="server" />
            </div>
            <div class="event-detail">
                <span class="label">Event Name: </span>
                <asp:Label ID="lblEventName" runat="server" />
            </div>
            <div class="event-detail">
                <span class="label">Event Description: </span>
                <asp:Label ID="lblEventDescription" runat="server" />
            </div>
            <div class="event-detail">
                <span class="label">Event Date: </span>
                <asp:Label ID="lblEventDate" runat="server" />
            </div>
            <div class="event-detail">
                <span class="label">Venue ID: </span>
                <asp:Label ID="lblVenueId" runat="server" />
            </div>
            <div class="event-detail">
                <span class="label">Category: </span>
                <asp:Label ID="lblCategory" runat="server" />
            </div>
            <div class="event-detail">
                <span class="label">Is Online: </span>
                <asp:Label ID="lblIsOnline" runat="server" />
            </div>
            <div class="event-detail">
                <span class="label">Active: </span>
                <asp:Label ID="lblActive" runat="server" />
            </div>
            <div class="event-detail">
                <span class="label">Date Added: </span>
                <asp:Label ID="lblDateAdded" runat="server" />
            </div>
        </div>
    </form>
</body>
</html>
