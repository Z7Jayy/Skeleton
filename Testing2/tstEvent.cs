using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
            AnEvent.EventID = TestData;

            // Test to see that the two values are the same
            Assert.AreEqual(TestData, AnEvent.EventID);
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
            AnEvent.VenueID = TestData;

            // Test to see that the two values are the same
            Assert.AreEqual(TestData, AnEvent.VenueID);
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
    }

    public class clsEvent
    {
        public int EventID { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public DateTime EventDate { get; set; }
        public bool IsOnline { get; set; }
        public int VenueID { get; set; }
        public string Category { get; set; }
        public bool Active { get; set; }
        public DateTime DateAdded { get; set; }

        public global::System.String Valid(global::System.String eventName, global::System.String eventDescription, global::System.String eventDate, global::System.String venueId, global::System.String category)
        {
            throw new global::System.NotImplementedException();
        }
    }
}
