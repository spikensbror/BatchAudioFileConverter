namespace BatchAudioFileConverter.Models
{
    public interface IPathTransformer
    {
        string Transform(string inputBasePath, string inputPath, string outputBasePath);
        string TransformToFlatOutput(string inputBasePath, string inputPath, string outputPath, bool removeExtension);
    }
}