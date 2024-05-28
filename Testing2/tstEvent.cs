using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Testing2
{
    [TestClass]
    public class tstEvent
    {
        public bool OK { get; private set; }

        // Good test data
        // Create some test data to pass the method
        string eventName = "Music Concert";
        string eventDescription = "An amazing music concert";
        string eventDate = DateTime.Now.ToShortDateString(); // Assuming this is in the format of "MM/dd/yyyy"
        string venueId = "101"; // Assuming VenueId is an integer
        string category = "Music";

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

        // Validation Method Tests 
        [TestMethod]
        public void ValidMethodOK()
        {
            // Creates an instance of the class we want to create 
            clsEvent AnEvent = new clsEvent();
            // String Variable to store any error message
            String Error = "";
            //invoke the method
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            // Test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        // Parameter Tests
        [TestMethod]
        public void EventNameMinLessOne()
        {
            // Create an instance of the class we want to create 
            clsEvent AnEvent = new clsEvent();
            // String variable to store any error message 
            string Error = "";
            // Create some test data to pass to the method 
            string eventName = "";  // This should trigger an error 
            // Invoke the method 
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            // Test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void EventNameMin()
        {
            // Create an instance of the class we want to test
            clsEvent AnEvent = new clsEvent();
            // String variable to store any error message
            string Error = "";
            // Create some test data to pass to the method
            string eventName = "a"; // This should be OK
            // Invoke the method
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            // Test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void EventNameMinPlusOne()
        {
            // Create an instance of the class we want to test
            clsEvent AnEvent = new clsEvent();
            // String variable to store any error message
            string Error = "";
            // Create some test data to pass to the method
            string eventName = "aa"; // This should be OK
            // Invoke the method
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            // Test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void EventNameMaxLessOne()
        {
            // Create an instance of the class we want to test
            clsEvent AnEvent = new clsEvent();
            // String variable to store any error message
            string Error = "";
            // Create some test data to pass to the method
            string eventName = "";
            eventName = eventName.PadRight(49, 'a');
            // Invoke the method
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            // Test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void EventNameMax()
        {
            // Create an instance of the class we want to test
            clsEvent AnEvent = new clsEvent();
            // String variable to store any error message
            string Error = "";
            // Create some test data to pass to the method
            string eventName = "";
            eventName = eventName.PadRight(50, 'a');
            // Invoke the method
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            // Test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void EventNameMid()
        {
            // Create an instance of the class we want to test
            clsEvent AnEvent = new clsEvent();
            // String variable to store any error message
            string Error = "";
            // Create some test data to pass to the method
            string eventName = "Event Name"; // Mid length
            // Invoke the method
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            // Test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void EventNameMaxPlusOne()
        {
            // Create an instance of the class we want to test
            clsEvent AnEvent = new clsEvent();
            // String variable to store any error message
            string Error = "";
            // Create some test data to pass to the method
            string eventName = "";
            eventName = eventName.PadRight(51, 'a');
            // This should trigger an error
            // Invoke the method
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            // Test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void EventNameExtremeMax()
        {
            // Create an instance of the class we want to test
            clsEvent AnEvent = new clsEvent();
            // String variable to store any error message
            string Error = "";
            // Create some test data to pass to the method
            string eventName = "";
            eventName = eventName.PadRight(500, 'a'); // This should fail
            // Invoke the method
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            // Test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void EventNameInvalidData()
        {
            // Create an instance of the class we want to create 
            clsEvent AnEvent = new clsEvent();
            // String variable to store any error message 
            string Error = "";
            // Create some test data to pass to the method 
            string eventName = "12345";  // Invalid data type
            // Invoke the method 
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            // Test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void EventDescriptionMinLessOne()
        {
            // Create an instance of the class we want to create 
            clsEvent AnEvent = new clsEvent();
            // String variable to store any error message 
            string Error = "";
            // Create some test data to pass to the method 
            string eventDescription = "";  // This should trigger an error 
            // Invoke the method 
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            // Test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void EventDescriptionMin()
        {
            // Create an instance of the class we want to test
            clsEvent AnEvent = new clsEvent();
            // String variable to store any error message
            string Error = "";
            // Create some test data to pass to the method
            string eventDescription = "a"; // This should be OK
            // Invoke the method
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            // Test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void EventDescriptionMinPlusOne()
        {
            // Create an instance of the class we want to test
            clsEvent AnEvent = new clsEvent();
            // String variable to store any error message
            string Error = "";
            // Create some test data to pass to the method
            string eventDescription = "aa"; // This should be OK
            // Invoke the method
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            // Test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void EventDescriptionMid()
        {
            // Create an instance of the class we want to test
            clsEvent AnEvent = new clsEvent();
            // String variable to store any error message
            string Error = "";
            // Create some test data to pass to the method
            string eventDescription = "".PadRight(100, 'a'); // Mid length
            // Invoke the method
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            // Test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void EventDescriptionMaxLessOne()
        {
            // Create an instance of the class we want to test
            clsEvent AnEvent = new clsEvent();
            // String variable to store any error message
            string Error = "";
            // Create some test data to pass to the method
            string eventDescription = "".PadRight(199, 'a'); // One less than the maximum allowed length (200)
            // Invoke the method
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            // Test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void EventDescriptionMax()
        {
            // Create an instance of the class we want to test
            clsEvent AnEvent = new clsEvent();
            // String variable to store any error message
            string Error = "";
            // Create some test data to pass to the method
            string eventDescription = "".PadRight(200, 'a'); // Maximum allowed length (200)
            // Invoke the method
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            // Test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void EventDescriptionMaxPlusOne()
        {
            // Create an instance of the class we want to test
            clsEvent AnEvent = new clsEvent();
            // String variable to store any error message
            string Error = "";
            // Create some test data to pass to the method
            string eventDescription = "".PadRight(201, 'a'); // One more than the maximum allowed length (200)
            // Invoke the method
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            // Test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void EventDescriptionExtremeMax()
        {
            // Create an instance of the class we want to test
            clsEvent AnEvent = new clsEvent();
            // String variable to store any error message
            string Error = "";
            // Create some test data to pass to the method
            string eventDescription = "".PadRight(500, 'a'); // This should fail
            // Invoke the method
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            // Test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }
        [TestMethod]
        public void EventDescriptionInvalidData()
        {
            // Create an instance of the class we want to create 
            clsEvent AnEvent = new clsEvent();
            // String variable to store any error message 
            string Error = "";
            // Create some test data to pass to the method 
            string eventDescription = "12345";  // Invalid data type
            // Invoke the method 
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            // Test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void EventDateMinLessOne()
        {
            // Create an instance of the class we want to test
            clsEvent AnEvent = new clsEvent();
            // String variable to store any error message
            string Error = "";
            // Create some test data to pass to the method
            string eventDate = DateTime.Now.AddDays(-1).ToShortDateString(); // This should trigger an error (yesterday)
            // Invoke the method
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            // Test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void EventDateMin()
        {
            // Create an instance of the class we want to test
            clsEvent AnEvent = new clsEvent();
            // String variable to store any error message
            string Error = "";
            // Create some test data to pass to the method
            string eventDate = DateTime.Now.ToShortDateString(); // This should be OK (today)
            // Invoke the method
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            // Test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void EventDateMinPlusOne()
        {
            // Create an instance of the class we want to test
            clsEvent AnEvent = new clsEvent();
            // String variable to store any error message
            string Error = "";
            // Create some test data to pass to the method
            string eventDate = DateTime.Now.AddDays(1).ToShortDateString(); // This should be OK (tomorrow)
            // Invoke the method
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            // Test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void EventDateMaxLessOne()
        {
            // Create an instance of the class we want to test
            clsEvent AnEvent = new clsEvent();
            // String variable to store any error message
            string Error = "";
            // Create some test data to pass to the method
            string eventDate = DateTime.Now.AddYears(1).AddDays(-1).ToShortDateString(); // This should be OK (one day less than a year from now)
            // Invoke the method
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            // Test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void EventDateMax()
        {
            // Create an instance of the class we want to test
            clsEvent AnEvent = new clsEvent();
            // String variable to store any error message
            string Error = "";
            // Create some test data to pass to the method
            string eventDate = DateTime.Now.AddYears(1).ToShortDateString(); // This should be OK (one year from now)
            // Invoke the method
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            // Test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void EventDateMaxPlusOne()
        {
            // Create an instance of the class we want to test
            clsEvent AnEvent = new clsEvent();
            // String variable to store any error message
            string Error = "";
            // Create some test data to pass to the method
            string eventDate = DateTime.Now.AddYears(1).AddDays(1).ToShortDateString(); // This should trigger an error (one day more than a year from now)
            // Invoke the method
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            // Test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void EventDateExtremeMin()
        {
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
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string eventDate = "not a date"; // Invalid date string
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void VenueIdMinLessOne()
        {
            // Create an instance of the class we want to test
            clsEvent AnEvent = new clsEvent();
            // String variable to store any error message
            string Error = "";
            // Create some test data to pass to the method
            string venueId = ""; // This should trigger an error (invalid venue ID)
            // Invoke the method
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            // Test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void VenueIdMin()
        {
            // Create an instance of the class we want to test
            clsEvent AnEvent = new clsEvent();
            // String variable to store any error message
            string Error = "";
            // Create some test data to pass to the method
            string venueId = "a"; // This should be OK (minimum valid venue ID)
            // Invoke the method
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            // Test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void VenueIdMinPlusOne()
        {
            // Create an instance of the class we want to test
            clsEvent AnEvent = new clsEvent();
            // String variable to store any error message
            string Error = "";
            // Create some test data to pass to the method
            string venueId = "aa"; // This should be OK (one more than the minimum valid venue ID)
            // Invoke the method
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            // Test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void VenueIdMaxLessOne()
        {
            // Create an instance of the class we want to test
            clsEvent AnEvent = new clsEvent();
            // String variable to store any error message
            string Error = "";
            // Create some test data to pass to the method
            string venueId = "".PadRight(49, 'a'); // One less than the maximum valid venue ID for a string
            // Invoke the method
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            // Test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void VenueIdMax()
        {
            // Create an instance of the class we want to test
            clsEvent AnEvent = new clsEvent();
            // String variable to store any error message
            string Error = "";
            // Create some test data to pass to the method
            string venueId = "".PadRight(50, 'a'); // Maximum valid venue ID for a string
            // Invoke the method
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            // Test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void VenueIdMaxPlusOne()
        {
            // Create an instance of the class we want to test
            clsEvent AnEvent = new clsEvent();
            // String variable to store any error message
            string Error = "";
            // Create some test data to pass to the method
            string venueId = "".PadRight(51, 'a'); // One more than the maximum valid venue ID for a string
            // Invoke the method
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            // Test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void VenueIdExtremeMax()
        {
            // Create an instance of the class we want to test
            clsEvent AnEvent = new clsEvent();
            // String variable to store any error message
            string Error = "";
            // Create some test data to pass to the method
            string venueId = "".PadRight(500, 'a'); // This should fail
            // Invoke the method
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            // Test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }
        [TestMethod]
        public void VenueIdInvalidData()
        {
            // Create an instance of the class we want to create 
            clsEvent AnEvent = new clsEvent();
            // String variable to store any error message 
            string Error = "";
            // Create some test data to pass to the method 
            string venueId = "one hundred";  // Invalid data type
            // Invoke the method 
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            // Test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void CategoryMinLessOne()
        {
            // Create an instance of the class we want to create 
            clsEvent AnEvent = new clsEvent();
            // String variable to store any error message 
            string Error = "";
            // Create some test data to pass to the method 
            string category = "";  // This should trigger an error 
            // Invoke the method 
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            // Test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void CategoryMin()
        {
            // Create an instance of the class we want to test
            clsEvent AnEvent = new clsEvent();
            // String variable to store any error message
            string Error = "";
            // Create some test data to pass to the method
            string category = "a"; // This should be OK
            // Invoke the method
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            // Test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CategoryMinPlusOne()
        {
            // Create an instance of the class we want to test
            clsEvent AnEvent = new clsEvent();
            // String variable to store any error message
            string Error = "";
            // Create some test data to pass to the method
            string category = "aa"; // This should be OK
            // Invoke the method
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            // Test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CategoryMid()
        {
            // Create an instance of the class we want to test
            clsEvent AnEvent = new clsEvent();
            // String variable to store any error message
            string Error = "";
            // Create some test data to pass to the method
            string category = "aaaa"; // Mid length
            // Invoke the method
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            // Test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CategoryMaxLessOne()
        {
            // Create an instance of the class we want to test
            clsEvent AnEvent = new clsEvent();
            // String variable to store any error message
            string Error = "";
            // Create some test data to pass to the method
            string category = new string('a', 29); // One less than the maximum allowed length (30)
            // Invoke the method
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            // Test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CategoryMax()
        {
            // Create an instance of the class we want to test
            clsEvent AnEvent = new clsEvent();
            // String variable to store any error message
            string Error = "";
            // Create some test data to pass to the method
            string category = new string('a', 30); // Maximum allowed length (30)
            // Invoke the method
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            // Test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CategoryMaxPlusOne()
        {
            // Create an instance of the class we want to test
            clsEvent AnEvent = new clsEvent();
            // String variable to store any error message
            string Error = "";
            // Create some test data to pass to the method
            string category = new string('a', 31); // One more than the maximum allowed length (30)
            // Invoke the method
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            // Test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void CategoryExtremeMax()
        {
            // Create an instance of the class we want to test
            clsEvent AnEvent = new clsEvent();
            // String variable to store any error message
            string Error = "";
            // Create some test data to pass to the method
            string category = new string('a', 500); // This should fail
            // Invoke the method
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            // Test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }
        [TestMethod]
        public void CategoryInvalidData()
        {
            // Create an instance of the class we want to create 
            clsEvent AnEvent = new clsEvent();
            // String variable to store any error message 
            string Error = "";
            // Create some test data to pass to the method 
            string category = "12345";  // Invalid data type
            // Invoke the method 
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            // Test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }
    }
}
