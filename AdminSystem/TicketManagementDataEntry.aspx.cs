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
        int ticketId;
        if (int.TryParse(txtTicketId.Text, out ticketId))
        {
            AnTicket.TicketID = ticketId;
        }

        // Capture the Date
        AnTicket.Date = Convert.ToDateTime(DateTime.Now);
        
        // Capture the Price 
        int price;
        if (int.TryParse(txtPrice.Text, out price))
        {
            AnTicket.Price = price;
        }

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
}