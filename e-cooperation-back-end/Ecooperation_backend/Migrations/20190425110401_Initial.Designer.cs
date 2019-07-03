﻿// <auto-generated />
using System;
using Ecooperation_backend.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Ecooperation_backend.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20190425110401_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Ecooperation_backend.Entities.Project", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("city");

                    b.Property<long?>("creatorid");

                    b.Property<string>("description");

                    b.Property<string>("title");

                    b.HasKey("id");

                    b.HasIndex("creatorid");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Ecooperation_backend.Entities.Tag", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("Projectid");

                    b.Property<string>("name");

                    b.HasKey("id");

                    b.HasIndex("Projectid");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Ecooperation_backend.Entities.User", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("Projectid");

                    b.Property<DateTime>("birthDate");

                    b.Property<string>("email");

                    b.Property<string>("firstName");

                    b.Property<string>("gender");

                    b.Property<string>("lastName");

                    b.Property<string>("password");

                    b.Property<string>("token");

                    b.Property<string>("userName");

                    b.HasKey("id");

                    b.HasIndex("Projectid");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Ecooperation_backend.Entities.Project", b =>
                {
                    b.HasOne("Ecooperation_backend.Entities.User", "creator")
                        .WithMany()
                        .HasForeignKey("creatorid");
                });

            modelBuilder.Entity("Ecooperation_backend.Entities.Tag", b =>
                {
                    b.HasOne("Ecooperation_backend.Entities.Project")
                        .WithMany("tags")
                        .HasForeignKey("Projectid");
                });

            modelBuilder.Entity("Ecooperation_backend.Entities.User", b =>
                {
                    b.HasOne("Ecooperation_backend.Entities.Project")
                        .WithMany("participants")
                        .HasForeignKey("Projectid");
                });
#pragma warning restore 612, 618
        }
    }
}