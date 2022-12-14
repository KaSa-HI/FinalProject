// <auto-generated />
using System;
using Merancea.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Merancea.Migrations
{
    [DbContext(typeof(MeranceaContext))]
    partial class MeranceaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Merancea.Models.Button", b =>
                {
                    b.Property<int>("ButtonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ButtonId"));

                    b.Property<string>("Attribute")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DestinationPageId")
                        .HasColumnType("int");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<int>("PageId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ButtonId");

                    b.HasIndex("DestinationPageId");

                    b.HasIndex("PageId");

                    b.ToTable("Buttons");
                });

            modelBuilder.Entity("Merancea.Models.Page", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoverArt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pages");
                });

            modelBuilder.Entity("Merancea.Models.Button", b =>
                {
                    b.HasOne("Merancea.Models.Page", "DestinationPage")
                        .WithMany("DestinationButtons")
                        .HasForeignKey("DestinationPageId");

                    b.HasOne("Merancea.Models.Page", "Page")
                        .WithMany("Buttons")
                        .HasForeignKey("PageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DestinationPage");

                    b.Navigation("Page");
                });

            modelBuilder.Entity("Merancea.Models.Page", b =>
                {
                    b.Navigation("Buttons");

                    b.Navigation("DestinationButtons");
                });
#pragma warning restore 612, 618
        }
    }
}
