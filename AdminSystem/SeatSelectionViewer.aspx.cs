using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _1Viewer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Create a new instance of clsSeatSelection
        clsSeatSelection AnSeatSelection = new clsSeatSelection();

        // Get the data from the session object
        AnSeatSelection = (clsSeatSelection)Session["AnSeatSelection"];

        // Display the house number for this entry
        Response.Write(AnSeatSelection.SeatType);
        Response.Write(AnSeatSelection.BookingID);
        Response.Write(AnSeatSelection.SeatID);
        Response.Write(AnSeatSelection.Availabilty);
        Response.Write(AnSeatSelection.NumberOfSeats);
        Response.Write(AnSeatSelection.Section);
        Response.Write(AnSeatSelection.BookingDate);

    }
}