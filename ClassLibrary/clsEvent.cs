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
            if (string.IsNullOrWhiteSpace(eventName))
            {
                return "Event name cannot be empty.";
            }

            // Additional validation logic...

            return "";
        }

        // Find Method
        public bool Find(int eventId)
        {
            // Mock data for testing
            EventId = 1;
            EventName = "Music Concert";
            EventDescription = "An amazing music concert";
            EventDate = Convert.ToDateTime("2024-01-01");
            VenueId = 101;
            Category = "Music";
            IsOnline = false;
            Active = true; // Example value for Active
            DateAdded = DateTime.Now; // Example value for DateAdded

            // Return true to indicate the method completed successfully
            return true;
        }
    }
}