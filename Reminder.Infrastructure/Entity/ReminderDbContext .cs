using Microsoft.EntityFrameworkCore;
using Reminder.Domain;

namespace Reminder.Infrastructure.Entity
{
    public class ReminderDbContext : DbContext
    {
        public ReminderDbContext(DbContextOptions<ReminderDbContext> options) : base(options)
        {
        }

        public DbSet<Candidat> Candidats { get; set; }
        public DbSet<Coach> Coachs { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Alert> Alerts { get; set; }
        public DbSet<Subject> Subjects { get; set; }
    }
}
