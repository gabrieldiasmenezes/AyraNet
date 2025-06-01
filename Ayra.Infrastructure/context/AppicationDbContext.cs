using Microsoft.EntityFrameworkCore;
using Ayra.Domain.Entities;

namespace Ayra.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSets - mapeiam as entidades para as tabelas
        public DbSet<Coordinate> Coordinates { get; set; }
        public DbSet<EmergencyContact> EmergencyContacts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<EmergencyUser> EmergencyUsers { get; set; }
        public DbSet<MapMarker> MapMarkers { get; set; }
        public DbSet<Alert> Alerts { get; set; }
        public DbSet<SafeRoute> SafeRoutes { get; set; }
        public DbSet<SafeLocation> SafeLocations { get; set; }
        public DbSet<SafeTip> SafeTips { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relacionamento 1:N: User → Coordinate
            modelBuilder.Entity<User>()
                .HasOne(u => u.Coordinate)
                .WithMany(c => c.Users)
                .HasForeignKey(u => u.CoordinateId);

            // Relacionamento 1:N: MapMarker → Coordinate
            modelBuilder.Entity<MapMarker>()
                .HasOne(m => m.Coordinate)
                .WithMany()
                .HasForeignKey(m => m.CoordinateId);

            // Relacionamento 1:N: Alert → Coordinate
            modelBuilder.Entity<Alert>()
                .HasOne(a => a.Coordinate)
                .WithMany()
                .HasForeignKey(a => a.CoordinateId);

            // Relacionamento 1:N: Alert → MapMarker
            modelBuilder.Entity<Alert>()
                .HasOne(a => a.MapMarker)
                .WithMany()
                .HasForeignKey(a => a.MapMarkerId);

            // Relacionamento N:M: User ↔ EmergencyContact via EmergencyUser
            modelBuilder.Entity<EmergencyUser>()
                .HasKey(eu => new { eu.EmergencyContactId, eu.UserId });

            modelBuilder.Entity<EmergencyUser>()
                .HasOne(eu => eu.EmergencyContact)
                .WithMany(e => e.EmergencyUsers)
                .HasForeignKey(eu => eu.EmergencyContactId);

            modelBuilder.Entity<EmergencyUser>()
                .HasOne(eu => eu.User)
                .WithMany(u => u.EmergencyUsers)
                .HasForeignKey(eu => eu.UserId);

            // Relacionamento 1:N: Alert → SafeRoute
            modelBuilder.Entity<SafeRoute>()
                .HasOne(sr => sr.Alert)
                .WithMany(a => a.SafeRoutes)
                .HasForeignKey(sr => sr.AlertId);

            // Relacionamento 1:N: Alert → SafeLocation
            modelBuilder.Entity<SafeLocation>()
                .HasOne(sl => sl.Alert)
                .WithMany(a => a.SafeLocations)
                .HasForeignKey(sl => sl.AlertId);

            // Relacionamento 1:N: Alert → SafeTip
            modelBuilder.Entity<SafeTip>()
                .HasOne(st => st.Alert)
                .WithMany(a => a.SafeTips)
                .HasForeignKey(st => st.AlertId);
        }
    }
}