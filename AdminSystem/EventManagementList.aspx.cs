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

    protected void DisplayEvents()
    {
        clsEventCollection Events = new clsEventCollection();
        lstEventList.DataSource = Events.EventList;
        lstEventList.DataTextField = "EventName";
        lstEventList.DataValueField = "EventId";
        lstEventList.DataBind();
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        if (lstEventList.SelectedIndex != -1)
        {
            int eventId = Convert.ToInt32(lstEventList.SelectedValue);
            Session["EventId"] = eventId;
            Response.Redirect("EventManagementDataEntry.aspx");
        }
        else
        {
            lblError.Text = "Please select an item to edit.";
        }
    }

    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        Session["EventId"] = -1;
        Response.Redirect("EventManagementDataEntry.aspx");
    }
}
