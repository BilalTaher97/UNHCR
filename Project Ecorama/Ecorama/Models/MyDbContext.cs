using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Ecorama.Models;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AboutU> AboutUs { get; set; }

    public virtual DbSet<Announcement> Announcements { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<CourseLesson> CourseLessons { get; set; }

    public virtual DbSet<CourseRegistration> CourseRegistrations { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<Partner> Partners { get; set; }

    public virtual DbSet<SliderItem> SliderItems { get; set; }

    public virtual DbSet<SocialMediaLink> SocialMediaLinks { get; set; }

    public virtual DbSet<TeamMember> TeamMembers { get; set; }

    public virtual DbSet<TrainingProgram> TrainingPrograms { get; set; }

    public virtual DbSet<TrainingProgramRegistration> TrainingProgramRegistrations { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserCourseSubscription> UserCourseSubscriptions { get; set; }

    public virtual DbSet<Workshop> Workshops { get; set; }

    public virtual DbSet<WorkshopRegistration> WorkshopRegistrations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-PPIRG99;Database=EcoramaDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AboutU>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AboutUs__3214EC07F3EAE621");

            entity.Property(e => e.ImagePath).HasMaxLength(500);
            entity.Property(e => e.Title).HasMaxLength(200);
        });

        modelBuilder.Entity<Announcement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Announce__3214EC071C1862E8");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ImageUrl).HasMaxLength(255);
            entity.Property(e => e.Title).HasMaxLength(200);
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Courses__3214EC07D7A9E841");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ImageUrl).HasMaxLength(255);
            entity.Property(e => e.PdfUrl).HasMaxLength(255);
            entity.Property(e => e.Title).HasMaxLength(200);
        });

        modelBuilder.Entity<CourseLesson>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CourseLe__3214EC077A3B7A1D");

            entity.Property(e => e.ImageUrl).HasMaxLength(255);
            entity.Property(e => e.Title).HasMaxLength(200);

            entity.HasOne(d => d.Course).WithMany(p => p.CourseLessons)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__CourseLes__Cours__5535A963");
        });

        modelBuilder.Entity<CourseRegistration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CourseRe__3214EC07C73494A0");

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(200);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.RegisteredAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Course).WithMany(p => p.CourseRegistrations)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__CourseReg__Cours__5070F446");

            entity.HasOne(d => d.User).WithMany(p => p.CourseRegistrations)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__CourseReg__UserI__5165187F");
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__News__3214EC072D939A10");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ImageUrl).HasMaxLength(255);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Title).HasMaxLength(200);
        });

        modelBuilder.Entity<Partner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Partners__3214EC071189877C");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<SliderItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SliderIt__3214EC07CC2C2AD6");

            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.ImageFilePath).HasMaxLength(500);
            entity.Property(e => e.ImageUrl).HasMaxLength(255);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Title).HasMaxLength(100);
        });

        modelBuilder.Entity<SocialMediaLink>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SocialMe__3214EC074CF9BF29");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IconClass).HasMaxLength(100);
            entity.Property(e => e.IconColor).HasMaxLength(7);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Url).HasMaxLength(500);
        });

        modelBuilder.Entity<TeamMember>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TeamMemb__3214EC077448E8E6");

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.GitHubLink).HasMaxLength(255);
            entity.Property(e => e.ImageUrl).HasMaxLength(255);
            entity.Property(e => e.LinkedInLink).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Role).HasMaxLength(100);
        });

        modelBuilder.Entity<TrainingProgram>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Training__3214EC07300996E8");

            entity.Property(e => e.ImageUrl).HasMaxLength(255);
            entity.Property(e => e.Title).HasMaxLength(200);
        });

        modelBuilder.Entity<TrainingProgramRegistration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Training__3214EC07ADA07499");

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.ExperienceLevel).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(200);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.RegisteredAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.TrainingProgram).WithMany(p => p.TrainingProgramRegistrations)
                .HasForeignKey(d => d.TrainingProgramId)
                .HasConstraintName("FK__TrainingP__Train__48CFD27E");

            entity.HasOne(d => d.User).WithMany(p => p.TrainingProgramRegistrations)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__TrainingP__UserI__49C3F6B7");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC075F559E68");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D105347CFC4753").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .HasDefaultValue("User");
        });

        modelBuilder.Entity<UserCourseSubscription>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserCour__3214EC07880565B5");

            entity.Property(e => e.SubscribedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Course).WithMany(p => p.UserCourseSubscriptions)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__UserCours__Cours__6383C8BA");

            entity.HasOne(d => d.TrainingProgram).WithMany(p => p.UserCourseSubscriptions)
                .HasForeignKey(d => d.TrainingProgramId)
                .HasConstraintName("FK__UserCours__Train__6477ECF3");

            entity.HasOne(d => d.User).WithMany(p => p.UserCourseSubscriptions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__UserCours__UserI__628FA481");

            entity.HasOne(d => d.Workshop).WithMany(p => p.UserCourseSubscriptions)
                .HasForeignKey(d => d.WorkshopId)
                .HasConstraintName("FK__UserCours__Works__656C112C");
        });

        modelBuilder.Entity<Workshop>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Workshop__3214EC07FE1A4666");

            entity.Property(e => e.Title).HasMaxLength(200);
        });

        modelBuilder.Entity<WorkshopRegistration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Workshop__3214EC075C75C03A");

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(200);
            entity.Property(e => e.Organization).HasMaxLength(200);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.RegisteredAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.User).WithMany(p => p.WorkshopRegistrations)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__WorkshopR__UserI__4316F928");

            entity.HasOne(d => d.Workshop).WithMany(p => p.WorkshopRegistrations)
                .HasForeignKey(d => d.WorkshopId)
                .HasConstraintName("FK__WorkshopR__Works__4222D4EF");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
