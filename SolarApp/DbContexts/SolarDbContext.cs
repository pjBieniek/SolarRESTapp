using Microsoft.EntityFrameworkCore;
using SolarApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarApp.DbContexts
{
    public class SolarDbContext : DbContext
    {
        public SolarDbContext(DbContextOptions<SolarDbContext> options) :
            base(options)
        { }

        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Competition>()
                .Property(c => c.CompetitionId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Result>()
                .Property(r => r.ResultId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Role>()
                .Property(r => r.RoleId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Session>()
                .Property(s => s.SessionId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Team>()
                .Property(t => t.TeamId).ValueGeneratedOnAdd();
            modelBuilder.Entity<User>()
                .Property(u => u.UserId)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<User>()
                .HasOne<Session>(s => s.Session)
                .WithOne(ad => ad.User)
                .HasForeignKey<Session>(ad => ad.UserId);
            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UId, ur.RId });
            modelBuilder.Entity<UserRole>()
                .HasOne<User>(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UId);
            modelBuilder.Entity<UserRole>()
                .HasOne<Role>(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RId);

            modelBuilder.Entity<Competition>()
                .HasData(
                new Competition
                {
                    CompetitionId = 1,
                    CompetitionTitle = "TestTitle",
                    CompetitionDescription = "this is a competition description",
                    CompetitionUrlAddress = "https://box.example.org/",
                    CompetitionDate = new DateTime(2010, 9, 1)
                },
                new Competition
                {
                    CompetitionId = 2,
                    CompetitionTitle = "TestTitle2",
                    CompetitionDescription = "this is a competition description2",
                    CompetitionUrlAddress = "https://box.example2.org/",
                    CompetitionDate = new DateTime(2012, 9, 1)
                });

            modelBuilder.Entity<Team>()
                .HasData(
                new Team
                {
                    TeamId = 1,
                    TeamName = "First team",
                    TeamDescription = "a description"
                });

            modelBuilder.Entity<Result>()
                .HasData(
                new Result
                {
                    ResultId = 1,
                    ResultPosition = 1,
                    CompetitionId = 1,
                    TeamId = 1
                },
                new Result
                {
                    ResultId = 2,
                    ResultPosition = 3,
                    CompetitionId = 2,
                    TeamId = 1
                });
            
            modelBuilder.Entity<Role>()
                .HasData(
                new Role
                {
                    RoleId = 1,
                    RoleTitle = "root"
                },
                new Role
                {
                    RoleId = 2,
                    RoleTitle = "kompozyt"
                },
                new Role
                {
                    RoleId = 3,
                    RoleTitle = "elektryk"
                },
                new Role
                {
                    RoleId = 4,
                    RoleTitle = "marketing"
                },
                new Role
                {
                    RoleId = 5,
                    RoleTitle = "konstrukcja"
                });
            modelBuilder.Entity<User>()
                .HasData(
                new User
                {
                    UserId = 1,
                    UserFullName = "Jan Kowalski",
                    UserEmail = "simple@mail.com",
                    UserPassword = "password"
                });
            modelBuilder.Entity<Session>()
                .HasData(
                new Session
                {
                    Date = new DateTime(2020, 2, 2),
                    UserId = 1,
                    SessionId = 1
                });

            //modelBuilder.Entity<UserRole>()
            //    .HasData(
            //    new UserRole
            //    {
            //        RId = 1,
            //        UId = 1
            //    },
            //    new UserRole
            //    {
            //        RoleId = 3,
            //        UserId = 1
            //    },
            //    new UserRole
            //    {
            //        RoleId = 1,
            //        UserId = 2
            //    });
            base.OnModelCreating(modelBuilder);
        }
    }
}
