using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class _1_DataEntry : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Any initialization code you need
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        // Create a new instance of clsEvent
        clsEvent AnEvent = new clsEvent();

        // Capture the Event ID
        int EventId = string.IsNullOrEmpty(txtEventId.Text) ? -1 : Convert.ToInt32(txtEventId.Text);

        // Capture the Event Name
        string EventName = txtEventName.Text;

        // Capture the Event Description
        string EventDescription = txtEventDescription.Text;

        // Capture the Event Date
        string EventDate = txtEventDate.Text;

        // Capture the Venue ID
        string VenueId = txtVenueId.Text;

        // Capture the Category
        string Category = txtCategory.Text;

        // Capture the IsOnline checkbox value
        bool IsOnline = chkIsOnline.Checked;

        // Variable to store any error messages
        string Error = "";

        // Validate the data
        Error = AnEvent.Valid(EventName, EventDescription, EventDate, VenueId, Category);
        if (Error == "")
        {
            // Capture the Event ID
            AnEvent.EventId = EventId;

            // Capture the Event Name
            AnEvent.EventName = EventName;

            // Capture the Event Description
            AnEvent.EventDescription = EventDescription;

            // Capture the Event Date
            AnEvent.EventDate = Convert.ToDateTime(EventDate);

            // Capture the Venue ID
            AnEvent.VenueId = Convert.ToInt32(VenueId);

            // Capture the Category
            AnEvent.Category = Category;

            // Capture the IsOnline value
            AnEvent.IsOnline = IsOnline;

            // Create a new instance of the event collection
            clsEventCollection EventList = new clsEventCollection();

            // If this is a new record i.e., EventId = -1, then add the data
            if (EventId == -1)
            {
                // Set the ThisEvent property
                EventList.ThisEvent = AnEvent;

                // Add the new record
                EventList.Add();
            }
            // Otherwise, it must be an update
            else
            {
                // Find the record to update
                AnEvent = EventList.Find(EventId); // Use Find method here

                // Set the properties of the found event
                AnEvent.EventId = EventId;
                AnEvent.EventName = EventName;
                AnEvent.EventDescription = EventDescription;
                AnEvent.EventDate = Convert.ToDateTime(EventDate);
                AnEvent.VenueId = Convert.ToInt32(VenueId);
                AnEvent.Category = Category;
                AnEvent.IsOnline = IsOnline;

                // Update the record
                EventList.Update();
            }

            // Redirect back to the list page
            Response.Redirect("EventManagementList.aspx");
        }
        else
        {
            // Display the error message
            lblError.Text = Error;
        }
    }


    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        // Your code to handle the checkbox change event
        bool isChecked = ((CheckBox)sender).Checked;
        // Do something based on the checkbox state
    }
}