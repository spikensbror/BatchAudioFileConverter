using Autofac;
using BatchAudioFileConverter.Factories.Adapters;
using BatchAudioFileConverter.Factories.Adapters.TagLib;
using BatchAudioFileConverter.Factories.Models;
using BatchAudioFileConverter.Models;
using BatchAudioFileConverter.Services;

namespace BatchAudioFileConverter.Autofac
{
    static class AutofacRegistrations
    {
        public static void Register(ContainerBuilder builder)
        {
            // Factories.Adapters

            builder.RegisterType<DirectoryInfoAdapterFactory>()
                .As<IDirectoryInfoFactory>()
                .SingleInstance();

            builder.RegisterType<FileInfoAdapterFactory>()
                .As<IFileInfoFactory>()
                .SingleInstance();

            // Factories.Adapters.TagLib

            builder.RegisterType<TagAdapterFactory>()
                .As<ITagFactory>();

            // Factories.Models

            builder.RegisterType<MetaDataFactory>()
                .As<IMetaDataFactory>()
                .SingleInstance();

            builder.RegisterType<MetaDataQueueFactory>()
                .As<IMetaDataQueueFactory>()
                .SingleInstance();

            // Models

            builder.RegisterType<PathTransformer>()
                .As<IPathTransformer>()
                .SingleInstance();

            // Services

            builder.RegisterType<AudioFileService>()
                .As<IAudioFileService>()
                .SingleInstance();

            builder.RegisterType<DirectoryService>()
                .As<IDirectoryService>()
                .SingleInstance();
        }
    }
}
