using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace Pati.EFUtils.Converters
{
    /// <summary>
    /// Makes sure that DateTime is converted to Local before sending to database.
    /// </summary>
    public class DateTimeLocalConverter : ValueConverter<DateTime, DateTime>
    {
        public DateTimeLocalConverter()
            : base(
                  src => src.Kind == DateTimeKind.Local ? src : DateTime.SpecifyKind(src, DateTimeKind.Local),
                  dst => dst.Kind == DateTimeKind.Local ? dst : DateTime.SpecifyKind(dst, DateTimeKind.Local))
        {
        }
    }
}
