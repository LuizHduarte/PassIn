using Microsoft.EntityFrameworkCore;
using PassIn.Domain.Entities.Events;
using PassIn.Domain.Entities.Attendees;
using PassIn.Domain.Entities.Checkin;
using Microsoft.Extensions.Configuration;
using System;

namespace PassIn.Infra;
public class PassInDbContext : DbContext
{
    public DbSet<Event> Events { get; set; }
    public DbSet<Attendee> Attendees { get; set; }
    public DbSet<CheckIn> CheckIns { get; set; }
    public PassInDbContext(DbContextOptions<PassInDbContext> options) : base(options) { }
}
