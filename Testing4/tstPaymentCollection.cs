﻿using ClassLibrary;
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

        [TestMethod]
        public void AddMethodOK()
        {
            //create an instance of the class we want to create
            clsPaymentCollection AllPayments = new clsPaymentCollection();
            //create the item of test data
            clsPayment TestItem = new clsPayment();
            //variable to store the primary key
            Int32 PrimaryKey = 0;
            //set its properties
            TestItem.PaymentID = 1;
            TestItem.TransactionID = "ABC-123";
            TestItem.Amount = 50.5;
            TestItem.PaymentDate = DateTime.Now;
            TestItem.PaymentMethod = "PayPal";
            TestItem.TicketID = 10;
            TestItem.IsPaymentSuccessful = true;
            //set thisPayment to the test data
            AllPayments.ThisPayment = TestItem;
            //add the record
            PrimaryKey = AllPayments.Add();
            //set the primarykey of the test data
            TestItem.PaymentID = PrimaryKey;
            //finf the record
            AllPayments.ThisPayment.Find(PrimaryKey);
            //test to see that the two values are the same
            Assert.AreEqual(AllPayments.ThisPayment, TestItem);

        }
        
        public void UpdateMethodOK()
        {
            //create an instance of the class we want to create
            clsPaymentCollection AllPayments = new clsPaymentCollection();
            //create the item of test data
            clsPayment TestItem = new clsPayment();
            //variable to store the primary key
            Int32 PrimaryKey = 0;
            //set its properties
            TestItem.TransactionID = "ABC-123";
            TestItem.Amount = 50.5;
            TestItem.PaymentDate = DateTime.Now;
            TestItem.PaymentMethod = "PayPal";
            TestItem.TicketID = 10;
            TestItem.IsPaymentSuccessful = true;
            //set thisPayment to the test data
            AllPayments.ThisPayment = TestItem;
            //add the record
            PrimaryKey = AllPayments.Add();
            //set the primary ket of the test data
            TestItem.PaymentID = PrimaryKey;
            //modify the test record
            TestItem.TransactionID = "DEF-123";
            TestItem.Amount = 100;
            TestItem.PaymentDate = DateTime.Now;
            TestItem.PaymentMethod = "Credit Card";
            TestItem.TicketID = 40;
            TestItem.IsPaymentSuccessful = false;
            //set the record based on the new data
            AllPayments.ThisPayment = TestItem;
            //update the record
            AllPayments.Update();
            //find the record
            AllPayments.ThisPayment.Find(PrimaryKey);
            //test to see if thispayment matches the test data
            Assert.AreEqual(AllPayments.ThisPayment, TestItem);
        
        }

    }
}
