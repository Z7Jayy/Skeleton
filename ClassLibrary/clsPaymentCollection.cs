using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ClassLibrary
{
    public class clsPaymentCollection
    {
        //private data member for the list
        List<clsPayment> mPaymentList = new List<clsPayment>();
        //private data member for thisPayment
        clsPayment mThisPayment = new clsPayment();

        //public property for the address list
        public List<clsPayment> PaymentList
        {
            get
            {
                //return the private data
                return mPaymentList;
            }
            set
            {
                //set the private data
                mPaymentList = value;
            }
        }

        public int Count
        {
            get
            {
                //return the private data
                return mPaymentList.Count;
            }
            set
            {
                //set the private data
            }
        }
        public clsPayment ThisPayment
        {
            get
            {
                //return the private data
                return mThisPayment;
            }

            set
            {
                //set the private data
                mThisPayment = value;
            }
        }

        public clsPaymentCollection()
        {
            clsDataConnection DB = new clsDataConnection();
            //Execute stored procedure
            DB.Execute("sproc_tblPayment_SelectAll");
            //get the count of records
            PopulateArray(DB);
        }

        

        public int Add()
        {
            //Add a record to the database based on the values of mThisAddress
            //connect to the database
            clsDataConnection DB = new clsDataConnection();
            //set the parameters for the stored procedure
            DB.AddParameter("@TransactionID", ThisPayment.TransactionID);
            DB.AddParameter("@Amount", ThisPayment.Amount);
            DB.AddParameter("@PaymentDate", ThisPayment.PaymentDate);
            DB.AddParameter("@IsPaymentSuccessful", ThisPayment.IsPaymentSuccessful);
            DB.AddParameter("@PaymentMethod", ThisPayment.PaymentMethod);
            DB.AddParameter("@TicketID", ThisPayment.TicketID);

            //execute the query returning to the primary key value
            return DB.Execute("sproc_tblPayment_Insert");

        }

        public void Update()
        {
            //Add a existing record  based on the values of ThisPayment
            //connect to the database
            clsDataConnection DB = new clsDataConnection();
            //set the parameters for the stored procedure
            DB.AddParameter("@PaymentID", mThisPayment.PaymentID);
            DB.AddParameter("@TransactionID", mThisPayment.TransactionID);
            DB.AddParameter("@Amount", mThisPayment.Amount);
            DB.AddParameter("@PaymentDate", mThisPayment.PaymentDate);
            DB.AddParameter("@IsPaymentSuccessful", mThisPayment.IsPaymentSuccessful);
            DB.AddParameter("@PaymentMethod", mThisPayment.PaymentMethod);
            DB.AddParameter("@TicketID", mThisPayment.TicketID);
            //execute the stored procedure
            DB.Execute("sproc_tblPayment_Update");
        }

        public void Delete()
        {
            //deletes the record pointed to by this address
            //connect to the database
            clsDataConnection DB = new clsDataConnection();
            //set the parameters for the stored procedure
            DB.AddParameter("@PaymentID", mThisPayment.PaymentID);
            //execute the stored procedure
            DB.Execute("sproc_tblPayment_Delete");
        }

        public void ReportByTransactionID(string TransactionID)
        {
            //Filters the records based on the full or partial code
            //Connect to the database
            clsDataConnection DB = new clsDataConnection();
            //send the transactionid parameter to the database
            DB.AddParameter("@TransactionID", TransactionID);
            //execute the stored procedure
            DB.Execute("sproc_tblPayment_FilterByTransactionID");
            //populate the array list with the data table
            PopulateArray(DB);
        }

        void PopulateArray(clsDataConnection DB)
        {
            //variable for index
            Int32 Index = 0;
            //variable to store the record count
            Int32 RecordCount = 0;
            //clear the private array list
            mPaymentList = new List<clsPayment>();
            //get the count of records
            RecordCount = DB.Count;
            //while there are records to process
            while (Index < RecordCount)
            {
                //create blank address
                clsPayment Payment = new clsPayment();
                //read in the feilds for the current record
                Payment.PaymentID = Convert.ToInt32(DB.DataTable.Rows[Index]["PaymentID"]);
                Payment.TransactionID = Convert.ToString(DB.DataTable.Rows[Index]["TransactionID"]);
                Payment.Amount = Convert.ToDouble(DB.DataTable.Rows[Index]["Amount"]);
                Payment.PaymentDate = Convert.ToDateTime(DB.DataTable.Rows[Index]["PaymentDate"]);
                Payment.IsPaymentSuccessful = Convert.ToBoolean(DB.DataTable.Rows[Index]["IsPaymentSuccessful"]);
                Payment.PaymentMethod = Convert.ToString(DB.DataTable.Rows[Index]["PaymentMethod"]);
                Payment.TicketID = Convert.ToInt32(DB.DataTable.Rows[Index]["TicketID"]);
                //add the record to the privte data member
                mPaymentList.Add(Payment);
                //Point at the next record
                Index++;
            }
        }
    }
}