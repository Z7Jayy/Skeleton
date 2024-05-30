using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TeamMainMenu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnPaymentProcessing_Click(object sender, EventArgs e)
    {
        //redirect the user to the Payment Processing list page
        Response.Redirect("PaymentProcessingList.aspx");
    }

    protected void btnTickets_Click(object sender, EventArgs e)
    {
        //redirect the user to the Payment Processing list page
        Response.Redirect("TicketManagementList.aspx");
    }
}