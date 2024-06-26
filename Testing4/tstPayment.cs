﻿using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using System.IO;



namespace Testing4
{
    [TestClass]
    public class tstPayment
    {
        public bool OK { get; private set; }
        //good test data
        //create some test data to pass the method
        string TransactionID = "ABC-123";
           string PaymentDate = DateTime.Now.ToShortDateString();
           string PaymentMethod = "PayPal";

        [TestMethod]
        public void TestPaymentInstantiation()
        {
            //create an instance of the class we want to create
            clsPayment Payment = new clsPayment();
            //test to see that it exixts
            Assert.IsNotNull(Payment);
        }

        [TestMethod]
        public void TestPaymentID()
        {
            // Arrange
            clsPayment Payment = new clsPayment();
            int expectedPaymentID = 1;

            // Act
            Payment.PaymentID = expectedPaymentID;

            // Assert
            Assert.AreEqual(expectedPaymentID, Payment.PaymentID, "Payment ID was not set correctly.");
        }   

        [TestMethod]
        public void TestTransactionID()
        {
            // Arrange
            clsPayment Payment = new clsPayment();
            string expectedTransactionID = "ABC-123";

            // Act
            Payment.TransactionID = expectedTransactionID;

            // Assert
            Assert.AreEqual(expectedTransactionID, Payment.TransactionID, "Transaction ID was not set correctly.");
        }

        [TestMethod]
        public void TestAmount()
        {
            clsPayment Payment = new clsPayment();
            double expectedAmount = 50.5;

            Payment.Amount = expectedAmount;

            Assert.AreEqual(expectedAmount, Payment.Amount, "Amount was not set correctly.");
        }

        [TestMethod]
        public void TestPaymentDate()
        {
            clsPayment Payment = new clsPayment();
            DateTime expectedPaymentDate = DateTime.Now.Date;

            Payment.PaymentDate = expectedPaymentDate;

            Assert.AreEqual(expectedPaymentDate, Payment.PaymentDate, "Payment Date was not set correctly.");
        }

        [TestMethod]
        public void TestIsPaymentSuccessful()
        {
            clsPayment Payment = new clsPayment();
            bool expectedIsSuccessful = true;

            Payment.IsPaymentSuccessful = expectedIsSuccessful;

            Assert.AreEqual(expectedIsSuccessful, Payment.IsPaymentSuccessful, "isPaymentSuccessful was not set correctly.");
        }

        [TestMethod]
        public void TestPaymentMethod()
        {
            clsPayment Payment = new clsPayment();
            string expectedPaymentMethod = "PayPal";

            Payment.PaymentMethod = expectedPaymentMethod;

            Assert.AreEqual(expectedPaymentMethod, Payment.PaymentMethod, "Payment Method was not set correctly.");
        }

        [TestMethod]
        public void TestTicketID()
        {
            clsPayment Payment = new clsPayment();
            int expectedTicketId = 10;

            Payment.TicketID = expectedTicketId;

            Assert.AreEqual(expectedTicketId, Payment.TicketID, "Ticket ID was not set correctly.");
        }

        [TestMethod]
        public void FindMethodOK()
        {
            // Create an instance of the class we want to create
            clsPayment Payment = new clsPayment();

            //Create a boolean variable to store the results of the search
            Boolean Found = false;

            //Create some test data to use with the method
            Int32 PaymentID = 7;

            //invoke the method
            Found = Payment.Find(PaymentID);

            //test to see that the result is correct
            Assert.IsTrue(Found);

        }

        [TestMethod]
        public void TestPaymentIDFound()
        {
            // Create an instance of the class we want to create
            clsPayment Payment = new clsPayment();

            //Create a boolean variable to store the results of the search
            Boolean Found = false;

            //Create a boolean to record if the data is OK (assume it is)
            Boolean OK = true;

            //Create some test data to use with the method
            Int32 PaymentID = 7;

            //invoke the method
            Found = Payment.Find(PaymentID);

            //check the payment id
            if (Payment.PaymentID != 7)
            {
                OK = false;
            }
            //test to see that the result is correct
            Assert.IsTrue(OK);

        }


        [TestMethod]
        public void TestTransactionIDFound()
        {
            // Create an instance of the class we want to create
            clsPayment Payment = new clsPayment();

            // Create a boolean variable to store the results of the search
            Boolean Found = false;

            // Create a boolean to record if the data is OK (assume it is)
            Boolean OK = true;

            //Create some test data to use with the method
            Int32 PaymentID = 7;

            // Invoke the method
            Found = Payment.Find(PaymentID);

            // Check the TransactionID
            if (Payment.TransactionID != "STU-123")
            {
                OK = false;
            }

            // Test to see that the result is correct
            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void TestAmountFound()
        {
            // Create an instance of the class we want to create
            clsPayment Payment = new clsPayment();

            // Create a boolean variable to store the results of the search
            Boolean Found = false;

            // Create a boolean to record if the data is OK (assume it is)
            Boolean OK = true;

            //Create some test data to use with the method
            Int32 PaymentID = 7;

            // Invoke the method
            Found = Payment.Find(PaymentID);

            // Check the Amount
            if (Payment.Amount != 50.5)
            {
                OK = false;
            }

            // Test to see that the result is correct
            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void TestPaymentDateFound()
        {
            // Create an instance of the class we want to create
            clsPayment Payment = new clsPayment();

            // Create a boolean variable to store the results of the search
            Boolean Found = false;

            // Create a boolean to record if the data is OK (assume it is)
            Boolean OK = true;

            // Create some test data to use with the method
            Int32 PaymentID = 7;

            // Invoke the method
            Found = Payment.Find(PaymentID);

            // Check the PaymentDate
            if (Payment.PaymentDate != Convert.ToDateTime("30/05/2024"))
            {
                OK = false;
            }

            // Test to see that the result is correct
            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void TestIsPaymentSuccessfulFound()
        {
            // Create an instance of the class we want to create
            clsPayment Payment = new clsPayment();

            // Create a boolean variable to store the results of the search
            Boolean Found = false;

            // Create a boolean to record if the data is OK (assume it is)
            Boolean OK = true;

            //Create some test data to use with the method
            Int32 PaymentID = 7;

            // Invoke the method
            Found = Payment.Find(PaymentID);

            // Check the IsPaymentSuccessful
            if (Payment.IsPaymentSuccessful != true)
            {
                OK = false;
            }

            // Test to see that the result is correct
            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void TestPaymentMethodFound()
        {
            // Create an instance of the class we want to create
            clsPayment Payment = new clsPayment();

            // Create a boolean variable to store the results of the search
            Boolean Found = false;

            // Create a boolean to record if the data is OK (assume it is)
            Boolean OK = true;

            //Create some test data to use with the method
            Int32 PaymentID = 7;

            // Invoke the method
            Found = Payment.Find(PaymentID);

            // Check the PaymentMethod
            if (Payment.PaymentMethod != "Debit Card")
            {
                OK = false;
            }

            // Test to see that the result is correct
            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void TestTicketIDFound()
        {
            // Create an instance of the class we want to create
            clsPayment Payment = new clsPayment();

            // Create a boolean variable to store the results of the search
            Boolean Found = false;

            // Create a boolean to record if the data is OK (assume it is)
            Boolean OK = true;

            //Create some test data to use with the method
            Int32 PaymentID = 7;

            // Invoke the method
            Found = Payment.Find(PaymentID);

            // Check the TicketID
            if (Payment.TicketID != 40)
            {
                OK = false;
            }

            // Test to see that the result is correct
            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void ValidMethodOK()
        {
            // Create an instance of the class we want to create
            clsPayment Payment = new clsPayment();

            //streing variable to store any error messages
            string Error = "";

            //invoke the method
            Error = Payment.Valid(TransactionID, PaymentMethod, PaymentDate);

            //test to see the result is correct
            Assert.AreEqual(Error, "");

        }

        [TestMethod]
        public void TransactionMinLessOne()
        {
            // Create an instance of the class we want to create
            clsPayment Payment = new clsPayment();

            //String c=variable to store any error message
            String Error = "";

            //Create some test data to pass the method
            string TransactionID = "";

            //Invoe the method
            Error = Payment.Valid(TransactionID, PaymentMethod, PaymentDate);

            //test to see that the result is correct
            Assert.AreNotEqual(Error, "");
         }

        [TestMethod]
        public void TransactionMin()
        {
            // Create an instance of the class we want to create
            clsPayment Payment = new clsPayment();

            //String c=variable to store any error message
            String Error = "";

            //Create some test data to pass the method
            string TransactionID = "A";

            //Invoe the method
            Error = Payment.Valid(TransactionID, PaymentMethod, PaymentDate);

            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void TransactionMinPlusOne()
        {
            // Create an instance of the class we want to create
            clsPayment Payment = new clsPayment();

            //String c=variable to store any error message
            String Error = "";

            //Create some test data to pass the method
            string TransactionID = "AB";

            //Invoe the method
            Error = Payment.Valid(TransactionID, PaymentMethod, PaymentDate);

            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void TransactionMaxLessOne()
        {
            // Create an instance of the class we want to create
            clsPayment Payment = new clsPayment();

            //String c=variable to store any error message
            String Error = "";

            //Create some test data to pass the method
            string TransactionID = "ABCDE";

            //Invoe the method
            Error = Payment.Valid(TransactionID, PaymentMethod, PaymentDate);

            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void TransactionMax()
        {
            // Create an instance of the class we want to create
            clsPayment Payment = new clsPayment();

            //String c=variable to store any error message
            String Error = "";

            //Create some test data to pass the method
            string TransactionID = "ABCDEF1234";
            
            //Invoe the method
            Error = Payment.Valid(TransactionID, PaymentMethod, PaymentDate);

            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void TransactionMid()
        {
            // Create an instance of the class we want to create
            clsPayment Payment = new clsPayment();

            //String c=variable to store any error message
            String Error = "";

            //Create some test data to pass the method
            string TransactionID = "ABC";

            //Invoe the method
            Error = Payment.Valid(TransactionID, PaymentMethod, PaymentDate);

            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void TransactionMaxPlusOne()
        {
            // Create an instance of the class we want to create
            clsPayment Payment = new clsPayment();

            //String c=variable to store any error message
            String Error = "";

            //Create some test data to pass the method
            string TransactionID = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA";

            //Invoe the method
            Error = Payment.Valid(TransactionID, PaymentMethod, PaymentDate);

            //test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void TransactionExtremeMax()
        {
            // Create an instance of the class we want to create
            clsPayment Payment = new clsPayment();

            //String c=variable to store any error message
            String Error = "";

            //Create some test data to pass the method
            string TransactionID = "";
            TransactionID = TransactionID.PadRight(65535, '0');

            //Invoe the method
            Error = Payment.Valid(TransactionID, PaymentMethod, PaymentDate);

            //test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void PaymentDateExtremeMin()
        {
            // Create an instance of the class we want to create
            clsPayment Payment = new clsPayment();

            //String c=variable to store any error message
            String Error = "";

            //create a valiable to store the test data 
            DateTime TestDate;

            //set the date to todays date
            TestDate = DateTime.Now.Date;

            //change the date to whatever the date is less 10 years
            TestDate = TestDate.AddYears(-10);

            //convert the date variable to a string variable
            string PaymentDate = TestDate.ToString();

            //Invoe the method
            Error = Payment.Valid(TransactionID, PaymentMethod, PaymentDate);

            //test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void PaymentDateMinLessOne()
        {
            // Create an instance of the class we want to create
            clsPayment Payment = new clsPayment();

            //String c=variable to store any error message
            String Error = "";

            //create a valiable to store the test data 
            DateTime TestDate;

            //set the date to todays date
            TestDate = DateTime.Now.Date;

            //change the date to whatever the date is less 10 years
            TestDate = TestDate.AddDays(-1);

            //convert the date variable to a string variable
            string PaymentDate = TestDate.ToString();

            //Invoe the method
            Error = Payment.Valid(TransactionID, PaymentMethod, PaymentDate);

            //test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void PaymentDateMin()
        {
            // Create an instance of the class we want to create
            clsPayment Payment = new clsPayment();

            //String c=variable to store any error message
            String Error = "";

            //create a valiable to store the test data 
            DateTime TestDate;

            //set the date to todays date
            TestDate = DateTime.Now.Date;

            //convert the date variable to a string variable
            string PaymentDate = TestDate.ToString();

            //Invoe the method
            Error = Payment.Valid(TransactionID, PaymentMethod, PaymentDate);

            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void PaymentDateMinPlusOne()
        {
            // Create an instance of the class we want to create
            clsPayment Payment = new clsPayment();

            //String c=variable to store any error message
            String Error = "";

            //create a valiable to store the test data 
            DateTime TestDate;

            //set the date to todays date
            TestDate = DateTime.Now.Date;

            //change the date to whatever the date is less 10 years
            TestDate = TestDate.AddDays(1);

            //convert the date variable to a string variable
            string PaymentDate = TestDate.ToString();

            //Invoe the method
            Error = Payment.Valid(TransactionID, PaymentMethod, PaymentDate);

            //test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void PaymentDateExtremeMax()
        {
            // Create an instance of the class we want to create
            clsPayment Payment = new clsPayment();

            //String c=variable to store any error message
            String Error = "";

            //create a valiable to store the test data 
            DateTime TestDate;

            //set the date to todays date
            TestDate = DateTime.Now.Date;

            //change the date to whatever the date is less 10 years
            TestDate = TestDate.AddYears(10);

            //convert the date variable to a string variable
            string PaymentDate = TestDate.ToString();

            //Invoe the method
            Error = Payment.Valid(TransactionID, PaymentMethod, PaymentDate);

            //test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void PaymentMethodMinLessOne()
        {
            // Create an instance of the class we want to create
            clsPayment Payment = new clsPayment();

            //String c=variable to store any error message
            String Error = "";

            //Create some test data to pass the method
            string PaymentMethod = "";

            //Invoe the method
            Error = Payment.Valid(TransactionID, PaymentMethod, PaymentDate);

            //test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void PaymentMethodMin()
        {
            // Create an instance of the class we want to create
            clsPayment Payment = new clsPayment();

            //String c=variable to store any error message
            String Error = "";

            //Create some test data to pass the method
            string PaymentMethod = "A";

            //Invoe the method
            Error = Payment.Valid(TransactionID, PaymentMethod, PaymentDate);

            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void PaymentMethodMinPlusOne()
        {
            // Create an instance of the class we want to create
            clsPayment Payment = new clsPayment();

            //String c=variable to store any error message
            String Error = "";

            //Create some test data to pass the method
            string PaymentMethod = "AB";

            //Invoe the method
            Error = Payment.Valid(TransactionID, PaymentMethod, PaymentDate);

            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void PaymentMethodMaxLessOne()
        {
            // Create an instance of the class we want to create
            clsPayment Payment = new clsPayment();

            //String c=variable to store any error message
            String Error = "";

            //Create some test data to pass the method
            string PaymentMethod = "ABCDE";

            //Invoe the method
            Error = Payment.Valid(TransactionID, PaymentMethod, PaymentDate);

            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void PaymentMethodMax()
        {
            // Create an instance of the class we want to create
            clsPayment Payment = new clsPayment();

            //String c=variable to store any error message
            String Error = "";

            //Create some test data to pass the method
            string PaymentMethod = "ABCDEF1234";

            //Invoe the method
            Error = Payment.Valid(TransactionID, PaymentMethod, PaymentDate);

            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void PaymentMethodMid()
        {
            // Create an instance of the class we want to create
            clsPayment Payment = new clsPayment();

            //String c=variable to store any error message
            String Error = "";

            //Create some test data to pass the method
            string PaymentMethod = "ABC";

            //Invoe the method
            Error = Payment.Valid(TransactionID, PaymentMethod, PaymentDate);

            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void PaymentMethodMaxPlusOne()
        {
            // Create an instance of the class we want to create
            clsPayment Payment = new clsPayment();

            //String c=variable to store any error message
            String Error = "";

            //Create some test data to pass the method
            string PaymentMethod = "AAAAAAAAAAAAAAAAAAAAA";

            //Invoe the method
            Error = Payment.Valid(TransactionID, PaymentMethod, PaymentDate);

            //test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void PaymentMethodExtremeMax()
        {
            // Create an instance of the class we want to create
            clsPayment Payment = new clsPayment();

            //String c=variable to store any error message
            String Error = "";

            //Create some test data to pass the method
            string PaymentMethod = "";
            PaymentMethod = PaymentMethod.PadRight(65535, '0');

            //Invoe the method
            Error = Payment.Valid(TransactionID, PaymentMethod, PaymentDate);

            //test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void StatisticsGroupedByAmount()
        {
            //create an new instance of the class we want to create
            clsPayment Payment = new clsPayment();
            //invoke the method
            DataTable dT = Payment.StatisticsGroupedByAmount();
            //rows of data produced by the last stored procedure
            int noOfRecord = 5;

            //test to see that the record is correct
            Assert.AreEqual(noOfRecord, dT.Rows.Count);
        }

        [TestMethod]
        public void StatisticsGroupedByPaymentDate()
        {
            //create an new instance of the class we want to create
            clsPayment Payment = new clsPayment();
            //invoke the method

            DataTable dT = Payment.StatisticsGroupedByPaymentDate();
            //rows of data produced by the last stored procedure
            int noOfRecord = 7;

            //test to see that the record is correct
            Assert.AreEqual(noOfRecord, dT.Rows.Count);
        }


    }

}
