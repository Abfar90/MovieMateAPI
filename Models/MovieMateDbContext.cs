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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
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
            entity.ToTable("Movie");

            entity.Property(e => e.MovieDetailsId).HasColumnName("MovieDetailsID");
            entity.Property(e => e.Rating).HasColumnType("decimal(4, 2)");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.MovieDetails).WithMany(p => p.Movies)
                .HasForeignKey(d => d.MovieDetailsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Movie_Movie_Details");

            entity.HasOne(d => d.User).WithMany(p => p.Movies)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Movie_User");
        });

        modelBuilder.Entity<MovieDetail>(entity =>
        {
            entity.ToTable("Movie_Details");

            entity.Property(e => e.Id).ValueGeneratedNever();
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
            entity.ToTable("User_Genre");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.GenreId).HasColumnName("genreID");
            entity.Property(e => e.UserId).HasColumnName("userID");

            entity.HasOne(d => d.Genre).WithMany(p => p.UserGenres)
                .HasForeignKey(d => d.GenreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Genre_Genre");

            entity.HasOne(d => d.User).WithMany(p => p.UserGenres)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Genre_User");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
