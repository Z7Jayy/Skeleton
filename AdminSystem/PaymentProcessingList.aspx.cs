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
        //if this is the first time displaying the page
        if (IsPostBack == false)
        {
            //update listbox
            DisplayPayments();
        }
    }

    void DisplayPayments()
    {
        clsPaymentCollection Payments = new clsPaymentCollection();
        //set the data source to the list of payments
        tstPaymentList.DataSource = Payments.PaymentList;
        //set the name of the primary key
        tstPaymentList.DataValueField = "PaymentID";
        //set the data field to display
        tstPaymentList.DataTextField = "TransactionID";
        //bind the data to the list
        tstPaymentList.DataBind();

    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        //store -1 into the session object to indicate this is a new record
        Session["PaymentID"] = -1;
        //redirect to the data entry page
        Response.Redirect("PaymentProcessingDataEntry.aspx");

    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        //variable to store the primary key value of the record to be edited
        Int32 PaymentID;

        //if a record has been selected form the list
        if (tstPaymentList.SelectedIndex != -1)
        {
            //get the primary key value of the record to be edit
            PaymentID = Convert.ToInt32(tstPaymentList.SelectedValue);
            //store the data in the session object
            Session["PaymentID"] = PaymentID;
            //redirect to the edit page
            Response.Redirect("PaymentProcessingDataEntry.aspx");
        }
        else
        {
            lblError.Text = "Please select a record from the list to edit";
        }
    }

}