using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Testing2
{
    [TestClass]
    public class tstEvent
    {
        [TestMethod]
        public void InstanceOK()
        {
            // Creates an instance of the class we want to create
            clsEvent AnEvent = new clsEvent();
            // Test to see that it exists
            Assert.IsNotNull(AnEvent);
        }

        [TestMethod]
        public void ActiveEvent()
        {
            // Creates an instance of the class we want to test
            clsEvent AnEvent = new clsEvent();

            // Creates some test data to assign to the event
            Boolean TestData = true;

            // Assign the data to the property
            AnEvent.Active = TestData;

            // Test to see that the two values are the same
            Assert.AreEqual(TestData, AnEvent.Active);
        }

        [TestMethod]
        public void DateAddedEventOK()
        {
            // Creates an instance of the class we want to test
            clsEvent AnEvent = new clsEvent();

            // Creates some test data to assign to the event
            DateTime TestData = DateTime.Now.Date;

            // Assign the data to the property
            AnEvent.DateAdded = TestData;

            // Test to see that the two values are the same
            Assert.AreEqual(TestData, AnEvent.DateAdded);
        }

        [TestMethod]
        public void TestEventIDProperty()
        {
            // Creates an instance of the class we want to test
            clsEvent AnEvent = new clsEvent();

            // Creates some test data to assign to the event
            int TestData = 1;

            // Assign the data to the property
            AnEvent.EventId = TestData;

            // Test to see that the two values are the same
            Assert.AreEqual(TestData, AnEvent.EventId);
        }

        [TestMethod]
        public void TestEventNameProperty()
        {
            // Creates an instance of the class we want to test
            clsEvent AnEvent = new clsEvent();

            // Creates some test data to assign to the event
            string TestData = "Music Concert";

            // Assign the data to the property
            AnEvent.EventName = TestData;

            // Test to see that the two values are the same
            Assert.AreEqual(TestData, AnEvent.EventName);
        }

        [TestMethod]
        public void TestEventDescriptionProperty()
        {
            // Creates an instance of the class we want to test
            clsEvent AnEvent = new clsEvent();

            // Creates some test data to assign to the event
            string TestData = "A live music concert featuring various artists.";

            // Assign the data to the property
            AnEvent.EventDescription = TestData;

            // Test to see that the two values are the same
            Assert.AreEqual(TestData, AnEvent.EventDescription);
        }

        [TestMethod]
        public void TestEventDateProperty()
        {
            // Creates an instance of the class we want to test
            clsEvent AnEvent = new clsEvent();

            // Creates some test data to assign to the event
            DateTime TestData = DateTime.Now;

            // Assign the data to the property
            AnEvent.EventDate = TestData;

            // Test to see that the two values are the same
            Assert.AreEqual(TestData, AnEvent.EventDate);
        }

        [TestMethod]
        public void TestIsOnlineProperty()
        {
            // Creates an instance of the class we want to test
            clsEvent AnEvent = new clsEvent();

            // Creates some test data to assign to the event
            bool TestData = true;

            // Assign the data to the property
            AnEvent.IsOnline = TestData;

            // Test to see that the two values are the same
            Assert.AreEqual(TestData, AnEvent.IsOnline);
        }

        [TestMethod]
        public void TestVenueIDProperty()
        {
            // Creates an instance of the class we want to test
            clsEvent AnEvent = new clsEvent();

            // Creates some test data to assign to the event
            int TestData = 123;

            // Assign the data to the property
            AnEvent.VenueId = TestData;

            // Test to see that the two values are the same
            Assert.AreEqual(TestData, AnEvent.VenueId);
        }

        [TestMethod]
        public void TestCategoryProperty()
        {
            // Creates an instance of the class we want to test
            clsEvent AnEvent = new clsEvent();

            // Creates some test data to assign to the event
            string TestData = "Concert";

            // Assign the data to the property
            AnEvent.Category = TestData;

            // Test to see that the two values are the same
            Assert.AreEqual(TestData, AnEvent.Category);
        }

        [TestMethod]
        public void FindMethodOK()
        {
            clsEvent AnEvent = new clsEvent();
            bool Found = false;
            int EventID = 1;
            Found = AnEvent.Find(EventID);
            Assert.IsTrue(Found);
        }

        [TestMethod]
        public void TestEventIDFound()
        {
            clsEvent AnEvent = new clsEvent();
            bool Found = false;
            bool OK = true;
            int EventID = 1;
            Found = AnEvent.Find(EventID);
            if (AnEvent.EventId != 1)
            {
                OK = false;
            }
            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void TestEventNameFound()
        {
            clsEvent AnEvent = new clsEvent();
            bool Found = false;
            bool OK = true;
            int EventID = 1;
            Found = AnEvent.Find(EventID);
            if (AnEvent.EventName != "Music Concert")
            {
                OK = false;
            }
            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void TestEventDescriptionFound()
        {
            clsEvent AnEvent = new clsEvent();
            bool Found = false;
            bool OK = true;
            int EventID = 1;
            Found = AnEvent.Find(EventID);
            if (AnEvent.EventDescription != "A live music concert featuring various artists.")
            {
                OK = false;
            }
            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void TestEventDateFound()
        {
            clsEvent AnEvent = new clsEvent();
            bool Found = false;
            bool OK = true;
            int EventID = 1;
            Found = AnEvent.Find(EventID);
            if (AnEvent.EventDate != Convert.ToDateTime("2024-01-01"))
            {
                OK = false;
            }
            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void TestVenueIDFound()
        {
            clsEvent AnEvent = new clsEvent();
            bool Found = false;
            bool OK = true;
            int EventID = 1;
            Found = AnEvent.Find(EventID);
            if (AnEvent.VenueId != 123)
            {
                OK = false;
            }
            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void TestCategoryFound()
        {
            clsEvent AnEvent = new clsEvent();
            bool Found = false;
            bool OK = true;
            int EventID = 1;
            Found = AnEvent.Find(EventID);
            if (AnEvent.Category != "Concert")
            {
                OK = false;
            }
            Assert.IsTrue(OK);
        }
    }
}
