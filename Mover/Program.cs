using Autofac;
using Mover.Autofac;
using Mover.Extensions;
using Mover.Factories.Models;
using Mover.Models;
using Mover.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Mover
{
    class Program
    {
        private static object ConsoleWriteLock { get; } = new object();

        static void Main(string[] args)
        {
            InternalMain(args);

#if DEBUG
            GC.Collect();
            Console.ReadKey(true);
#endif
        }

        static void InternalMain(string[] args)
        {
            if (args.Length != 2)
            {
                WriteUsage();
                return;
            }

            var inputPath = args[0].ToApplicationRelativeAbsolutePath();
            var outputPath = args[1].ToApplicationRelativeAbsolutePath();

            using (var bootstrapper = new AutofacBootstrapper())
            {
                var context = bootstrapper.GetContext();

                var directoryService = context.Resolve<IDirectoryService>();
                var metaDataFactory = context.Resolve<IMetaDataFactory>();
                var audioFileService = context.Resolve<IAudioFileService>();
                var metaDataQueueFactory = context.Resolve<IMetaDataQueueFactory>();

                // Create input path traverser and replicate the input directory
                // structure into the output directory.
                var inputPathTraverser = directoryService.Traverse(inputPath);
                directoryService.PrepareReplication(inputPath, outputPath).Replicate();

                // Create metadata for each .m4a file in the input directory.
                var inputMetaData = inputPathTraverser
                    .SelectMany(di => di.GetFiles("*.m4a"))
                    .Select(f => metaDataFactory.Create(inputPath, f.FullName, outputPath))
                    .ToArray();

                // Create the metadata queue.
                var metaDataQueue = metaDataQueueFactory.Create(inputMetaData);

                // Run conversion.
                Task.WaitAll(
                        ConvertRoutine(audioFileService, metaDataQueue),
                        ConvertRoutine(audioFileService, metaDataQueue),
                        ConvertRoutine(audioFileService, metaDataQueue),
                        ConvertRoutine(audioFileService, metaDataQueue)
                    );

                Console.WriteLine("Conversion has been completed.");
            }
        }

        static async Task ConvertRoutine(IAudioFileService audioFileService
            , IMetaDataQueue queue
            )
        {
            await Task.Factory.StartNew(() =>
            {
                while (!queue.IsEmpty())
                {
                    var container = queue.Dequeue();
                    lock (ConsoleWriteLock)
                    {
                        Console.WriteLine("Converting: {0}", container.InputFilePath);
                    }

                    audioFileService.PrepareConversion(container).Convert();
                }
            }, TaskCreationOptions.LongRunning);
        }

        static void WriteUsage()
        {
            Console.WriteLine("Mover.exe <input-path> <output-path>");
        }
    }
}
