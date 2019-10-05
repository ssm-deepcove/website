﻿using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Deepcove_Trust_Website.Models;
using System.Threading.Tasks;
using System.Threading;
using Newtonsoft.Json;
using System.Collections.Generic;
using Deepcove_Trust_Website.Helpers;
using Deepcove_Trust_Website.DiscoverDeepCove;

namespace Deepcove_Trust_Website.Data
{
    public class WebsiteDataContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<CmsButton> CmsButtons { get; set; }
        public DbSet<PasswordReset> PasswordResets { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<PageRevision> PageRevisions { get; set; }
        public DbSet<TextComponent> TextComponents { get; set; }
        public DbSet<MediaComponent> MediaComponent { get; set; }
        public DbSet<PageTemplate> PageTemplates { get; set; }
        public DbSet<SystemSettings> SystemSettings { get; set; }
        public DbSet<NotificationChannel> NotificationChannels { get; set; }
        public DbSet<BaseMedia> Media { get; set; }
        public DbSet<ImageMedia> ImageMedia { get; set; }
        public DbSet<AudioMedia> AudioMedia { get; set; }
        public DbSet<GeneralMedia> GeneralMedia { get; set; }

        // ----- Discover Deep Cove DB Sets ----------------

        public DbSet<Config> Config { get; set; }
        
        // Fact-files
        public DbSet<FactFileEntry> FactFileEntries { get; set; }
        public DbSet<FactFileNugget> FactFileNuggets { get; set; }
        public DbSet<FactFileCategory> FactFileCategories { get; set; }
        public DbSet<FactFileEntryImage> FactFileEntryImages { get; set; }

        // Quiz models
        public DbSet<Quiz> Quizzes { get; set; }        
        public DbSet<QuizAnswer> QuizAnswers { get; set; }
        public DbSet<QuizQuestion> QuizQuestions { get; set; }

        // Activity models
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<ActivityImage> ActivityImages { get; set; }


        // --------------------------------------------------


        public WebsiteDataContext(DbContextOptions<WebsiteDataContext> options) : base(options)
        {
            // Temporarily disabled as it seems to prevent database rollbacks.
            // Auto runs migrations
            //Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dburl = Environment.GetEnvironmentVariable("DATABASE_URL");
            if (!string.IsNullOrEmpty(dburl))
            {
                // Use the URL from the docker file
                optionsBuilder.UseSqlServer(dburl);
            }
            else
            {
                // appsettings.json
                base.OnConfiguring(optionsBuilder);
            }
        }


        // Adds timestamps to database record(s)
        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        //Adds timestamps to database record(s)
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AddTimestamps();
            return await base.SaveChangesAsync();
        }

        // Adds timestamps to database record(s)
        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries()
                .Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                var now = DateTime.UtcNow;

                if (entity.State == EntityState.Added)
                {
                    ((BaseEntity)entity.Entity).CreatedAt = now;
                }
                ((BaseEntity)entity.Entity).UpdatedAt = now;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasQueryFilter(f => f.DeletedAt == null);
            modelBuilder.Entity<Page>().HasQueryFilter(f => f.DeletedAt == null);

            // Enum Conversions
            modelBuilder.Entity<Page>().Property(p => p.Section).HasConversion(c => (int)c, c => (Section)c);
            modelBuilder.Entity<Page>().Property(p => p.QuickLink).HasConversion(c => (int)c, c => (QuickLinkSection)c);
            modelBuilder.Entity<CmsButton>().Property(p => p.Align).HasConversion(c => (int)c, c => (Align)c);
            modelBuilder.Entity<CmsButton>().Property(p => p.Color).HasConversion(c => (int)c, c => (Color)c);

            // Discover Deep Cove
            modelBuilder.Entity<Activity>().Property(p => p.ActivityType).HasConversion(c => (int)c, c => (ActivityType)c);

            // End Enum Conversions

            // Conversions
            modelBuilder.Entity<BaseMedia>().Property(p => p.MediaType).HasConversion(c => c.Mime, c => MediaType.FromString(c));
            modelBuilder.Entity<ImageMedia>().Property(p => p.Versions)
                .HasConversion(c => JsonConvert.SerializeObject(c), c => JsonConvert.DeserializeObject<List<ImageVersion>>(c));
            // End conversions

            // Define keys for junction tables
            modelBuilder.Entity<ChannelMembership>()
                .HasKey(e => new { e.AccountId, e.NotificationChannelId });

            modelBuilder.Entity<RevisionTextComponent>()
                .HasKey(e => new { e.PageRevisionId, e.TextComponentId });

            modelBuilder.Entity<RevisionMediaComponent>()
                .HasKey(e => new { e.PageRevisionId, e.MediaComponentId });

            // -- Discover Deep Cove

            modelBuilder.Entity<ActivityImage>()
                .HasKey(e => new { e.ActivityId, e.ImageId });

            modelBuilder.Entity<FactFileEntryImage>()
                .HasKey(e => new { e.FactFileEntryId, e.MediaFileId });

            // ---------------------

            // Place unique constraints onto appropriate properties

            modelBuilder.Entity<PageTemplate>()
                .HasIndex(e => e.Name).IsUnique();

            modelBuilder.Entity<Page>()
                .HasIndex(e => e.Name).IsUnique();

            // -- Configure relationship between QuizQuestion and correct QuizAnswer
            //modelBuilder.Entity<QuizQuestion>()
            //    .HasOne(qq => qq.CorrectAnswer)
            //    .WithOne(qa => qa.QuizQuestion)
            //    .HasForeignKey<QuizAnswer>(qq => qq.QuizQuestionId);

            // -- Configure relationship between activities and media files
            modelBuilder.Entity<Activity>().HasMany(a => a.ActivityImages).WithOne(ai => ai.Activity).HasForeignKey(ai => ai.ActivityId).OnDelete(DeleteBehavior.Restrict);

            // -- Configure relationships between fact file entries and media files
            modelBuilder.Entity<FactFileEntry>().HasMany(ff => ff.FactFileEntryImages).WithOne(ei => ei.FactFileEntry).HasForeignKey(ei => ei.FactFileEntryId).OnDelete(DeleteBehavior.Restrict);            
        }

        /// <summary>
        /// Adds the items in the list to the database, turning IDENTITY_INSERT on
        /// for the insertion. This allows insertion of explicit ID values.
        /// </summary>
        public void AddRangeWithIdentityInsert<T>(IEnumerable<T> items, string tableName)
        {
            string onString = $"SET IDENTITY_INSERT dbo.{tableName} ON";
            string offString = $"SET IDENTITY_INSERT dbo.{tableName} OFF";
            Database.OpenConnection();
            Database.ExecuteSqlCommand(onString);
            foreach(T item in items) Add(item);
            SaveChanges();
            Database.ExecuteSqlCommand(offString);
            Database.CloseConnection();
        }
    }
}
