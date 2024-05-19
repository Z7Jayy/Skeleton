using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class clsPaymentCollection
    {
        //private data member for the list
        List<clsPayment> mPaymentList = new List<clsPayment>();

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
        public clsPayment ThisPayment { get; set; }

        public clsPaymentCollection()
        {

            //create the item of test data
            clsPayment TestItem = new clsPayment();
            //set its properties
            TestItem.PaymentID = 1;
            TestItem.TransactionID = "ABC-123";
            TestItem.Amount = 50.5;
            TestItem.PaymentDate = DateTime.Now;
            TestItem.PaymentMethod = "PayPal";
            TestItem.TicketID = 10;
            TestItem.IsPaymentSuccessful = true;

            mPaymentList.Add(TestItem);

            TestItem = new clsPayment();

            TestItem.PaymentID = 2;
            TestItem.TransactionID = "BCD-123";
            TestItem.Amount = 60.5;
            TestItem.PaymentDate = DateTime.Now;
            TestItem.PaymentMethod = "Debit Card";
            TestItem.TicketID = 12;
            TestItem.IsPaymentSuccessful = true;

            mPaymentList.Add(TestItem);
        } 
    }
}