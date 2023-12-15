﻿// <auto-generated />
using System;
using API.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API.Database.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231214185726_Initialization")]
    partial class Initialization
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("API.Entity.Database.IpInfo", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("city");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("country");

                    b.Property<string>("Ip")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("ip");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("loc");

                    b.Property<string>("Organization")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("org");

                    b.Property<string>("Readme")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("readme");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("region");

                    b.Property<string>("TimeZone")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("timezone");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("zip");

                    b.HasKey("UserId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("ip_infos", "api");
                });

            modelBuilder.Entity("API.Entity.Database.User", b =>
                {
                    b.Property<string>("Guid")
                        .HasColumnType("text")
                        .HasColumnName("guid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp")
                        .HasColumnName("created_at");

                    b.HasKey("Guid");

                    b.HasIndex("Guid")
                        .IsUnique();

                    b.ToTable("users", "api");
                });

            modelBuilder.Entity("API.Entity.Database.IpInfo", b =>
                {
                    b.HasOne("API.Entity.Database.User", "User")
                        .WithOne("IpInfo")
                        .HasForeignKey("API.Entity.Database.IpInfo", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("API.Entity.Database.User", b =>
                {
                    b.Navigation("IpInfo");
                });
#pragma warning restore 612, 618
        }
    }
}