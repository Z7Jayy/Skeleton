using ClassLibrary;
using System;
using System.Web.UI;

public partial class _1_ConfirmDelete : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Your code for loading the page
    }

    protected void btnConfirmDelete_Click(object sender, EventArgs e)
    {
        try
        {
            // Gets the event ID from the session
            int eventId = Convert.ToInt32(Session["EventId"]);
            clsEventCollection EventList = new clsEventCollection();
            // If the event is found, delete it and redirects to the event list
            if (EventList.Find(eventId))
            {
                EventList.Delete(eventId); // Passes the eventId to the Delete method
                Response.Redirect("EventManagementList.aspx");
            }
            else
            {
                lblError.Text = "Event not found.";
            }
        }
        catch (Exception ex)
        {
            lblError.Text = "An error occurred: " + ex.Message;
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        // Redirects to the event list page
        Response.Redirect("EventManagementList.aspx");
    }
}
