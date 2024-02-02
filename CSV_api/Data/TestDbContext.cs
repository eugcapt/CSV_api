using System;
using System.Collections.Generic;
using CSV_api.Models;
using Microsoft.EntityFrameworkCore;

namespace CSV_api.Data;

public partial class TestDbContext : DbContext
{
    public TestDbContext()
    {
    }

    public TestDbContext(DbContextOptions<TestDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Models.Task> Tasks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=UAIR18;Initial Catalog=TestDB;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Comment");

            entity.Property(e => e.CommentId).HasColumnName("CommentID");
            entity.Property(e => e.TaskId).HasColumnName("TaskID");

            entity.HasOne(d => d.Task).WithMany()
                .HasForeignKey(d => d.TaskId)
                .HasConstraintName("FK_Comment_Tasks");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.ToTable("Project");

            entity.Property(e => e.ProjectId)
                .ValueGeneratedNever()
                .HasColumnName("ProjectID");
        });

        modelBuilder.Entity<Models.Task>(entity =>
        {
            entity.Property(e => e.TaskId)
                .ValueGeneratedNever()
                .HasColumnName("TaskID");
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
           // entity.Property(e => e.Status).HasConversion<StatusCodes>();

            entity.HasOne(d => d.Project).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK_Tasks_Project");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("UserID");
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

            entity.HasOne(d => d.Project).WithMany(p => p.Users)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK_Users_Project");
        });

       

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
