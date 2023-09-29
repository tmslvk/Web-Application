﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using webapi;

#nullable disable

namespace webapi.Migrations
{
    [DbContext(typeof(UserContext))]
    [Migration("20230923160941_new3")]
    partial class new3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("webapi.Models.Band", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfFoundation")
                        .HasColumnType("datetime2");

                    b.Property<string>("NameOfBand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StatusOfActivity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Bands");
                });

            modelBuilder.Entity("webapi.Models.Musician", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfileInstruments")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StatusOfActivity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("YearsOfExperience")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Musicians");
                });

            modelBuilder.Entity("webapi.Models.MusicianBand", b =>
                {
                    b.Property<int>("BandID")
                        .HasColumnType("int");

                    b.Property<int>("MusicianId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("ParticiapationDateFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ParticiapationDateTo")
                        .HasColumnType("datetime2");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BandID", "MusicianId");

                    b.HasIndex("MusicianId");

                    b.ToTable("MusicianBand", (string)null);
                });

            modelBuilder.Entity("webapi.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("webapi.Models.Musician", b =>
                {
                    b.HasOne("webapi.Models.User", "User")
                        .WithOne("Musician")
                        .HasForeignKey("webapi.Models.Musician", "UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("webapi.Models.MusicianBand", b =>
                {
                    b.HasOne("webapi.Models.Band", "BandWrap")
                        .WithMany("BandsWrapper")
                        .HasForeignKey("BandID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webapi.Models.Musician", "MusicianWrap")
                        .WithMany("MusicianWrapper")
                        .HasForeignKey("MusicianId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BandWrap");

                    b.Navigation("MusicianWrap");
                });

            modelBuilder.Entity("webapi.Models.Band", b =>
                {
                    b.Navigation("BandsWrapper");
                });

            modelBuilder.Entity("webapi.Models.Musician", b =>
                {
                    b.Navigation("MusicianWrapper");
                });

            modelBuilder.Entity("webapi.Models.User", b =>
                {
                    b.Navigation("Musician");
                });
#pragma warning restore 612, 618
        }
    }
}