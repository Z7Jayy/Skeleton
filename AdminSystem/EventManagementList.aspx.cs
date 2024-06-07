using System;
using System.Web.UI;
using ClassLibrary;

public partial class _1_List : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Loads the event list on the initial page load
            LoadEventList();
        }
    }

    protected void LoadEventList()
    {
        // Retrieves the event list from the database and bind it to the ListBox
        clsEventCollection Events = new clsEventCollection();
        lstEventList.DataSource = Events.EventList;
        lstEventList.DataValueField = "EventId";
        lstEventList.DataTextField = "EventName";
        lstEventList.DataBind();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        // Sets the session event ID to -1 to indicate a new event and redirect to the data entry page
        Session["EventId"] = -1;
        Response.Redirect("EventManagementDataEntry.aspx");
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        // If an event is selected, sets the session event ID and redirect to the data entry page
        if (lstEventList.SelectedIndex != -1)
        {
            int eventId = Convert.ToInt32(lstEventList.SelectedValue);
            Session["EventId"] = eventId;
            Response.Redirect("EventManagementDataEntry.aspx");
        }
        else
        {
            lblError.Text = "Please select an event to edit.";
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        // If an event is selected, sest the session event ID and redirect to the confirm delete page
        if (lstEventList.SelectedIndex != -1)
        {
            int eventId = Convert.ToInt32(lstEventList.SelectedValue);
            Session["EventId"] = eventId;
            Response.Redirect("EventManagementConfirmDelete.aspx");
        }
        else
        {
            lblError.Text = "Please select an event to delete.";
        }
    }

    protected void btnFilter_Click(object sender, EventArgs e)
    {
        // Filters the event list by event name and bind the results to the ListBox
        clsEventCollection Events = new clsEventCollection();
        Events.FilterByEventName(txtEventName.Text);
        lstEventList.DataSource = Events.EventList;
        lstEventList.DataValueField = "EventId";
        lstEventList.DataTextField = "EventName";
        lstEventList.DataBind();
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        // Clears the filter and reload the event list
        txtEventName.Text = "";
        LoadEventList();
    }

    protected void btnStatisticsPage_Click(object sender, EventArgs e)
    {
        // Redirects to the statistics page
        Response.Redirect("EventManagementStatistics.aspx");
    }

    protected void btnMainMenu_Click(object sender, EventArgs e)
    {
        // Redirects to the main menu
        Response.Redirect("TeamMainMenu.aspx");
    }
}
