

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
        if (!IsPostBack)
        {
            // Retrieve payment object from session
            clsPayment Payment = Session["PaymentObject"] as clsPayment;

            // Display payment data if available
            if (Payment != null)
            {
                lblTransactionID.Text = "Transaction ID: " + Payment.transactionID;
                lblAmount.Text = "Amount: $" + Payment.amount.ToString();
                lblPaymentDate.Text = "Payment Date: " + Payment.paymentDate.ToString("MM/dd/yyyy");
                lblIsPaymentSuccessful.Text = "Payment Successful: " + (Payment.isPaymentSuccessful ? "Yes" : "No");
                lblPaymentMethod.Text = "Payment Method: " + Payment.paymentMethod;
                lblTicketId.Text = "Ticket ID: " + Payment.ticketId.ToString();

            }
            else
            {
                lblError.Text = "No Payment data found";
            }
        }

    }
}