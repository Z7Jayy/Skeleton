using ClassLibrary;
using System;
using System.Data;
using System.Web.UI;

public partial class EventManagementStatistics : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadStatistics();
        }
    }

    private void LoadStatistics()
    {
        // Creates an instance of the class
        clsEventCollection clsEventCollection = new clsEventCollection();

        // Retrieves data grouped by category
        DataTable dtCategory = clsEventCollection.StatisticsGroupedByCategory();
        GridViewGroupByCategory.DataSource = dtCategory;
        GridViewGroupByCategory.DataBind();
        if (GridViewGroupByCategory.HeaderRow != null)
        {
            GridViewGroupByCategory.HeaderRow.Cells[0].Text = "Category";
        }

        // Retrieves data grouped by event date
        DataTable dtEventDate = clsEventCollection.StatisticsGroupedByEventDate();
        GridViewGroupByEventDate.DataSource = dtEventDate;
        GridViewGroupByEventDate.DataBind();
        if (GridViewGroupByEventDate.HeaderRow != null)
        {
            GridViewGroupByEventDate.HeaderRow.Cells[0].Text = "Event Date";
        }
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("EventManagementList.aspx");
    }
}
