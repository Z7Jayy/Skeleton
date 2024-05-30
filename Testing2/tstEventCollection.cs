using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace Testing2
{
    [TestClass]
    public class tstEventCollection
    {
        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            try
            {
                var config = ConfigurationManager.ConnectionStrings["ConnectionString"];
                if (config == null || string.IsNullOrEmpty(config.ConnectionString))
                {
                    throw new InvalidOperationException("Connection string is not loaded.");
                }
                Console.WriteLine("Connection string loaded successfully: " + config.ConnectionString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading connection string: {ex.Message}");
                throw;
            }
        }

        [TestMethod]
        public void InstanceOK()
        {
            clsEventCollection AllEvents = new clsEventCollection();
            Assert.IsNotNull(AllEvents);
        }

        [TestMethod]
        public void EventListOK()
        {
            clsEventCollection AllEvents = new clsEventCollection();
            List<clsEvent> TestList = new List<clsEvent>();
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
            TestList.Add(TestItem);
            AllEvents.EventList = TestList;
            Assert.AreEqual(AllEvents.EventList.Count, TestList.Count);
        }

        [TestMethod]
        public void CountPropertyOK()
        {
            clsEventCollection AllEvents = new clsEventCollection();
            List<clsEvent> TestList = new List<clsEvent>();
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
            TestList.Add(TestItem);
            AllEvents.EventList = TestList;
            Assert.AreEqual(AllEvents.Count, TestList.Count);
        }

        [TestMethod]
        public void ThisEventPropertyOK()
        {
            clsEventCollection AllEvents = new clsEventCollection();
            clsEvent TestEvent = new clsEvent
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
            AllEvents.ThisEvent = TestEvent;
            Assert.AreEqual(AllEvents.ThisEvent, TestEvent);
        }

        [TestMethod]
        public void AddMethodOK()
        {
            clsEventCollection eventCollection = new clsEventCollection();
            clsEvent newEvent = new clsEvent
            {
                EventName = "Sample Event",
                EventDescription = "Sample Description",
                EventDate = DateTime.Now,
                VenueId = 1,
                Category = "Sample Category",
                IsOnline = true,
                Active = true,
                DateAdded = DateTime.Now
            };
            eventCollection.ThisEvent = newEvent;
            int newEventId = eventCollection.Add();
            Assert.AreNotEqual(0, newEventId);
        }

        [TestMethod]
        public void UpdateMethodOK()
        {
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

            // Update the event
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

            // Find the updated event and verify the changes
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
    }
}
