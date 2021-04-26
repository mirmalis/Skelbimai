﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Skelbimai.Db;

namespace Skelbimai.Db.Migrations
{
    [DbContext(typeof(SkelbimaiContext))]
    [Migration("20210426072101_Added Classifications dbset")]
    partial class AddedClassificationsdbset
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("Skelbimai.Core.Skelbimas", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Body")
                        .HasColumnType("TEXT");

                    b.Property<string>("BodyShort")
                        .HasColumnType("TEXT");

                    b.Property<string>("Header")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Skelbimai");
                });

            modelBuilder.Entity("Skelbimai.Core.SkelbimasClassification", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Action")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SkelbimasID")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("UserID")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("SkelbimasID");

                    b.HasIndex("UserID");

                    b.ToTable("Classifications");
                });

            modelBuilder.Entity("Skelbimai.Core.User", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Skelbimai.Core.SkelbimasClassification", b =>
                {
                    b.HasOne("Skelbimai.Core.Skelbimas", "Skelbimas")
                        .WithMany()
                        .HasForeignKey("SkelbimasID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Skelbimai.Core.User", "User")
                        .WithMany("Groupings")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Skelbimas");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Skelbimai.Core.User", b =>
                {
                    b.Navigation("Groupings");
                });
#pragma warning restore 612, 618
        }
    }
}
