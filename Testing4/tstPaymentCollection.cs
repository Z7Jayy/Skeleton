using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace Testing4
{
    [TestClass]
    public class tstPaymentCollection
    {
        [TestMethod]
        public void InstanceOK()
        {
            //crete an instance of the class we want to create
            clsPaymentCollection AllPayments = new clsPaymentCollection();
            //test to prove it exists
            Assert.IsNotNull(AllPayments);

        }

        [TestMethod]
        public void PaymentListOK()
        {
            //crete an instance of the class we want to create
            clsPaymentCollection AllPayments = new clsPaymentCollection();
            //create some test data to assign to this property,
            //in this case the data needs to be a list of objects
            List<clsPayment> TestList = new List<clsPayment>();
            //Add an item to the list
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
            //add the time to the test list
            TestList.Add(TestItem);
            //assign the data to the property
            AllPayments.PaymentList = TestList;
            //test to see that the two values are the same
            Assert.AreEqual(AllPayments.PaymentList, TestList);
        
        }


        [TestMethod]
        public void ThisPaymentPropertyOK()
        {
            //crete an instance of the class we want to create
            clsPaymentCollection AllPayments = new clsPaymentCollection();
            //create some test data to assign to this property,
            clsPayment TestPayment = new clsPayment();
            //set its properties
            TestPayment.PaymentID = 1;
            TestPayment.TransactionID = "ABC-123";
            TestPayment.Amount = 50.5;
            TestPayment.PaymentDate = DateTime.Now;
            TestPayment.PaymentMethod = "PayPal";
            TestPayment.TicketID = 10;
            TestPayment.IsPaymentSuccessful = true;
            //assign the data to the property
            AllPayments.ThisPayment = TestPayment;
            //test to see that the two values are the same
            Assert.AreEqual(AllPayments.ThisPayment, TestPayment);

        }

        [TestMethod]
        public void ListAndCountOK()
        {
            //crete an instance of the class we want to create
            clsPaymentCollection AllPayments = new clsPaymentCollection();
            //create some test data to assign to this property,
            //in this case the data needs to be a list of objects
            List<clsPayment> TestList = new List<clsPayment>();
            //Add an item to the list
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
            //add the time to the test list
            TestList.Add(TestItem);
            //assign the data to the property
            AllPayments.PaymentList = TestList;
            //test to see that the two values are the same
            Assert.AreEqual(AllPayments.Count, TestList.Count);

        }
    }
}
