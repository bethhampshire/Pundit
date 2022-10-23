﻿// <auto-generated />
using System;
using EFPundit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EFPundit.Migrations
{
    [DbContext(typeof(PunditDbContext))]
    partial class PunditDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EFPundit.Models.Club", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<Guid>("ClubKey")
                        .HasColumnType("uuid");

                    b.Property<int>("GameTypes")
                        .HasColumnType("integer");

                    b.Property<int?>("LeagueKey")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("LeagueKey");

                    b.ToTable("Clubs");
                });

            modelBuilder.Entity("EFPundit.Models.ClubColours", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("PrimaryHex")
                        .HasColumnType("text");

                    b.Property<string>("SecondaryHex")
                        .HasColumnType("text");

                    b.Property<string>("TertiaryHex")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ClubColours");
                });

            modelBuilder.Entity("EFPundit.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<Guid>("CountryKey")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nationality")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("EFPundit.Models.League", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CountryKey")
                        .HasColumnType("integer");

                    b.Property<Guid>("LeagueKey")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CountryKey");

                    b.ToTable("Leagues");
                });

            modelBuilder.Entity("EFPundit.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("ClubKey")
                        .HasColumnType("integer");

                    b.Property<int?>("CountryKey")
                        .HasColumnType("integer");

                    b.Property<string>("Dob")
                        .HasColumnType("text");

                    b.Property<string>("Foot")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("PlayerKey")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SeasonKey")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ClubKey");

                    b.HasIndex("CountryKey");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("EFPundit.Models.PlayerStats", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("Appearances")
                        .HasColumnType("integer");

                    b.Property<int?>("Assists")
                        .HasColumnType("integer");

                    b.Property<int?>("Cleansheets")
                        .HasColumnType("integer");

                    b.Property<int?>("ClubKey")
                        .HasColumnType("integer");

                    b.Property<int>("GameTypes")
                        .HasColumnType("integer");

                    b.Property<int?>("Goals")
                        .HasColumnType("integer");

                    b.Property<int?>("MinutesPlayed")
                        .HasColumnType("integer");

                    b.Property<int?>("PlayerKey")
                        .HasColumnType("integer");

                    b.Property<int?>("RedCards")
                        .HasColumnType("integer");

                    b.Property<int?>("YellowCards")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ClubKey");

                    b.HasIndex("PlayerKey");

                    b.ToTable("PlayerStats");
                });

            modelBuilder.Entity("EFPundit.Models.Season", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<bool>("Current")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Year")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Seasons");
                });

            modelBuilder.Entity("EFPundit.Models.Club", b =>
                {
                    b.HasOne("EFPundit.Models.ClubColours", "ClubColours")
                        .WithOne("Club")
                        .HasForeignKey("EFPundit.Models.Club", "Id")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("EFPundit.Models.League", "League")
                        .WithMany("Clubs")
                        .HasForeignKey("LeagueKey")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("ClubColours");

                    b.Navigation("League");
                });

            modelBuilder.Entity("EFPundit.Models.League", b =>
                {
                    b.HasOne("EFPundit.Models.Country", "Country")
                        .WithMany("Leagues")
                        .HasForeignKey("CountryKey")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Country");
                });

            modelBuilder.Entity("EFPundit.Models.Player", b =>
                {
                    b.HasOne("EFPundit.Models.Club", "Club")
                        .WithMany("Players")
                        .HasForeignKey("ClubKey")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("EFPundit.Models.Country", "Country")
                        .WithMany("Players")
                        .HasForeignKey("CountryKey")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Club");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("EFPundit.Models.PlayerStats", b =>
                {
                    b.HasOne("EFPundit.Models.Club", "Club")
                        .WithMany("PlayerStats")
                        .HasForeignKey("ClubKey")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("EFPundit.Models.Player", "Player")
                        .WithMany("PlayerStats")
                        .HasForeignKey("PlayerKey")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Club");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("EFPundit.Models.Season", b =>
                {
                    b.HasOne("EFPundit.Models.PlayerStats", "PlayerStats")
                        .WithOne("Season")
                        .HasForeignKey("EFPundit.Models.Season", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlayerStats");
                });

            modelBuilder.Entity("EFPundit.Models.Club", b =>
                {
                    b.Navigation("PlayerStats");

                    b.Navigation("Players");
                });

            modelBuilder.Entity("EFPundit.Models.ClubColours", b =>
                {
                    b.Navigation("Club")
                        .IsRequired();
                });

            modelBuilder.Entity("EFPundit.Models.Country", b =>
                {
                    b.Navigation("Leagues");

                    b.Navigation("Players");
                });

            modelBuilder.Entity("EFPundit.Models.League", b =>
                {
                    b.Navigation("Clubs");
                });

            modelBuilder.Entity("EFPundit.Models.Player", b =>
                {
                    b.Navigation("PlayerStats");
                });

            modelBuilder.Entity("EFPundit.Models.PlayerStats", b =>
                {
                    b.Navigation("Season");
                });
#pragma warning restore 612, 618
        }
    }
}
