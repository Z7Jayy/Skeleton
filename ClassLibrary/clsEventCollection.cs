using System;
using System.Collections.Generic;
using System.Data;

namespace ClassLibrary
{
    public class clsEventCollection
    {
        // Private data member for the list
        private List<clsEvent> mEventList = new List<clsEvent>();
        // Private data member ThisEvent
        private clsEvent mThisEvent = new clsEvent();

        // Public property for the event list
        public List<clsEvent> EventList
        {
            get { return mEventList; }
            set { mEventList = value; }
        }

        // Public property for ThisEvent
        public clsEvent ThisEvent
        {
            get { return mThisEvent; }
            set { mThisEvent = value; }
        }

        // Public property for the count of the list
        public int Count
        {
            get { return mEventList.Count; }
            set { /* do nothing */ }
        }

        // Constructor for the class
        public clsEventCollection()
        {
            // Initialize the data connection
            clsDataConnection DB = new clsDataConnection();
            // Execute the stored procedure
            DB.Execute("sproc_tblEvent_SelectAll");
            // Populate the array
            PopulateArray(DB);
        }

        // Method to add a new record
        public void Add()
        {
            // Add a new record to the database based on the values of ThisEvent
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@EventName", ThisEvent.EventName);
            DB.AddParameter("@EventDescription", ThisEvent.EventDescription);
            DB.AddParameter("@EventDate", ThisEvent.EventDate);
            DB.AddParameter("@VenueId", ThisEvent.VenueId);
            DB.AddParameter("@Category", ThisEvent.Category);
            DB.AddParameter("@IsOnline", ThisEvent.IsOnline);
            DB.Execute("sproc_tblEvent_Insert");
        }

        // Method to update an existing record
        public void Update()
        {
            // Update an existing record based on the values of ThisEvent
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@EventId", ThisEvent.EventId);
            DB.AddParameter("@EventName", ThisEvent.EventName);
            DB.AddParameter("@EventDescription", ThisEvent.EventDescription);
            DB.AddParameter("@EventDate", ThisEvent.EventDate);
            DB.AddParameter("@VenueId", ThisEvent.VenueId);
            DB.AddParameter("@Category", ThisEvent.Category);
            DB.AddParameter("@IsOnline", ThisEvent.IsOnline);
            DB.Execute("sproc_tblEvent_Update");
        }

        // Method to find a record by EventId
        public bool Find(int EventId)
        {
            // Find a record in the database based on the EventId
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@EventId", EventId);
            DB.Execute("sproc_tblEvent_FilterByEventId");

            if (DB.Count == 1)
            {
                // Set the private data members to the found data
                mThisEvent.EventId = Convert.ToInt32(DB.DataTable.Rows[0]["EventId"]);
                mThisEvent.EventName = Convert.ToString(DB.DataTable.Rows[0]["EventName"]);
                mThisEvent.EventDescription = Convert.ToString(DB.DataTable.Rows[0]["EventDescription"]);
                mThisEvent.EventDate = Convert.ToDateTime(DB.DataTable.Rows[0]["EventDate"]);
                mThisEvent.VenueId = Convert.ToInt32(DB.DataTable.Rows[0]["VenueId"]);
                mThisEvent.Category = Convert.ToString(DB.DataTable.Rows[0]["Category"]);
                mThisEvent.IsOnline = Convert.ToBoolean(DB.DataTable.Rows[0]["IsOnline"]);
                return true;
            }
            else
            {
                return false;
            }
        }

        // Method to populate the array with data from the database
        private void PopulateArray(clsDataConnection DB)
        {
            int Index = 0;
            int RecordCount = DB.Count;
            mEventList = new List<clsEvent>();

            while (Index < RecordCount)
            {
                clsEvent AnEvent = new clsEvent();
                AnEvent.EventId = Convert.ToInt32(DB.DataTable.Rows[Index]["EventId"]);
                AnEvent.EventName = Convert.ToString(DB.DataTable.Rows[Index]["EventName"]);
                AnEvent.EventDescription = Convert.ToString(DB.DataTable.Rows[Index]["EventDescription"]);
                AnEvent.EventDate = Convert.ToDateTime(DB.DataTable.Rows[Index]["EventDate"]);
                AnEvent.VenueId = Convert.ToInt32(DB.DataTable.Rows[Index]["VenueId"]);
                AnEvent.Category = Convert.ToString(DB.DataTable.Rows[Index]["Category"]);
                AnEvent.IsOnline = Convert.ToBoolean(DB.DataTable.Rows[Index]["IsOnline"]);
                mEventList.Add(AnEvent);
                Index++;
            }
        }
    }
}
