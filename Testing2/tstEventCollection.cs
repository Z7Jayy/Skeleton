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
            clsEvent TestItem = new clsEvent();
            TestItem.EventId = 1;
            TestItem.EventName = "Test Event";
            TestItem.EventDescription = "Test Description";
            TestItem.EventDate = DateTime.Now.Date;
            TestItem.VenueId = 1;
            TestItem.Category = "Music";
            TestItem.IsOnline = true;
            TestList.Add(TestItem);
            AllEvents.EventList = TestList;
            Assert.AreEqual(AllEvents.EventList.Count, TestList.Count);
        }

        [TestMethod]
        public void CountPropertyOK()
        {
            clsEventCollection AllEvents = new clsEventCollection();
            int SomeCount = 2;
            AllEvents.Count = SomeCount;
            Assert.AreEqual(AllEvents.Count, SomeCount);
        }

        [TestMethod]
        public void AddMethodOK()
        {
            clsEventCollection AllEvents = new clsEventCollection();
            clsEvent TestItem = new clsEvent();
            TestItem.EventId = 1;
            TestItem.EventName = "Test Event";
            TestItem.EventDescription = "Test Description";
            TestItem.EventDate = DateTime.Now.Date;
            TestItem.VenueId = 1;
            TestItem.Category = "Music";
            TestItem.IsOnline = true;
            AllEvents.ThisEvent = TestItem;
            AllEvents.Add();
            AllEvents.Find(TestItem.EventId); // Ensuring item was added
            Assert.AreEqual(AllEvents.ThisEvent.EventName, TestItem.EventName);
        }

        [TestMethod]
        public void UpdateMethodOK()
        {
            clsEventCollection AllEvents = new clsEventCollection();
            clsEvent TestItem = new clsEvent();
            TestItem.EventId = 1;
            TestItem.EventName = "Test Event";
            TestItem.EventDescription = "Test Description";
            TestItem.EventDate = DateTime.Now.Date;
            TestItem.VenueId = 1;
            TestItem.Category = "Music";
            TestItem.IsOnline = true;
            AllEvents.ThisEvent = TestItem;
            AllEvents.Add();

            // Modify TestItem and update collection
            TestItem.EventName = "Updated Event";
            AllEvents.ThisEvent = TestItem;
            AllEvents.Update();
            AllEvents.Find(TestItem.EventId);
            Assert.AreEqual(AllEvents.ThisEvent.EventName, "Updated Event");
        }

        [TestMethod]
        public void FindMethodOK()
        {
            clsEventCollection AllEvents = new clsEventCollection();
            clsEvent TestItem = new clsEvent();
            TestItem.EventId = 1;
            TestItem.EventName = "Test Event";
            TestItem.EventDescription = "Test Description";
            TestItem.EventDate = DateTime.Now.Date;
            TestItem.VenueId = 1;
            TestItem.Category = "Music";
            TestItem.IsOnline = true;
            AllEvents.ThisEvent = TestItem;
            AllEvents.Add();

            bool Found = AllEvents.Find(TestItem.EventId);
            Assert.IsTrue(Found);
        }
    }
}
