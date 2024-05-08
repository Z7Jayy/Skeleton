using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
            clsPayment payment = new clsPayment();
            int expectedPaymentID = 1;

            // Act
            payment.paymentID = expectedPaymentID;

            // Assert
            Assert.AreEqual(expectedPaymentID, payment.paymentID, "Payment ID was not set correctly.");
        }

        [TestMethod]
        public void TestTransactionID()
        {
            // Arrange
            clsPayment payment = new clsPayment();
            string expectedTransactionID = "ABC-123";

            // Act
            payment.transactionID = expectedTransactionID;

            // Assert
            Assert.AreEqual(expectedTransactionID, payment.transactionID, "Transaction ID was not set correctly.");
        }

        [TestMethod]
        public void TestAmount()
        {
            clsPayment payment = new clsPayment();
            double expectedAmount = 55.5;

            payment.amount = expectedAmount;

            Assert.AreEqual(expectedAmount, payment.amount, "Amount was not set correctly.");
        }

        [TestMethod]
        public void TestPaymentDate()
        {
            clsPayment payment = new clsPayment();
            DateTime expectedPaymentDate = DateTime.Now.Date;

            payment.paymentDate = expectedPaymentDate;

            Assert.AreEqual(expectedPaymentDate, payment.paymentDate, "Payment Date was not set correctly.");
        }

        [TestMethod]
        public void TestIsPaymentSuccessful()
        {
            clsPayment payment = new clsPayment();
            bool expectedIsSuccessful = true;

            payment.isPaymentSuccessful = expectedIsSuccessful;

            Assert.AreEqual(expectedIsSuccessful, payment.isPaymentSuccessful, "isPaymentSuccessful was not set correctly.");
        }

        [TestMethod]
        public void TestPaymentMethod()
        {
            clsPayment payment = new clsPayment();
            string expectedPaymentMethod = "paypal";

            payment.paymentMethod = expectedPaymentMethod;

            Assert.AreEqual(expectedPaymentMethod, payment.paymentMethod, "Payment Method was not set correctly.");
        }

        [TestMethod]
        public void TestTicketID()
        {
            clsPayment payment = new clsPayment();
            int expectedTicketId = 45;

            payment.ticketId = expectedTicketId;

            Assert.AreEqual(expectedTicketId, payment.ticketId, "Ticket ID was not set correctly.");
        }
    }
}