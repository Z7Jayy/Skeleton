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

    protected void btnOK_Click(object sender, EventArgs e)
    {
       /* //create a new instance of clsPayment
        clsPayment Payment = new clsPayment();
        //Capture Data
        Payment.paymentID = Convert.ToInt32(txtpaymentID.Text);
        Payment.transactionID = txttransactionID.Text;
        Payment.amount = Convert.ToDouble(txtamount.Text);
        Payment.paymentDate = Convert.ToDateTime(DateTime.Now);
        Payment.isPaymentSuccessful = chkisPaymentSuccessful.Checked;
        Payment.paymentMethod = txtpaymentMethod.Text;  
        Payment.ticketId = Convert.ToInt32(txtticketId.Text);
        //Store the data in this session object
        Session["PaymentData"]= Payment;
        //navigate to the view page */
        Response.Redirect("PaymentProcessingViewer.aspx");
    }
}