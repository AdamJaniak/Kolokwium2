﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Poprawa2.DAL;

#nullable disable

namespace Poprawa2.Migrations
{
    [DbContext(typeof(GalleriesDbContext))]
    [Migration("20250620123807_firstMigration")]
    partial class firstMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Poprawa2.Models.Artist", b =>
                {
                    b.Property<int>("ArtistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArtistId"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ArtistId");

                    b.ToTable("Artist");

                    b.HasData(
                        new
                        {
                            ArtistId = 1,
                            BirthDate = new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Daniel",
                            LastName = "Danov"
                        });
                });

            modelBuilder.Entity("Poprawa2.Models.Artwork", b =>
                {
                    b.Property<int>("ArtworkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArtworkId"));

                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YearCreated")
                        .HasColumnType("int");

                    b.HasKey("ArtworkId");

                    b.HasIndex("ArtistId");

                    b.ToTable("Artwork");

                    b.HasData(
                        new
                        {
                            ArtworkId = 1,
                            ArtistId = 1,
                            Title = "Daniel",
                            YearCreated = 2000
                        });
                });

            modelBuilder.Entity("Poprawa2.Models.Exhibition", b =>
                {
                    b.Property<int>("ExhibitionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExhibitionId"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("GalleryId")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfArtWorks")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ExhibitionId");

                    b.HasIndex("GalleryId");

                    b.ToTable("Exhibition");

                    b.HasData(
                        new
                        {
                            ExhibitionId = 1,
                            EndDate = new DateTime(2000, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GalleryId = 1,
                            NumberOfArtWorks = 1,
                            StartDate = new DateTime(2000, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "War of the Ring"
                        });
                });

            modelBuilder.Entity("Poprawa2.Models.Exhibition_Artwork", b =>
                {
                    b.Property<int>("ExhibitionId")
                        .HasColumnType("int");

                    b.Property<int>("ArtworkId")
                        .HasColumnType("int");

                    b.Property<double>("InsuranceValue")
                        .HasColumnType("float");

                    b.HasKey("ExhibitionId", "ArtworkId");

                    b.HasIndex("ArtworkId");

                    b.ToTable("Exhibition_Artwork");

                    b.HasData(
                        new
                        {
                            ExhibitionId = 1,
                            ArtworkId = 1,
                            InsuranceValue = 100.0
                        });
                });

            modelBuilder.Entity("Poprawa2.Models.Gallery", b =>
                {
                    b.Property<int>("GalleryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GalleryId"));

                    b.Property<DateTime>("EstabilishedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GalleryId");

                    b.ToTable("Gallery");

                    b.HasData(
                        new
                        {
                            GalleryId = 1,
                            EstabilishedDate = new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Daniel"
                        });
                });

            modelBuilder.Entity("Poprawa2.Models.Artwork", b =>
                {
                    b.HasOne("Poprawa2.Models.Artist", "Artist")
                        .WithMany("Artworks")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("Poprawa2.Models.Exhibition", b =>
                {
                    b.HasOne("Poprawa2.Models.Gallery", "Gallery")
                        .WithMany("Exhibitions")
                        .HasForeignKey("GalleryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gallery");
                });

            modelBuilder.Entity("Poprawa2.Models.Exhibition_Artwork", b =>
                {
                    b.HasOne("Poprawa2.Models.Artwork", "Artwork")
                        .WithMany("Exhibition_Artworks")
                        .HasForeignKey("ArtworkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Poprawa2.Models.Exhibition", "Exhibition")
                        .WithMany("ExhibitionArtworks")
                        .HasForeignKey("ExhibitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artwork");

                    b.Navigation("Exhibition");
                });

            modelBuilder.Entity("Poprawa2.Models.Artist", b =>
                {
                    b.Navigation("Artworks");
                });

            modelBuilder.Entity("Poprawa2.Models.Artwork", b =>
                {
                    b.Navigation("Exhibition_Artworks");
                });

            modelBuilder.Entity("Poprawa2.Models.Exhibition", b =>
                {
                    b.Navigation("ExhibitionArtworks");
                });

            modelBuilder.Entity("Poprawa2.Models.Gallery", b =>
                {
                    b.Navigation("Exhibitions");
                });
#pragma warning restore 612, 618
        }
    }
}
