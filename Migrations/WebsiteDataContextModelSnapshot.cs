﻿// <auto-generated />
using System;
using Deepcove_Trust_Website.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
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
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Deepcove_Trust_Website.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

            modelBuilder.Entity("Deepcove_Trust_Website.Models.PasswordReset", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AccountId");

                    b.Property<DateTime>("ExpiresAt");

                    b.Property<string>("Token")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("PasswordReset");
                });

            modelBuilder.Entity("Deepcove_Trust_Website.Models.WebsiteSettings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContactEmail");

                    b.Property<string>("ContactPhone");

                    b.Property<string>("FacebookUrl");

                    b.Property<string>("MissionStatment");

                    b.Property<string>("QLinksTitleA");

                    b.Property<string>("QLinksTitleB");

                    b.HasKey("Id");

                    b.ToTable("WebsiteSettings");
                });

            modelBuilder.Entity("Deepcove_Trust_Website.Models.PasswordReset", b =>
                {
                    b.HasOne("Deepcove_Trust_Website.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId");
                });
#pragma warning restore 612, 618
        }
    }
}