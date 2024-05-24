using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class _1_ConfirmDelete : System.Web.UI.Page
{
    //variable to store the primary key value of the record to be deleted 
    Int32 TicketId;

    protected void Page_Load(object sender, EventArgs e)
    {
        //get the number of the ticket to be deleted from the session object
        TicketId = Convert.ToInt32(Session["TicketId"]);
    }

    protected void btnYes_Click(object sender, EventArgs e)
    {
        //create an instance of the tickets management  collection class
        clsTicketCollection TicketManagement = new clsTicketCollection();
        //find the record to delete
        TicketManagement.ThisTicket.Find(TicketId);
        //delete the record
        TicketManagement.Delete();
        //redirect back to the main page
        Response.Redirect("TicketManagementList.aspx");
    }

    protected void btnNo_Click(object sender, EventArgs e)
    {
        //redirect back to the main page 
        Response.Redirect("TicketManagementList.aspx");
    }
}