﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PisiTechSchool.Data;

#nullable disable

namespace PisiTechSchool.Migrations
{
    [DbContext(typeof(PisiTechSchoolContext))]
    [Migration("20240312132221_firstMigration")]
    partial class firstMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("PisiTechSchool.Models.Service", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ServiceId"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ServiceId");

                    b.ToTable("Service");

                    b.HasData(
                        new
                        {
                            ServiceId = 1,
                            CreatedDate = new DateTime(2024, 3, 12, 0, 0, 0, 0, DateTimeKind.Local),
                            Email = "goodjoe@gmail.com",
                            PhoneNumber = "09078884321"
                        },
                        new
                        {
                            ServiceId = 2,
                            CreatedDate = new DateTime(2024, 3, 12, 0, 0, 0, 0, DateTimeKind.Local),
                            Email = "thomike@gmail.com",
                            PhoneNumber = "08087654321"
                        },
                        new
                        {
                            ServiceId = 3,
                            CreatedDate = new DateTime(2024, 3, 12, 0, 0, 0, 0, DateTimeKind.Local),
                            Email = "jkay@gmail.com",
                            PhoneNumber = "070876543217"
                        },
                        new
                        {
                            ServiceId = 4,
                            CreatedDate = new DateTime(2024, 3, 12, 0, 0, 0, 0, DateTimeKind.Local),
                            Email = "smith@gmail.com",
                            PhoneNumber = "07087699092"
                        });
                });

            modelBuilder.Entity("PisiTechSchool.Models.Subscription", b =>
                {
                    b.Property<int>("SubscriptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("SubscriptionId"));

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("SubscribedDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("SubscriptionId");

                    b.ToTable("Subscription");
                });

            modelBuilder.Entity("PisiTechSchool.Models.TokenPeriod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<int>("ExpiryPeriod")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TokenPeriod");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Expires After I day",
                            ExpiryPeriod = 1
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
