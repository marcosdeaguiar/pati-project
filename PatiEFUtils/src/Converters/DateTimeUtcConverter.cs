using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace Pati.EFUtils.Converters
{
    /// <summary>
    /// Makes sure that DateTime is converted to UTC before sending to database.
    /// </summary>
    public class DateTimeUtcConverter : ValueConverter<DateTime, DateTime>
    {
        public DateTimeUtcConverter()
            : base(
                  src => src.Kind == DateTimeKind.Utc ? src : DateTime.SpecifyKind(src, DateTimeKind.Utc),
                  dst => dst.Kind == DateTimeKind.Utc ? dst : DateTime.SpecifyKind(dst, DateTimeKind.Utc))
        {
        }
    }
}
