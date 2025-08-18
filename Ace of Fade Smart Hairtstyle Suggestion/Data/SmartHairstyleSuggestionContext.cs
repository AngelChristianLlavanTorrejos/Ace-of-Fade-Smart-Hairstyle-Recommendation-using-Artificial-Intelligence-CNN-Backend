using System;
using System.Collections.Generic;
using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Models;
using Microsoft.EntityFrameworkCore;

namespace Ace_of_Fade_Smart_Hairtstyle_Suggestion.Data;

public partial class SmartHairstyleSuggestionContext : DbContext
{
    public SmartHairstyleSuggestionContext()
    {
    }

    public SmartHairstyleSuggestionContext(DbContextOptions<SmartHairstyleSuggestionContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<AppointmentStatus> AppointmentStatuses { get; set; }

    public virtual DbSet<Barber> Barbers { get; set; }

    public virtual DbSet<BarberReview> BarberReviews { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-NKVKRTR\\SQLEXPRESS;Initial Catalog=SmartHairstyleSuggestion;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Appointm__3214EC07AE8A447F");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.StatusId).HasDefaultValue(3);

            entity.HasOne(d => d.Barber).WithMany(p => p.Appointments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Appointme__Barbe__18EBB532");

            entity.HasOne(d => d.Client).WithMany(p => p.Appointments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Appointme__Clien__17F790F9");

            entity.HasOne(d => d.Status).WithMany(p => p.Appointments).HasConstraintName("FK_Appointments_AppointmentStatus");
        });

        modelBuilder.Entity<AppointmentStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Appointm__3214EC079B4DB310");
        });

        modelBuilder.Entity<Barber>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Barbers__3214EC07F4357DE4");
        });

        modelBuilder.Entity<BarberReview>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BarberRe__3214EC07948BB634");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4CDD14180B");

            entity.Property(e => e.RegistrationDate).HasDefaultValueSql("(getdate())");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
