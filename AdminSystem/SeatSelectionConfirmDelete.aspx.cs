using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class _1_ConfirmDelete : System.Web.UI.Page
{
    Int32 BookingID;
    protected void Page_Load(object sender, EventArgs e)
    {
        BookingID = Convert.ToInt32(Session[BookingID]);
    }

    protected void btnYes_Click(object sender, EventArgs e)
    {
       clsSeatSelectionCollection SeatSelection = new clsSeatSelectionCollection();
        SeatSelection.ThisBooking.Find(BookingID);
        SeatSelection.Delete();
        Response.Redirect("SeatSelectionList.aspx");

    }

    protected void btnNo_Click(object sender, EventArgs e)
    {
        Response.Redirect("SeatSelectionList.aspx");
    }
}