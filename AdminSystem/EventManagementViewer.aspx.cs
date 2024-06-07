using System;
using System.Web.UI;
using ClassLibrary;

public partial class _1Viewer : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DisplayEventDetails();
        }
    }

    private void DisplayEventDetails()
    {
        // Retrieves event object from session
        clsEvent eventDetail = (clsEvent)Session["Event"];

        if (eventDetail != null)
        {
            lblEventId.Text = eventDetail.EventId.ToString();
            lblEventName.Text = eventDetail.EventName;
            lblEventDescription.Text = eventDetail.EventDescription;
            lblEventDate.Text = eventDetail.EventDate.ToString("dd-MM-yyyy");
            lblVenueId.Text = eventDetail.VenueId.ToString();
            lblCategory.Text = eventDetail.Category;
            lblIsOnline.Text = eventDetail.IsOnline ? "Yes" : "No";
            lblActive.Text = eventDetail.Active ? "Yes" : "No";
            lblDateAdded.Text = eventDetail.DateAdded.ToString("dd-MM-yyyy");
        }
        else
        {
            // Handles case where event detail is not found in session
            lblEventName.Text = "No event details available.";
        }
    }
}
