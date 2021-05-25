using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ISTPLR_two
{
    public class ParticipantTeamPairs
    {
        [Required]
        public int ParticipantTeamPairsId { get; set; }
        [Required]
        public int ParticipantId { get; set; }
        [Required]
        public int TeamId { get; set; }
        [Required]
        public int RoleId { get; set; }

        public virtual Team Team { get; set; }
        public virtual Participant Participant { get; set; }
        public virtual Role Role { get; set; }

    }
}