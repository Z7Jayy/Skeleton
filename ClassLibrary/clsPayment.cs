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
            // Create a string variable to store the error
            String Error = "";

            // Create a temporary variable to store the date values
            DateTime DateTemp;

            // Validate TransactionID
            if (transactionID.Length == 0)
            {
                // Record the error
                Error += "The Transaction number may not be blank: ";
            }
            if (transactionID.Length > 50)
            {
                // Record the error
                Error += "The transaction ID must be less than 50 characters: ";
            }

            // Validate PaymentMethod
            if (paymentMethod.Length == 0)
            {
                // Record the error
                Error += "The Payment Method may not be blank: ";
            }
            if (paymentMethod.Length > 20)
            {
                // Record the error
                Error += "The Payment Method must be less than 20 characters: ";
            }

            // Validate PaymentDate
            try
            {
                DateTemp = Convert.ToDateTime(paymentDate);
                if (DateTemp < DateTime.Now.Date)
                {
                    Error += "The date cannot be in the past: ";
                }
                if (DateTemp > DateTime.Now.Date)
                {
                    Error += "The date cannot be in the future: ";
                }
            }
            catch
            {
                // Record the error
                Error += "Invalid Date: ";
            }

            // Return any error messages
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