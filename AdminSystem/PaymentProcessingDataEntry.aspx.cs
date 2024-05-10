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
        // Create a new instance of clsPayment
        clsPayment Payment = new clsPayment();

        // Perform validation for numeric fields
        int paymentID;
        if (!int.TryParse(txtpaymentID.Text, out paymentID))
        {
            // Display error message or handle invalid input
            // For example, show a message to the user and return
            lblError.Text = "Invalid Payment ID. Please enter a valid integer.";
            return;
        }

        double amount;
        if (!double.TryParse(txtamount.Text, out amount))
        {
            // Display error message or handle invalid input
            // For example, show a message to the user and return
            lblError.Text = "Invalid Amount. Please enter a valid number.";
            return;
        }

        int ticketId;
        if (!int.TryParse(txtticketId.Text, out ticketId))
        {
            // Display error message or handle invalid input
            // For example, show a message to the user and return
            lblError.Text = "Invalid Ticket ID. Please enter a valid integer.";
            return;
        }

        // Capture Data
        Payment.paymentID = paymentID;
        Payment.transactionID = txttransactionID.Text;
        Payment.amount = amount;
        Payment.paymentDate = DateTime.Now;
        Payment.isPaymentSuccessful = chkisPaymentSuccessful.Checked;
        Payment.paymentMethod = ddlpaymentMethod.SelectedValue;
        Payment.ticketId = ticketId;

        // Store the data in session
        Session["PaymentData"] = Payment;

        // Navigate to the view page 
        Response.Redirect("PaymentProcessingViewer.aspx");
    }

    public void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selectedPaymentMethod = ddlpaymentMethod.SelectedItem.Value;

    }
}