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
}
