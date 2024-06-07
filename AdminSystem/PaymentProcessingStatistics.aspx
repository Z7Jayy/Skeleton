<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaymentProcessingStatistics.aspx.cs" Inherits="PaymentProcessingStatistics" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Payment Processing Statistics</title>
    <style>
        body {
            font-family: sans-serif;
            background-color: ghostwhite;
        }

        .page-container {
            display: flex; /* Center content using Flexbox */
            justify-content: center;
            flex-direction: column; /* Stack children vertically */
            align-items: center;
            min-height: 100vh; /* Make sure container fills viewport */
            padding: 20px;
        }

        h1, h3 {
            text-align: center;
        }

        /* GridView Styling */
        .gridview-container {
            display: flex; /* Place GridViews side-by-side */
            justify-content: space-around;
            gap: 20px; /* Add space between GridViews */
            margin-bottom: 20px; /* Add space below GridViews */
        }

        .gridview-container .table {
            width: 300px; /* Adjust width as needed */
        }

        .gridview-container th {
            background-color: #333;
            color: white;
        }

        .gridview-container td {
            border: 1px solid #ddd; /* Add borders to cells */
            padding: 8px;
        }

        .gridview-container tr:nth-child(even) {
            background-color: #f2f2f2; /* Zebra striping */
        }

        /* Button Styling */
        #btnReturn {
            background-color: #007bff; /* Blue background */
            color: white;
            border: none;
            padding: 10px 20px;
            border-radius: 5px;
            cursor: pointer;
        }

        #btnReturn:hover {
            background-color: #0056b3; /* Darker blue on hover */
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="page-container">
        <h1>Statistics Page</h1>

        <div class="gridview-container">
            <h3>Payment List - Grouped by Amount</h3>
            <asp:GridView ID="GridViewGroupByAmount" runat="server" CssClass="table"></asp:GridView>

            <h3>Payment List - Grouped by Payment Date</h3>
            <asp:GridView ID="GridViewGroupByPaymentDate" runat="server" CssClass="table"></asp:GridView>
        </div>

        <asp:Button ID="btnReturn" runat="server" OnClick="btnReturn_Click" Text="Return to Previous Page" />
    </form>
</body>
</html>
