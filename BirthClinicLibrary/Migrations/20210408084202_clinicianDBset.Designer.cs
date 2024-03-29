﻿// <auto-generated />
using System;
using EFModels.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BirthClinicLibrary.Migrations
{
    [DbContext(typeof(BirthDbContext))]
    [Migration("20210408084202_clinicianDBset")]
    partial class clinicianDBset
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BirthClinicLibrary.Models.Birth", b =>
                {
                    b.Property<int>("BirthId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthRoomReservationEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("BirthRoomReservationStart")
                        .HasColumnType("datetime2");

                    b.Property<int?>("BirthRoomRoomId")
                        .HasColumnType("int");

                    b.Property<int?>("ChildPersonId")
                        .HasColumnType("int");

                    b.Property<int?>("ClinicianPersonId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PlannedStartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("BirthId");

                    b.HasIndex("BirthRoomRoomId");

                    b.HasIndex("ChildPersonId");

                    b.HasIndex("ClinicianPersonId");

                    b.ToTable("Birth");
                });

            modelBuilder.Entity("BirthClinicLibrary.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BirthId")
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("PersonId");

                    b.HasIndex("BirthId");

                    b.HasIndex("RoomId");

                    b.ToTable("Person");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");
                });

            modelBuilder.Entity("BirthClinicLibrary.Models.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("RoomId");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("BirthClinicLibrary.Models.Clinician", b =>
                {
                    b.HasBaseType("BirthClinicLibrary.Models.Person");

                    b.HasDiscriminator().HasValue("Clinician");
                });

            modelBuilder.Entity("BirthClinicLibrary.Models.Doctor", b =>
                {
                    b.HasBaseType("BirthClinicLibrary.Models.Clinician");

                    b.HasDiscriminator().HasValue("Doctor");
                });

            modelBuilder.Entity("BirthClinicLibrary.Models.Birth", b =>
                {
                    b.HasOne("BirthClinicLibrary.Models.Room", "BirthRoom")
                        .WithMany("Reservations")
                        .HasForeignKey("BirthRoomRoomId");

                    b.HasOne("BirthClinicLibrary.Models.Person", "Child")
                        .WithMany()
                        .HasForeignKey("ChildPersonId");

                    b.HasOne("BirthClinicLibrary.Models.Clinician", null)
                        .WithMany("AssociatedBirths")
                        .HasForeignKey("ClinicianPersonId");

                    b.Navigation("BirthRoom");

                    b.Navigation("Child");
                });

            modelBuilder.Entity("BirthClinicLibrary.Models.Person", b =>
                {
                    b.HasOne("BirthClinicLibrary.Models.Birth", null)
                        .WithMany("Clinicians")
                        .HasForeignKey("BirthId");

                    b.HasOne("BirthClinicLibrary.Models.Room", null)
                        .WithMany("AssociatedPersons")
                        .HasForeignKey("RoomId");
                });

            modelBuilder.Entity("BirthClinicLibrary.Models.Birth", b =>
                {
                    b.Navigation("Clinicians");
                });

            modelBuilder.Entity("BirthClinicLibrary.Models.Room", b =>
                {
                    b.Navigation("AssociatedPersons");

                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("BirthClinicLibrary.Models.Clinician", b =>
                {
                    b.Navigation("AssociatedBirths");
                });
#pragma warning restore 612, 618
        }
    }
}
