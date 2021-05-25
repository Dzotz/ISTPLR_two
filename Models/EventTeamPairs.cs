using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ISTPLR_two
{
    public class EventTeamPairs
    {
        public EventTeamPairs()
        {
        }
        [Required]
        public int EventTeamPairsId { get; set; }
        [Required]
        public int Result { get; set; }
        [Required]
        public int EventId { get; set; }
        [Required]
        public int TeamId { get; set; }
        public virtual Event Event { get; set; }
        public virtual Team Team { get; set; }
    }
}