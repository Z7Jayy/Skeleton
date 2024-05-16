using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Testing3
{
    [TestClass]
    public class tstTicket
    {
        public bool OK { get; private set; }

        [TestMethod]
        public void InstanceOK()
        {
            //create an instance of the class we want to create
            clsTicket AnTicket = new clsTicket();
            //test to see that it exists
            Assert.IsNotNull(AnTicket);
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

        [TestMethod]
        public void FindMethodOK()
        {
            //create an instance of the class we want to create
            clsTicket AnTicket = new clsTicket();
            //create a Boolean variable to store the results of the validation
            Boolean Found = false;
            //create some test data to use with the method
            Int32 TicketID = 2;
            //invoke the method
            Found = AnTicket.Find(TicketID);
            //test to see if the result is true
            Assert.IsTrue(Found);
        }

        [TestMethod]
        public void TestTicketIdFound()
        {
            //create an instance of the class we want to create
            clsTicket AnTicket = new clsTicket();
            //create a Boolean variable to store the result of the search
            Boolean Found = false;
            //create a Boolean variable to record if the data is OK (assume it is)
            Boolean OK = true;
            //create some test data to use with the method
            Int32 TicketID = 2;
            //invoke the method
            Found = AnTicket.Find(TicketID);
            //check the TicketId
            if (AnTicket.TicketID != 2)
            {
                OK = false;
            }
            //test to see that the result is correct
            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void TestDateFound()
        {
            //create an instance of the class we want to create
            clsTicket AnTicket = new clsTicket();
            //create a Boolean variable to store the result of the search
            Boolean Found = false;
            //create a Boolean variable to record if the data is OK (assume it is)
            Boolean OK = true;
            //create some test data to use with the method
            Int32 TicketID = 2;
            //invoke the method
            Found = AnTicket.Find(TicketID);
            //check the Date
            if (AnTicket.Date != Convert.ToDateTime("04/09/2003"))
            {
                OK = false;
            }
            //test to see that the result is correct
            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void TestPriceFound()
        {
            //create an instance of the class we want to create
            clsTicket AnTicket = new clsTicket();
            //create a Boolean variable to store the result of the search
            Boolean Found = false;
            //create a Boolean variable to record if data is OK (assume it is)
            Boolean OK = true;
            //create some test data to use with the method
            Int32 TicketID = 2;
            //invoke the method
            Found = AnTicket.Find(TicketID);
            //check the price property
            if (AnTicket.Price != 50)
            {
                OK = false;
            }
            //test to see that the result is correct
            Assert.IsTrue(OK);


        }

        [TestMethod]
        public void TestVenueFound()
        {
            //create an instance of the class we want to create
            clsTicket AnTicket = new clsTicket();
            //create a Boolean variable to store the result of the search
            Boolean Found = false;
            //create a Boolean variable to record if data is OK (assume it is)
            Boolean OK = true;
            //create some test data to use with the method
            Int32 TicketID = 2;
            //invoke the method
            Found = AnTicket.Find(TicketID);
            //check the venue property
            if (AnTicket.Venue != "Test Venue")
            {
                OK = false;
            }
            //test to see that the result is correct
            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void TestArtistFound()
        {
            //create an instance of the class we want to create
            clsTicket AnTicket = new clsTicket();
            //create a Boolean variable to store the result of the search
            Boolean Found = false;
            //create a Boolean variable to record if the data is OK (assume it is)
            Boolean OK = true;
            //create some test data to use with the method
            Int32 TicketID = 2;
            //invoke the method
            Found = AnTicket.Find(TicketID);
            //check the Artist
            if (AnTicket.Artist != "Test Artist")
            {
                OK = false;
            }
            //test to see that the result is correct
            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void TestIsSoldFound()
        {
            //create an instance of the class we want to create
            clsTicket AnTicket = new clsTicket();
            //create a Boolean variable to store the result of the search
            Boolean Found = false;
            //create a Boolean variable to record if the data is OK (assume it is)
            Boolean OK = true;
            //create some test data to use with the method
            Int32 TicketID = 2;
            //invoke the method
            Found = AnTicket.Find(TicketID);
            //check the IsSold property
            if (AnTicket.IsSold != true)
            {
                OK = false;
            }
            //test to see that the result is correct
            Assert.IsTrue(OK);

        }
        [TestMethod]
        public void TestTicketTypeFound()
        {
            //create an instance of the class we want to create
            clsTicket AnTicket = new clsTicket();
            //create a Boolean variable to store the result of the search
            Boolean Found = false;
            //create a Boolean variable to record if the data is OK (assume it is)
            Boolean OK = true;
            //create some test data to use with the method
            Int32 TicketID = 2;
            //invoke the method
            Found = AnTicket.Find(TicketID);
            //check the Artist
            if (AnTicket.TicketType != "VIP")
            {
                OK = false;
            }
            //test to see that the result is correct
            Assert.IsTrue(OK);
        }
    }
}
