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
    Int32 BookingID;
    protected void Page_Load(object sender, EventArgs e)
    {
        // Get the number out of the session["BookingID"]
        BookingID = Convert.ToInt32(Session["BookingID"]);

        if (!IsPostBack)
        {
            // If this is not a new record
            if (BookingID != -1)
            {
                // Display the current data for the record
                DisplaySeatSelection();
            }
        }
    }

    private void DisplaySeatSelection()
    {
        // Create an instance of the seat selection collection
        clsSeatSelectionCollection SeatSelectionList = new clsSeatSelectionCollection();
        // Find the record to update
        SeatSelectionList.ThisBooking.Find(BookingID);
        // Display the data for the record
        txtSeatID.Text = SeatSelectionList.ThisBooking.SeatID.ToString();
        chkAvailability.Checked = SeatSelectionList.ThisBooking.Availabilty;
        txtBookingID.Text = SeatSelectionList.ThisBooking.BookingID.ToString();
        txtNumberOfSeats.Text = SeatSelectionList.ThisBooking.NumberOfSeats.ToString();
        txtBookingDate.Text = SeatSelectionList.ThisBooking.BookingDate.ToString("yyyy-MM-dd");
        txtSeatType.Text = SeatSelectionList.ThisBooking.SeatType;
        txtSection.Text = SeatSelectionList.ThisBooking.Section;
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        // Create a new instance of clsSeatSelection
        clsSeatSelection AnSeatSelection = new clsSeatSelection();

        string seatType = txtSeatType.Text;
        string section = txtSection.Text;
        string bookingDate = txtBookingDate.Text;
        string seatID = txtSeatID.Text;
        string numberOfSeats = txtNumberOfSeats.Text;
        string Error = "";

        Error = AnSeatSelection.Valid(seatType, section, bookingDate, seatID, numberOfSeats);

        if (Error == "")
        {
            AnSeatSelection.Availabilty = chkAvailability.Checked;
            // capture the booking ID
            AnSeatSelection.BookingID = BookingID;
            // capture the number of seats
            AnSeatSelection.NumberOfSeats = Convert.ToInt32(numberOfSeats);
            // capture the seat ID
            AnSeatSelection.SeatID = Convert.ToInt32(seatID);
            // capture the booking date
            AnSeatSelection.BookingDate = Convert.ToDateTime(bookingDate);
            // capture the seat type
            AnSeatSelection.SeatType = seatType;
            // capture the section
            AnSeatSelection.Section = section;
            // create a new instance of the seat selection collection
            clsSeatSelectionCollection SeatSelectionList = new clsSeatSelectionCollection();
            // set the ThisBooking property
            SeatSelectionList.ThisBooking = AnSeatSelection;

            if (BookingID == -1)
            {
                // add the new record
                SeatSelectionList.Add();
            }
            else
            {
                // update the existing record
                SeatSelectionList.Update();
            }

            Response.Redirect("SeatSelectionViewer.aspx");
        }
        else
        {
            iblError.Text = Error;
        }
    }

    protected void btnFind_Click(object sender, EventArgs e)
    {
        //create an instance of the seat selection class
        clsSeatSelection AnSeatSelection = new clsSeatSelection();
        //create a variable to store the primary key
        Int32 BookingID;
        //create a variable to store the result of the find operation
        Boolean Found = false;
        //get the primary key entered by the user
        BookingID = Convert.ToInt32(txtBookingID.Text);
        //find the record
        Found = AnSeatSelection.Find(BookingID);
        //if found
        if (Found == true)
        {
            //display the values of the properties in the form
            txtBookingID.Text = AnSeatSelection.BookingID.ToString();
            txtSeatID.Text = AnSeatSelection.SeatID.ToString();
            txtSeatType.Text = AnSeatSelection.SeatType;
            txtNumberOfSeats.Text = AnSeatSelection.NumberOfSeats.ToString();
            txtBookingDate.Text = AnSeatSelection.BookingDate.ToString("yyyy-MM-dd");
            chkAvailability.Checked = AnSeatSelection.Availabilty;
            txtSection.Text = AnSeatSelection.Section;
        }
    }

    protected void chkAvailability_CheckedChanged(object sender, EventArgs e)
    {

    }
}
