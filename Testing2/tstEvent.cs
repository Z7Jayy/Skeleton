using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;

namespace Testing2
{
    [TestClass]
    public class tstEvent
    {
        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            // Initialize the connection string for the test class
            var connStr = ConfigurationManager.ConnectionStrings["ConnectionString"];
            if (connStr == null || string.IsNullOrEmpty(connStr.ConnectionString))
            {
                throw new InvalidOperationException("Connection string is not loaded.");
            }
            clsDataConnection.SetConnectionString(connStr.ConnectionString);
        }

        // Good test data
        string eventName = "Music Concert";
        string eventDescription = "An amazing music concert";
        string eventDate = DateTime.Now.ToShortDateString(); // Assuming this is in the format of "MM/dd/yyyy"
        string venueId = "101"; // Assuming VenueId is an integer
        string category = "Music";

        [TestMethod]
        public void InstanceOK()
        {
            // Test if an instance of clsEvent can be created
            clsEvent AnEvent = new clsEvent();
            Assert.IsNotNull(AnEvent);
        }

        [TestMethod]
        public void ActiveEvent()
        {
            // Test setting and getting the Active property
            clsEvent AnEvent = new clsEvent();
            Boolean TestData = true;
            AnEvent.Active = TestData;
            Assert.AreEqual(TestData, AnEvent.Active);
        }

        [TestMethod]
        public void DateAddedEventOK()
        {
            // Test setting and getting the DateAdded property
            clsEvent AnEvent = new clsEvent();
            DateTime TestData = DateTime.Now.Date;
            AnEvent.DateAdded = TestData;
            Assert.AreEqual(TestData, AnEvent.DateAdded);
        }

        [TestMethod]
        public void TestEventIDProperty()
        {
            // Test setting and getting the EventId property
            clsEvent AnEvent = new clsEvent();
            int TestData = 1;
            AnEvent.EventId = TestData;
            Assert.AreEqual(TestData, AnEvent.EventId);
        }

        [TestMethod]
        public void TestEventNameProperty()
        {
            // Test setting and getting the EventName property
            clsEvent AnEvent = new clsEvent();
            string TestData = "Music Concert";
            AnEvent.EventName = TestData;
            Assert.AreEqual(TestData, AnEvent.EventName);
        }

        [TestMethod]
        public void TestEventDescriptionProperty()
        {
            // Test setting and getting the EventDescription property
            clsEvent AnEvent = new clsEvent();
            string TestData = "A live music concert featuring various artists.";
            AnEvent.EventDescription = TestData;
            Assert.AreEqual(TestData, AnEvent.EventDescription);
        }

        [TestMethod]
        public void TestEventDateProperty()
        {
            // Test setting and getting the EventDate property
            clsEvent AnEvent = new clsEvent();
            DateTime TestData = DateTime.Now;
            AnEvent.EventDate = TestData;
            Assert.AreEqual(TestData, AnEvent.EventDate);
        }

        [TestMethod]
        public void TestIsOnlineProperty()
        {
            // Test setting and getting the IsOnline property
            clsEvent AnEvent = new clsEvent();
            bool TestData = true;
            AnEvent.IsOnline = TestData;
            Assert.AreEqual(TestData, AnEvent.IsOnline);
        }

        [TestMethod]
        public void TestVenueIDProperty()
        {
            // Test setting and getting the VenueId property
            clsEvent AnEvent = new clsEvent();
            int TestData = 123;
            AnEvent.VenueId = TestData;
            Assert.AreEqual(TestData, AnEvent.VenueId);
        }

        [TestMethod]
        public void TestCategoryProperty()
        {
            // Test setting and getting the Category property
            clsEvent AnEvent = new clsEvent();
            string TestData = "Concert";
            AnEvent.Category = TestData;
            Assert.AreEqual(TestData, AnEvent.Category);
        }

        [TestMethod]
        public void FindMethodOK()
        {
            // Test if Find method works correctly
            clsEvent AnEvent = new clsEvent();
            bool Found = AnEvent.Find(1);
            Assert.IsTrue(Found);
        }

        [TestMethod]
        public void TestEventIDFound()
        {
            // Test if EventId is found correctly
            clsEvent AnEvent = new clsEvent();
            bool Found = AnEvent.Find(1);
            Assert.IsTrue(Found);
            Assert.AreEqual(AnEvent.EventId, 1);
        }

        [TestMethod]
        public void TestEventNameFound()
        {
            // Test if EventName is found correctly
            clsEvent AnEvent = new clsEvent();
            bool Found = AnEvent.Find(1);
            Assert.IsTrue(Found);
            Assert.IsNotNull(AnEvent.EventName);
        }

        [TestMethod]
        public void TestEventDescriptionFound()
        {
            // Test if EventDescription is found correctly
            clsEvent AnEvent = new clsEvent();
            bool Found = AnEvent.Find(1);
            Assert.IsTrue(Found);
            Assert.IsNotNull(AnEvent.EventDescription);
        }

        [TestMethod]
        public void TestEventDateFound()
        {
            // Test if EventDate is found correctly
            clsEvent AnEvent = new clsEvent();
            bool Found = AnEvent.Find(1);
            Assert.IsTrue(Found);
            Assert.AreNotEqual(AnEvent.EventDate, DateTime.MinValue);
        }

        [TestMethod]
        public void TestVenueIDFound()
        {
            // Test if VenueId is found correctly
            clsEvent AnEvent = new clsEvent();
            bool Found = AnEvent.Find(1);
            Assert.IsTrue(Found);
            Assert.AreNotEqual(AnEvent.VenueId, 0);
        }

        [TestMethod]
        public void TestCategoryFound()
        {
            // Test if Category is found correctly
            clsEvent AnEvent = new clsEvent();
            bool Found = AnEvent.Find(1);
            Assert.IsTrue(Found);
            Assert.IsNotNull(AnEvent.Category);
        }

        [TestMethod]
        public void ValidMethodOK()
        {
            // Test if Valid method works correctly with valid data
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreEqual(Error, "");
        }

        // Parameter Tests
        [TestMethod]
        public void EventNameMinLessOne()
        {
            // Test if Valid method catches too short EventName
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string eventName = "";  // This should trigger an error 
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void EventNameMin()
        {
            // Test if Valid method allows minimum length EventName
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string eventName = "a"; // This should be OK
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void EventNameMinPlusOne()
        {
            // Test if Valid method allows slightly longer than minimum EventName
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string eventName = "aa"; // This should be OK
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void EventNameMaxLessOne()
        {
            // Test if Valid method allows maximum length EventName minus one character
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string eventName = "";
            eventName = eventName.PadRight(49, 'a');
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void EventNameMax()
        {
            // Test if Valid method allows maximum length EventName
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string eventName = "";
            eventName = eventName.PadRight(50, 'a');
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void EventNameMid()
        {
            // Test if Valid method allows mid length EventName
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string eventName = "Event Name"; // Mid length
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void EventNameMaxPlusOne()
        {
            // Test if Valid method catches too long EventName
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string eventName = "";
            eventName = eventName.PadRight(51, 'a');
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void EventNameExtremeMax()
        {
            // Test if Valid method catches extremely long EventName
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string eventName = "";
            eventName = eventName.PadRight(500, 'a'); // This should fail
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void EventNameInvalidData()
        {
            // Test if Valid method catches numeric EventName
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string eventName = "12345";  // Invalid data type
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void EventDescriptionMinLessOne()
        {
            // Test if Valid method catches too short EventDescription
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string eventDescription = "";  // This should trigger an error 
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void EventDescriptionMin()
        {
            // Test if Valid method allows minimum length EventDescription
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string eventDescription = "a"; // This should be OK
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void EventDescriptionMinPlusOne()
        {
            // Test if Valid method allows slightly longer than minimum EventDescription
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string eventDescription = "aa"; // This should be OK
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void EventDescriptionMid()
        {
            // Test if Valid method allows mid length EventDescription
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string eventDescription = "".PadRight(100, 'a'); // Mid length
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void EventDescriptionMaxLessOne()
        {
            // Test if Valid method allows maximum length EventDescription minus one character
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string eventDescription = "".PadRight(199, 'a'); // One less than the maximum allowed length (200)
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void EventDescriptionMax()
        {
            // Test if Valid method allows maximum length EventDescription
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string eventDescription = "".PadRight(200, 'a'); // Maximum allowed length (200)
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void EventDescriptionMaxPlusOne()
        {
            // Test if Valid method catches too long EventDescription
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string eventDescription = "".PadRight(201, 'a'); // One more than the maximum allowed length (200)
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void EventDescriptionInvalidData()
        {
            // Test if Valid method catches invalid EventDescription data
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string eventDescription = "Invalid@Description!";  // Invalid data for description
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void EventDateMinLessOne()
        {
            // Test if Valid method catches too early EventDate
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string eventDate = DateTime.Now.AddDays(-1).ToShortDateString(); // This should trigger an error (yesterday)
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void EventDateMin()
        {
            // Test if Valid method allows minimum EventDate
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string eventDate = DateTime.Now.ToShortDateString(); // This should be OK (today)
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void EventDateMinPlusOne()
        {
            // Test if Valid method allows slightly later than minimum EventDate
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string eventDate = DateTime.Now.AddDays(1).ToShortDateString(); // This should be OK (tomorrow)
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void EventDateMaxLessOne()
        {
            // Test if Valid method allows EventDate one day less than a year from now
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string eventDate = DateTime.Now.AddYears(1).AddDays(-1).ToShortDateString(); // This should be OK (one day less than a year from now)
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void EventDateMax()
        {
            // Test if Valid method allows maximum EventDate
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string eventDate = DateTime.Now.AddYears(1).ToShortDateString(); // This should be OK (one year from now)
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void EventDateMaxPlusOne()
        {
            // Test if Valid method catches EventDate one day more than a year from now
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string eventDate = DateTime.Now.AddYears(1).AddDays(1).ToShortDateString(); // This should trigger an error (one day more than a year from now)
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void EventDateExtremeMin()
        {
            // Test if Valid method catches extremely early EventDate
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            DateTime TestDate = DateTime.Now.AddYears(-100); // 100 years in the past
            string eventDate = TestDate.ToShortDateString();
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void EventDateExtremeMax()
        {
            // Test if Valid method catches extremely late EventDate
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            DateTime TestDate = DateTime.Now.AddYears(100); // 100 years in the future
            string eventDate = TestDate.ToShortDateString();
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void EventDateInvalidData()
        {
            // Test if Valid method catches invalid EventDate
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string eventDate = "not a date"; // Invalid date string
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void VenueIdMinLessOne()
        {
            // Test if Valid method catches too short VenueId
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string venueId = ""; // This should trigger an error (invalid venue ID)
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void VenueIdMin()
        {
            // Test if Valid method allows minimum VenueId
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string venueId = "1"; // This should be OK (minimum valid venue ID)
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void VenueIdMinPlusOne()
        {
            // Test if Valid method allows slightly longer than minimum VenueId
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string venueId = "2"; // This should be OK (one more than the minimum valid venue ID)
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void VenueIdMaxLessOne()
        {
            // Test if Valid method catches too long VenueId minus one character
            clsEvent AnEvent = new clsEvent();
            string Error = AnEvent.Valid("Valid name", "Valid description", DateTime.Now.AddDays(1).ToShortDateString(), "one hundred", "Valid category");
            Assert.AreEqual(Error, "The venue ID must be a valid non-negative number.");
        }

        [TestMethod]
        public void VenueIdMax()
        {
            // Test if Valid method catches maximum invalid VenueId
            clsEvent AnEvent = new clsEvent();
            string Error = AnEvent.Valid("Valid name", "Valid description", DateTime.Now.AddDays(1).ToShortDateString(), "-1", "Valid category");
            Assert.AreEqual(Error, "The venue ID must be a valid non-negative number.");
        }

        [TestMethod]
        public void VenueIdMaxPlusOne()
        {
            // Test if Valid method catches too long VenueId
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string venueId = "".PadRight(51, 'a'); // One more than the maximum valid venue ID for a string
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void VenueIdExtremeMax()
        {
            // Test if Valid method catches extremely long VenueId
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string venueId = "".PadRight(500, 'a'); // This should fail
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void VenueIdInvalidData()
        {
            // Test if Valid method catches invalid VenueId
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string venueId = "one hundred";  // Invalid data type
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void CategoryMinLessOne()
        {
            // Test if Valid method catches too short Category
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string category = "";  // This should trigger an error 
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void CategoryMin()
        {
            // Test if Valid method allows minimum Category
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string category = "a"; // This should be OK
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CategoryMinPlusOne()
        {
            // Test if Valid method allows slightly longer than minimum Category
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string category = "aa"; // This should be OK
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CategoryMid()
        {
            // Test if Valid method allows mid length Category
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string category = "aaaa"; // Mid length
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CategoryMaxLessOne()
        {
            // Test if Valid method allows maximum Category minus one character
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string category = new string('a', 29); // One less than the maximum allowed length (30)
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CategoryMax()
        {
            // Test if Valid method allows maximum Category
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string category = new string('a', 30); // Maximum allowed length (30)
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CategoryMaxPlusOne()
        {
            // Test if Valid method catches too long Category
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string category = new string('a', 31); // One more than the maximum allowed length (30)
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void CategoryExtremeMax()
        {
            // Test if Valid method catches extremely long Category
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string category = new string('a', 500); // This should fail
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void CategoryInvalidData()
        {
            // Test if Valid method catches invalid Category
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string category = "12345";  // Invalid data for category
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreNotEqual(Error, "");
        }
    }
}
