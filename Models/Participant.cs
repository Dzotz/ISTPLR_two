using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ISTPLR_two
{
    public class Participant
    {
        public Participant()
        {
            ParticipantTeamPairs = new List<ParticipantTeamPairs>();
        }
        [Required]
        public int ParticipantId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range (0, 120)]
        public int Age { get; set; }


        public virtual ICollection<ParticipantTeamPairs> ParticipantTeamPairs { get; set; }
    }
}