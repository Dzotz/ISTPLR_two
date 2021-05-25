using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ISTPLR_two
{
    public class Event
    {
        public Event()
        {
            EventTeamPairs = new List<EventTeamPairs>();
        }
        [Required]
        public int EventId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public string Description { get; set; }

        public int CategoryId { get; set; }
        public int OrganizerId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Organizer Organizer { get; set; }
        public virtual ICollection<EventTeamPairs> EventTeamPairs { get; set; }

    }
}