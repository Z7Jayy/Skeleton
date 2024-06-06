using ClassLibrary;
using System;

namespace AdminSystem
{
    public partial class EventManagementConfirmDelete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Retrieve the EventID from the query string
            int eventId = Convert.ToInt32(Request.QueryString["EventID"]);
            if (!IsPostBack)
            {
                // Initialize the event collection and find the event
                clsEventCollection Events = new clsEventCollection();
                Events.ThisEvent.Find(eventId);

                // Display event details
                lblEventDetails.Text = "Are you sure you want to delete the event: " + Events.ThisEvent.EventName + "?";
            }
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            // Delete the event
            int eventId = Convert.ToInt32(Request.QueryString["EventID"]);
            clsEventCollection Events = new clsEventCollection();
            Events.ThisEvent.Find(eventId);
            Events.Delete();

            // Redirect to the event management list page
            Response.Redirect("EventManagementList.aspx");
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            // Redirect to the event management list page without deleting
            Response.Redirect("EventManagementList.aspx");
        }
    }
}
