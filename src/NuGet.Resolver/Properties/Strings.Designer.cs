// <auto-generated />
namespace NuGet.Resolver
{
    using System.Globalization;
    using System.Reflection;
    using System.Resources;

    internal static class Strings
    {
        private static readonly ResourceManager _resourceManager
            = new ResourceManager("NuGet.Resolver.Strings", typeof(Strings).GetTypeInfo().Assembly);

        /// <summary>
        /// Circular dependency detected '{0}'.
        /// </summary>
        internal static string CircularDependencyDetected
        {
            get { return GetString("CircularDependencyDetected"); }
        }

        /// <summary>
        /// Circular dependency detected '{0}'.
        /// </summary>
        internal static string FormatCircularDependencyDetected(object p0)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("CircularDependencyDetected"), p0);
        }

        /// <summary>
        /// constraint
        /// </summary>
        internal static string DependencyConstraint
        {
            get { return GetString("DependencyConstraint"); }
        }

        /// <summary>
        /// constraint
        /// </summary>
        internal static string FormatDependencyConstraint()
        {
            return GetString("DependencyConstraint");
        }

        /// <summary>
        /// A fatal error occured while resolving dependencies.
        /// </summary>
        internal static string FatalError
        {
            get { return GetString("FatalError"); }
        }

        /// <summary>
        /// A fatal error occured while resolving dependencies.
        /// </summary>
        internal static string FormatFatalError()
        {
            return GetString("FatalError");
        }

        /// <summary>
        /// Unable to find package '{0}'. Existing packages must be restored before performing an install or update.
        /// </summary>
        internal static string MissingDependencyInfo
        {
            get { return GetString("MissingDependencyInfo"); }
        }

        /// <summary>
        /// Unable to find package '{0}'. Existing packages must be restored before performing an install or update.
        /// </summary>
        internal static string FormatMissingDependencyInfo(object p0)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("MissingDependencyInfo"), p0);
        }

        /// <summary>
        /// Unable to resolve dependencies.
        /// </summary>
        internal static string NoSolution
        {
            get { return GetString("NoSolution"); }
        }

        /// <summary>
        /// Unable to resolve dependencies.
        /// </summary>
        internal static string FormatNoSolution()
        {
            return GetString("NoSolution");
        }

        /// <summary>
        /// '{0}' has an additional constraint {1} defined in {2}.
        /// </summary>
        internal static string PackagesConfigConstraint
        {
            get { return GetString("PackagesConfigConstraint"); }
        }

        /// <summary>
        /// '{0}' has an additional constraint {1} defined in {2}.
        /// </summary>
        internal static string FormatPackagesConfigConstraint(object p0, object p1, object p2)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("PackagesConfigConstraint"), p0, p1, p2);
        }

        /// <summary>
        /// Unable to find a version of '{0}' that is compatible with {1}.
        /// </summary>
        internal static string UnableToFindCompatibleVersion
        {
            get { return GetString("UnableToFindCompatibleVersion"); }
        }

        /// <summary>
        /// Unable to find a version of '{0}' that is compatible with {1}.
        /// </summary>
        internal static string FormatUnableToFindCompatibleVersion(object p0, object p1)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("UnableToFindCompatibleVersion"), p0, p1);
        }

        /// <summary>
        /// Unable to resolve dependency '{0}'.
        /// </summary>
        internal static string UnableToResolveDependencyForEmptySource
        {
            get { return GetString("UnableToResolveDependencyForEmptySource"); }
        }

        /// <summary>
        /// Unable to resolve dependency '{0}'.
        /// </summary>
        internal static string FormatUnableToResolveDependencyForEmptySource(object p0)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("UnableToResolveDependencyForEmptySource"), p0);
        }

        /// <summary>
        /// Unable to resolve dependency '{0}'. Source(s) used: {1}.
        /// </summary>
        internal static string UnableToResolveDependencyForMultipleSources
        {
            get { return GetString("UnableToResolveDependencyForMultipleSources"); }
        }

        /// <summary>
        /// Unable to resolve dependency '{0}'. Source(s) used: {1}.
        /// </summary>
        internal static string FormatUnableToResolveDependencyForMultipleSources(object p0, object p1)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("UnableToResolveDependencyForMultipleSources"), p0, p1);
        }

        /// <summary>
        /// Unknown DependencyBehavior value.
        /// </summary>
        internal static string UnknownDependencyBehavior
        {
            get { return GetString("UnknownDependencyBehavior"); }
        }

        /// <summary>
        /// Unknown DependencyBehavior value.
        /// </summary>
        internal static string FormatUnknownDependencyBehavior()
        {
            return GetString("UnknownDependencyBehavior");
        }

        /// <summary>
        /// Unable to resolve dependencies. '{0}' is not compatible with {1}.
        /// </summary>
        internal static string VersionIsNotCompatible
        {
            get { return GetString("VersionIsNotCompatible"); }
        }

        /// <summary>
        /// Unable to resolve dependencies. '{0}' is not compatible with {1}.
        /// </summary>
        internal static string FormatVersionIsNotCompatible(object p0, object p1)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("VersionIsNotCompatible"), p0, p1);
        }

        private static string GetString(string name, params string[] formatterNames)
        {
            var value = _resourceManager.GetString(name);

            System.Diagnostics.Debug.Assert(value != null);

            if (formatterNames != null)
            {
                for (var i = 0; i < formatterNames.Length; i++)
                {
                    value = value.Replace("{" + formatterNames[i] + "}", "{" + i + "}");
                }
            }

            return value;
        }
    }
}
