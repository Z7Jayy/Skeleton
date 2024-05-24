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
        //create a new instance of clsPayment
        clsPayment Payment = new clsPayment();
        //Capture the Attribute
        string TransactionID = txtTransactionID.Text;
        string Amount = txtAmount.Text;
        string PaymentDate = txtPaymentDate.Text;
        string IsPaymentSuccessful = CheckBoxIsPaymentSuccessful.Text;
        string PaymentMethod = txtPaymentMethod.Text;
        string TicketID = txtTicketID.Text;
        //variable to store any error messages
        string Error = "";

        //validate the data
        Error = Payment.Valid(TransactionID, PaymentMethod, PaymentDate);
        if (Error == "")
        {
            //Capture the paymentid
            Payment.PaymentID = PaymentID;
            //Capture the TransactionId
            Payment.TransactionID = TransactionID;
            //Capture the PaymentMethod
            Payment.PaymentMethod = PaymentMethod;
            //Capture the Paymentdate
            Payment.PaymentDate = Convert.ToDateTime(PaymentDate);
            //Capture the Amount
            Payment.Amount = Convert.ToDouble(txtAmount.Text);
            //Capture IsPaymentSucessful
            Payment.IsPaymentSuccessful = CheckBoxIsPaymentSuccessful.Checked;
            //Capture the TicketId
            Payment.TicketID = Convert.ToInt32(txtTicketID.Text);
            //create a new instance of the payment collection
            clsPaymentCollection PaymentList = new clsPaymentCollection();

            //if this is a new record i.e PaymentID = -1 then add the data
            if (PaymentID == -1)
            {
                //set the ThisPayment property
                PaymentList.ThisPayment = Payment;
                //add the new record
                PaymentList.Add();
            }
            else
            {
                //find the record to update
                PaymentList.ThisPayment.Find(PaymentID);
                //set the ThisPayment property
                PaymentList.ThisPayment = Payment;
                //update the record
                PaymentList.Update();
            }
            //navigate to the view page
            Response.Redirect("PaymentProcessingList.aspx");
        }
        else
        {
            //display the error message
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
        txtTicketID.Text = PaymentProcessing.ThisPayment.ToString();

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }
}
