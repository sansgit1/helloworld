using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace helloworld.Infrastructure
{
    /// <summary>
    /// Application constant.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class Constants
    {
#pragma warning disable CA1034 // Nested types should not be visible

        /// <summary>
        /// Environment constants.
        /// </summary>
        public static class Environment
#pragma warning restore CA1034 // Nested types should not be visible
        {
            /// <summary>
            /// Default environment variable name for DutchConnectionString.
            /// </summary>
            public const string DutchConnectionString = "DutchConnectionString";

            /// <summary>
            /// Default environment variable name for ToDoLDBConnectionString.
            /// </summary>
            public const string ToDoLDBConnectionString = "ToDoLDBConnectionString";

            /// <summary>
            /// Default environment variable name for VirtualPath.
            /// </summary>
            public const string VirtualPath = "VirtualPath";
        }
    }
}
