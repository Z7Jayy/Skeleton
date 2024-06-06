using System;
using System.Web.UI;
using ClassLibrary;

public partial class _1_DataEntry : System.Web.UI.Page
{
    int eventId;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["EventId"] != null)
            {
                eventId = Convert.ToInt32(Session["EventId"]);
                DisplayEvent();
            }
        }
    }

    private void DisplayEvent()
    {
        clsEventCollection EventCollection = new clsEventCollection();
        if (EventCollection.Find(eventId))
        {
            txtEventId.Text = EventCollection.ThisEvent.EventId.ToString();
            txtEventName.Text = EventCollection.ThisEvent.EventName;
            txtEventDescription.Text = EventCollection.ThisEvent.EventDescription;
            txtEventDate.Text = EventCollection.ThisEvent.EventDate.ToString("yyyy-MM-dd");
            txtVenueId.Text = EventCollection.ThisEvent.VenueId.ToString();
            txtCategory.Text = EventCollection.ThisEvent.Category;
            chkIsOnline.Checked = EventCollection.ThisEvent.IsOnline;
            chkActive.Checked = EventCollection.ThisEvent.Active;
        }
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        clsEvent AnEvent = new clsEvent();
        int EventId;

        if (!int.TryParse(txtEventId.Text, out EventId))
        {
            EventId = -1;
        }

        string EventName = txtEventName.Text.Trim();
        string EventDescription = txtEventDescription.Text.Trim();
        string EventDate = txtEventDate.Text.Trim();
        string VenueId = txtVenueId.Text.Trim();
        string Category = txtCategory.Text.Trim();
        bool IsOnline = chkIsOnline.Checked;
        bool Active = chkActive.Checked;

        string Error = "";
        Error = AnEvent.Valid(EventName, EventDescription, EventDate, VenueId, Category);
        if (Error == "")
        {
            try
            {
                AnEvent.EventId = EventId;
                AnEvent.EventName = EventName;
                AnEvent.EventDescription = EventDescription;
                AnEvent.EventDate = Convert.ToDateTime(EventDate);
                AnEvent.VenueId = Convert.ToInt32(VenueId);
                AnEvent.Category = Category;
                AnEvent.IsOnline = IsOnline;
                AnEvent.Active = Active;

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

    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        // Handle checkbox change event if needed
    }
}
