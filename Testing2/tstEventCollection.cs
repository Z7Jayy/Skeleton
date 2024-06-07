using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;

namespace Testing2
{
    [TestClass]
    public class tstEventCollection
    {
        private static string connectionString;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            // Initializes the connection string for the test class
            var connStr = ConfigurationManager.ConnectionStrings["ConnectionString"];
            connectionString = connStr == null ? null : connStr.ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string is not loaded.");
            }

            clsDataConnection.SetConnectionString(connectionString);
        }

        [TestMethod]
        public void InstanceOK()
        {
            // Tests if an instance of clsEventCollection can be created
            clsEventCollection AllEvents = new clsEventCollection();
            Assert.IsNotNull(AllEvents);
        }

        [TestMethod]
        public void AddMethodOK()
        {
            // Tests if Add method works correctly
            clsEventCollection AllEvents = new clsEventCollection();
            clsEvent TestItem = new clsEvent
            {
                EventId = 1,
                EventName = "Music Concert",
                EventDescription = "An amazing music concert",
                EventDate = DateTime.Now,
                VenueId = 101,
                Category = "Music",
                IsOnline = true,
                Active = true,
                DateAdded = DateTime.Now
            };
            int PrimaryKey = 0;
            AllEvents.ThisEvent = TestItem;
            PrimaryKey = AllEvents.Add();
            AllEvents.ThisEvent.Find(PrimaryKey);
            Assert.AreEqual(AllEvents.ThisEvent.EventId, TestItem.EventId);
            Assert.AreEqual(AllEvents.ThisEvent.EventName, TestItem.EventName);
            Assert.AreEqual(AllEvents.ThisEvent.EventDescription, TestItem.EventDescription);
            Assert.AreEqual(AllEvents.ThisEvent.EventDate, TestItem.EventDate);
            Assert.AreEqual(AllEvents.ThisEvent.VenueId, TestItem.VenueId);
            Assert.AreEqual(AllEvents.ThisEvent.Category, TestItem.Category);
            Assert.AreEqual(AllEvents.ThisEvent.IsOnline, TestItem.IsOnline);
            Assert.AreEqual(AllEvents.ThisEvent.Active, TestItem.Active);
            Assert.AreEqual(AllEvents.ThisEvent.DateAdded, TestItem.DateAdded);
        }

        [TestMethod]
        public void UpdateMethodOK()
        {
            // Tests if Update method works correctly
            clsEventCollection AllEvents = new clsEventCollection();
            clsEvent TestItem = new clsEvent
            {
                EventId = 1,
                EventName = "Test Event",
                EventDescription = "Test Description",
                EventDate = DateTime.Now.Date,
                VenueId = 1,
                Category = "Music",
                IsOnline = true,
                Active = true,
                DateAdded = DateTime.Now.Date
            };
            AllEvents.ThisEvent = TestItem;
            int newEventId = AllEvents.Add();

            clsEvent UpdatedEvent = new clsEvent
            {
                EventId = newEventId,
                EventName = "Updated Event",
                EventDescription = "Updated Description",
                EventDate = DateTime.Now.Date,
                VenueId = 2,
                Category = "Updated Category",
                IsOnline = false,
                Active = false,
                DateAdded = DateTime.Now.Date
            };
            AllEvents.ThisEvent = UpdatedEvent;
            AllEvents.Update();

            bool found = AllEvents.Find(newEventId);
            Assert.IsTrue(found);
            Assert.AreEqual(AllEvents.ThisEvent.EventName, "Updated Event");
            Assert.AreEqual(AllEvents.ThisEvent.EventDescription, "Updated Description");
            Assert.AreEqual(AllEvents.ThisEvent.VenueId, 2);
            Assert.AreEqual(AllEvents.ThisEvent.Category, "Updated Category");
            Assert.AreEqual(AllEvents.ThisEvent.IsOnline, false);
            Assert.AreEqual(AllEvents.ThisEvent.Active, false);
        }

        [TestMethod]
        public void FindMethodOK()
        {
            // Tests if Find method works correctly
            clsEventCollection AllEvents = new clsEventCollection();
            clsEvent TestItem = new clsEvent
            {
                EventId = 1,
                EventName = "Test Event",
                EventDescription = "Test Description",
                EventDate = DateTime.Now.Date,
                VenueId = 1,
                Category = "Music",
                IsOnline = true,
                Active = true,
                DateAdded = DateTime.Now.Date
            };
            AllEvents.ThisEvent = TestItem;
            int newEventId = AllEvents.Add();

            bool Found = AllEvents.Find(newEventId);

            Assert.IsTrue(Found);
            Assert.AreEqual(AllEvents.ThisEvent.EventId, newEventId);
            Assert.AreEqual(AllEvents.ThisEvent.EventName, TestItem.EventName);
            Assert.AreEqual(AllEvents.ThisEvent.EventDescription, TestItem.EventDescription);
            Assert.AreEqual(AllEvents.ThisEvent.EventDate, TestItem.EventDate);
            Assert.AreEqual(AllEvents.ThisEvent.VenueId, TestItem.VenueId);
            Assert.AreEqual(AllEvents.ThisEvent.Category, TestItem.Category);
            Assert.AreEqual(AllEvents.ThisEvent.IsOnline, TestItem.IsOnline);
            Assert.AreEqual(AllEvents.ThisEvent.Active, TestItem.Active);
            Assert.AreEqual(AllEvents.ThisEvent.DateAdded, TestItem.DateAdded);
        }

        [TestMethod]
        public void EventListOK()
        {
            // Tests if EventList property works correctly
            clsEventCollection AllEvents = new clsEventCollection();
            Assert.IsNotNull(AllEvents.EventList);
        }

        [TestMethod]
        public void CountPropertyOK()
        {
            // Tests if Count property works correctly
            clsEventCollection AllEvents = new clsEventCollection();
            int count = AllEvents.Count;
            Assert.AreEqual(AllEvents.EventList.Count, count);
        }

        [TestMethod]
        public void ThisEventPropertyOK()
        {
            // Tests if ThisEvent property works correctly
            clsEventCollection AllEvents = new clsEventCollection();
            clsEvent TestItem = new clsEvent
            {
                EventId = 1,
                EventName = "Test Event",
                EventDescription = "Test Description",
                EventDate = DateTime.Now.Date,
                VenueId = 1,
                Category = "Music",
                IsOnline = true,
                Active = true,
                DateAdded = DateTime.Now.Date
            };
            AllEvents.ThisEvent = TestItem;
            Assert.AreEqual(AllEvents.ThisEvent, TestItem);
        }
    }
}
