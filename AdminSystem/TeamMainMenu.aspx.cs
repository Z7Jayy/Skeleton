using System;
using System.Web.UI;

public partial class TeamMainMenu : Page
{
    protected void btnPaymentProcessing_Click(object sender, EventArgs e)
    {
        // Redirects the user to the Payment Processing list page
        Response.Redirect("PaymentProcessingList.aspx");
    }

    protected void btnEvents_Click(object sender, EventArgs e)
    {
        // Redirects the user to the Event Management list page
        Response.Redirect("EventManagementList.aspx");
    }

    protected void btnTickets_Click(object sender, EventArgs e)
    {
        // Redirects the user to the ticket management list page
        Response.Redirect("TicketManagementList.aspx");
    }
}
