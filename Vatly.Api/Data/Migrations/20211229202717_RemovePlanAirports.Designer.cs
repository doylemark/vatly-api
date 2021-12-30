﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Vatly.Api.Data;

#nullable disable

namespace Vatly.Api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211229202717_RemovePlanAirports")]
    partial class RemovePlanAirports
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Vatly.Api.Models.Airport", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Elevation")
                        .HasColumnType("integer");

                    b.Property<string>("Iata")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Icao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Latitude")
                        .HasColumnType("double precision");

                    b.Property<double>("Longitude")
                        .HasColumnType("double precision");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TimeZone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Airports");
                });

            modelBuilder.Entity("Vatly.Api.Models.Controller", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Callsign")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Cid")
                        .HasColumnType("integer");

                    b.Property<int>("Facility")
                        .HasColumnType("integer");

                    b.Property<string>("Frequency")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LogonTime")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.Property<string>("Server")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("VisualRange")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Controllers");
                });

            modelBuilder.Entity("Vatly.Api.Models.Flight", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double>("Altitude")
                        .HasColumnType("double precision");

                    b.Property<string>("Callsign")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Cid")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Heading")
                        .HasColumnType("integer");

                    b.Property<double>("Latitude")
                        .HasColumnType("double precision");

                    b.Property<double>("Longitude")
                        .HasColumnType("double precision");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Server")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Transponder")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("Vatly.Api.Models.FlightPlan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Aircraft")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Altitude")
                        .HasColumnType("double precision");

                    b.Property<string>("Arrival")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DepartureTime")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("EnrouteTime")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("FlightId")
                        .HasColumnType("uuid");

                    b.Property<string>("FuelTime")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Origin")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Remarks")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Route")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Rules")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Speed")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("FlightId")
                        .IsUnique();

                    b.ToTable("FlightPlans");
                });

            modelBuilder.Entity("Vatly.Api.Models.Metar", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("DewPoint")
                        .HasColumnType("double precision");

                    b.Property<string>("Icao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Pressure")
                        .HasColumnType("double precision");

                    b.Property<string>("RawText")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Temperature")
                        .HasColumnType("double precision");

                    b.Property<double?>("Visibility")
                        .HasColumnType("double precision");

                    b.Property<int>("WindDirection")
                        .HasColumnType("integer");

                    b.Property<double?>("WindGust")
                        .HasColumnType("double precision");

                    b.Property<int>("WindSpeed")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Metars");
                });

            modelBuilder.Entity("Vatly.Api.Models.FlightPlan", b =>
                {
                    b.HasOne("Vatly.Api.Models.Flight", null)
                        .WithOne("FlightPlan")
                        .HasForeignKey("Vatly.Api.Models.FlightPlan", "FlightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Vatly.Api.Models.Flight", b =>
                {
                    b.Navigation("FlightPlan");
                });
#pragma warning restore 612, 618
        }
    }
}
