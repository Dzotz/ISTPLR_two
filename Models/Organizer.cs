using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ISTPLR_two
{
    public class Organizer
    {
        public Organizer()
        {
            Events = new List<Event>();
        }

        [Required]
        public int OrganizerId { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}