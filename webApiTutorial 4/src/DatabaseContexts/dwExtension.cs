using webApiTutorial.Models;
using webApiTutorial.DatabaseTools;
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
                var dbSeeder = new DatabaseSeeder(context);
                if (!context.Books.Any())
                {
                    dbSeeder.SeedBookEntitiesFromJson();
                }
                if (!context.Characters.Any())
                {
                    dbSeeder.SeedCharacterEntitiesFromJson();
                }
                if (!context.BookCharacters.Any())
                {
                    dbSeeder.SeedBookCharacterEntriesFromJson();
                }

                context.SaveChanges();
            }
        }
    }
}