using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ISTPLR_two
{
    public class Team
    {
        public Team()
        {
            EventTeamPairs = new List<EventTeamPairs>();
            ParticipantTeamPairs = new List<ParticipantTeamPairs>();
        }
        [Required]
        public int TeamId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(0, 100)]
        public int Rating { get; set; }

        public virtual ICollection<EventTeamPairs> EventTeamPairs { get; set; }
        public virtual ICollection<ParticipantTeamPairs> ParticipantTeamPairs { get; set; }
    }
}
