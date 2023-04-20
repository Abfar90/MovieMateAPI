using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MovieMateAPI.Models;

public partial class MovieMateDbContext : DbContext
{
    public MovieMateDbContext()
    {
    }

    public MovieMateDbContext(DbContextOptions<MovieMateDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<MovieDetail> MovieDetails { get; set; }

    public virtual DbSet<MovieGenre> MovieGenres { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserGenre> UserGenres { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=.;Database=MovieMateDB;Trusted_Connection=true;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>(entity =>
        {
            entity.ToTable("Genre");

            entity.Property(e => e.GenreId)
                .ValueGeneratedNever()
                .HasColumnName("genreID");
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Movie");

            entity.Property(e => e.MovieId).HasColumnName("movieID");
            entity.Property(e => e.Rating).HasColumnType("decimal(4, 2)");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.MovieNavigation).WithMany()
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Movie_Movie_Details");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Movie_User");
        });

        modelBuilder.Entity<MovieDetail>(entity =>
        {
            entity.HasKey(e => e.MovieId);

            entity.ToTable("Movie_Details");

            entity.Property(e => e.MovieId)
                .ValueGeneratedNever()
                .HasColumnName("movieID");
            entity.Property(e => e.Release).HasColumnType("date");
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<MovieGenre>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Movie_Genre");

            entity.Property(e => e.GenreId).HasColumnName("genreID");
            entity.Property(e => e.MovieId).HasColumnName("movieID");

            entity.HasOne(d => d.Genre).WithMany()
                .HasForeignKey(d => d.GenreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Movie_Genre_Genre");

            entity.HasOne(d => d.Movie).WithMany()
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Movie_Genre_Movie_Details");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.UserId).HasColumnName("userID");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<UserGenre>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("User_Genre");

            entity.Property(e => e.GenreId).HasColumnName("genreID");
            entity.Property(e => e.UserId).HasColumnName("userID");

            entity.HasOne(d => d.Genre).WithMany()
                .HasForeignKey(d => d.GenreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Genre_Genre");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Genre_User");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
