using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class clsEventCollection
    {
        // Private data member for the list
        private List<clsEvent> eventList = new List<clsEvent>();

        // Public property for the event list
        public List<clsEvent> EventList
        {
            get { return eventList; }
            set { eventList = value; }
        }

        // Public property for the count of events
        public int Count
        {
            get { return eventList.Count; }
        }

        // Public property for the current event
        public clsEvent ThisEvent { get; set; }

        // Constructor for the class
        public clsEventCollection()
        {
            // Populate the list with data from the database
            FetchAllEvents();
        }

        // Add method to add a new event
        public void Add()
        {
            eventList.Add(ThisEvent);
        }

        // Update method to update an existing event
        public void Update()
        {
            // Find the existing event in the list and update it
            foreach (var ev in eventList)
            {
                if (ev.EventId == ThisEvent.EventId)
                {
                    ev.EventName = ThisEvent.EventName;
                    ev.EventDescription = ThisEvent.EventDescription;
                    ev.EventDate = ThisEvent.EventDate;
                    ev.VenueId = ThisEvent.VenueId;
                    ev.Category = ThisEvent.Category;
                    ev.IsOnline = ThisEvent.IsOnline;
                    ev.Active = ThisEvent.Active;
                    ev.DateAdded = ThisEvent.DateAdded;
                    break;
                }
            }
        }

        // Find method to find an event by its ID
        public bool Find(int eventId)
        {
            ThisEvent = eventList.Find(e => e.EventId == eventId);
            return ThisEvent != null;
        }

        // Method to fetch all events from the database
        private void FetchAllEvents()
        {
            // Create an instance of the data connection
            clsDataConnection DB = new clsDataConnection();
            DB.Execute("sproc_tblEvent_SelectAll"); // Assuming you have a stored procedure to fetch all events

            // Populate the list
            for (int i = 0; i < DB.Count; i++)
            {
                clsEvent AnEvent = new clsEvent();
                try
                {
                    AnEvent.EventId = Convert.ToInt32(DB.DataTable.Rows[i]["EventId"]);
                    AnEvent.EventName = Convert.ToString(DB.DataTable.Rows[i]["EventName"]);
                    AnEvent.EventDescription = Convert.ToString(DB.DataTable.Rows[i]["EventDescription"]);
                    AnEvent.EventDate = Convert.ToDateTime(DB.DataTable.Rows[i]["EventDate"]);
                    AnEvent.VenueId = Convert.ToInt32(DB.DataTable.Rows[i]["VenueId"]);
                    AnEvent.Category = Convert.ToString(DB.DataTable.Rows[i]["Category"]);
                    AnEvent.IsOnline = Convert.ToBoolean(DB.DataTable.Rows[i]["IsOnline"]);
                    AnEvent.Active = Convert.ToBoolean(DB.DataTable.Rows[i]["Active"]);
                    AnEvent.DateAdded = Convert.ToDateTime(DB.DataTable.Rows[i]["DateAdded"]);
                }
                catch (FormatException ex)
                {
                    // Handle format exception
                    Console.WriteLine("Format exception: " + ex.Message);
                    // Set default values or handle accordingly
                    AnEvent.IsOnline = false;
                    AnEvent.Active = false;
                }
                catch (InvalidCastException ex)
                {
                    // Handle invalid cast exception
                    Console.WriteLine("Invalid cast exception: " + ex.Message);
                    // Set default values or handle accordingly
                    AnEvent.IsOnline = false;
                    AnEvent.Active = false;
                }

                eventList.Add(AnEvent);
            }
        }
    }
}
