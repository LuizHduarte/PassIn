using Microsoft.EntityFrameworkCore;
using PassIn.Domain.Entities.Events;
using PassIn.Domain.Entities.Attendees;
using PassIn.Domain.Entities.Checkin;

namespace PassIn.Infrastructure;
public class PassInDbContext : DbContext
{
    public DbSet<Event> Events { get; set; }
    public DbSet<Attendee> Attendees { get; set; }
    public DbSet<CheckIn> CheckIns { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //NEED TO CHANGE THE PATH TO YOURS
        optionsBuilder.UseSqlite("Data Source=D:\\Devs\\CSharp\\PassIn\\PassIn.Infrastructure\\Database\\PassInDb.db");
    }
}
