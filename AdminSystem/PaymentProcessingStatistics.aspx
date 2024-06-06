<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaymentProcessingStatistics.aspx.cs" Inherits="PaymentProcessingStatistics" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            height: 682px;
        }
    </style>
</head>
<body style="background-color:ghostwhite;">
    <form id="form1" runat="server">
        <div>
          
            <div style="text-align: center;"><h1 dir="ltr">  Statistics Page </h1></div>
            <div  style="text-align: center;">

             <h3 style="height: 28px"> Payment List - Grouped by Amount</h3>
        </div>

        <div style="text-align: center; height: 573px;">
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:GridView ID="GridViewGroupByAmount" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" HorizontalAlign="Center" Height="209px" Width="251px">
                 <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                 <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                 <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                 <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                 <SortedAscendingCellStyle BackColor="#F7F7F7" />
                 <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                 <SortedDescendingCellStyle BackColor="#E5E5E5" />
                 <SortedDescendingHeaderStyle BackColor="#242121" />
             </asp:GridView>

            <h3 style="height: 28px"> Payment List - Grouped by Payment Date</h3>
            <asp:GridView ID="GridViewGroupByPaymentDate" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" HorizontalAlign="Center" Height="225px" Width="265px">
                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#242121" />
             </asp:GridView>
        </div>
        </div>
        <p>
      <asp:Button ID="btnReturn" runat="server" OnClick="btnReturn_Click" style="z-index: 1; left: 477px; top: 654px; position: fixed; height: 27px; width: 173px" Text="Return to Previous Page" />


        </p>


</form>
</body>
</html>
