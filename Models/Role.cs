using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ISTPLR_two
{
    public class Role
    {
        public Role()
        {
            ParticipantTeamPairs = new List<ParticipantTeamPairs>();
        }
        [Required]
        public int RoleId { get; set; }
        [Required]
        public string Name { get; set; }


        public virtual ICollection<ParticipantTeamPairs> ParticipantTeamPairs { get; set; }
    }
}