using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using webApiTutorial.DatabaseContexts;

namespace webApiTutorial.Migrations
{
    [DbContext(typeof(DwContext))]
    [Migration("20170212181834_AddedCharacterModel")]
    partial class AddedCharacterModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("webApiTutorial.Models.Character", b =>
                {
                    b.Property<int>("CharacterId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CharacterName");

                    b.Property<int>("CharacterOrdinal");

                    b.HasKey("CharacterId");

                    b.ToTable("Characters");
                });
        }
    }
}
