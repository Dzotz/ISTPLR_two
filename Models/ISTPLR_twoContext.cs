using Microsoft.EntityFrameworkCore;

namespace ISTPLR_two.Models
{
    public class ISTPLR_twoContext : DbContext
    {
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventTeamPairs> EventTeamPairs { get; set; }
        public virtual DbSet<Organizer> Organizers { get; set; }
        public virtual DbSet<Participant> Participants { get; set; }
        public virtual DbSet<ParticipantTeamPairs> ParticipantTeamPairs { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Team> Teams { get; set; }

        public ISTPLR_twoContext(DbContextOptions<ISTPLR_twoContext> options) 
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}