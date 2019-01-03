using System.IO;

namespace BatchAudioFileConverter.Models
{
    public class PathTransformer : IPathTransformer
    {
        public string Transform(string inputBasePath
            , string inputPath
            , string outputBasePath
            )
        {
            return Path.Combine(outputBasePath
                , inputPath
                    .Replace(inputBasePath, string.Empty)
                    .Trim(Path.DirectorySeparatorChar)
                );
        }

        public string TransformToFlatOutput(string inputBasePath
            , string inputPath
            , string outputPath
            , bool removeExtension
            )
        {
            var outputFileName = inputPath
                .Replace(inputBasePath, string.Empty)
                .Trim('\\')
                .Replace('\\', '_');

            if (removeExtension)
            {
                outputFileName = Path.GetFileNameWithoutExtension(outputFileName);
            }

            return Path.Combine(outputPath, outputFileName);
        }
    }
}
