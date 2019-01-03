using TagLib;

namespace BatchAudioFileConverter.Adapters.TagLib
{
    class TagAdapter : ITag
    {
        public Tag Tag { get; }

        public string Album => this.Tag.Album;
        public string Artist => this.Tag.JoinedAlbumArtists;
        public string Comment => this.Tag.Comment;
        public string Genre => this.Tag.JoinedGenres;
        public string Title => this.Tag.Title;
        public string Track => this.Tag.Track.ToString();
        public string Year => this.Tag.Year.ToString();
        public string Disc => this.Tag.Disc.ToString();

        public TagAdapter(Tag tag)
        {
            this.Tag = tag;
        }

        public void CopyTo(string targetFilePath)
        {
            using (var outputFile = File.Create(targetFilePath))
            {
                this.Tag.CopyTo(outputFile.Tag, true);
                outputFile.Save();
            }
        }
    }
}
