using webApiTutorial.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace webApiTutorial.DatabaseContexts
{
    public static class DatabaseContextExtentsions
    {
        public static bool AllMigrationsApplied(this DwContext context)
        {
            var applied = context.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            var total = context.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);

            return !total.Except(applied).Any();
        }

        public static void EnsureSeedData(this DwContext context)
        {
            if (context.AllMigrationsApplied())
            {
                if(!context.Books.Any())
                {
                    context.Books.AddRange(GenerateAllBookEntiies());
                }

                if (!context.Characters.Any())
                {
                    context.Characters.AddRange(GenerateAllCharacterEntities());
                }

                context.SaveChanges();
            }
        }

        private static List<Book> GenerateAllBookEntiies()
        {
            return new List<Book>() {
                new Book {
                    BookName = "The Colour of Magic",
                    BookOrdinal = 1,
                    BookIsbn10 = "086140324X",
                    BookIsbn13 = "9780552138932",
                    BookDescription = "On a world supported on the back of a giant turtle (sex unknown), a gleeful, explosive, wickedly eccentric expedition sets out. There's an avaricious but inept wizard, a naive tourist whose luggage moves on hundreds of dear little legs, dragons who only exist if you believe in them, and of course THE EDGE of the planet ...",
                }
            };
        }

        private static List<Character> GenerateAllCharacterEntities()
        {
            return new List<Character>() {
                new Character {
                    CharacterName = "Rincewind",
                    CharacterOrdinal = 1
                }, new Character{
                    CharacterName = "Two-flower",
                    CharacterOrdinal = 2
                }, new Character {
                    CharacterName = "Death",
                    CharacterOrdinal = 3
                }
            };
        }
    }
}