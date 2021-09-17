﻿// <auto-generated />
using FullStackDeveloperAssessment.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FullStackDeveloperAssessment.Migrations
{
    [DbContext(typeof(FullStackDeveloperAssessmentContext))]
    partial class FullStackDeveloperAssessmentContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FullStackAPIAssessment.Models.ImageModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("height")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("meta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("prefix")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("suffix")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("venueid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("width")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("ImageModel");
                });

            modelBuilder.Entity("FullStackAPIAssessment.Models.LocationModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LocationId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lng")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("meta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("photoid")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("LocationModel");
                });
#pragma warning restore 612, 618
        }
    }
}
