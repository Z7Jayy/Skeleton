using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class _1_DataEntry : System.Web.UI.Page
{
    //variable to store the primary key with page level scope 
    Int32 TicketId;
    protected void Page_Load(object sender, EventArgs e)
    {
        //get the number of the ticket id to be processed 
        TicketId = Convert.ToInt32(Session["TicketId"]);
        if (IsPostBack == false)
        {
            //if this is not a new record 
            if (TicketId != -1)
            {
                //display the current data for the record
                DisplayTicket();
            }
        }
    }

    protected void txtTicketId_TextChanged(object sender, EventArgs e)
    {

    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        //create a new instance of clsTicket
        clsTicket AnTicket = new clsTicket();

        //capture the ticket id 
        //int TicketId = AnTicket.TicketId;

        // Capture the Date
        string Date = txtDate.Text;

        // Capture the Price 
        string Price = txtPrice.Text;

        //capture the Venue
        string Venue = txtVenue.Text;

        //capture the Artist
        string Artist = txtArtist.Text;

        //capture is sold check box
        string IsSold = chkIsSold.Text;

        //capture the Ticket Type
        string TicketType = txtTicketType.Text;

        //variable to store any error messages 
        string Error = "";

        //validate the data 
        Error = AnTicket.Valid(Venue, Artist, TicketType, Date);
        if (Error == "")
        {
            //capture the Ticketid
            AnTicket.TicketId = TicketId; 
            
            //capture the Venue
            AnTicket.Venue = Venue ;

            //capture the Artist
            AnTicket.Artist = Artist;

            //capture the Ticket Type
            AnTicket.TicketType = TicketType;

            // Capture the Date
            AnTicket.Date = Convert.ToDateTime(Date);

            //capture the Price
            AnTicket.Price = Convert.ToInt32(Price);

            //capture the is sold 
            AnTicket.IsSold = chkIsSold.Checked;

            //create a new instance of the ticket collection 
            clsTicketCollection TicketList = new clsTicketCollection();

            //if this is a new record i.e. Ticketid = -1 then add the data 
            if (TicketId == -1)
            {
                //set the ThisTicket property
                TicketList.ThisTicket = AnTicket;

                //add the new record
                TicketList.Add();

            }
            //otherwise it must be an update
            else
            {
                //find the recordto update 
                TicketList.ThisTicket.Find(TicketId);
                //set the thisticket property
                TicketList.ThisTicket = AnTicket;
                //update the record
                TicketList.Update();

            }
            //redirect back to the list page 
            Response.Redirect("TicketManagementList.aspx");

        }
        else
        {
            //display the error message 
            lblError.Text = Error;
        }
    }


    protected void TextBox1_TextChanged1(object sender, EventArgs e)
    {

    }

    protected void btnFind_Click(object sender, EventArgs e)
    {
        //create an instance of the ticket class
        clsTicket AnTicket = new clsTicket();
        //create a variable to store the primary key 
        Int32 TicketId;
        //create a variable to store the result of the find operation
        Boolean Found = false;
        //get the primary key enetered by the user 
        TicketId = Convert.ToInt32(txtTicketId.Text);
        //find the record
        Found = AnTicket.Find(TicketId);
        //if found
        {
            //display the values of the properties in the form 
            txtDate.Text = AnTicket.Date.ToString();
            txtPrice.Text = AnTicket.Price.ToString();
            txtVenue.Text = AnTicket.Venue;
            txtArtist.Text = AnTicket.Artist;
            chkIsSold.Checked = AnTicket.IsSold;
            txtTicketType.Text = AnTicket.TicketType;
        }

    }

    void DisplayTicket()
    {
        //create an instance of the ticket management
        clsTicketCollection TicketManagement = new clsTicketCollection();
        //find the record to update 
        TicketManagement.ThisTicket.Find(TicketId);
        //display the data for the record
        txtTicketId.Text = TicketManagement.ThisTicket.TicketId.ToString();
        txtPrice.Text = TicketManagement.ThisTicket.Price.ToString();
        txtDate.Text = TicketManagement.ThisTicket.Date.ToString();
        txtVenue.Text = TicketManagement.ThisTicket.Venue.ToString();
        txtArtist.Text = TicketManagement.ThisTicket.Artist.ToString();
        chkIsSold.Checked = TicketManagement.ThisTicket.IsSold;
        txtTicketType.Text = TicketManagement.ThisTicket.TicketType.ToString();
    }

    protected void txtTicketType_TextChanged(object sender, EventArgs e)
    {

    }

    protected void btnMainMenu_Click(object sender, EventArgs e)
    {
        //redirect the user to the Payment Processing list page
        Response.Redirect("TeamMainMenu.aspx");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        //redirect the user to the Payment Processing list page
        Response.Redirect("TicketManagementList.aspx");
    }
}