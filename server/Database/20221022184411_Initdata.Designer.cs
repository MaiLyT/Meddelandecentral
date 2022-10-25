﻿// <auto-generated />
using System;
using Meddelandecentral.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Meddelandecentral.Database
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221022184411_Initdata")]
    partial class Initdata
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("Meddelandecentral.Models.ChatMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("Meddelandecentral.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("RoomName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("isCleaned")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RoomName = "Room 1",
                            isCleaned = false
                        },
                        new
                        {
                            Id = 2,
                            RoomName = "Room 2",
                            isCleaned = false
                        },
                        new
                        {
                            Id = 3,
                            RoomName = "Room 3",
                            isCleaned = true
                        },
                        new
                        {
                            Id = 4,
                            RoomName = "Room 4",
                            isCleaned = true
                        },
                        new
                        {
                            Id = 5,
                            RoomName = "Room 5",
                            isCleaned = true
                        },
                        new
                        {
                            Id = 6,
                            RoomName = "Conference Room",
                            isCleaned = false
                        });
                });

            modelBuilder.Entity("Meddelandecentral.Models.Todo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Notis")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("RoomId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("isDone")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("Todos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Notis = "Wakeup call att 05:00 am",
                            RoomId = 1,
                            isDone = false
                        });
                });

            modelBuilder.Entity("Meddelandecentral.Models.Todo", b =>
                {
                    b.HasOne("Meddelandecentral.Models.Room", null)
                        .WithMany("Todo")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Meddelandecentral.Models.Room", b =>
                {
                    b.Navigation("Todo");
                });
#pragma warning restore 612, 618
        }
    }
}