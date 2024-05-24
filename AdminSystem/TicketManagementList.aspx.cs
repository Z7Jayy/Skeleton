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
        //create an instance of the tickets collection class
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


    protected void btnAdd_Click(object sender, EventArgs e)
    {
        //store -1 into the session object to indicate this is a new record 
        Session["TicketId"] = -1;
        //redirect to the data entry page 
        Response.Redirect("TicketManagementDataEntry.aspx");
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        //variable to store the primary key value of the record to be edited 
        Int32 TicketId;
        //if a record has been selected from the list 
        if (lstTicketList.SelectedIndex != -1)
        {
            //get the primary key value of the record to edit
            TicketId = Convert.ToInt32(lstTicketList.SelectedValue);
            //store the data in the session object
            Session["TicketId"] = TicketId;
            //redirect to the edit page 
            Response.Redirect("TicketManagementDataEntry.aspx");
        }
        else      //if no record has been selected
        {
            lblError.Text = "Please select a record from the list to edit";
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        //variable to store the primary key value of the record to be deleted 
        Int32 TicketId;
        //if a record has been selected from the list 
        if (lstTicketList.SelectedIndex != -1)
        {
            //get the primary key value of the record to edit
            TicketId = Convert.ToInt32(lstTicketList.SelectedValue);
            //store the data in the session object
            Session["TicketId"] = TicketId;
            //redirect to the delete page 
            Response.Redirect("TicketManagementConfirmDelete.aspx");
        }
        else      //if no record has been selected
        {
            lblError.Text = "Please select a record from the list to delete";
        }
    }

    protected void btnApplyFilter_Click(object sender, EventArgs e)
    {
        //create an instance of the address object
        clsTicketCollection AnTicket = new clsTicketCollection();
        //retrieve the value of artist from the presentation layer 
        AnTicket.ReportByArtist(txtFilter.Text);
        //set the data source to the list of tickets in the collection
        lstTicketList.DataSource = AnTicket.TicketList;
        //set the name of the primary key 
        lstTicketList.DataValueField = "TicketId";
        //set the name of the field to display
        lstTicketList.DataTextField = "Artist";
        //bind the data to the list 
        lstTicketList.DataBind();
    }

    protected void btnClearFilter_Click(object sender, EventArgs e)
    {
        //create an instance of the address object
        clsTicketCollection AnTicket = new clsTicketCollection();
        //set an empty string 
        AnTicket.ReportByArtist("");
        //clear any existing filter to tidy up the interface
        txtFilter.Text = "";
        //set the data source to the list of tickets in the collection
        lstTicketList.DataSource = AnTicket.TicketList;
        //set the name of the primary key 
        lstTicketList.DataValueField = "TicketId";
        //set the name of the field to display
        lstTicketList.DataTextField = "Artist";
        //bind the data to the list 
        lstTicketList.DataBind();
    }
}