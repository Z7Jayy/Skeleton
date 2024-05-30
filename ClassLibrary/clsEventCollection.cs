using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

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
            DB.AddParameter(newEventIdParam);
            DB.Execute("sproc_tblEvent_Insert");

            return Convert.ToInt32(newEventIdParam.Value);
        }

        public void Update()
        {
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
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@EventId", eventId);
            DB.Execute("sproc_tblEvent_FilterByEventId");

            if (DB.Count == 1)
            {
                mThisEvent = new clsEvent
                {
                    EventId = Convert.ToInt32(DB.DataTable.Rows[0]["EventId"]),
                    EventName = Convert.ToString(DB.DataTable.Rows[0]["EventName"]),
                    EventDescription = Convert.ToString(DB.DataTable.Rows[0]["EventDescription"]),
                    EventDate = Convert.ToDateTime(DB.DataTable.Rows[0]["EventDate"]),
                    VenueId = Convert.ToInt32(DB.DataTable.Rows[0]["VenueId"]),
                    Category = Convert.ToString(DB.DataTable.Rows[0]["Category"]),
                    IsOnline = ConvertToBoolean(DB.DataTable.Rows[0]["IsOnline"]),
                    Active = ConvertToBoolean(DB.DataTable.Rows[0]["Active"]),
                    DateAdded = Convert.ToDateTime(DB.DataTable.Rows[0]["DateAdded"])
                };
                return true;
            }
            else
            {
                return false;
            }
        }

        private void FetchAllEvents()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.Execute("sproc_tblEvent_SelectAll");

            for (int i = 0; i < DB.Count; i++)
            {
                clsEvent AnEvent = new clsEvent
                {
                    EventId = Convert.ToInt32(DB.DataTable.Rows[i]["EventId"]),
                    EventName = Convert.ToString(DB.DataTable.Rows[i]["EventName"]),
                    EventDescription = Convert.ToString(DB.DataTable.Rows[i]["EventDescription"]),
                    EventDate = Convert.ToDateTime(DB.DataTable.Rows[i]["EventDate"]),
                    VenueId = Convert.ToInt32(DB.DataTable.Rows[i]["VenueId"]),
                    Category = Convert.ToString(DB.DataTable.Rows[i]["Category"]),
                    IsOnline = ConvertToBoolean(DB.DataTable.Rows[i]["IsOnline"]),
                    Active = ConvertToBoolean(DB.DataTable.Rows[i]["Active"]),
                    DateAdded = Convert.ToDateTime(DB.DataTable.Rows[i]["DateAdded"])
                };

                eventList.Add(AnEvent);
            }
        }

        private bool ConvertToBoolean(object value)
        {
            try
            {
                if (value is bool)
                {
                    return (bool)value;
                }

                // Attempt to handle common Boolean representations
                string stringValue = value.ToString().ToLower();
                if (stringValue == "true" || stringValue == "1")
                {
                    return true;
                }
                if (stringValue == "false" || stringValue == "0")
                {
                    return false;
                }

                throw new FormatException("String was not recognized as a valid Boolean.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error converting value '{value}' to Boolean: {ex.Message}");
                throw;
            }
        }
    }
}
