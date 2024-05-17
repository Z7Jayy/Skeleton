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
            Payment.PaymentID = Convert.ToInt32(txtPaymentID.Text);
            Payment.TransactionID = txtTransactionID.Text;
            Payment.Amount = Convert.ToDouble(txtAmount.Text);
            Payment.PaymentDate = Convert.ToDateTime(DateTime.Now);
            Payment.IsPaymentSuccessful = CheckBoxIsPaymentSuccessful.Checked;
            Payment.PaymentMethod = txtPaymentMethod.Text;
            Payment.TicketID = Convert.ToInt32(txtTicketID.Text);
            //store the Attribute in the session object
            Session["Payment"] = Payment;
            //navigate to the view page
            Response.Redirect("PaymentProcessingViewer.aspx");
        }

        else
        {
            //display the error message
            lblError.Text = Error;
        }
    }
}
