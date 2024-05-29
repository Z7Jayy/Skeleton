using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PaymentProcessingStatistics : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //create an new instance of the class we want to create
        clsPayment clspayment = new clsPayment();

        //retrieve data from the database
        DataTable dT = clspayment.StatisticsGroupedByAmount();

        //upload dT into the database
        GridViewGroupByAmount.DataSource = dT;
        GridViewGroupByAmount.DataBind();

        //change the header of the first column
        GridViewGroupByAmount.HeaderRow.Cells[0].Text = " Total ";


        //retrieve data from the database
         dT = clspayment.StatisticsGroupedByPaymentDate();

        //upload dT into the database
        GridViewGroupByPaymentDate.DataSource = dT;
        GridViewGroupByPaymentDate.DataBind();

        //change the header of the first column
        GridViewGroupByPaymentDate.HeaderRow.Cells[0].Text = " Total ";




    }
}