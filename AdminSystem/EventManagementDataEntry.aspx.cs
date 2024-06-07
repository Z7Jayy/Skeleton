using System;
using System.Web.UI;
using ClassLibrary;

public partial class _1_DataEntry : Page
{
    int eventId;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // If there is an event ID in the session, display the event details
            if (Session["EventId"] != null)
            {
                eventId = Convert.ToInt32(Session["EventId"]);
                DisplayEvent();
            }
        }
    }

    private void DisplayEvent()
    {
        // Load the event details from the database and display them in the form fields
        clsEventCollection EventCollection = new clsEventCollection();
        if (EventCollection.Find(eventId))
        {
            txtEventId.Text = EventCollection.ThisEvent.EventId.ToString();
            txtEventName.Text = EventCollection.ThisEvent.EventName;
            txtEventDescription.Text = EventCollection.ThisEvent.EventDescription;
            txtEventDate.Text = EventCollection.ThisEvent.EventDate.ToString("dd-MM-yyyy");
            txtVenueId.Text = EventCollection.ThisEvent.VenueId.ToString();
            txtCategory.Text = EventCollection.ThisEvent.Category;
            chkIsOnline.Checked = EventCollection.ThisEvent.IsOnline;
            chkActive.Checked = EventCollection.ThisEvent.Active;
        }
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        clsEvent AnEvent = new clsEvent();
        string Error = "";

        // Attempt to parse the event ID
        int EventId;
        if (!int.TryParse(txtEventId.Text, out EventId))
        {
            EventId = -1;
        }

        // Gather form input
        string EventName = txtEventName.Text.Trim();
        string EventDescription = txtEventDescription.Text.Trim();
        string EventDate = txtEventDate.Text.Trim();
        string VenueId = txtVenueId.Text.Trim();
        string Category = txtCategory.Text.Trim();
        bool IsOnline = chkIsOnline.Checked;
        bool Active = chkActive.Checked;

        // Validate input
        Error = AnEvent.Valid(EventName, EventDescription, EventDate, VenueId, Category);
        if (Error == "")
        {
            try
            {
                // Assign form input to event properties
                AnEvent.EventId = EventId;
                AnEvent.EventName = EventName;
                AnEvent.EventDescription = EventDescription;
                AnEvent.EventDate = Convert.ToDateTime(EventDate);
                AnEvent.VenueId = Convert.ToInt32(VenueId);
                AnEvent.Category = Category;
                AnEvent.IsOnline = IsOnline;
                AnEvent.Active = Active;

                clsEventCollection EventList = new clsEventCollection();
                // Adds or updates the event in the database
                if (EventId == -1)
                {
                    EventList.ThisEvent = AnEvent;
                    EventList.Add();
                }
                else
                {
                    if (EventList.Find(EventId))
                    {
                        EventList.ThisEvent = AnEvent;
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

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        // Redirects to the event list page
        Response.Redirect("EventManagementList.aspx");
    }

    protected void btnMainMenu_Click(object sender, EventArgs e)
    {
        // Redirects to the main menu
        Response.Redirect("TeamMainMenu.aspx");
    }
}
