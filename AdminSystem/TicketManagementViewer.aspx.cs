using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class _1Viewer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //create a new instance of clsTicket
        clsTicket AnTicket = new clsTicket();
        
        //get the data from the session objecty
        AnTicket = (clsTicket)Session["AnTicket"];

        //display the Ticket ID for this entry
        Response.Write(AnTicket.TicketId);

        //display the Date for this entry
        Response.Write(AnTicket.Date);

        //display the Price for this entry
        Response.Write(AnTicket.Price);

        //display the Venue for this entry
        Response.Write(AnTicket.Venue);

        //display the Artist for this entry
        Response.Write(AnTicket.Artist);

        //display the is sold  for this entry
        Response.Write(AnTicket.IsSold);

        //display the Ticket Type for this entry
        Response.Write(AnTicket.TicketType);




    }
}