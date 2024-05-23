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
    protected void CheckBoxIsPaymentSuccessful_CheckedChanged(object sender, EventArgs e)
    {

    }


    protected void btnOK_Click(object sender, EventArgs e)
    {
        //create a new instance of clsPayment
        clsPayment Payment = new clsPayment();
        //Capture the Attribute
        string PaymentID = txtPaymentID.Text;
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

            //Capture the Attribute
            Payment.TransactionID = TransactionID;
            Payment.PaymentMethod = PaymentMethod;
            Payment.PaymentDate = Convert.ToDateTime(PaymentDate);
            Payment.PaymentID = Convert.ToInt32(txtPaymentID.Text);
            Payment.Amount = Convert.ToDouble(txtAmount.Text);
            Payment.IsPaymentSuccessful = CheckBoxIsPaymentSuccessful.Checked;
            Payment.TicketID = Convert.ToInt32(txtTicketID.Text);
            //create a new instance of the payment collection
            clsPaymentCollection PaymentList = new clsPaymentCollection();
            //set the thispayment property
            PaymentList.ThisPayment = Payment;
            //add the record
            PaymentList.Add();
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
                ;
        }

    }
}
