using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class _1_ConfirmDelete : System.Web.UI.Page
{
    //variable to store the primary key value
    Int32 PaymentID;
    protected void Page_Load(object sender, EventArgs e)
    {
        //get the number of the payment to be deleted from the session object
        PaymentID = Convert.ToInt32(Session["PaymentID"]);
    }

    protected void btnYes_Click(object sender, EventArgs e)
    {
        clsPaymentCollection PaymentProcessing = new clsPaymentCollection();
        //Finds the rcord to delete
        PaymentProcessing.ThisPayment.Find(PaymentID);
        //handles deleting the record
        PaymentProcessing.Delete();
        //redirect back to the list page
        Response.Redirect("PaymentProcessingList.aspx");
    }

    protected void btnNo_Click(object sender, EventArgs e)
    {
        //redirect back to the list page
        Response.Redirect("PaymentProcessingList.aspx");
    }
}