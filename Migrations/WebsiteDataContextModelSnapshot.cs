﻿// <auto-generated />
using System;
using Deepcove_Trust_Website.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Deepcove_Trust_Website.Migrations
{
    [DbContext(typeof(WebsiteDataContext))]
    partial class WebsiteDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Deepcove_Trust_Website.DiscoverDeepCove.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<int>("ActivityType");

                    b.Property<double>("CoordX");

                    b.Property<double>("CoordY");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("Description");

                    b.Property<int?>("FactFileId");

                    b.Property<int?>("ImageId");

                    b.Property<string>("QrCode");

                    b.Property<string>("Task");

                    b.Property<string>("Title");

                    b.Property<int>("TrackId");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("FactFileId");

                    b.HasIndex("ImageId");

                    b.HasIndex("TrackId");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("Deepcove_Trust_Website.DiscoverDeepCove.ActivityImage", b =>
                {
                    b.Property<int>("ActivityId");

                    b.Property<int>("ImageId");

                    b.HasKey("ActivityId", "ImageId");

                    b.HasIndex("ImageId");

                    b.ToTable("ActivityImages");
                });

            modelBuilder.Entity("Deepcove_Trust_Website.DiscoverDeepCove.Config", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("MasterUnlockCode");

                    b.HasKey("Id");

                    b.ToTable("Config");
                });

            modelBuilder.Entity("Deepcove_Trust_Website.DiscoverDeepCove.FactFileCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("FactFileCategories");
                });

            modelBuilder.Entity("Deepcove_Trust_Website.DiscoverDeepCove.FactFileEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("AltName");

                    b.Property<string>("BodyText");

                    b.Property<int>("CategoryId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<int?>("ListenAudioId");

                    b.Property<int>("MainImageId");

                    b.Property<string>("PrimaryName");

                    b.Property<int?>("PronounceAudioId");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ListenAudioId");

                    b.HasIndex("MainImageId");

                    b.HasIndex("PronounceAudioId");

                    b.ToTable("FactFileEntries");
                });

            modelBuilder.Entity("Deepcove_Trust_Website.DiscoverDeepCove.FactFileEntryImage", b =>
                {
                    b.Property<int>("FactFileEntryId");

                    b.Property<int>("MediaFileId");

                    b.HasKey("FactFileEntryId", "MediaFileId");

                    b.HasIndex("MediaFileId");

                    b.ToTable("FactFileEntryImages");
                });

            modelBuilder.Entity("Deepcove_Trust_Website.DiscoverDeepCove.FactFileNugget", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FactFileEntryId");

                    b.Property<int?>("ImageId");

                    b.Property<string>("Name");

                    b.Property<int>("OrderIndex");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("FactFileEntryId");

                    b.HasIndex("ImageId");

                    b.ToTable("FactFileNuggets");
                });

            modelBuilder.Entity("Deepcove_Trust_Website.DiscoverDeepCove.Quiz", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<int>("ImageId");

                    b.Property<string>("Title");

                    b.Property<string>("UnlockCode");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.ToTable("Quizzes");
                });

            modelBuilder.Entity("Deepcove_Trust_Website.DiscoverDeepCove.QuizAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ImageId");

                    b.Property<int>("QuizQuestionId");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.HasIndex("QuizQuestionId");

                    b.ToTable("QuizAnswers");
                });

            modelBuilder.Entity("Deepcove_Trust_Website.DiscoverDeepCove.QuizQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AudioId");

                    b.Property<int?>("CorrectAnswerId");

                    b.Property<int?>("ImageId");

                    b.Property<int>("QuizId");

                    b.Property<string>("Text");

                    b.Property<int?>("TrueFalseAnswer");

                    b.HasKey("Id");

                    b.HasIndex("AudioId");

                    b.HasIndex("CorrectAnswerId")
                        .IsUnique();

                    b.HasIndex("ImageId");

                    b.HasIndex("QuizId");

                    b.ToTable("QuizQuestions");
                });

            modelBuilder.Entity("Deepcove_Trust_Website.DiscoverDeepCove.Track", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Tracks");
                });

            modelBuilder.Entity("Deepcove_Trust_Website.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<bool>("ForcePasswordReset");

                    b.Property<DateTime?>("LastLogin");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("PhoneNumber");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Deepcove_Trust_Website.Models.BaseMedia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("FilePath");

                    b.Property<bool>("IsPublic");

                    b.Property<string>("MediaType");

                    b.Property<string>("Name");

                    b.Property<bool>("ShowCopyright");

                    b.Property<long>("Size");

                    b.Property<string>("Source");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("Media");

                    b.HasDiscriminator<string>("Discriminator").HasValue("BaseMedia");
                });

            modelBuilder.Entity("Deepcove_Trust_Website.Models.ChannelMembership", b =>
                {
                    b.Property<int>("AccountId");

                    b.Property<int>("NotificationChannelId");

                    b.HasKey("AccountId", "NotificationChannelId");

                    b.HasIndex("NotificationChannelId");

                    b.ToTable("ChannelMembership");
                });

            modelBuilder.Entity("Deepcove_Trust_Website.Models.CmsButton", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Align");

                    b.Property<int>("Color");

                    b.Property<string>("Href")
                        .IsRequired();

                    b.Property<string>("Text")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("CmsButtons");
                });

            modelBuilder.Entity("Deepcove_Trust_Website.Models.MediaComponent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ImageMediaId");

                    b.Property<int>("SlotNo");

                    b.HasKey("Id");

                    b.HasIndex("ImageMediaId");

                    b.ToTable("MediaComponent");
                });

            modelBuilder.Entity("Deepcove_Trust_Website.Models.NavItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("OrderIndex");

                    b.Property<int?>("PageId");

                    b.Property<int>("Section");

                    b.Property<string>("Text");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("PageId");

                    b.ToTable("NavItems");
                });

            modelBuilder.Entity("Deepcove_Trust_Website.Models.NavItemPage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("NavItemId");

                    b.Property<int>("OrderIndex");

                    b.Property<int?>("PageId");

                    b.Property<string>("Text");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("NavItemId");

                    b.HasIndex("PageId");

                    b.ToTable("NavItemPages");
                });

            modelBuilder.Entity("Deepcove_Trust_Website.Models.Notice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<int?>("ImageId");

                    b.Property<string>("LongDesc");

                    b.Property<int>("Noticeboard");

                    b.Property<string>("ShortDesc");

                    b.Property<string>("Title");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<int>("Urgent");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.ToTable("Notices");
                });

            modelBuilder.Entity("Deepcove_Trust_Website.Models.NotificationChannel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("NotificationChannels");
                });

            modelBuilder.Entity("Deepcove_Trust_Website.Models.Page", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<bool>("Public");

                    b.Property<int>("QuickLink");

                    b.Property<int>("Section");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Pages");
                });

            modelBuilder.Entity("Deepcove_Trust_Website.Models.PageRevision", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int?>("CreatedById");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<int?>("PageId");

                    b.Property<string>("Reason");

                    b.Property<int?>("TemplateId");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("PageId");

                    b.HasIndex("TemplateId");

                    b.ToTable("PageRevisions");
                });

            modelBuilder.Entity("Deepcove_Trust_Website.Models.PageTemplate", b =>
                {
                    b.Property<int>("Id");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("Description");

                    b.Property<int>("MediaAreas");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("TextAreas");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("PageTemplates");
                });

            modelBuilder.Entity("Deepcove_Trust_Website.Models.PasswordReset", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AccountId");

                    b.Property<DateTime>("ExpiresAt");

                    b.Property<string>("Token")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("PasswordResets");
                });

            modelBuilder.Entity("Deepcove_Trust_Website.Models.RevisionMediaComponent", b =>
                {
                    b.Property<int>("PageRevisionId");

                    b.Property<int>("MediaComponentId");

                    b.HasKey("PageRevisionId", "MediaComponentId");

                    b.HasIndex("MediaComponentId");

                    b.ToTable("RevisionMediaComponent");
                });

            modelBuilder.Entity("Deepcove_Trust_Website.Models.RevisionTextComponent", b =>
                {
                    b.Property<int>("PageRevisionId");

                    b.Property<int>("TextComponentId");

                    b.HasKey("PageRevisionId", "TextComponentId");

                    b.HasIndex("TextComponentId");

                    b.ToTable("RevisionTextComponent");
                });

            modelBuilder.Entity("Deepcove_Trust_Website.Models.SystemSettings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EmailBookings");

                    b.Property<string>("EmailGeneral");

                    b.Property<string>("FooterText");

                    b.Property<string>("LinkTitleA");

                    b.Property<string>("LinkTitleB");

                    b.Property<string>("Phone");

                    b.Property<string>("UrlFacebook");

                    b.Property<string>("UrlGoogleMaps");

                    b.Property<string>("UrlGooglePlay");

                    b.HasKey("Id");

                    b.ToTable("SystemSettings");
                });

            modelBuilder.Entity("Deepcove_Trust_Website.Models.TextComponent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CmsButtonId");

                    b.Property<int>("SlotNo");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("CmsButtonId");

                    b.ToTable("TextComponents");
                });

            modelBuilder.Entity("Deepcove_Trust_Website.Models.AudioMedia", b =>
                {
                    b.HasBaseType("Deepcove_Trust_Website.Models.BaseMedia");

                    b.Property<double>("Duration");

                    b.HasDiscriminator().HasValue("AudioMedia");
                });

            modelBuilder.Entity("Deepcove_Trust_Website.Models.GeneralMedia", b =>
                {
                    b.HasBaseType("Deepcove_Trust_Website.Models.BaseMedia");

                    b.HasDiscriminator().HasValue("GeneralMedia");
                });

            modelBuilder.Entity("Deepcove_Trust_Website.Models.ImageMedia", b =>
                {
                    b.HasBaseType("Deepcove_Trust_Website.Models.BaseMedia");

                    b.Property<string>("Alt");

                    b.Property<double>("Height");

                    b.Property<string>("Title");

                    b.Property<string>("Versions");

                    b.Property<double>("Width");

                    b.HasDiscriminator().HasValue("ImageMedia");
                });

            modelBuilder.Entity("Deepcove_Trust_Website.DiscoverDeepCove.Activity", b =>
                {
                    b.HasOne("Deepcove_Trust_Website.DiscoverDeepCove.FactFileEntry", "FactFile")
                        .WithMany()
                        .HasForeignKey("FactFileId");

                    b.HasOne("Deepcove_Trust_Website.Models.ImageMedia", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId");

                    b.HasOne("Deepcove_Trust_Website.DiscoverDeepCove.Track", "Track")
                        .WithMany("Activities")
                        .HasForeignKey("TrackId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Deepcove_Trust_Website.DiscoverDeepCove.ActivityImage", b =>
                {
                    b.HasOne("Deepcove_Trust_Website.DiscoverDeepCove.Activity", "Activity")
                        .WithMany("ActivityImages")
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Deepcove_Trust_Website.Models.ImageMedia", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Deepcove_Trust_Website.DiscoverDeepCove.FactFileEntry", b =>
                {
                    b.HasOne("Deepcove_Trust_Website.DiscoverDeepCove.FactFileCategory", "Category")
                        .WithMany("FactFileEntries")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Deepcove_Trust_Website.Models.AudioMedia", "ListenAudio")
                        .WithMany()
                        .HasForeignKey("ListenAudioId");

                    b.HasOne("Deepcove_Trust_Website.Models.ImageMedia", "MainImage")
                        .WithMany()
                        .HasForeignKey("MainImageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Deepcove_Trust_Website.Models.AudioMedia", "PronounceAudio")
                        .WithMany()
                        .HasForeignKey("PronounceAudioId");
                });

            modelBuilder.Entity("Deepcove_Trust_Website.DiscoverDeepCove.FactFileEntryImage", b =>
                {
                    b.HasOne("Deepcove_Trust_Website.DiscoverDeepCove.FactFileEntry", "FactFileEntry")
                        .WithMany("FactFileEntryImages")
                        .HasForeignKey("FactFileEntryId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Deepcove_Trust_Website.Models.ImageMedia", "MediaFile")
                        .WithMany()
                        .HasForeignKey("MediaFileId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Deepcove_Trust_Website.DiscoverDeepCove.FactFileNugget", b =>
                {
                    b.HasOne("Deepcove_Trust_Website.DiscoverDeepCove.FactFileEntry", "FactFileEntry")
                        .WithMany("FactFileNuggets")
                        .HasForeignKey("FactFileEntryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Deepcove_Trust_Website.Models.ImageMedia", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId");
                });

            modelBuilder.Entity("Deepcove_Trust_Website.DiscoverDeepCove.Quiz", b =>
                {
                    b.HasOne("Deepcove_Trust_Website.Models.ImageMedia", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Deepcove_Trust_Website.DiscoverDeepCove.QuizAnswer", b =>
                {
                    b.HasOne("Deepcove_Trust_Website.Models.ImageMedia", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId");

                    b.HasOne("Deepcove_Trust_Website.DiscoverDeepCove.QuizQuestion", "QuizQuestion")
                        .WithMany("Answers")
                        .HasForeignKey("QuizQuestionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Deepcove_Trust_Website.DiscoverDeepCove.QuizQuestion", b =>
                {
                    b.HasOne("Deepcove_Trust_Website.Models.AudioMedia", "Audio")
                        .WithMany()
                        .HasForeignKey("AudioId");

                    b.HasOne("Deepcove_Trust_Website.DiscoverDeepCove.QuizAnswer", "CorrectAnswer")
                        .WithOne("CorrectForQuestion")
                        .HasForeignKey("Deepcove_Trust_Website.DiscoverDeepCove.QuizQuestion", "CorrectAnswerId");

                    b.HasOne("Deepcove_Trust_Website.Models.ImageMedia", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId");

                    b.HasOne("Deepcove_Trust_Website.DiscoverDeepCove.Quiz", "Quiz")
                        .WithMany("Questions")
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Deepcove_Trust_Website.Models.ChannelMembership", b =>
                {
                    b.HasOne("Deepcove_Trust_Website.Models.Account", "Account")
                        .WithMany("ChannelMemberships")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Deepcove_Trust_Website.Models.NotificationChannel", "NotificationChannel")
                        .WithMany("ChannelMemberships")
                        .HasForeignKey("NotificationChannelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Deepcove_Trust_Website.Models.MediaComponent", b =>
                {
                    b.HasOne("Deepcove_Trust_Website.Models.ImageMedia", "ImageMedia")
                        .WithMany()
                        .HasForeignKey("ImageMediaId");
                });

            modelBuilder.Entity("Deepcove_Trust_Website.Models.NavItem", b =>
                {
                    b.HasOne("Deepcove_Trust_Website.Models.Page", "Page")
                        .WithMany("NavItems")
                        .HasForeignKey("PageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Deepcove_Trust_Website.Models.NavItemPage", b =>
                {
                    b.HasOne("Deepcove_Trust_Website.Models.NavItem", "NavItem")
                        .WithMany("NavItemPages")
                        .HasForeignKey("NavItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Deepcove_Trust_Website.Models.Page", "Page")
                        .WithMany("NavItemPages")
                        .HasForeignKey("PageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Deepcove_Trust_Website.Models.Notice", b =>
                {
                    b.HasOne("Deepcove_Trust_Website.Models.ImageMedia", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId");
                });

            modelBuilder.Entity("Deepcove_Trust_Website.Models.PageRevision", b =>
                {
                    b.HasOne("Deepcove_Trust_Website.Models.Account", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("Deepcove_Trust_Website.Models.Page", "Page")
                        .WithMany("PageRevisions")
                        .HasForeignKey("PageId");

                    b.HasOne("Deepcove_Trust_Website.Models.PageTemplate", "Template")
                        .WithMany("PageRevisions")
                        .HasForeignKey("TemplateId");
                });

            modelBuilder.Entity("Deepcove_Trust_Website.Models.PasswordReset", b =>
                {
                    b.HasOne("Deepcove_Trust_Website.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId");
                });

            modelBuilder.Entity("Deepcove_Trust_Website.Models.RevisionMediaComponent", b =>
                {
                    b.HasOne("Deepcove_Trust_Website.Models.MediaComponent", "MediaComponent")
                        .WithMany("RevisionMediaComponents")
                        .HasForeignKey("MediaComponentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Deepcove_Trust_Website.Models.PageRevision", "PageRevision")
                        .WithMany("RevisionMediaComponents")
                        .HasForeignKey("PageRevisionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Deepcove_Trust_Website.Models.RevisionTextComponent", b =>
                {
                    b.HasOne("Deepcove_Trust_Website.Models.PageRevision", "PageRevision")
                        .WithMany("RevisionTextComponents")
                        .HasForeignKey("PageRevisionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Deepcove_Trust_Website.Models.TextComponent", "TextComponent")
                        .WithMany("RevisionTextComponents")
                        .HasForeignKey("TextComponentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Deepcove_Trust_Website.Models.TextComponent", b =>
                {
                    b.HasOne("Deepcove_Trust_Website.Models.CmsButton", "CmsButton")
                        .WithMany("TextFields")
                        .HasForeignKey("CmsButtonId");
                });
#pragma warning restore 612, 618
        }
    }
}
