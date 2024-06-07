using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DEMO_dev.Domain.Entities;

public partial class DemoDevContext : DbContext
{
    public DemoDevContext()
    {
    }

    public DemoDevContext(DbContextOptions<DemoDevContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Artist> Artists { get; set; }

    public virtual DbSet<ArtistDemo> ArtistDemos { get; set; }

    public virtual DbSet<ArtistUser> ArtistUsers { get; set; }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Demo> Demos { get; set; }

    public virtual DbSet<Label> Labels { get; set; }

    public virtual DbSet<LabelDemo> LabelDemos { get; set; }

    public virtual DbSet<LabelUser> LabelUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQL_DEMO; Database=DEMO_dev; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Artist>(entity =>
        {
            entity.ToTable("Artist");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Bio)
                .HasColumnType("text")
                .HasColumnName("bio");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Picture)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("picture");
        });

        modelBuilder.Entity<ArtistDemo>(entity =>
        {
            entity.ToTable("Artist_Demo");

            entity.HasIndex(e => new { e.ArtistId, e.DemoId }, "UQ_Artist_Demo").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ArtistId).HasColumnName("artist_id");
            entity.Property(e => e.DemoId).HasColumnName("demo_id");

            entity.HasOne(d => d.Artist).WithMany(p => p.ArtistDemos)
                .HasForeignKey(d => d.ArtistId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ArtistDemo_Artist");

            entity.HasOne(d => d.Demo).WithMany(p => p.ArtistDemos)
                .HasForeignKey(d => d.DemoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ArtistDemo_Demo");
        });

        modelBuilder.Entity<ArtistUser>(entity =>
        {
            entity.ToTable("Artist_User");

            entity.HasIndex(e => new { e.ArtistId, e.UserId }, "UQ_Artist_User").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ArtistId).HasColumnName("artist_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Artist).WithMany(p => p.ArtistUsers)
                .HasForeignKey(d => d.ArtistId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ArtistUser_Artist");

            entity.HasOne(d => d.User).WithMany(p => p.ArtistUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ArtistUser_User");
        });

        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.ProviderKey).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.Name).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.ToTable("Country");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Initials)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("initials");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Demo>(entity =>
        {
            entity.ToTable("Demo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Filepath)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("filepath");
            entity.Property(e => e.SubmissionDate).HasColumnName("submission_date");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Label>(entity =>
        {
            entity.ToTable("Label");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Bio)
                .HasColumnType("text")
                .HasColumnName("bio");
            entity.Property(e => e.CompanyNumber)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("company_number");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Picture)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("picture");

            entity.HasOne(d => d.Country).WithMany(p => p.Labels)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Label_Country");
        });

        modelBuilder.Entity<LabelDemo>(entity =>
        {
            entity.ToTable("Label_Demo");

            entity.HasIndex(e => new { e.LabelId, e.DemoId }, "UQ_Label_Demo").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DemoId).HasColumnName("demo_id");
            entity.Property(e => e.LabelId).HasColumnName("label_id");

            entity.HasOne(d => d.Demo).WithMany(p => p.LabelDemos)
                .HasForeignKey(d => d.DemoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LabelDemo_Demo");

            entity.HasOne(d => d.Label).WithMany(p => p.LabelDemos)
                .HasForeignKey(d => d.LabelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LabelDemo_Label");
        });

        modelBuilder.Entity<LabelUser>(entity =>
        {
            entity.ToTable("Label_User");

            entity.HasIndex(e => new { e.LabelId, e.UserId }, "UQ_Label_User").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.LabelId).HasColumnName("label_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Label).WithMany(p => p.LabelUsers)
                .HasForeignKey(d => d.LabelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LabelUser_Label");

            entity.HasOne(d => d.User).WithMany(p => p.LabelUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LabelUser_User");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
