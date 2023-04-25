using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TeacherBookApi.Models;

public partial class TeacherBookContext : DbContext
{
    public TeacherBookContext()
    {
    }

    public TeacherBookContext(DbContextOptions<TeacherBookContext> options)
        : base(options)
    {

    }

    public virtual DbSet<FormTime> FormTimes { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<History> Histories { get; set; }

    public virtual DbSet<Journal> Journals { get; set; }

    public virtual DbSet<Profession> Professions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<TeacherHasSubject> TeacherHasSubjects { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<YearAdd> YearAdds { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=TeacherBook");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FormTime>(entity =>
        {
            entity.ToTable("FormTime");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.IdGroup);

            entity.Property(e => e.NameGroup).HasMaxLength(20);
        });

        modelBuilder.Entity<History>(entity =>
        {
            entity.HasKey(e => e.IdHistory);

            entity.ToTable("History");

            entity.Property(e => e.DateEvent).HasColumnType("date");

            entity.HasOne(d => d.IdStatusNavigation).WithMany(p => p.Histories)
                .HasForeignKey(d => d.IdStatus)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_History_Status");

            entity.HasOne(d => d.IdStudentNavigation).WithMany(p => p.Histories)
                .HasForeignKey(d => d.IdStudent)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_History_Students");

            entity.HasOne(d => d.IdTeacherNavigation).WithMany(p => p.Histories)
                .HasForeignKey(d => d.IdTeacher)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_History_Teachers");
        });

        modelBuilder.Entity<Journal>(entity =>
        {
            entity.HasKey(e => e.IdJournal).HasName("PK_Journal");

            entity.HasOne(d => d.IdGroupNavigation).WithMany(p => p.Journals)
                .HasForeignKey(d => d.IdGroup)
                .HasConstraintName("FK_Journal_Groups");

            entity.HasOne(d => d.IdStudentNavigation).WithMany(p => p.Journals)
                .HasForeignKey(d => d.IdStudent)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Journal_Students");

            entity.HasOne(d => d.IdSubjectNavigation).WithMany(p => p.Journals)
                .HasForeignKey(d => d.IdSubject)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Journal_Subjects");
        });

        modelBuilder.Entity<Profession>(entity =>
        {
            entity.HasKey(e => e.IdProfession);

            entity.Property(e => e.NameProfession).HasMaxLength(100);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRole);

            entity.ToTable("Role");

            entity.Property(e => e.NameRole).HasMaxLength(15);
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.IdStatus);

            entity.ToTable("Status");

            entity.Property(e => e.NameStatus).HasMaxLength(20);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.IdStudent);

            entity.Property(e => e.FiestName).HasMaxLength(20);
            entity.Property(e => e.LastName).HasMaxLength(20);
            entity.Property(e => e.PatronomicName).HasMaxLength(20);

            entity.HasOne(d => d.IdFormTimeNavigation).WithMany(p => p.Students)
                .HasForeignKey(d => d.IdFormTime)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Students_FormTime");

            entity.HasOne(d => d.IdGroupNavigation).WithMany(p => p.Students)
                .HasForeignKey(d => d.IdGroup)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Students_Groups");

            entity.HasOne(d => d.IdProfessionNavigation).WithMany(p => p.Students)
                .HasForeignKey(d => d.IdProfession)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Students_Professions");

            entity.HasOne(d => d.IdYearAddNavigation).WithMany(p => p.Students)
                .HasForeignKey(d => d.IdYearAdd)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Students_YearAdd");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.IdSubject);

            entity.Property(e => e.NameSubject).HasMaxLength(100);
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.IdTeacher);

            entity.Property(e => e.IdTeacher).HasColumnName("idTeacher");
            entity.Property(e => e.TeacherName).HasMaxLength(100);
        });

        modelBuilder.Entity<TeacherHasSubject>(entity =>
        {
            entity.HasKey(e => e.IdTd);

            entity.Property(e => e.IdTd).HasColumnName("idTD");

            entity.HasOne(d => d.IdSubjectNavigation).WithMany(p => p.TeacherHasSubjects)
                .HasForeignKey(d => d.IdSubject)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_TeacherHasSubjects_Subjects");

            entity.HasOne(d => d.IdTeacherNavigation).WithMany(p => p.TeacherHasSubjects)
                .HasForeignKey(d => d.IdTeacher)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_TeacherHasSubjects_Teachers");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser);

            entity.Property(e => e.IdRole).HasDefaultValueSql("((1))");
            entity.Property(e => e.Login)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRole)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Users_Role");
        });

        modelBuilder.Entity<YearAdd>(entity =>
        {
            entity.HasKey(e => e.IdYear);

            entity.ToTable("YearAdd");

            entity.Property(e => e.IdYear).HasColumnName("idYear");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
