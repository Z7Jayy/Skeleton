using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class clsEvent
    {
        // Properties
        public int EventId { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public DateTime EventDate { get; set; }
        public int VenueId { get; set; }
        public string Category { get; set; }
        public bool IsOnline { get; set; }
        public bool Active { get; set; } // Add Active property
        public DateTime DateAdded { get; set; } // Add DateAdded property

        // Validation Method
        public string Valid(string eventName, string eventDescription, string eventDate, string venueId, string category)
        {
            //create a string variable to store the error 
            String Error = "";

            //create a temporary variable to store the date values 
            DateTime DateTemp;

            //if the EventName is blank
            if (string.IsNullOrWhiteSpace(eventName))
            {
                //record the error 
                Error = Error + "The event name may not be blank : ";
            }

            //if the EventDescription is blank
            if (string.IsNullOrWhiteSpace(eventDescription))
            {
                //record the error 
                Error = Error + "The event description may not be blank : ";
            }

            //if the Category is blank
            if (string.IsNullOrWhiteSpace(category))
            {
                //record the error 
                Error = Error + "The category may not be blank : ";
            }

            //if the VenueId is blank or not a number
            int venueIdParsed;
            if (string.IsNullOrWhiteSpace(venueId) || !int.TryParse(venueId, out venueIdParsed))
            {
                //record the error 
                Error = Error + "The venue ID must be a valid number : ";
            }

            try
            {
                //copy the eventDate value to the DateTemp variable
                DateTemp = Convert.ToDateTime(eventDate);

                // if the event date is in the past
                if (DateTemp < DateTime.Now.Date)
                {
                    // record the error
                    Error = Error + "The event date cannot be in the past : ";
                }

                // if the event date is too far in the future (e.g., more than 2 years from now)
                if (DateTemp > DateTime.Now.Date.AddYears(2))
                {
                    // record the error
                    Error = Error + "The event date cannot be more than 2 years in the future : ";
                }
            }
            catch
            {
                // record the error 
                Error = Error + "The event date was not a valid date : ";
            }

            //return any error messages
            return Error;
        }
     

        // Find Method
        public bool Find(int eventId)
        {
            // Create an instance of the data connection
            clsDataConnection DB = new clsDataConnection();

            // Add the parameter for the EventId to search for 
            DB.AddParameter("@EventId", eventId);

            // Execute the stored procedure to filter records by EventId
            DB.Execute("sproc_tblEvent_FilterByEventId");

            // If one record is found (there should be either one or zero)
            if (DB.Count == 1)
            {
                // Copy the data from the database to the private data members 
                EventId = Convert.ToInt32(DB.DataTable.Rows[0]["EventId"]);
                EventName = Convert.ToString(DB.DataTable.Rows[0]["EventName"]);
                EventDescription = Convert.ToString(DB.DataTable.Rows[0]["EventDescription"]);
                EventDate = Convert.ToDateTime(DB.DataTable.Rows[0]["EventDate"]);
                VenueId = Convert.ToInt32(DB.DataTable.Rows[0]["VenueId"]);
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
                // Return false indicating there is a problem 
                return false;
            }
        }

        
    }
}