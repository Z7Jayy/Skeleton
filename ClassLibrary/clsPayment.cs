using System;
using System.Data;
using System.Reflection;
using System.Runtime.Remoting.Messaging;

namespace ClassLibrary
{
    public class clsPayment
    {
        //private data member for the payment id property
        private Int32 mPaymentID;

        //paymentID public property
        public Int32 PaymentID
        {
            get
            {
                //this line of code sends data out of the property
                return mPaymentID;
            }
            set
            {
                //this line of code allows data into the property
                mPaymentID = value;
            }
        }

            //private data member for the payment id property
            private string mTransactionID;

            //paymentID public property
            public string TransactionID
            {
                get
                {
                    //this line of code sends data out of the property
                    return mTransactionID;
                }
                set
                {
                   //this line of code allows data into the property
                   mTransactionID = value;
                }
            }

            // Private data member for Amount property
            private double mAmount;

            // Amount public property
            public double Amount
            {
                get
                {
                     // This line of code sends data out of the property
                     return mAmount;
                }
                set
                {
                     // This line of code allows data into the property
                     mAmount = value;
                }
            }


        // Private data member for PaymentDate property
        private DateTime mPaymentDate;

        // PaymentDate public property
        public DateTime PaymentDate
        {
            get
            {
                // This line of code sends data out of the property
                return mPaymentDate;
            }
            set
            {
                // This line of code allows data into the property
                mPaymentDate = value;
            }
        }


        // Private data member for IsPaymentSuccessful property
        private bool mIsPaymentSuccessful;

        // IsPaymentSuccessful public property
        public bool IsPaymentSuccessful
        {
            get
            {
                // This line of code sends data out of the property
                return mIsPaymentSuccessful;
            }
            set
            {
                // This line of code allows data into the property
                mIsPaymentSuccessful = value;
            }
        }


        // Private data member for PaymentMethod property
        private string mPaymentMethod;

        // PaymentMethod public property
        public string PaymentMethod
        {
            get
            {
                // This line of code sends data out of the property
                return mPaymentMethod;
            }
            set
            {
                // This line of code allows data into the property
                mPaymentMethod = value;
            }
        }


        // Private data member for TicketID property
        private int mTicketID;

        // TicketID public property
        public int TicketID
        {
            get
            {
                // This line of code sends data out of the property
                return mTicketID;
            }
            set
            {
                // This line of code allows data into the property
                mTicketID = value;
            }
        }

        /****** FIND METHOD ******/
        public bool Find(int PaymentID)
        {
            //object for the data connect
            clsDataConnection DB = new clsDataConnection();

            //add the parameter for the address id to search for
            DB.AddParameter("@PaymentID", PaymentID);

            //execute the stored procedure
            DB.Execute("sproc_tblPayment_FilterByPaymentID");

            //if one record is found there should be either one or zero
            if (DB.Count == 1)
            {
                //read in the feilds for the current record
                mPaymentID = Convert.ToInt32(DB.DataTable.Rows[0]["PaymentID"]);
                mTransactionID = Convert.ToString(DB.DataTable.Rows[0]["TransactionID"]);
                mAmount = Convert.ToDouble(DB.DataTable.Rows[0]["Amount"]);
                mPaymentDate = Convert.ToDateTime(DB.DataTable.Rows[0]["PaymentDate"]);
                mIsPaymentSuccessful = Convert.ToBoolean(DB.DataTable.Rows[0]["IsPaymentSuccessful"]);
                mPaymentMethod = Convert.ToString(DB.DataTable.Rows[0]["PaymentMethod"]);
                mTicketID = Convert.ToInt32(DB.DataTable.Rows[0]["TicketID"]);
                //return that everything worked ok
                return true;
            }
            //if no record was found
            else
            {
                return false;
            }
        }

        public string Valid(string transactionID, string paymentMethod, string paymentDate)
        {
            //create a string variable to store the error
            String Error = "";

            //create a temporary variable to store the date values
            DateTime DateTemp;

            //if the Transaction ID is blank
            if (transactionID.Length == 0)
            {
                //record the error
                Error = Error + "The Transaction number may be blank : ";
            }
            //if the Transaction id is greater then max characters 
            if (transactionID.Length > 10) 
            {
                //Record the error
                Error = Error + "The transaction id must be less then 10 characters : ";
            }
           
            //copy the paymentdate value to the DateTemp variable
            DateTemp = Convert.ToDateTime(paymentDate);

            //check to see if the date is less than todays's date
            if (DateTemp < DateTime.Now.Date) 
            {
                Error = Error + "The date cannot be in the past : ";
            }
            //check to see if the date is greater then today's date
            if (DateTemp > DateTime.Now.Date) 
            {
                //record the error
                Error = Error + "The date cannot be in the future : ";
            }

            //if the Transaction ID is blank
            if (paymentMethod.Length == 0)
            {
                //record the error
                Error = Error + "The Payment Method number may be blank : ";
            }
            //if the Transaction id is greater then max characters 
            if (paymentMethod.Length > 10)
            {
                //Record the error
                Error = Error + "The Payment Method must be less then 10 characters : ";
            }
                //return any error messages
                return Error;
        }

        public DataTable StatisticsGroupedByAmount()
        {
            //create an instance of the data connection
            clsDataConnection DB = new clsDataConnection();

            //execute the stored procedure
            DB.Execute("sproc_tblPayment_Count_GroupByAmount");
            //there should be either zero, one, or more records
            return DB.DataTable;
        }

        public DataTable StatisticsGroupedByPaymentDate()
        {
            //create an instance of the data connection
            clsDataConnection DB = new clsDataConnection();

            //execute the stored procedure
            DB.Execute("sproc_tblPayment_Count_GroupPaymentDate");
            //there should be either zero, one, or more records
            return DB.DataTable;
        }


    }
}