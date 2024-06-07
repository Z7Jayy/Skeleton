using System;
using System.Linq;

namespace ClassLibrary
{
    public class clsEvent
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public DateTime EventDate { get; set; }
        public int VenueId { get; set; }
        public string Category { get; set; }
        public bool IsOnline { get; set; }
        public bool Active { get; set; }
        public DateTime DateAdded { get; set; }

        public bool Find(int eventId)
        {
            // Finds an event by ID and populate the properties
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@EventId", eventId);
            DB.Execute("sproc_tblEvent_FilterByEventId");

            if (DB.Count == 1)
            {
                EventId = Convert.ToInt32(DB.DataTable.Rows[0]["EventId"]);
                EventName = Convert.ToString(DB.DataTable.Rows[0]["EventName"]);
                EventDescription = Convert.ToString(DB.DataTable.Rows[0]["EventDescription"]);
                EventDate = Convert.ToDateTime(DB.DataTable.Rows[0]["EventDate"]);
                VenueId = Convert.ToInt32(DB.DataTable.Rows[0]["VenueId"]);
                Category = Convert.ToString(DB.DataTable.Rows[0]["Category"]);
                IsOnline = Convert.ToBoolean(DB.DataTable.Rows[0]["IsOnline"]);
                Active = Convert.ToBoolean(DB.DataTable.Rows[0]["Active"]);
                DateAdded = Convert.ToDateTime(DB.DataTable.Rows[0]["DateAdded"]);
                return true;
            }
            else
            {
                return false;
            }
        }

        public string Valid(string eventName, string eventDescription, string eventDate, string venueId, string category)
        {
            string error = "";

            // Event Name validation
            if (string.IsNullOrEmpty(eventName))
            {
                error += "The event name must not be empty. ";
            }
            else if (eventName.Length > 50)
            {
                error += "The event name must be less than 50 characters. ";
            }
            else if (eventName.All(char.IsDigit))
            {
                error += "The event name must contain non-numeric characters. ";
            }

            // Event Description validation
            if (string.IsNullOrEmpty(eventDescription))
            {
                error += "The event description must not be empty. ";
            }
            else if (eventDescription.Length > 200)
            {
                error += "The event description must be less than 200 characters. ";
            }

            // Event Date validation
            DateTime dateTemp;
            if (!DateTime.TryParse(eventDate, out dateTemp))
            {
                error += "The event date is not a valid date. ";
            }
            else if (dateTemp < DateTime.Now.Date)
            {
                error += "The event date cannot be in the past. ";
            }
            else if (dateTemp > DateTime.Now.AddYears(1).Date)
            {
                error += "The event date cannot be more than one year in the future. ";
            }
            else if (dateTemp < new DateTime(1753, 1, 1) || dateTemp > new DateTime(9999, 12, 31))
            {
                error += "The event date must be between 1/1/1753 and 12/31/9999. ";
            }

            // Venue ID validation
            int venueIdTemp;
            if (!int.TryParse(venueId, out venueIdTemp) || venueIdTemp < 0)
            {
                error += "The venue ID must be a valid non-negative number. ";
            }

            // Category validation
            if (string.IsNullOrEmpty(category))
            {
                error += "The category must not be empty. ";
            }
            else if (category.Length > 30)
            {
                error += "The category must be less than 30 characters. ";
            }

            return error.Trim();
        }
    }
}
