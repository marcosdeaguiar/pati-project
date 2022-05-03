using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Pati.EFUtils
{
    /// <summary>
    /// Methods to change the default table naming in Entity Framework Core.
    /// </summary>
    public class DbContextNamingHelper
    {
        /// <summary>
        /// Changes the naming schema from default Entity Framework Core to
        /// snake case. I.e "ColumnName" now is column_name.
        /// </summary>
        /// <param name="modelBuilder">The DbContext model builder to have the naming changed.</param>
        public static void NamesToSnakeCase(ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                // Replace table names
                entity.SetTableName(ToSnakeCase(entity.GetTableName()));

                // Replace column names
                foreach (var property in entity.GetProperties())
                {
                    property.SetColumnName(ToSnakeCase(property.Name));
                }

                foreach (var key in entity.GetKeys())
                {
                    key.SetName(ToSnakeCase(key.GetName()));
                }

                foreach (var key in entity.GetForeignKeys())
                {
                    key.SetConstraintName(ToSnakeCase(key.GetConstraintName()));
                }

                foreach (var index in entity.GetIndexes())
                {
                    index.SetDatabaseName(ToSnakeCase(index.GetDatabaseName()));
                }
            }
        }

        /// <summary>
        /// Helper method with the regex to change to snake case.
        /// </summary>
        /// <param name="input">Name to be changed to snake case.</param>
        /// <returns>Snake case version of the name.</returns>
        private static string ToSnakeCase(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            var startUnderscores = Regex.Match(input, @"^_+");
            return startUnderscores + Regex.Replace(input, @"([a-z0-9])([A-Z])", "$1_$2").ToLower();
        }
    }
}
