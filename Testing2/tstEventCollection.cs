using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class clsEventCollection
    {
        private List<clsEvent> mEventList = new List<clsEvent>();
        private clsEvent mThisEvent = new clsEvent();

        public clsEventCollection()
        {
            // Fetch all events from the database and populate the EventList
            clsDataConnection DB = new clsDataConnection();
            DB.Execute("sproc_tblEvent_SelectAll");
            PopulateArray(DB);
        }

        public List<clsEvent> EventList
        {
            get { return mEventList; }
            set { mEventList = value; }
        }

        public int Count
        {
            get { return mEventList.Count; }
            set { /* We shall worry about this later */ }
        }

        public clsEvent ThisEvent
        {
            get { return mThisEvent; }
            set { mThisEvent = value; }
        }

        public int Add()
        {
            // Add new event to the database
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@EventName", mThisEvent.EventName);
            DB.AddParameter("@EventDescription", mThisEvent.EventDescription);
            DB.AddParameter("@EventDate", mThisEvent.EventDate);
            DB.AddParameter("@IsOnline", mThisEvent.IsOnline);
            DB.AddParameter("@VenueID", mThisEvent.VenueId);
            DB.AddParameter("@Category", mThisEvent.Category);
            DB.AddParameter("@Active", mThisEvent.Active);
            DB.AddParameter("@DateAdded", mThisEvent.DateAdded);
            return DB.Execute("sproc_tblEvent_Insert");
        }

        public void Update()
        {
            // Update an existing event in the database
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@EventID", mThisEvent.EventId);
            DB.AddParameter("@EventName", mThisEvent.EventName);
            DB.AddParameter("@EventDescription", mThisEvent.EventDescription);
            DB.AddParameter("@EventDate", mThisEvent.EventDate);
            DB.AddParameter("@IsOnline", mThisEvent.IsOnline);
            DB.AddParameter("@VenueID", mThisEvent.VenueId);
            DB.AddParameter("@Category", mThisEvent.Category);
            DB.AddParameter("@Active", mThisEvent.Active);
            DB.AddParameter("@DateAdded", mThisEvent.DateAdded);
            DB.Execute("sproc_tblEvent_Update");
        }

        public void Delete()
        {
            // Delete an event from the database
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@EventID", mThisEvent.EventId);
            DB.Execute("sproc_tblEvent_Delete");
        }

        public bool Find(int EventID)
        {
            // Find a specific event in the database
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@EventID", EventID);
            DB.Execute("sproc_tblEvent_FilterByEventID");

            if (DB.Count == 1)
            {
                mThisEvent.EventId = Convert.ToInt32(DB.DataTable.Rows[0]["EventID"]);
                mThisEvent.EventName = Convert.ToString(DB.DataTable.Rows[0]["EventName"]);
                mThisEvent.EventDescription = Convert.ToString(DB.DataTable.Rows[0]["EventDescription"]);
                mThisEvent.EventDate = Convert.ToDateTime(DB.DataTable.Rows[0]["EventDate"]);
                mThisEvent.IsOnline = Convert.ToBoolean(DB.DataTable.Rows[0]["IsOnline"]);
                mThisEvent.VenueId = Convert.ToInt32(DB.DataTable.Rows[0]["VenueID"]);
                mThisEvent.Category = Convert.ToString(DB.DataTable.Rows[0]["Category"]);
                mThisEvent.Active = Convert.ToBoolean(DB.DataTable.Rows[0]["Active"]);
                mThisEvent.DateAdded = Convert.ToDateTime(DB.DataTable.Rows[0]["DateAdded"]);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void PopulateArray(clsDataConnection DB)
        {
            // Populate the array list based on the data table in the parameter DB
            int Index = 0;
            int RecordCount = DB.Count;
            mEventList = new List<clsEvent>();

            while (Index < RecordCount)
            {
                clsEvent AnEvent = new clsEvent();
                AnEvent.EventId = Convert.ToInt32(DB.DataTable.Rows[Index]["EventID"]);
                AnEvent.EventName = Convert.ToString(DB.DataTable.Rows[Index]["EventName"]);
                AnEvent.EventDescription = Convert.ToString(DB.DataTable.Rows[Index]["EventDescription"]);
                AnEvent.EventDate = Convert.ToDateTime(DB.DataTable.Rows[Index]["EventDate"]);
                AnEvent.IsOnline = Convert.ToBoolean(DB.DataTable.Rows[Index]["IsOnline"]);
                AnEvent.VenueId = Convert.ToInt32(DB.DataTable.Rows[Index]["VenueID"]);
                AnEvent.Category = Convert.ToString(DB.DataTable.Rows[Index]["Category"]);
                AnEvent.Active = Convert.ToBoolean(DB.DataTable.Rows[Index]["Active"]);
                AnEvent.DateAdded = Convert.ToDateTime(DB.DataTable.Rows[Index]["DateAdded"]);
                mEventList.Add(AnEvent);
                Index++;
            }
        }
    }
}
