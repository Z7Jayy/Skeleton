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


    protected void btnDelete_Click(object sender, EventArgs e)
    {
        //variable to store the primary key value to be deleted
        Int32 PaymentID;

        //if a record is selected from the list
        if(tstPaymentList.SelectedIndex != -1)
        {
            //get the fromary key value of the record delete
            PaymentID = Convert.ToInt32(tstPaymentList.SelectedValue);
            //store the data in the session object
            Session["PaymentID"] = PaymentID;
            // redirect to the delete page
            Response.Redirect("PaymentProcessingConfirmDelete.aspx");
        }
        else
        {
            //display error message
            lblError.Text = "Please select a record from the list to delete";
        }
    }

    protected void btnFilter_Click(object sender, EventArgs e)
    {
        //create an instance of the payment object
        clsPaymentCollection Payment = new clsPaymentCollection();
        //retrieve the value of the transaction id from the presentation layer
        Payment.ReportByTransactionID(txtTransactionID.Text);
        //set the data source to the list of payments in the collection
        tstPaymentList.DataSource = Payment.PaymentList;
        tstPaymentList.DataValueField = "PaymentID";
        tstPaymentList.DataTextField = "TransactionID";
        tstPaymentList.DataBind();
    
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        //create an instance of the payment object
        clsPaymentCollection Payment = new clsPaymentCollection();
        //retrieve the value of the transaction id from the presentation layer
        Payment.ReportByTransactionID("");
        //clear any existing filter to tidy up the interface
        txtTransactionID.Text = "";
        //set the data source to the list of payments in the collection
        tstPaymentList.DataSource = Payment.PaymentList;
        tstPaymentList.DataValueField = "PaymentID";
        tstPaymentList.DataTextField = "TransactionID";
        tstPaymentList.DataBind();

    }

    protected void btnMainMenu_Click(object sender, EventArgs e)
    {
        Response.Redirect("TeamMainMenu.aspx");
    }

    protected void btnStatisticsPage_Click(object sender, EventArgs e)
    {
        Response.Redirect("PaymentProcessingStatistics.aspx");
    }
}