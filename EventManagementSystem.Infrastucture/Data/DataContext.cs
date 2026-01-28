using EventManagementSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManagementSystem.Infrastructure.Data
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Client>? Clients { get; set; }
        public DbSet<Producer>? Producers { get; set; }
        public DbSet<Event>? Events { get; set; }
        public DbSet<Ticket>? Tickets { get; set; }
        public DbSet<EventAttendee>? EventAttendees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>()
                .HasData( 
                   new IdentityRole
                   {
                       Id = "1",
                       Name = "producer",
                       NormalizedName = "PRODUCER",
                       ConcurrencyStamp = "22222222-2222-2222-2222-222222222222"
                   },
                    new IdentityRole
                    {
                        Id = "2",
                        Name = "client",
                        NormalizedName = "CLIENT",
                        ConcurrencyStamp = "33333333-3333-3333-3333-333333333333"
                    
                    }
                );

            modelBuilder.Entity<EventAttendee>()
                .HasKey(eve => new
                {
                    eve.EventId,
                    eve.ClientId,
                });
            modelBuilder.Entity<EventAttendee>()
                .HasOne(c => c.Client)
                .WithMany(eve => eve.EventAttendees)
                .HasForeignKey(c => c.ClientId);
            modelBuilder.Entity<EventAttendee>()
                .HasOne(e => e.Event)
                .WithMany(eve => eve.EventAttendees)
                .HasForeignKey(e => e.EventId)
                 .OnDelete(DeleteBehavior.Cascade); ;

            // Event → Tickets cascade delete
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Event)
                .WithMany(e => e.Tickets)
                .HasForeignKey(t => t.EventId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
