using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ISTPLR_two
{
    public class Category
    {
        public Category()
        {
            Events = new List<Event>();
        }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Event> Events { get; set; }

    }
}