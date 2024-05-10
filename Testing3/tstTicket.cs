using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Testing3
{
    [TestClass]
    public class tstTicket
    {
        [TestMethod]
        public void InstanceOK()
        {
            //create an instance of the class we want to create
            clsTicket AnTicket = new clsTicket();
            //test to see that it exists
            Assert.IsNotNull( AnTicket );
        }

        [TestMethod]
        public void TicketIDPropertyOK()
        {
            // Create an instance of the class we want to test
            clsTicket AnTicket = new clsTicket();
            // Create some test data to assign to the property
            int TestData = 1;
            // Assign the data to the property
            AnTicket.TicketID = TestData;
            // Test to see that the two values are the same
            Assert.AreEqual(AnTicket.TicketID, TestData);
        }

        [TestMethod]
        public void DatePropertyOK()
        {
            // Create an instance of the class we want to test
            clsTicket AnTicket = new clsTicket();
            // Create some test data to assign to the property
            DateTime TestData = DateTime.Now.Date;
            // Assign the data to the property
            AnTicket.Date = TestData;
            // Test to see that the two values are the same
            Assert.AreEqual(AnTicket.Date, TestData);
        }

        [TestMethod]
        public void PricePropertyOK()
        {
            // Create an instance of the class we want to test
            clsTicket AnTicket = new clsTicket();
            // Create some test data to assign to the property
            int TestData = 100;
            // Assign the data to the property
            AnTicket.Price = TestData;
            // Test to see that the two values are the same
            Assert.AreEqual(AnTicket.Price, TestData);
        }

        [TestMethod]
        public void VenuePropertyOK()
        {
            // Create an instance of the class we want to test
            clsTicket AnTicket = new clsTicket();
            // Create some test data to assign to the property
            string TestData = "Some Venue";
            // Assign the data to the property
            AnTicket.Venue = TestData;
            // Test to see that the two values are the same
            Assert.AreEqual(AnTicket.Venue, TestData);
        }

        [TestMethod]
        public void ArtistPropertyOK()
        {
            // Create an instance of the class we want to test
            clsTicket AnTicket = new clsTicket();
            // Create some test data to assign to the property
            string TestData = "Some Artist";
            // Assign the data to the property
            AnTicket.Artist = TestData;
            // Test to see that the two values are the same
            Assert.AreEqual(AnTicket.Artist, TestData);
        }

        [TestMethod]
        public void IsSoldPropertyOK()
        {
            // Create an instance of the class we want to test
            clsTicket AnTicket = new clsTicket();
            // Create some test data to assign to the property
            Boolean TestData = true;
            // Assign the data to the property
            AnTicket.IsSold = TestData;
            // Test to see that the two values are the same
            Assert.AreEqual(AnTicket.IsSold, TestData);
        }

        [TestMethod]
        public void TicketTypePropertyOK()
        {
            // Create an instance of the class we want to test
            clsTicket AnTicket = new clsTicket();
            // Create some test data to assign to the property
            string TestData = "VIP";
            // Assign the data to the property
            AnTicket.TicketType = TestData;
            // Test to see that the two values are the same
            Assert.AreEqual(AnTicket.TicketType, TestData);
        }

    }
}
