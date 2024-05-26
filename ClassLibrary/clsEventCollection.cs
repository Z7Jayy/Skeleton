using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class clsEventCollection
    {
        // Collection to store instances of clsEvent
        private List<clsEvent> eventList = new List<clsEvent>();

        // Property to access the collection
        public List<clsEvent> EventList
        {
            get { return eventList; }
            set { eventList = value; }
        }

        // Property to access the current clsEvent object
        public clsEvent ThisEvent { get; set; }

        // Method to add a new clsEvent object to the collection
        public void Add()
        {
            eventList.Add(ThisEvent);
        }

        // Method to update an existing clsEvent object in the collection
        public void Update()
        {
            // Find the existing event in the collection and update its properties
            // Example:
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
                    break;
                }
            }
        }

        // Method to find a clsEvent object by its ID
        public clsEvent Find(int eventId)
        {
            return eventList.Find(e => e.EventId == eventId);
        }
    }
}
