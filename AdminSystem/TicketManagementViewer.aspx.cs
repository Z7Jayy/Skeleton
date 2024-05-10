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
        //display the Artist for this entry
        Response.Write(AnTicket.Artist);
    }
}