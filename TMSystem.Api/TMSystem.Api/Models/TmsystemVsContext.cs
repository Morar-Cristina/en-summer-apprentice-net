using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TMSystem.Api.Models;

public partial class TmsystemVsContext : DbContext
{
    public TmsystemVsContext()
    {
    }

    public TmsystemVsContext(DbContextOptions<TmsystemVsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventType> EventTypes { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<TicketCategory> TicketCategories { get; set; }

    public virtual DbSet<Venue> Venues { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-UEFCLH4\\SQLEXPRESS;Initial Catalog=TMSystemVS;Integrated Security=True;TrustServerCertificate=True;encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__B611CB7DD402EB59");

            entity.ToTable("Customer");

            entity.HasIndex(e => e.CustomerEmail, "UQ__Customer__FFE82D72038243B4").IsUnique();

            entity.Property(e => e.CustomerId).HasColumnName("customerId");
            entity.Property(e => e.CustomerEmail)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("customerEmail");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("customerName");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.ToTable("Event");

            entity.Property(e => e.EventId).HasColumnName("eventId");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("endDate");
            entity.Property(e => e.EventDescription)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("eventDescription");
            entity.Property(e => e.EventName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("eventName");
            entity.Property(e => e.EventTypeId).HasColumnName("eventTypeId");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("startDate");
            entity.Property(e => e.VenueId).HasColumnName("venueId");

            entity.HasOne(d => d.EventType).WithMany(p => p.Events)
                .HasForeignKey(d => d.EventTypeId)
                .HasConstraintName("FK_EventType");

            entity.HasOne(d => d.Venue).WithMany(p => p.Events)
                .HasForeignKey(d => d.VenueId)
                .HasConstraintName("FK_Venue");
        });

        modelBuilder.Entity<EventType>(entity =>
        {
            entity.HasKey(e => e.EventTypeId).HasName("PK__EventTyp__04ACC4BD432350E0");

            entity.ToTable("EventType");

            entity.HasIndex(e => e.EventTypeName, "UQ__EventTyp__F1C27EB17B769D3F").IsUnique();

            entity.Property(e => e.EventTypeId).HasColumnName("eventTypeId");
            entity.Property(e => e.EventTypeName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("eventTypeName");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__0809335D38B94DF9");

            entity.Property(e => e.OrderId).HasColumnName("orderId");
            entity.Property(e => e.CustomerId).HasColumnName("customerId");
            entity.Property(e => e.NumberOfTickets).HasColumnName("numberOfTickets");
            entity.Property(e => e.OrderedAt)
                .HasColumnType("datetime")
                .HasColumnName("orderedAt");
            entity.Property(e => e.TicketCategoryId).HasColumnName("ticket_category_id");
            entity.Property(e => e.TotalPrice)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("totalPrice");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_Customer");

            entity.HasOne(d => d.TicketCategory).WithMany(p => p.Orders)
                .HasForeignKey(d => d.TicketCategoryId)
                .HasConstraintName("FK_TicketCategory");
        });

        modelBuilder.Entity<TicketCategory>(entity =>
        {
            entity.HasKey(e => e.TicketCategoryId).HasName("PK__TicketCa__56F2E61A2B8D8FB8");

            entity.ToTable("TicketCategory");

            entity.Property(e => e.TicketCategoryId).HasColumnName("ticketCategoryId");
            entity.Property(e => e.EventId).HasColumnName("eventId");
            entity.Property(e => e.TicketDescription)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ticketDescription");
            entity.Property(e => e.TicketPrice)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("ticketPrice");

            entity.HasOne(d => d.Event).WithMany(p => p.TicketCategories)
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("FK_Event");
        });

        modelBuilder.Entity<Venue>(entity =>
        {
            entity.HasKey(e => e.VenueId).HasName("PK__Venue__4DDFB6FF6EAF58A7");

            entity.ToTable("Venue");

            entity.Property(e => e.VenueId).HasColumnName("venueId");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.Location)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("location");
            entity.Property(e => e.Type)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("type");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
