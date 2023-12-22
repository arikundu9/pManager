using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using pMan.DAL.Entities;

namespace pMan.DAL;

public partial class pManDBContext : DbContext
{
    public pManDBContext()
    {
    }

    public pManDBContext(DbContextOptions<pManDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Board> Boards { get; set; }

    public virtual DbSet<Card> Cards { get; set; }

    public virtual DbSet<CardAssignedToUser> CardAssignedToUsers { get; set; }

    public virtual DbSet<List> Lists { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Name=ConnectionStrings:pManDBConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Board>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("board_pk");
        });

        modelBuilder.Entity<Card>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("card_pk");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.CardCreatedByNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("card_fk_created_by");

            entity.HasOne(d => d.ParentList).WithMany(p => p.Cards)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("card_fk_in_list");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.CardUpdatedByNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("card_fk_updated_by");
        });

        modelBuilder.Entity<CardAssignedToUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("card_assigned_to_user_pk");

            entity.HasOne(d => d.Card).WithMany(p => p.CardAssignedToUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("card_assigned_to_user_fk_card");

            entity.HasOne(d => d.User).WithMany(p => p.CardAssignedToUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("card_assigned_to_user_fk_user");
        });

        modelBuilder.Entity<List>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("list_pk");

            entity.HasOne(d => d.ParentBoard).WithMany(p => p.Lists)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("list_fk_board");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_pk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
