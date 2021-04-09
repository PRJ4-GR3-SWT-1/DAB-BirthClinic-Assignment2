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
    [Migration("20210409071932_reservations")]
    partial class reservations
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

                    b.Property<int?>("BirthRoomRoomId1")
                        .HasColumnType("int");

                    b.Property<int?>("ClinicianPersonId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PlannedStartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("BirthId");

                    b.HasIndex("BirthRoomRoomId");

                    b.HasIndex("BirthRoomRoomId1");

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

                    b.HasKey("PersonId");

                    b.HasIndex("BirthId");

                    b.ToTable("Person");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");
                });

            modelBuilder.Entity("BirthClinicLibrary.Models.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoomName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoomId");

                    b.ToTable("Room");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Room");
                });

            modelBuilder.Entity("BirthClinicLibrary.Models.Child", b =>
                {
                    b.HasBaseType("BirthClinicLibrary.Models.Person");

                    b.Property<DateTime>("ActualBirthTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("BirthId1")
                        .HasColumnType("int");

                    b.Property<int?>("MotherPersonId")
                        .HasColumnType("int");

                    b.HasIndex("BirthId1");

                    b.HasIndex("MotherPersonId");

                    b.HasDiscriminator().HasValue("Child");
                });

            modelBuilder.Entity("BirthClinicLibrary.Models.Clinician", b =>
                {
                    b.HasBaseType("BirthClinicLibrary.Models.Person");

                    b.HasDiscriminator().HasValue("Clinician");
                });

            modelBuilder.Entity("BirthClinicLibrary.Models.Mother", b =>
                {
                    b.HasBaseType("BirthClinicLibrary.Models.Person");

                    b.Property<DateTime>("MaternityRoomReservationEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("MaternityRoomReservationStart")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MaternityRoomRoomId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RestingRoomReservationEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RestingRoomReservationStart")
                        .HasColumnType("datetime2");

                    b.Property<int?>("RestingRoomRoomId")
                        .HasColumnType("int");

                    b.HasIndex("MaternityRoomRoomId");

                    b.HasIndex("RestingRoomRoomId");

                    b.HasDiscriminator().HasValue("Mother");
                });

            modelBuilder.Entity("BirthClinicLibrary.Models.BirthRoom", b =>
                {
                    b.HasBaseType("BirthClinicLibrary.Models.Room");

                    b.HasDiscriminator().HasValue("BirthRoom");
                });

            modelBuilder.Entity("BirthClinicLibrary.Models.MaternityRoom", b =>
                {
                    b.HasBaseType("BirthClinicLibrary.Models.Room");

                    b.HasDiscriminator().HasValue("MaternityRoom");
                });

            modelBuilder.Entity("BirthClinicLibrary.Models.RestingRoom", b =>
                {
                    b.HasBaseType("BirthClinicLibrary.Models.Room");

                    b.HasDiscriminator().HasValue("RestingRoom");
                });

            modelBuilder.Entity("BirthClinicLibrary.Models.Doctor", b =>
                {
                    b.HasBaseType("BirthClinicLibrary.Models.Clinician");

                    b.HasDiscriminator().HasValue("Doctor");
                });

            modelBuilder.Entity("BirthClinicLibrary.Models.Birth", b =>
                {
                    b.HasOne("BirthClinicLibrary.Models.Room", "BirthRoom")
                        .WithMany()
                        .HasForeignKey("BirthRoomRoomId");

                    b.HasOne("BirthClinicLibrary.Models.BirthRoom", null)
                        .WithMany("BirthReservations")
                        .HasForeignKey("BirthRoomRoomId1");

                    b.HasOne("BirthClinicLibrary.Models.Clinician", null)
                        .WithMany("AssociatedBirths")
                        .HasForeignKey("ClinicianPersonId");

                    b.Navigation("BirthRoom");
                });

            modelBuilder.Entity("BirthClinicLibrary.Models.Person", b =>
                {
                    b.HasOne("BirthClinicLibrary.Models.Birth", null)
                        .WithMany("Clinicians")
                        .HasForeignKey("BirthId");
                });

            modelBuilder.Entity("BirthClinicLibrary.Models.Child", b =>
                {
                    b.HasOne("BirthClinicLibrary.Models.Birth", "Birth")
                        .WithMany()
                        .HasForeignKey("BirthId1");

                    b.HasOne("BirthClinicLibrary.Models.Mother", "Mother")
                        .WithMany()
                        .HasForeignKey("MotherPersonId");

                    b.Navigation("Birth");

                    b.Navigation("Mother");
                });

            modelBuilder.Entity("BirthClinicLibrary.Models.Mother", b =>
                {
                    b.HasOne("BirthClinicLibrary.Models.MaternityRoom", "MaternityRoom")
                        .WithMany("MotherReservations")
                        .HasForeignKey("MaternityRoomRoomId");

                    b.HasOne("BirthClinicLibrary.Models.RestingRoom", "RestingRoom")
                        .WithMany("MotherReservations")
                        .HasForeignKey("RestingRoomRoomId");

                    b.Navigation("MaternityRoom");

                    b.Navigation("RestingRoom");
                });

            modelBuilder.Entity("BirthClinicLibrary.Models.Birth", b =>
                {
                    b.Navigation("Clinicians");
                });

            modelBuilder.Entity("BirthClinicLibrary.Models.Clinician", b =>
                {
                    b.Navigation("AssociatedBirths");
                });

            modelBuilder.Entity("BirthClinicLibrary.Models.BirthRoom", b =>
                {
                    b.Navigation("BirthReservations");
                });

            modelBuilder.Entity("BirthClinicLibrary.Models.MaternityRoom", b =>
                {
                    b.Navigation("MotherReservations");
                });

            modelBuilder.Entity("BirthClinicLibrary.Models.RestingRoom", b =>
                {
                    b.Navigation("MotherReservations");
                });
#pragma warning restore 612, 618
        }
    }
}
