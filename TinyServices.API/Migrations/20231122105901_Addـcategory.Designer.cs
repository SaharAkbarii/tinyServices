﻿// <auto-generated />
using System;
using System.Collections.Generic;
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
    [Migration("20231122105901_Addـcategory")]
    partial class Addـcategory
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TinyServices.API.Divar.Model.Advertisement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("boolean");

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("Price")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<List<string>>("UrlImage")
                        .HasColumnType("text[]");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Advertisements");
                });

            modelBuilder.Entity("TinyServices.API.Divar.Model.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("TinyServices.API.Divar.Model.CategoryProperty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsMandatory")
                        .HasColumnType("boolean");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("Title", "CategoryId")
                        .IsUnique();

                    b.ToTable("CategoryProperties");
                });

            modelBuilder.Entity("TinyServices.API.Divar.Model.PropertyValue", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AdvertisementId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("PropertyId")
                        .HasColumnType("uuid");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AdvertisementId");

                    b.HasIndex("PropertyId");

                    b.ToTable("PropertyValues");
                });

            modelBuilder.Entity("TinyServices.API.Divar.Model.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TinyServices.API.LinkService.Model.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("TinyServices.API.LinkService.Model.DeepLink", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AndroidLink")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

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

                    b.Property<DateTimeOffset>("CreatedAt")
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

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

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

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("DeadLine")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("MainLink")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("ShortLinks");
                });

            modelBuilder.Entity("TinyServices.API.Linkedin.Model.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("LinkedinPostId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("LinkedinUserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("LinkedinPostId");

                    b.HasIndex("LinkedinUserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("TinyServices.API.Linkedin.Model.Connection", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ConnectionUserId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ConnectionUserId");

                    b.HasIndex("UserId");

                    b.ToTable("Connections");
                });

            modelBuilder.Entity("TinyServices.API.Linkedin.Model.ConnectionRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("ReceiverId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SenderId")
                        .HasColumnType("uuid");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("ConnectionRequests");
                });

            modelBuilder.Entity("TinyServices.API.Linkedin.Model.Like", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("LinkedinPostId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("LinkedinUserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("LinkedinPostId");

                    b.HasIndex("LinkedinUserId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("TinyServices.API.Linkedin.Model.LinkedinPost", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<List<string>>("ImageUrls")
                        .HasColumnType("text[]");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("linkedinPosts");
                });

            modelBuilder.Entity("TinyServices.API.Linkedin.Model.LinkedinUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("LinkedinUsers");
                });

            modelBuilder.Entity("TinyServices.API.NewsMagazine.Model.FavoriteCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("FavoriteCategory");
                });

            modelBuilder.Entity("TinyServices.API.NewsMagazine.Model.News", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("NewsNumber")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset?>("PublishAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("News");
                });

            modelBuilder.Entity("TinyServices.API.NewsMagazine.Model.NewsCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("NewsCategories");
                });

            modelBuilder.Entity("TinyServices.API.NewsMagazine.Model.NewsCategoryContainer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("NewsCategoryId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("NewsId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("NewsCategoryId");

                    b.HasIndex("NewsId");

                    b.ToTable("NewsCategoryContainer");
                });

            modelBuilder.Entity("TinyServices.API.NewsMagazine.Model.NewsComment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("NewsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("NewsUserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("NewsId");

                    b.HasIndex("NewsUserId");

                    b.ToTable("NewsComments");
                });

            modelBuilder.Entity("TinyServices.API.NewsMagazine.Model.NewsDisLike", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("NewsPostId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("NewsUserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("NewsPostId");

                    b.HasIndex("NewsUserId");

                    b.ToTable("NewsDisLikes");
                });

            modelBuilder.Entity("TinyServices.API.NewsMagazine.Model.NewsLike", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("NewsPostId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("NewsUserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("NewsPostId");

                    b.HasIndex("NewsUserId");

                    b.ToTable("NewsLikes");
                });

            modelBuilder.Entity("TinyServices.API.NewsMagazine.Model.NewsUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("NewsUsers");
                });

            modelBuilder.Entity("TinyServices.API.Divar.Model.Advertisement", b =>
                {
                    b.HasOne("TinyServices.API.Divar.Model.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TinyServices.API.Divar.Model.User", "User")
                        .WithMany("Advertisements")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("TinyServices.API.Divar.Model.PhoneNumber", "PhoneNumber", b1 =>
                        {
                            b1.Property<Guid>("AdvertisementId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("AdvertisementId");

                            b1.ToTable("Advertisements");

                            b1.WithOwner()
                                .HasForeignKey("AdvertisementId");
                        });

                    b.Navigation("Category");

                    b.Navigation("PhoneNumber")
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TinyServices.API.Divar.Model.CategoryProperty", b =>
                {
                    b.HasOne("TinyServices.API.Divar.Model.Category", "Category")
                        .WithMany("Properties")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("TinyServices.API.Divar.Model.PropertyValue", b =>
                {
                    b.HasOne("TinyServices.API.Divar.Model.Advertisement", "Advertisement")
                        .WithMany("PropertyValues")
                        .HasForeignKey("AdvertisementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TinyServices.API.Divar.Model.CategoryProperty", "Property")
                        .WithMany()
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Advertisement");

                    b.Navigation("Property");
                });

            modelBuilder.Entity("TinyServices.API.Divar.Model.User", b =>
                {
                    b.OwnsOne("TinyServices.API.Divar.Model.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("UserId");

                            b1.HasIndex("Value")
                                .IsUnique();

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("TinyServices.API.Divar.Model.PhoneNumber", "PhoneNumber", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("UserId");

                            b1.HasIndex("Value")
                                .IsUnique();

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("PhoneNumber")
                        .IsRequired();
                });

            modelBuilder.Entity("TinyServices.API.LinkService.Model.ShortLink", b =>
                {
                    b.HasOne("TinyServices.API.LinkService.Model.Company", "Company")
                        .WithMany("ShortLinks")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("TinyServices.API.Linkedin.Model.Comment", b =>
                {
                    b.HasOne("TinyServices.API.Linkedin.Model.LinkedinPost", "LinkedinPost")
                        .WithMany("Comments")
                        .HasForeignKey("LinkedinPostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TinyServices.API.Linkedin.Model.LinkedinUser", "LinkedinUser")
                        .WithMany()
                        .HasForeignKey("LinkedinUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LinkedinPost");

                    b.Navigation("LinkedinUser");
                });

            modelBuilder.Entity("TinyServices.API.Linkedin.Model.Connection", b =>
                {
                    b.HasOne("TinyServices.API.Linkedin.Model.LinkedinUser", "ConnectionUser")
                        .WithMany()
                        .HasForeignKey("ConnectionUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TinyServices.API.Linkedin.Model.LinkedinUser", "User")
                        .WithMany("Conections")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ConnectionUser");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TinyServices.API.Linkedin.Model.ConnectionRequest", b =>
                {
                    b.HasOne("TinyServices.API.Linkedin.Model.LinkedinUser", "Receiver")
                        .WithMany("ConnectionRequests")
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TinyServices.API.Linkedin.Model.LinkedinUser", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("TinyServices.API.Linkedin.Model.Like", b =>
                {
                    b.HasOne("TinyServices.API.Linkedin.Model.LinkedinPost", "LinkedinPost")
                        .WithMany("Likes")
                        .HasForeignKey("LinkedinPostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TinyServices.API.Linkedin.Model.LinkedinUser", "LinkedinUser")
                        .WithMany()
                        .HasForeignKey("LinkedinUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LinkedinPost");

                    b.Navigation("LinkedinUser");
                });

            modelBuilder.Entity("TinyServices.API.Linkedin.Model.LinkedinPost", b =>
                {
                    b.HasOne("TinyServices.API.Linkedin.Model.LinkedinUser", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TinyServices.API.Linkedin.Model.LinkedinUser", b =>
                {
                    b.OwnsOne("TinyServices.API.Divar.Model.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("LinkedinUserId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("LinkedinUserId");

                            b1.HasIndex("Value")
                                .IsUnique();

                            b1.ToTable("LinkedinUsers");

                            b1.WithOwner()
                                .HasForeignKey("LinkedinUserId");
                        });

                    b.Navigation("Email")
                        .IsRequired();
                });

            modelBuilder.Entity("TinyServices.API.NewsMagazine.Model.FavoriteCategory", b =>
                {
                    b.HasOne("TinyServices.API.NewsMagazine.Model.NewsCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TinyServices.API.NewsMagazine.Model.NewsUser", "User")
                        .WithMany("FavoriteCategories")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TinyServices.API.NewsMagazine.Model.NewsCategoryContainer", b =>
                {
                    b.HasOne("TinyServices.API.NewsMagazine.Model.NewsCategory", "NewsCategory")
                        .WithMany()
                        .HasForeignKey("NewsCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TinyServices.API.NewsMagazine.Model.News", "News")
                        .WithMany("NewsCategories")
                        .HasForeignKey("NewsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("News");

                    b.Navigation("NewsCategory");
                });

            modelBuilder.Entity("TinyServices.API.NewsMagazine.Model.NewsComment", b =>
                {
                    b.HasOne("TinyServices.API.NewsMagazine.Model.News", "News")
                        .WithMany("Comments")
                        .HasForeignKey("NewsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TinyServices.API.NewsMagazine.Model.NewsUser", "NewsUser")
                        .WithMany()
                        .HasForeignKey("NewsUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("News");

                    b.Navigation("NewsUser");
                });

            modelBuilder.Entity("TinyServices.API.NewsMagazine.Model.NewsDisLike", b =>
                {
                    b.HasOne("TinyServices.API.NewsMagazine.Model.News", "NewsPost")
                        .WithMany("DisLikes")
                        .HasForeignKey("NewsPostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TinyServices.API.NewsMagazine.Model.NewsUser", "NewsUser")
                        .WithMany()
                        .HasForeignKey("NewsUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NewsPost");

                    b.Navigation("NewsUser");
                });

            modelBuilder.Entity("TinyServices.API.NewsMagazine.Model.NewsLike", b =>
                {
                    b.HasOne("TinyServices.API.NewsMagazine.Model.News", "NewsPost")
                        .WithMany("Likes")
                        .HasForeignKey("NewsPostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TinyServices.API.NewsMagazine.Model.NewsUser", "NewsUser")
                        .WithMany()
                        .HasForeignKey("NewsUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NewsPost");

                    b.Navigation("NewsUser");
                });

            modelBuilder.Entity("TinyServices.API.NewsMagazine.Model.NewsUser", b =>
                {
                    b.OwnsOne("TinyServices.API.Divar.Model.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("NewsUserId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("NewsUserId");

                            b1.HasIndex("Value")
                                .IsUnique();

                            b1.ToTable("NewsUsers");

                            b1.WithOwner()
                                .HasForeignKey("NewsUserId");
                        });

                    b.Navigation("Email")
                        .IsRequired();
                });

            modelBuilder.Entity("TinyServices.API.Divar.Model.Advertisement", b =>
                {
                    b.Navigation("PropertyValues");
                });

            modelBuilder.Entity("TinyServices.API.Divar.Model.Category", b =>
                {
                    b.Navigation("Properties");
                });

            modelBuilder.Entity("TinyServices.API.Divar.Model.User", b =>
                {
                    b.Navigation("Advertisements");
                });

            modelBuilder.Entity("TinyServices.API.LinkService.Model.Company", b =>
                {
                    b.Navigation("ShortLinks");
                });

            modelBuilder.Entity("TinyServices.API.Linkedin.Model.LinkedinPost", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Likes");
                });

            modelBuilder.Entity("TinyServices.API.Linkedin.Model.LinkedinUser", b =>
                {
                    b.Navigation("Conections");

                    b.Navigation("ConnectionRequests");

                    b.Navigation("Posts");
                });

            modelBuilder.Entity("TinyServices.API.NewsMagazine.Model.News", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("DisLikes");

                    b.Navigation("Likes");

                    b.Navigation("NewsCategories");
                });

            modelBuilder.Entity("TinyServices.API.NewsMagazine.Model.NewsUser", b =>
                {
                    b.Navigation("FavoriteCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
