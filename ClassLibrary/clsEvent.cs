using System;

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
            // Create an instance of the data connection
            clsDataConnection DB = new clsDataConnection();
            // Add the parameter for the event ID to search for
            DB.AddParameter("@EventID", eventId);
            // Execute the stored procedure to find the event by ID
            DB.Execute("sproc_tblEvent_FilterByEventID");
            // If one record is found (should be at most one)
            if (DB.Count == 1)
            {
                // Copy the data from the database to the properties
                EventId = Convert.ToInt32(DB.DataTable.Rows[0]["EventID"]);
                EventName = Convert.ToString(DB.DataTable.Rows[0]["EventName"]);
                EventDescription = Convert.ToString(DB.DataTable.Rows[0]["EventDescription"]);
                EventDate = Convert.ToDateTime(DB.DataTable.Rows[0]["EventDate"]);
                VenueId = Convert.ToInt32(DB.DataTable.Rows[0]["VenueID"]);
                Category = Convert.ToString(DB.DataTable.Rows[0]["Category"]);
                IsOnline = Convert.ToBoolean(DB.DataTable.Rows[0]["IsOnline"]);
                Active = Convert.ToBoolean(DB.DataTable.Rows[0]["Active"]);
                DateAdded = Convert.ToDateTime(DB.DataTable.Rows[0]["DateAdded"]);
                // Return that everything worked OK
                return true;
            }
            // If no record was found
            else
            {
                // Return false indicating a problem
                return false;
            }
        }

            public string Valid(string eventName, string eventDescription, string eventDate, string venueId, string category)
        {
            string error = "";

            // EventName validation
            if (string.IsNullOrWhiteSpace(eventName))
            {
                error += "The event name may not be blank. ";
            }
            else if (eventName.Length < 1)
            {
                error += "The event name must be at least 1 character long. ";
            }
            else if (eventName.Length > 50)
            {
                error += "The event name must be less than 50 characters. ";
            }
            else if (int.TryParse(eventName, out _))
            {
                error += "The event name cannot be numeric. ";
            }

            // EventDescription validation
            if (string.IsNullOrWhiteSpace(eventDescription))
            {
                error += "The event description may not be blank. ";
            }
            else if (eventDescription.Length < 1)
            {
                error += "The event description must be at least 1 character long. ";
            }
            else if (eventDescription.Length > 200)
            {
                error += "The event description must be less than 200 characters. ";
            }
            else if (int.TryParse(eventDescription, out _))
            {
                error += "The event description cannot be numeric. ";
            }

            // EventDate validation
            DateTime dateTemp;
            if (!DateTime.TryParse(eventDate, out dateTemp))
            {
                error += "The event date is not a valid date. ";
            }
            else if (dateTemp < DateTime.Now.Date)
            {
                error += "The event date cannot be in the past. ";
            }
            else if (dateTemp > DateTime.Now.Date.AddYears(1))
            {
                error += "The event date cannot be more than 1 year in the future. ";
            }

            // VenueId validation
            if (string.IsNullOrWhiteSpace(venueId))
            {
                error += "The venue ID may not be blank. ";
            }
            else if (!int.TryParse(venueId, out int venueIdTemp))
            {
                error += "The venue ID must be a valid number. ";
            }
            else if (venueIdTemp < 1 || venueIdTemp > 99999999)
            {
                error += "The venue ID must be between 1 and 99999999. ";
            }

            // Category validation
            if (string.IsNullOrWhiteSpace(category))
            {
                error += "The category may not be blank. ";
            }
            else if (category.Length < 1)
            {
                error += "The category must be at least 1 character long. ";
            }
            else if (category.Length > 30)
            {
                error += "The category must be less than 30 characters. ";
            }
            else if (int.TryParse(category, out _))
            {
                error += "The category cannot be numeric. ";
            }

            return error;
        }
    }
}
