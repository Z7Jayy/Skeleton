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
        //create a new instance of clsPayment
        clsPayment Payment = new clsPayment();
        //Capture the transaction id
        Payment.transactionID = txttransactionID.Text;
        //store the transaction id in the session object
        Session["Payment"] = Payment;
        //navigate to the view page
        Response.Redirect("PaymentProcessingViewer.aspx");
    }
}