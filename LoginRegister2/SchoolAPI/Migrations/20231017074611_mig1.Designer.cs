﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolAPI.Data.Context;

#nullable disable

namespace SchoolAPI.Migrations
{
    [DbContext(typeof(SchoolDbContext))]
    [Migration("20231017074611_mig1")]
    partial class mig1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SchoolAPI.Data.Entity.Bölüm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Bölümler");
                });

            modelBuilder.Entity("SchoolAPI.Data.Entity.Fakülte", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BolumId")
                        .HasColumnType("int");

                    b.Property<int>("BölümId")
                        .HasColumnType("int");

                    b.Property<string>("FakülteName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BölümId");

                    b.ToTable("Fakülteler");
                });

            modelBuilder.Entity("SchoolAPI.Data.Entity.Fakülte", b =>
                {
                    b.HasOne("SchoolAPI.Data.Entity.Bölüm", "Bölüm")
                        .WithMany("Fakülteler")
                        .HasForeignKey("BölümId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bölüm");
                });

            modelBuilder.Entity("SchoolAPI.Data.Entity.Bölüm", b =>
                {
                    b.Navigation("Fakülteler");
                });
#pragma warning restore 612, 618
        }
    }
}
