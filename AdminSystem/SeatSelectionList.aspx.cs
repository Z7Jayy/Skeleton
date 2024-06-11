using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class _1_List : System.Web.UI.Page
{
    clsSeatSelectionCollection SeatSelection = new clsSeatSelectionCollection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // update the list box
            DisplaySeatSelections();
        }
    }

    void DisplaySeatSelections()
    {
        // create an instance of the Seat Selection collection
        clsSeatSelectionCollection SeatSelection = new clsSeatSelectionCollection();

        // set the data source to the list of seat selections in the collection
        lstBookingList.DataSource = SeatSelection.BookingList;

        // set the name of the primary key
        lstBookingList.DataValueField = "BookingID";

        // set the data field to display
        lstBookingList.DataTextField = "SeatID";

        // bind the data to the list
        lstBookingList.DataBind();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        // Store -1 into the session object to indicate this is a new record
        Session["SeatSelectionId"] = -1;
        // Redirect to the data entry page
        Response.Redirect("SeatSelectionDataEntry.aspx");
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        // Variable to store the primary key value of the record to be edited
        int SeatID;

        // If a record has been selected from the list
        if (lstBookingList.SelectedIndex != -1)
        {
            // Get the primary key value of the record to edit
            SeatID = Convert.ToInt32(lstBookingList.SelectedValue);

            // Store the data in the session object
            Session["SeatID"] = SeatID;

            // Redirect to the edit page
            Response.Redirect("SeatSelectionDataEntry.aspx");
        }
        else
        {
            // If no record has been selected
            lblError.Text = "Please select a record from the list to edit";
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int SeatID;
        // If a record has been selected from the list
        if (lstBookingList.SelectedIndex != -1)
        {
            // Get the primary key value of the record to delete
            SeatID = Convert.ToInt32(lstBookingList.SelectedValue);
            // Store the data in the session object
            Session["SeatID"] = SeatID;
            // Redirect to the delete confirmation page
            Response.Redirect("SeatSelectionConfirmDelete.aspx");
        }
        else
        {
            // If no record has been selected, display an error message
            lblError.Text = "Please select a record from the list to delete";
        }
    }

    protected void btnApply_Click(object sender, EventArgs e)
    {
        clsSeatSelectionCollection SeatSelection = new clsSeatSelectionCollection();

        // Retrieve the value of the section from the presentation layer
        SeatSelection.ReportBySection(txtfilter.Text);

        // Set the data source to the list of seat selections in the collection
        lstBookingList.DataSource = SeatSelection.BookingList;

        // Set the name of the primary key
        lstBookingList.DataValueField = "SeatID";

        // Set the name of the field to display
        lstBookingList.DataTextField = "Section";

        // Bind the data to the list
        lstBookingList.DataBind();
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        clsSeatSelectionCollection SeatSelections = new clsSeatSelectionCollection();

        // Set an empty string to clear the filter
        SeatSelections.ReportBySection("");

        // Clear any existing filter to tidy up the interface
        txtfilter.Text = "";

        // Set the data source to the list of seat selections in the collection
        lstBookingList.DataSource = SeatSelections.BookingList;

        // Set the name of the primary key
        lstBookingList.DataValueField = "SeatID";

        // Set the name of the field to display
        lstBookingList.DataTextField = "Section";

        // Bind the data to the list
        lstBookingList.DataBind();
    }
}
