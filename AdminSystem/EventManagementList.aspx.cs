using System;
using System.Web.UI;
using ClassLibrary;

public partial class _1_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DisplayEvents();
        }
    }

    void DisplayEvents()
    {
        clsEventCollection Events = new clsEventCollection();
        lstEventList.DataSource = Events.EventList;
        lstEventList.DataTextField = "EventName";
        lstEventList.DataValueField = "EventId";
        lstEventList.DataBind();
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        // Check if an item is selected in the list
        if (lstEventList.SelectedIndex != -1)
        {
            // Get the primary key value of the selected item
            int eventId = Convert.ToInt32(lstEventList.SelectedValue);
            // Store the primary key value in the session object
            Session["EventId"] = eventId;
            // Redirect to the page EventDataEntry.aspx
            Response.Redirect("EventDataEntry.aspx");
        }
        else
        {
            // Display an error message if no item is selected
            lblError.Text = "Please select an item to edit.";
        }
    }
}
