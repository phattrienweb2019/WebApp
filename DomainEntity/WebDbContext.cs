using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using WebApp.Models;

namespace DomainEntity
{
    public class WebDbContext:DbContext
    {
        public WebDbContext()
            : base("WebDbContext")
        {
        }

        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Function> Functions { get; set; }
        public virtual DbSet<Level> Levels { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>()
                .HasMany(e => e.Questions)
                .WithMany(e => e.Answers)
                .Map(m => m.ToTable("QuestionAnswer").MapLeftKey("AnswerId").MapRightKey("QuestionId"));

            modelBuilder.Entity<Function>()
                .HasMany(e => e.Roles)
                .WithMany(e => e.Functions)
                .Map(m => m.ToTable("RoleFuntion").MapLeftKey("FuncId").MapRightKey("RoleId"));

            modelBuilder.Entity<Level>()
                .HasMany(e => e.Questions)
                .WithRequired(e => e.Level)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Log>()
                .Property(e => e.IP)
                .IsUnicode(false);

            modelBuilder.Entity<Question>()
                .HasMany(e => e.Tests)
                .WithMany(e => e.Questions)
                .Map(m => m.ToTable("QuestionTest").MapLeftKey("QuestionId").MapRightKey("TestId"));

            modelBuilder.Entity<Role>()
                .HasOptional(e => e.User)
                .WithRequired(e => e.Role);

            modelBuilder.Entity<Test>()
                .HasMany(e => e.Users)
                .WithMany(e => e.Tests)
                .Map(m => m.ToTable("UserTest").MapLeftKey("TestId").MapRightKey("UserId"));

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);
        }
    }
}
