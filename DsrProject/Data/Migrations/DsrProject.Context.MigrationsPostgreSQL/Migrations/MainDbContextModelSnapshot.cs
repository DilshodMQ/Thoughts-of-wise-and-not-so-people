﻿// <auto-generated />
using System;
using DsrProject.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DsrProject.Context.MigrationsPostgreSQL.Migrations
{
    [DbContext(typeof(MainDbContext))]
    partial class MainDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DsrProject.Context.Entities.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<Guid>("Uid")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("Uid")
                        .IsUnique();

                    b.ToTable("authors", (string)null);
                });

            modelBuilder.Entity("DsrProject.Context.Entities.AuthorDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Family")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId")
                        .IsUnique();

                    b.ToTable("authordetails", (string)null);
                });

            modelBuilder.Entity("DsrProject.Context.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<Guid>("Uid")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("Uid")
                        .IsUnique();

                    b.ToTable("categories", (string)null);
                });

            modelBuilder.Entity("DsrProject.Context.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RespondentId")
                        .HasColumnType("integer");

                    b.Property<int>("ThoughtId")
                        .HasColumnType("integer");

                    b.Property<Guid>("Uid")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RespondentId");

                    b.HasIndex("ThoughtId");

                    b.HasIndex("Uid")
                        .IsUnique();

                    b.ToTable("comments", (string)null);
                });

            modelBuilder.Entity("DsrProject.Context.Entities.Respondent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("Uid")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("Uid")
                        .IsUnique();

                    b.ToTable("respondents", (string)null);
                });

            modelBuilder.Entity("DsrProject.Context.Entities.Thought", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<Guid>("Uid")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("Uid")
                        .IsUnique();

                    b.ToTable("thoughts", (string)null);
                });

            modelBuilder.Entity("DsrProject.Context.Entities.ThoughtCategory", b =>
                {
                    b.Property<int>("ThoughtId")
                        .HasColumnType("integer");

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<Guid>("Uid")
                        .HasColumnType("uuid");

                    b.HasKey("ThoughtId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("thoughts_categories", (string)null);
                });

            modelBuilder.Entity("DsrProject.Context.Entities.ThoughtRespondent", b =>
                {
                    b.Property<int>("ThoughtId")
                        .HasColumnType("integer");

                    b.Property<int>("RespondentId")
                        .HasColumnType("integer");

                    b.HasKey("ThoughtId", "RespondentId");

                    b.HasIndex("RespondentId");

                    b.ToTable("thoughts_respondents", (string)null);
                });

            modelBuilder.Entity("DsrProject.Context.Entities.AuthorDetail", b =>
                {
                    b.HasOne("DsrProject.Context.Entities.Author", "Author")
                        .WithOne("Detail")
                        .HasForeignKey("DsrProject.Context.Entities.AuthorDetail", "AuthorId");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("DsrProject.Context.Entities.Comment", b =>
                {
                    b.HasOne("DsrProject.Context.Entities.Respondent", "Respondent")
                        .WithMany("Comments")
                        .HasForeignKey("RespondentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DsrProject.Context.Entities.Thought", "Thought")
                        .WithMany("Comments")
                        .HasForeignKey("ThoughtId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Respondent");

                    b.Navigation("Thought");
                });

            modelBuilder.Entity("DsrProject.Context.Entities.Thought", b =>
                {
                    b.HasOne("DsrProject.Context.Entities.Author", "Author")
                        .WithMany("Thoughts")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("DsrProject.Context.Entities.ThoughtCategory", b =>
                {
                    b.HasOne("DsrProject.Context.Entities.Category", "Category")
                        .WithMany("ThoughtCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DsrProject.Context.Entities.Thought", "Thought")
                        .WithMany("ThoughtCategories")
                        .HasForeignKey("ThoughtId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Thought");
                });

            modelBuilder.Entity("DsrProject.Context.Entities.ThoughtRespondent", b =>
                {
                    b.HasOne("DsrProject.Context.Entities.Respondent", "Respondent")
                        .WithMany("ThoughtRespondents")
                        .HasForeignKey("RespondentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DsrProject.Context.Entities.Thought", "Thought")
                        .WithMany("ThoughtRespondents")
                        .HasForeignKey("ThoughtId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Respondent");

                    b.Navigation("Thought");
                });

            modelBuilder.Entity("DsrProject.Context.Entities.Author", b =>
                {
                    b.Navigation("Detail");

                    b.Navigation("Thoughts");
                });

            modelBuilder.Entity("DsrProject.Context.Entities.Category", b =>
                {
                    b.Navigation("ThoughtCategories");
                });

            modelBuilder.Entity("DsrProject.Context.Entities.Respondent", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("ThoughtRespondents");
                });

            modelBuilder.Entity("DsrProject.Context.Entities.Thought", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("ThoughtCategories");

                    b.Navigation("ThoughtRespondents");
                });
#pragma warning restore 612, 618
        }
    }
}
