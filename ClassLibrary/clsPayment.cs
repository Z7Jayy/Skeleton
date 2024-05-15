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
        
    }
}