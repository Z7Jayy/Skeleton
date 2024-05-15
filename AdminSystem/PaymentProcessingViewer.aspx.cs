

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class _1Viewer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Retrieve payment object from session
        clsPayment Payment = new clsPayment();
        //get data from session object
        Payment = (clsPayment)Session["Payment"];
        //display the payment number for this entry
        Response.Write(Payment.PaymentID);
        Response.Write(Payment.TransactionID);
        Response.Write(Payment.Amount);
        Response.Write(Payment.PaymentDate);
        Response.Write(Payment.PaymentMethod);
        Response.Write(Payment.TicketID);
        Response.Write(Payment.IsPaymentSuccessful);



    }
}
