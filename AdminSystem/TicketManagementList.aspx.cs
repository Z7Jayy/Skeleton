using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class _1_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if this is the first time the page is displayed
        if (IsPostBack == false)
        {
            //update the list box 
            DisplayTickets();
        }
    }

    void DisplayTickets()
    {
        //create an instance of the tickets collection
        clsTicketCollection Tickets = new clsTicketCollection();
        //set the data source to list of tickets in the collection
        lstTicketList.DataSource = Tickets.TicketList;
        //set the name of the primary key 
        lstTicketList.DataValueField = "TicketId";
        //set the data field to display
        lstTicketList.DataTextField = "Venue";
        //bind the data to the list
        lstTicketList.DataBind(); 
    }
}