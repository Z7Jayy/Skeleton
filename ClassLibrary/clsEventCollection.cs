using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ClassLibrary
{
    public class clsEventCollection
    {
        private List<clsEvent> eventList = new List<clsEvent>();
        private clsEvent mThisEvent;

        public List<clsEvent> EventList
        {
            get { return eventList; }
            set { eventList = value; }
        }

        public int Count
        {
            get { return eventList.Count; }
        }

        public clsEvent ThisEvent
        {
            get { return mThisEvent; }
            set { mThisEvent = value; }
        }

        public clsEventCollection()
        {
            FetchAllEvents();
        }

        public int Add()
        {
            // Add a new event to the database
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@EventName", ThisEvent.EventName);
            DB.AddParameter("@EventDescription", ThisEvent.EventDescription);
            DB.AddParameter("@EventDate", ThisEvent.EventDate);
            DB.AddParameter("@VenueId", ThisEvent.VenueId);
            DB.AddParameter("@Category", ThisEvent.Category);
            DB.AddParameter("@IsOnline", ThisEvent.IsOnline);
            DB.AddParameter("@Active", ThisEvent.Active);
            DB.AddParameter("@DateAdded", ThisEvent.DateAdded);

            SqlParameter newEventIdParam = new SqlParameter("@NewEventId", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };

            int result = DB.ExecuteWithOutput("sproc_tblEvent_Insert", newEventIdParam);
            return result;
        }

        public void Update()
        {
            // Update an existing event in the database
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@EventId", ThisEvent.EventId);
            DB.AddParameter("@EventName", ThisEvent.EventName);
            DB.AddParameter("@EventDescription", ThisEvent.EventDescription);
            DB.AddParameter("@EventDate", ThisEvent.EventDate);
            DB.AddParameter("@VenueId", ThisEvent.VenueId);
            DB.AddParameter("@Category", ThisEvent.Category);
            DB.AddParameter("@IsOnline", ThisEvent.IsOnline);
            DB.AddParameter("@Active", ThisEvent.Active);
            DB.AddParameter("@DateAdded", ThisEvent.DateAdded);

            DB.Execute("sproc_tblEvent_Update");
        }

        public bool Find(int eventId)
        {
            // Find an event by ID and populate the properties
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@EventId", eventId);
            DB.Execute("sproc_tblEvent_FilterByEventId");

            if (DB.Count == 1)
            {
                DataRow row = DB.DataTable.Rows[0];
                mThisEvent = new clsEvent
                {
                    EventId = Convert.ToInt32(row["EventId"]),
                    EventName = Convert.ToString(row["EventName"]),
                    EventDescription = Convert.ToString(row["EventDescription"]),
                    EventDate = Convert.ToDateTime(row["EventDate"]),
                    VenueId = Convert.ToInt32(row["VenueId"]),
                    Category = Convert.ToString(row["Category"]),
                    IsOnline = Convert.ToBoolean(row["IsOnline"]),
                    Active = Convert.ToBoolean(row["Active"]),
                    DateAdded = Convert.ToDateTime(row["DateAdded"])
                };
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(int eventId)
        {
            // Delete an event by ID
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@EventId", eventId);
            return DB.Execute("sproc_tblEvent_Delete") == 1;
        }

        public void FilterByEventName(string eventName)
        {
            // Filter the event list by event name
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@EventName", eventName);
            DB.Execute("sproc_tblEvent_FilterByEventName");

            eventList.Clear();
            for (int i = 0; i < DB.Count; i++)
            {
                DataRow row = DB.DataTable.Rows[i];
                clsEvent AnEvent = new clsEvent
                {
                    EventId = Convert.ToInt32(row["EventId"]),
                    EventName = Convert.ToString(row["EventName"]),
                    EventDescription = Convert.ToString(row["EventDescription"]),
                    EventDate = Convert.ToDateTime(row["EventDate"]),
                    VenueId = Convert.ToInt32(row["VenueId"]),
                    Category = Convert.ToString(row["Category"]),
                    IsOnline = Convert.ToBoolean(row["IsOnline"]),
                    Active = Convert.ToBoolean(row["Active"]),
                    DateAdded = Convert.ToDateTime(row["DateAdded"])
                };

                eventList.Add(AnEvent);
            }
        }

        private void FetchAllEvents()
        {
            // Fetches all events from the database and populate the event list
            clsDataConnection DB = new clsDataConnection();
            DB.Execute("sproc_tblEvent_SelectAll");

            for (int i = 0; i < DB.Count; i++)
            {
                DataRow row = DB.DataTable.Rows[i];
                clsEvent AnEvent = new clsEvent
                {
                    EventId = Convert.ToInt32(row["EventId"]),
                    EventName = Convert.ToString(row["EventName"]),
                    EventDescription = Convert.ToString(row["EventDescription"]),
                    EventDate = Convert.ToDateTime(row["EventDate"]),
                    VenueId = Convert.ToInt32(row["VenueId"]),
                    Category = Convert.ToString(row["Category"]),
                    IsOnline = Convert.ToBoolean(row["IsOnline"]),
                    Active = Convert.ToBoolean(row["Active"]),
                    DateAdded = Convert.ToDateTime(row["DateAdded"])
                };

                eventList.Add(AnEvent);
            }
        }

        public DataTable StatisticsGroupedByCategory()
        {
            // Fetches event statistics grouped by category
            clsDataConnection DB = new clsDataConnection();
            DB.Execute("sproc_tblEvent_StatisticsGroupedByCategory");
            return DB.DataTable;
        }

        public DataTable StatisticsGroupedByEventDate()
        {
            // Fetches event statistics grouped by event date
            clsDataConnection DB = new clsDataConnection();
            DB.Execute("sproc_tblEvent_StatisticsGroupedByEventDate");
            return DB.DataTable;
        }
    }
}
