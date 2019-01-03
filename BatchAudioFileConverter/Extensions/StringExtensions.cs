using System.IO;
using System.Reflection;

namespace BatchAudioFileConverter.Extensions
{
    public static class StringExtensions
    {
        public static string ToApplicationRelativeAbsolutePath(this string source)
        {
            return Path.Combine(Assembly.GetEntryAssembly().Location, source);
        }
    }
}
