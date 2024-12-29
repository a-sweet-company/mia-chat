﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Mindful_AI_Backend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241229194344_RemoveChatHistory")]
    partial class RemoveChatHistory
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("ChatHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ChatHistory");
                });

            modelBuilder.Entity("Mindful_AI_Backend.Models.Ai", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Ai");
                });

            modelBuilder.Entity("Mindful_AI_Backend.Models.Message", b =>
                {
                    b.Property<int>("messageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ChatHistoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("textmMessage")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("messageId");

                    b.HasIndex("ChatHistoryId");

                    b.ToTable("Message");

                    b.HasDiscriminator().HasValue("Message");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Mindful_AI_Backend.Models.MessageAi", b =>
                {
                    b.HasBaseType("Mindful_AI_Backend.Models.Message");

                    b.Property<int>("aiId")
                        .HasColumnType("INTEGER");

                    b.HasIndex("aiId");

                    b.ToTable("Message");

                    b.HasDiscriminator().HasValue("MessageAi");
                });

            modelBuilder.Entity("Mindful_AI_Backend.Models.MessageUser", b =>
                {
                    b.HasBaseType("Mindful_AI_Backend.Models.Message");

                    b.Property<int>("userId")
                        .HasColumnType("INTEGER");

                    b.HasIndex("userId");

                    b.ToTable("Message");

                    b.HasDiscriminator().HasValue("MessageUser");
                });

            modelBuilder.Entity("ChatHistory", b =>
                {
                    b.HasOne("User", null)
                        .WithMany("ChatHistories")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Mindful_AI_Backend.Models.Message", b =>
                {
                    b.HasOne("ChatHistory", null)
                        .WithMany("Message")
                        .HasForeignKey("ChatHistoryId");
                });

            modelBuilder.Entity("Mindful_AI_Backend.Models.MessageAi", b =>
                {
                    b.HasOne("Mindful_AI_Backend.Models.Ai", "ai")
                        .WithMany()
                        .HasForeignKey("aiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ai");
                });

            modelBuilder.Entity("Mindful_AI_Backend.Models.MessageUser", b =>
                {
                    b.HasOne("User", "user")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("ChatHistory", b =>
                {
                    b.Navigation("Message");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Navigation("ChatHistories");
                });
#pragma warning restore 612, 618
        }
    }
}
