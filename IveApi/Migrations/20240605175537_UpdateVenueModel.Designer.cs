﻿// <auto-generated />
using System;
using IveApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IveApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240605175537_UpdateVenueModel")]
    partial class UpdateVenueModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("IveApi.Models.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Artists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Genre = "Pop",
                            Name = "Dua Lipa"
                        },
                        new
                        {
                            Id = 2,
                            Genre = "Pop",
                            Name = "Taylor Swift"
                        },
                        new
                        {
                            Id = 3,
                            Genre = "Pop",
                            Name = "Elton John"
                        });
                });

            modelBuilder.Entity("IveApi.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("VenueId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("VenueId");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = new DateOnly(2024, 10, 5),
                            Name = "Open Mic Night",
                            VenueId = 2
                        },
                        new
                        {
                            Id = 2,
                            Date = new DateOnly(2024, 8, 20),
                            Name = "Talent Show",
                            VenueId = 3
                        });
                });

            modelBuilder.Entity("IveApi.Models.Performance", b =>
                {
                    b.Property<int>("ArtistId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EventId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ArtistId", "EventId");

                    b.HasIndex("EventId");

                    b.ToTable("Performances");

                    b.HasData(
                        new
                        {
                            ArtistId = 2,
                            EventId = 2
                        },
                        new
                        {
                            ArtistId = 3,
                            EventId = 2
                        });
                });

            modelBuilder.Entity("IveApi.Models.Venue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Capacity")
                        .HasColumnType("INTEGER");

                    b.Property<double>("MaxLat")
                        .HasColumnType("REAL");

                    b.Property<double>("MaxLong")
                        .HasColumnType("REAL");

                    b.Property<double>("MinLat")
                        .HasColumnType("REAL");

                    b.Property<double>("MinLong")
                        .HasColumnType("REAL");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Venues");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Capacity = 200,
                            MaxLat = 3.4350000000000001,
                            MaxLong = 3.556,
                            MinLat = 0.34499999999999997,
                            MinLong = 0.43534,
                            Name = "Pub"
                        },
                        new
                        {
                            Id = 3,
                            Capacity = 300,
                            MaxLat = -3.2400000000000002,
                            MaxLong = -3.24234,
                            MinLat = 0.32432,
                            MinLong = 0.43240000000000001,
                            Name = "Cocktail Bar"
                        });
                });

            modelBuilder.Entity("IveApi.Models.Event", b =>
                {
                    b.HasOne("IveApi.Models.Venue", "Venue")
                        .WithMany("Events")
                        .HasForeignKey("VenueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Venue");
                });

            modelBuilder.Entity("IveApi.Models.Performance", b =>
                {
                    b.HasOne("IveApi.Models.Artist", "Artist")
                        .WithMany("Performances")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IveApi.Models.Event", "Event")
                        .WithMany("Performances")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("IveApi.Models.Artist", b =>
                {
                    b.Navigation("Performances");
                });

            modelBuilder.Entity("IveApi.Models.Event", b =>
                {
                    b.Navigation("Performances");
                });

            modelBuilder.Entity("IveApi.Models.Venue", b =>
                {
                    b.Navigation("Events");
                });
#pragma warning restore 612, 618
        }
    }
}
