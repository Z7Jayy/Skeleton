using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TicketManagementStatistics : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        clsTicket clsticket = new clsTicket();

        //retrieve data from the database 
        DataTable dT = clsticket.StatisticsGroupedByTicketType();

        //upload dT into gridview 
        GridViewStGroupByTicketType.DataSource = dT;
        GridViewStGroupByTicketType.DataBind();

        //change the header of the first column 
        GridViewStGroupByTicketType.HeaderRow.Cells[0].Text = " Total ";

        //retrieve data from the database 
        dT = clsticket.StatisticsGroupedByDate();

        //upload dt into grid view 
        GridViewStGroupByDate.DataSource = dT;
        GridViewStGroupByDate.DataBind();

        //change the header of the first column 
        GridViewStGroupByDate.HeaderRow.Cells[0].Text = " Total ";
    }



    protected void btnPreviousPage_Click(object sender, EventArgs e)
    {
        Response.Redirect("TicketManagementList.aspx");
    }
}