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
            modelBuilder.Entity<UserRole>()
                .HasKey(r => new { r.RoleId, r.UserId });
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);

            modelBuilder.Entity<Competition>()
                .HasData(
                new Competition
                {
                    CompetitionTitle = "TestTitle",
                    CompetitionDescription = "this is a competition description",
                    CompetitionUrlAddress = "https://box.example.org/",
                    CompetitionDate = new DateTime(2010, 9, 1)
                },
                new Competition
                {
                    CompetitionTitle = "TestTitle2",
                    CompetitionDescription = "this is a competition description2",
                    CompetitionUrlAddress = "https://box.example2.org/",
                    CompetitionDate = new DateTime(2012, 9, 1)
                });
            
            modelBuilder.Entity<Result>()
                .HasData(
                new Result
                {
                    ResultPosition = 1,
                    CompetitionId = 1
                },
                new Result
                {
                    ResultPosition = 3,
                    CompetitionId = 2
                });
            
            modelBuilder.Entity<Role>()
                .HasData(
                new Role
                {
                    RoleTitle = "root"
                },
                new Role
                {
                    RoleTitle = "kompozyt"
                },
                new Role
                {
                    RoleTitle = "elektryk"
                },
                new Role
                {
                    RoleTitle = "marketing"
                },
                new Role
                {
                    RoleTitle = "konstrukcja"
                });
            modelBuilder.Entity<User>()
                .HasData(
                new User
                {
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
            modelBuilder.Entity<Team>()
                .HasData(
                new Team
                {
                    TeamName = "First team",
                    TeamDescription = "a description"
                });

            modelBuilder.Entity<UserRole>()
                .HasData(
                new UserRole
                {
                    RoleId = 1,
                    UserId = 1
                },
                new UserRole
                {
                    RoleId = 3,
                    UserId = 1
                },
                new UserRole
                {
                    RoleId = 1,
                    UserId = 2
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}
