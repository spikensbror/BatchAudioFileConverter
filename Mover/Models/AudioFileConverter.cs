using Mover.Factories.Adapters.TagLib;
using NAudio.Lame;
using NAudio.Wave;
using System.IO;

namespace Mover.Models
{
    class AudioFileConverter : IAudioFileConverter
    {
        public IMetaData MetaData { get; }

        public AudioFileConverter(IMetaData metaData)
        {
            this.MetaData = metaData;
        }

        public void Convert()
        {
            if (File.Exists(this.MetaData.OutputFilePath.Value))
            {
                return;
            }

            var outputTag = new ID3TagData
            {
                Album = this.MetaData.Tag.Album,
                Artist = this.MetaData.Tag.Artist,
                Comment = this.MetaData.Tag.Comment,
                Genre = this.MetaData.Tag.Genre,
                Title = this.MetaData.Tag.Title,
                Track = this.MetaData.Tag.Track,
                Year = this.MetaData.Tag.Year,
            };

            using (var reader = new AudioFileReader(this.MetaData.InputFilePath))
            using (var writer = new LameMP3FileWriter(this.MetaData.OutputFilePath.Value
                , reader.WaveFormat
                , 320
                , outputTag
                ))
            {
                reader.CopyTo(writer);
            }

            using (var outputFile = TagLib.File.Create(this.MetaData.OutputFilePath.Value))
            {
                this.MetaData.Tag.CopyTo(this.MetaData.OutputFilePath.Value);
                outputFile.Save();
            }
        }
    }
}
