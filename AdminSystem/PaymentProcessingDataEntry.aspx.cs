using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class _1_DataEntry : System.Web.UI.Page
{   
    //variable to store the primary key with page level scope
    Int32 PaymentID;
    protected void Page_Load(object sender, EventArgs e)
    {
        //get the number of the payment to be processed
        PaymentID = Convert.ToInt32(Session["PaymentID"]);
        //if this is the first time displaying the page
        if (IsPostBack == false)
        {
            //if this is not a new record
            if (PaymentID != -1)
            {
                //display the current data for hte record
                DisplayPayment();
            }
        }
    }
    protected void CheckBoxIsPaymentSuccessful_CheckedChanged(object sender, EventArgs e)
    {

    }


    protected void btnOK_Click(object sender, EventArgs e)
    {
        // Create a new instance of clsPayment
        clsPayment Payment = new clsPayment();

        // Capture the attributes
        string TransactionID = txtTransactionID.Text;
        string Amount = txtAmount.Text;
        string PaymentDate = txtPaymentDate.Text;
        string IsPaymentSuccessful = CheckBoxIsPaymentSuccessful.Text;
        string PaymentMethod = txtPaymentMethod.Text;
        string TicketID = txtTicketID.Text;
       

        // Validate the data
        string Error = Payment.Valid(TransactionID, PaymentMethod, PaymentDate, Amount, TicketID);

        if (Error == "")
        {
            // Proceed with capturing and processing the data
            Payment.PaymentID = PaymentID;
            Payment.TransactionID = TransactionID;
            Payment.PaymentMethod = PaymentMethod;
            Payment.PaymentDate = Convert.ToDateTime(PaymentDate);
            Payment.Amount = Convert.ToDouble(Amount);
            Payment.IsPaymentSuccessful = CheckBoxIsPaymentSuccessful.Checked;
            Payment.TicketID = Convert.ToInt32(TicketID);

            // Create a new instance of the payment collection
            clsPaymentCollection PaymentList = new clsPaymentCollection();

            if (PaymentID == -1)
            {
                // Add new record
                PaymentList.ThisPayment = Payment;
                PaymentList.Add();
            }
            else
            {
                // Update existing record
                PaymentList.ThisPayment.Find(PaymentID);
                PaymentList.ThisPayment = Payment;
                PaymentList.Update();
            }

            // Navigate to the view page
            Response.Redirect("PaymentProcessingList.aspx");
        }
        else
        {
            // Display the error message
            lblError.Text = Error;
        }
    }

    protected void btnFind_Click(object sender, EventArgs e)
    {
        //create an instace of the Find Class
        clsPayment Payment = new clsPayment();
        //create a variable to store the primary key
        Int32 PaymentID;
        //create a variable to store the results of the fid operation
        Boolean Found = false;
        //get the primary key entered by the user
        PaymentID = Convert.ToInt32(txtPaymentID.Text);
        //find the record
        Found = Payment.Find(PaymentID);
        //if found
        if (Found == true)
        {
            //display
            txtTransactionID.Text = Payment.TransactionID;
            txtAmount.Text = Payment.Amount.ToString();
            txtPaymentDate.Text = Payment.PaymentDate.ToString();
            CheckBoxIsPaymentSuccessful.Checked = Payment.IsPaymentSuccessful;
            txtPaymentMethod.Text = Payment.PaymentMethod;
            txtTicketID.Text = Payment.TicketID.ToString();
                
        }

    }

    void DisplayPayment()
    {
        //create an instance of the payment book
        clsPaymentCollection PaymentProcessing = new clsPaymentCollection();
        //find the record to update
        PaymentProcessing.ThisPayment.Find(PaymentID);
        //display the data for the record
        txtPaymentID.Text = PaymentProcessing.ThisPayment.PaymentID.ToString();
        txtTransactionID.Text = PaymentProcessing.ThisPayment.TransactionID.ToString();
        txtAmount.Text = PaymentProcessing.ThisPayment.Amount.ToString();
        txtPaymentMethod.Text = PaymentProcessing.ThisPayment.PaymentMethod.ToString();
        txtPaymentDate.Text = PaymentProcessing.ThisPayment.PaymentDate.ToString();
        CheckBoxIsPaymentSuccessful.Checked = PaymentProcessing.ThisPayment.IsPaymentSuccessful;
        txtTicketID.Text = PaymentProcessing.ThisPayment.TicketID.ToString();

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        //redirect to the list page
        Response.Redirect("PaymentProcessingList.aspx");
    }

    protected void btnMainMenu_Click(object sender, EventArgs e)
    {
        //redirect to the main menue page
        Response.Redirect("TeamMainMenu.aspx");
    }
}
