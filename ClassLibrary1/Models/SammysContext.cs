using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models;

public partial class SammysContext : DbContext
{
    public SammysContext()
    {
    }

    public SammysContext(DbContextOptions<SammysContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<SystemUser> SystemUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\medaw\\source\\repos\\WebApplication1\\ClassLibrary1\\RoomReservation.mdf;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.CompanyId).HasName("PK__Company__2D971CAC9D6298D0");

            entity.ToTable("Company");

            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.RelatedUserNavigation).WithMany(p => p.Companies)
                .HasForeignKey(d => d.RelatedUser)
                .HasConstraintName("Company_SystemUser_Related");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.ReservationId).HasName("PK__Reservat__B7EE5F2418BDC1C2");

            entity.ToTable("Reservation");

            entity.Property(e => e.Endtime).HasColumnName("ENDTIME");
            entity.Property(e => e.ReservationDate).HasColumnType("datetime");

            entity.HasOne(d => d.Room).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("FK__Reservati__RoomI__403A8C7D");

            entity.HasOne(d => d.User).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Reservati__UserI__412EB0B6");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.RoomId).HasName("PK__Room__328639395B8D96BD");

            entity.ToTable("Room");

            entity.Property(e => e.Location).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.RoomDescription).HasMaxLength(255);

            entity.HasOne(d => d.Company).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK__Room__CompanyId__3C69FB99");

            entity.HasOne(d => d.User).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Room__UserId__3D5E1FD2");
        });

        modelBuilder.Entity<SystemUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__SystemUs__1788CC4C70BC3E2A");

            entity.ToTable("SystemUser");

            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Password).HasMaxLength(255);

            entity.HasOne(d => d.Company).WithMany(p => p.SystemUsers)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("SystemUser_Company_Belongs");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
