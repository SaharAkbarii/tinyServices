﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TinyServices.API.Repository;

#nullable disable

namespace TinyServices.API.Migrations
{
    [DbContext(typeof(TinyServicesDbContext))]
    [Migration("20230808083033_UpdateLinkInfoClickedAt")]
    partial class UpdateLinkInfoClickedAt
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TinyServices.API.LinkService.Model.DeepLink", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AndroidLink")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset?>("DeadLine")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DefaultRoute")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DesktopLink")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IosLink")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("DeepLinks");
                });

            modelBuilder.Entity("TinyServices.API.LinkService.Model.LinkClickInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("ClickedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Token");

                    b.ToTable("LinkClickInfos");
                });

            modelBuilder.Entity("TinyServices.API.LinkService.Model.OneTimeLink", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("IsVisited")
                        .HasColumnType("boolean");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("oneTimeLinks");
                });

            modelBuilder.Entity("TinyServices.API.LinkService.Model.ShortLink", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("DeadLine")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("MainLink")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ShortLinks");
                });
#pragma warning restore 612, 618
        }
    }
}
