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
        //capture the Artist
        AnTicket.Artist = txtArtist.Text;
        //store the Ticket in the session object
        Session["AnTicket"] = AnTicket;
        //navigate to the view page
        Response.Redirect("TicketManagementViewer.aspx");
    }


    protected void TextBox1_TextChanged1(object sender, EventArgs e)
    {

    }
}