using Microsoft.EntityFrameworkCore;
using PassIn.Infrastructure.Entities;
using static System.Net.Mime.MediaTypeNames;

namespace PassIn.Infrastructure;
public class PassInDbContext : DbContext
{
    public DbSet<Event> Events { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //NEED TO CHANGE THE PATH TO YOURS
        optionsBuilder.UseSqlite("Data Source=D:\\Devs\\CSharp\\PassIn\\PassIn.Infrastructure\\Database\\PassInDb.db");
    }
}
