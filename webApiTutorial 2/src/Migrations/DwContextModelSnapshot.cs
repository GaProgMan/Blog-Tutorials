using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using webApiTutorial.DatabaseContexts;

namespace webApiTutorial.Migrations
{
    [DbContext(typeof(DwContext))]
    partial class DwContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("webApiTutorial.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BookDescription");

                    b.Property<string>("BookIsbn10");

                    b.Property<string>("BookIsbn13");

                    b.Property<string>("BookName");

                    b.Property<int>("BookOrdinal");

                    b.HasKey("BookId");

                    b.ToTable("Books");
                });
        }
    }
}
