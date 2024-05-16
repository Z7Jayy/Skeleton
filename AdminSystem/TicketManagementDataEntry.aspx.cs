using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class _1_DataEntry : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

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

        // Capture the Ticket ID 
        AnTicket.TicketId = Convert.ToInt32(txtTicketId.Text);

        // Capture the Date
        AnTicket.Date = Convert.ToDateTime(DateTime.Now);
        
        // Capture the Price 
        AnTicket.Price = Convert.ToInt32(txtPrice.Text);

        //capture the Venue
        AnTicket.Venue = txtVenue.Text;

        //capture the Artist
        AnTicket.Artist = txtArtist.Text;
        
        //capture is sold check box
        AnTicket.IsSold = chkIsSold.Checked;

        //capture the Ticket Type
        AnTicket.TicketType = txtTicketType.Text;

        //store the Ticket in the session object
        Session["AnTicket"] = AnTicket;
       
        //navigate to the view page
        Response.Redirect("TicketManagementViewer.aspx");
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

    protected void txtTicketType_TextChanged(object sender, EventArgs e)
    {

    }
}