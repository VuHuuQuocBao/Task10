using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using Task10_11.EFCore.Configurations;

namespace Task10_11.EFCore.DTOs
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {
        }

        #region DbSet

        public DbSet<Announcement> Announcement { get; set; }
        public DbSet<Document> Document { get; set; }
        public DbSet<DocumentItem> DocumentItem { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<New> New { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<QuickLink> QuickLink { get; set; }

        #endregion DbSet

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AnnouncementConfig());

            modelBuilder.ApplyConfiguration(new NewConfig());

            modelBuilder.ApplyConfiguration(new QuickLinkConfig());

            modelBuilder.ApplyConfiguration(new EventConfig());

            modelBuilder.ApplyConfiguration(new QuestionConfig());

            modelBuilder.ApplyConfiguration(new DocumentConfig());

            modelBuilder.ApplyConfiguration(new DocumentItemConfig());
        }
    }
}