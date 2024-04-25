using System;

namespace Pati.Core
{
    /// <summary>
    /// Attribute to be used for the model binder not to trim the string.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class NoTrimAttribute : Attribute
    {
    }
}
