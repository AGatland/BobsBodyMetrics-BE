using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using bobsbodymetrics.Models;
using Microsoft.AspNetCore.Identity;

namespace bobsbodymetrics.Data;
public class ApplicationDbContext : IdentityDbContext<AppUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
        base(options)
    { }

    // DbSet properties for each model
    public DbSet<Profile> Profiles { get; set; }
    public DbSet<Activity> Activities { get; set; }
    public DbSet<ActivityPB> ActivityPBs { get; set; }
    public DbSet<UserGoal> UserGoals { get; set; }
    public DbSet<Friend> Friends { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);


        List<IdentityRole> roles = new List<IdentityRole>
        {
            new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                Name = "User",
                NormalizedName = "USER"
            },
        };
        builder.Entity<IdentityRole>().HasData(roles);

        // Configure relationships and constraints
        builder.Entity<Profile>()
            .HasKey(p => p.ProfileId);
        builder.Entity<Activity>()
            .HasKey(a => a.ActivityId);
        builder.Entity<ActivityPB>()
            .HasKey(pb => pb.ActivityPBId);
        builder.Entity<UserGoal>()
            .HasKey(ug => ug.UserGoalId);
        builder.Entity<Friend>()
            .HasKey(f => f.FriendId);


        // Configure relationships
        builder.Entity<Profile>()
            .HasOne<AppUser>()
            .WithOne()
            .HasForeignKey<Profile>(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Profile>()
            .HasOne(p => p.User)
            .WithOne()
            .HasForeignKey<Profile>(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Activity>()
            .HasOne<AppUser>()
            .WithMany()
            .HasForeignKey(a => a.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<ActivityPB>()
            .HasOne<AppUser>()
            .WithMany()
            .HasForeignKey(pb => pb.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<UserGoal>()
            .HasOne<AppUser>()
            .WithMany()
            .HasForeignKey(ug => ug.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Friend>()
            .HasOne<AppUser>()
            .WithMany()
            .HasForeignKey(f => f.UserId)
            .OnDelete(DeleteBehavior.Cascade);
            
        builder.Entity<Friend>()
            .HasOne<AppUser>()
            .WithMany()
            .HasForeignKey(f => f.FriendUserId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configure composite unique constraint for ActivityPB to ensure one entry per combination of ActivityType and DistanceType for each user
        builder.Entity<ActivityPB>()
            .HasIndex(pb => new { pb.UserId, pb.ActivityType, pb.DistanceType })
            .IsUnique();
    }
    
}