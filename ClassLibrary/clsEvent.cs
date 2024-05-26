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

        // Validation Method
        public string Valid(string eventName, string eventDescription, string eventDate, string venueId, string category)
        {
            // Perform validation here
            // Example:
            if (string.IsNullOrWhiteSpace(eventName))
            {
                return "Event name cannot be empty.";
            }

            // Additional validation logic...

            // If all validation passes, return an empty string
            return "";
        }
    }
}