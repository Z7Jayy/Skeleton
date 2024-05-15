using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Dynamic;

namespace Testing4
{
    [TestClass]
    public class tstPayment
    {
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
            double expectedAmount = 55.5;

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
            string expectedPaymentMethod = "paypal";

            Payment.PaymentMethod = expectedPaymentMethod;

            Assert.AreEqual(expectedPaymentMethod, Payment.PaymentMethod, "Payment Method was not set correctly.");
        }

        [TestMethod]
        public void TestTicketID()
        {
            clsPayment Payment = new clsPayment();
            int expectedTicketId = 45;

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
            Int32 PaymentID = 1;

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
            Int32 PaymentID = 1;

            //invoke the method
            Found = Payment.Find(PaymentID);

            //check the payment id
            if (Payment.PaymentID != 1)
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
            Int32 PaymentID = 1;

            // Invoke the method
            Found = Payment.Find(PaymentID);

            // Check the TransactionID
            if (Payment.TransactionID != "ABC-123")
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
            Int32 PaymentID = 1;

            // Invoke the method
            Found = Payment.Find(PaymentID);

            // Check the Amount
            if (Payment.Amount != 85.50)
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
            Int32 PaymentID = 1;

            // Invoke the method
            Found = Payment.Find(PaymentID);

            // Check the PaymentDate
            if (Payment.PaymentDate != Convert.ToDateTime("01/05/2024"))
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
            Int32 PaymentID = 1;

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
            Int32 PaymentID = 1;

            // Invoke the method
            Found = Payment.Find(PaymentID);

            // Check the PaymentMethod
            if (Payment.PaymentMethod != "PayPal")
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
            Int32 PaymentID = 1;

            // Invoke the method
            Found = Payment.Find(PaymentID);

            // Check the TicketID
            if (Payment.TicketID != 10)
            {
                OK = false;
            }

            // Test to see that the result is correct
            Assert.IsTrue(OK);
        }

    }
}