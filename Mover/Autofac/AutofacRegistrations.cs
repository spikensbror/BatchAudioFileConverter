using Autofac;
using Mover.Factories.Adapters;
using Mover.Factories.Adapters.TagLib;
using Mover.Factories.Models;
using Mover.Models;
using Mover.Services;

namespace Mover.Autofac
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
