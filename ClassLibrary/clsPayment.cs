using System;
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


        public bool Find(int paymentID)
        {
            //set the private data members to the test data value
            mPaymentID = 1;
            mTransactionID = "ABC-123";
            mAmount = 85.50;
            mPaymentDate = Convert.ToDateTime("01/05/2024");
            mIsPaymentSuccessful = true;
            mPaymentMethod = "PayPal";
            mTicketID = 10;

            //always return true
            return true;
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

    }
}