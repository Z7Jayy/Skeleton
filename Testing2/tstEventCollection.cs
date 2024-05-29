using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Testing2
{
    [TestClass]
    public class tstEventCollection
    {
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
            AllEvents.Add();
            Assert.AreEqual(AllEvents.Count, 1);
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
            AllEvents.Add();
            Assert.AreEqual(AllEvents.EventList.Count, 1);
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
            AllEvents.Add();

            clsEvent UpdatedEvent = new clsEvent
            {
                EventId = 1,
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
            Assert.AreEqual(AllEvents.EventList[0].EventName, "Updated Event");
        }

        [TestMethod]
        public void FindMethodOK()
        {
            // Create an instance of the event collection
            clsEventCollection AllEvents = new clsEventCollection();

            // Create a test event and add it to the collection
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
            AllEvents.Add();

            // Try to find the event with EventId = 1
            bool Found = AllEvents.Find(1);

            // Check if the found event is not null
            Assert.IsTrue(Found);

            // Check if the found event matches the test item
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
    }
}
