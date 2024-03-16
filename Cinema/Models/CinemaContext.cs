using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Cinema.Models
{
    public partial class CinemaContext : DbContext
    {
        public CinemaContext()
        {
        }

        public CinemaContext(DbContextOptions<CinemaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Film> Films { get; set; } = null!;
        public virtual DbSet<Genre> Genres { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<Seat> Seats { get; set; } = null!;
        public virtual DbSet<Show> Shows { get; set; } = null!;
        public virtual DbSet<Slot> Slots { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-ALU23ESG;Database=Cinema;User=sa;Password=55555;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking");

                entity.Property(e => e.BookingId).HasColumnName("bookingId");

                entity.Property(e => e.ShowId).HasColumnName("showId");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Show)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.ShowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_booking_Show");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_booking_user");

                entity.HasMany(d => d.Seats)
                    .WithMany(p => p.Bookings)
                    .UsingEntity<Dictionary<string, object>>(
                        "BookingDetail",
                        l => l.HasOne<Seat>().WithMany().HasForeignKey("SeatId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_booking_detail_Seat"),
                        r => r.HasOne<Booking>().WithMany().HasForeignKey("BookingId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_booking_detail_booking"),
                        j =>
                        {
                            j.HasKey("BookingId", "SeatId").HasName("PK_booking_detail");

                            j.ToTable("BookingDetails");

                            j.IndexerProperty<int>("BookingId").HasColumnName("bookingId");

                            j.IndexerProperty<int>("SeatId").HasColumnName("seatId");
                        });
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.CountryCode)
                    .HasName("PK_Country");

                entity.Property(e => e.CountryCode)
                    .HasMaxLength(3)
                    .IsFixedLength();

                entity.Property(e => e.CountryName).HasMaxLength(50);
            });

            modelBuilder.Entity<Film>(entity =>
            {
                entity.Property(e => e.FilmId).HasColumnName("FilmID");

                entity.Property(e => e.Actor)
                    .HasMaxLength(300)
                    .HasColumnName("actor");

                entity.Property(e => e.Author)
                    .HasMaxLength(100)
                    .HasColumnName("author");

                entity.Property(e => e.CountryCode)
                    .HasMaxLength(3)
                    .IsFixedLength();

                entity.Property(e => e.Description)
                    .HasMaxLength(3000)
                    .HasColumnName("description");

                entity.Property(e => e.GenreId).HasColumnName("GenreID");

                entity.Property(e => e.ImagesSlide)
                    .HasColumnType("ntext")
                    .HasColumnName("images_slide");

                entity.Property(e => e.Img)
                    .HasColumnType("ntext")
                    .HasColumnName("img");

                entity.Property(e => e.Premiere)
                    .HasColumnType("date")
                    .HasColumnName("premiere");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Time).HasColumnName("time");

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.HasOne(d => d.CountryCodeNavigation)
                    .WithMany(p => p.Films)
                    .HasForeignKey(d => d.CountryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Films_Countries");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Films)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Films_Genres");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.Property(e => e.GenreId).HasColumnName("GenreID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Seat>(entity =>
            {
                entity.ToTable("Seat");

                entity.Property(e => e.SeatId).HasColumnName("seatId");

                entity.Property(e => e.SeatName)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("seatName");
            });

            modelBuilder.Entity<Show>(entity =>
            {
                entity.ToTable("Show");

                entity.Property(e => e.ShowId).HasColumnName("showId");

                entity.Property(e => e.FilmId).HasColumnName("filmId");

                entity.Property(e => e.RoomId).HasColumnName("roomId");

                entity.Property(e => e.ShowDate)
                    .HasColumnType("date")
                    .HasColumnName("showDate");

                entity.Property(e => e.SlotId).HasColumnName("slotId");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Film)
                    .WithMany(p => p.Shows)
                    .HasForeignKey(d => d.FilmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Show_Films");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Shows)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Show_Rooms");

                entity.HasOne(d => d.Slot)
                    .WithMany(p => p.Shows)
                    .HasForeignKey(d => d.SlotId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Show_Slot");
            });

            modelBuilder.Entity<Slot>(entity =>
            {
                entity.ToTable("Slot");

                entity.Property(e => e.SlotId)
                    .ValueGeneratedNever()
                    .HasColumnName("slotId");

                entity.Property(e => e.Time).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .HasColumnName("address");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(50)
                    .HasColumnName("fullname");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(11)
                    .HasColumnName("phone")
                    .IsFixedLength();

                entity.Property(e => e.Role).HasColumnName("role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
