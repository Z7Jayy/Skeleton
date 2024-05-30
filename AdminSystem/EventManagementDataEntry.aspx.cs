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
    int eventId;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Check if there is an EventId in the session
            if (Session["EventId"] != null)
            {
                // Get the EventId from the session
                eventId = Convert.ToInt32(Session["EventId"]);
                // Display the event details
                DisplayEvent();
            }
        }
    }

    private void DisplayEvent()
    {
        // Create an instance of the event collection
        clsEventCollection EventCollection = new clsEventCollection();
        // Find the event by EventId
        if (EventCollection.Find(eventId))
        {
            // Populate the text boxes with the event details
            txtEventId.Text = EventCollection.ThisEvent.EventId.ToString();
            txtEventName.Text = EventCollection.ThisEvent.EventName;
            txtEventDescription.Text = EventCollection.ThisEvent.EventDescription;
            txtEventDate.Text = EventCollection.ThisEvent.EventDate.ToString("yyyy-MM-dd");
            txtVenueId.Text = EventCollection.ThisEvent.VenueId.ToString();
            txtCategory.Text = EventCollection.ThisEvent.Category;
            chkIsOnline.Checked = EventCollection.ThisEvent.IsOnline;
        }
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        // Create a new instance of clsEvent
        clsEvent AnEvent = new clsEvent();

        // Initialize EventId
        int EventId;

        // Try to parse the Event ID
        if (!int.TryParse(txtEventId.Text, out EventId))
        {
            // If parsing fails, set EventId to -1 (assuming -1 indicates a new record)
            EventId = -1;
        }

        // Capture the Event Name
        string EventName = txtEventName.Text.Trim();

        // Capture the Event Description
        string EventDescription = txtEventDescription.Text.Trim();

        // Capture the Event Date
        string EventDate = txtEventDate.Text.Trim();

        // Capture the Venue ID
        string VenueId = txtVenueId.Text.Trim();

        // Capture the Category
        string Category = txtCategory.Text.Trim();

        // Capture the IsOnline checkbox value
        bool IsOnline = chkIsOnline.Checked;

        // Variable to store any error messages
        string Error = "";

        // Validate the data
        Error = AnEvent.Valid(EventName, EventDescription, EventDate, VenueId, Category);
        if (Error == "")
        {
            try
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

                if (EventId == -1)
                {
                    EventList.ThisEvent = AnEvent;
                    EventList.Add();
                }
                else
                {
                    bool Found = EventList.Find(EventId);
                    if (Found)
                    {
                        EventList.ThisEvent.EventId = EventId;
                        EventList.ThisEvent.EventName = EventName;
                        EventList.ThisEvent.EventDescription = EventDescription;
                        EventList.ThisEvent.EventDate = Convert.ToDateTime(EventDate);
                        EventList.ThisEvent.VenueId = Convert.ToInt32(VenueId);
                        EventList.ThisEvent.Category = Category;
                        EventList.ThisEvent.IsOnline = IsOnline;
                        EventList.Update();
                    }
                    else
                    {
                        lblError.Text = "Event not found.";
                        return;
                    }
                }
                Response.Redirect("EventManagementList.aspx");
            }
            catch (FormatException)
            {
                lblError.Text = "There was a problem with the format of the input data.";
            }
            catch (Exception ex)
            {
                lblError.Text = "An error occurred: " + ex.Message;
            }
        }
        else
        {
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
