using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DbContext;

public class ApplicationDbContext
    : IdentityDbContext<
        User, Role, Guid,
        UserClaim, UserRole, UserLogin,
        RoleClaim, UserToken>
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Role> ApplicationRoles { get; set; } = null!;
    public virtual DbSet<RoleClaim> ApplicationRoleClaims { get; set; } = null!;
    public virtual DbSet<RolesSecPortalModuleAccess> RolesSecPortalModuleAccesses { get; set; } = null!;
    public virtual DbSet<User> ApplicationUsers { get; set; } = null!;
    public virtual DbSet<UserClaim> ApplicationUserClaims { get; set; } = null!;
    public virtual DbSet<UserLogin> ApplicationUserLogins { get; set; } = null!;
    public virtual DbSet<UserRole> ApplicationUserRoles { get; set; } = null!;
    public virtual DbSet<UserToken> ApplicationUserTokens { get; set; } = null!;
    public virtual DbSet<SecPortal> SecPortals { get; set; } = null!;
    public virtual DbSet<SecPortalModule> SecPortalModules { get; set; } = null!;
    public virtual DbSet<SecPortalModuleAccess> SecPortalModuleAccesses { get; set; } = null!;
    public virtual DbSet<SecPortalModuleAccessPermission> SecPortalModuleAccessPermissions { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Role>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.Property(e => e.Name).HasMaxLength(256);

            entity.Property(e => e.NormalizedName).HasMaxLength(256);

            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<RoleClaim>(entity =>
        {
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.Role)
                .WithMany(p => p.RoleClaims)
                .HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<RolesSecPortalModuleAccess>(entity =>
        {
            entity.HasKey(e => new { e.RoleId, e.PortalModuleAccessId });

            entity.ToTable("AspNetRolesSecPortalModuleAccess");

            entity.Property(e => e.RowCreatedBy)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.Property(e => e.RowCreatedDateTimeUtc).HasColumnName("RowCreatedDateTimeUTC");

            entity.Property(e => e.RowLastUpdatedBy)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.Property(e => e.RowLastUpdatedDateTimeUtc).HasColumnName("RowLastUpdatedDateTimeUTC");

            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.PortalModuleAccess)
                .WithMany(p => p.RolesSecPortalModuleAccesses)
                .HasForeignKey(d => d.PortalModuleAccessId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AspNetRolesSecPortalModuleAccess_PortalModuleAccess");

            entity.HasOne(d => d.Role)
                .WithMany(p => p.RolesSecPortalModuleAccesses)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AspNetRolesSecPortalModuleAccess_AspNetRoles");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.Property(e => e.Email).HasMaxLength(256);

            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.Property(e => e.UserName).HasMaxLength(256);
        });

        modelBuilder.Entity<UserClaim>(entity =>
        {
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.User)
                .WithMany(p => p.UserClaims)
                .HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<UserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.User)
                .WithMany(p => p.UserLogins)
                .HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.RoleId });

            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.Role)
                .WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.RoleId);

            entity.HasOne(d => d.User)
                .WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<UserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.User)
                .WithMany(p => p.UserTokens)
                .HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<SecPortal>(entity =>
        {
            entity.HasKey(e => e.PortalId);

            entity.ToTable("SecPortal");

            entity.Property(e => e.PortalName).HasMaxLength(300);

            entity.Property(e => e.RowCreatedBy)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.Property(e => e.RowCreatedDateTimeUtc).HasColumnName("RowCreatedDateTimeUTC");

            entity.Property(e => e.RowLastUpdatedBy)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.Property(e => e.RowLastUpdatedDateTimeUtc).HasColumnName("RowLastUpdatedDateTimeUTC");

            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<SecPortalModule>(entity =>
        {
            entity.HasKey(e => e.PortalModuleId);

            entity.ToTable("SecPortalModule");

            entity.Property(e => e.PortalModuleName).HasMaxLength(300);

            entity.Property(e => e.RowCreatedBy)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.Property(e => e.RowCreatedDateTimeUtc).HasColumnName("RowCreatedDateTimeUTC");

            entity.Property(e => e.RowLastUpdatedBy)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.Property(e => e.RowLastUpdatedDateTimeUtc).HasColumnName("RowLastUpdatedDateTimeUTC");

            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.Portal)
                .WithMany(p => p.SecPortalModules)
                .HasForeignKey(d => d.PortalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SecPortalModule_CommonPortal");
        });

        modelBuilder.Entity<SecPortalModuleAccess>(entity =>
        {
            entity.HasKey(e => e.PortalModuleAccessId);

            entity.ToTable("SecPortalModuleAccess");

            entity.Property(e => e.PortalModuleAccessName).HasMaxLength(2000);

            entity.Property(e => e.RowCreatedBy)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.Property(e => e.RowCreatedDateTimeUtc).HasColumnName("RowCreatedDateTimeUTC");

            entity.Property(e => e.RowLastUpdatedBy)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.Property(e => e.RowLastUpdatedDateTimeUtc).HasColumnName("RowLastUpdatedDateTimeUTC");

            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.PortalModule)
                .WithMany(p => p.SecPortalModuleAccesses)
                .HasForeignKey(d => d.PortalModuleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SecPortalModuleAccess_CommonPortalModule");
        });

        modelBuilder.Entity<SecPortalModuleAccessPermission>(entity =>
        {
            entity.HasKey(e => e.PortalModuleAccessPermissionId);

            entity.ToTable("SecPortalModuleAccessPermission");

            entity.Property(e => e.Httpverb)
                .HasMaxLength(500)
                .HasColumnName("HTTPVerb");

            entity.Property(e => e.RoutingPath).HasMaxLength(500);

            entity.Property(e => e.RowCreatedBy)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.Property(e => e.RowCreatedDateTimeUtc).HasColumnName("RowCreatedDateTimeUTC");

            entity.Property(e => e.RowLastUpdatedBy)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.Property(e => e.RowLastUpdatedDateTimeUtc).HasColumnName("RowLastUpdatedDateTimeUTC");

            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.PortalModuleAccess)
                .WithMany(p => p.SecPortalModuleAccessPermissions)
                .HasForeignKey(d => d.PortalModuleAccessId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SecPortalModuleAccessPermission_SecPortalModuleAccess");
        });



    }
}