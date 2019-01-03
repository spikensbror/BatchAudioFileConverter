using Autofac;
using IWshRuntimeLibrary;
using Mover.Adapters;
using Mover.Autofac;
using Mover.Extensions;
using Mover.Models;
using Mover.Services;
using System;
using System.IO;
using System.Linq;

namespace Shortcutter
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
                var pathTransformer = context.Resolve<IPathTransformer>();

                // Create input path traverser and replicate the input directory
                // structure into the output directory.
                var inputPathTraverser = directoryService.Traverse(inputPath);

                var shortcutEmbryos = inputPathTraverser
                    .SelectMany(di => di
                        .GetFiles("*.mp3")
                        .Select(fi => new ShortcutEmbryo(pathTransformer, fi, inputPath, outputPath))
                    )
                    .ToArray();

                foreach (var embryo in shortcutEmbryos)
                {
                    Console.WriteLine();
                    Console.WriteLine("Input file: {0}", embryo.FileInfo.FullName);
                    Console.WriteLine("Output shortcut: {0}", embryo.OutputFilePath);
                    CreateShortcut(embryo.OutputName, embryo.OutputFilePath, embryo.FileInfo.FullName);
                }

                Console.WriteLine("Shortcuts have been created.");
            }
        }

        static void WriteUsage()
        {
            Console.WriteLine("Shortcutter.exe <input-path> <output-path>");
        }

        static void CreateShortcut(string name
            , string path
            , string targetPath
            )
        {
            var shell = new WshShell();
            var shortcut = (IWshShortcut)shell.CreateShortcut(path);
            shortcut.TargetPath = targetPath;
            shortcut.Save();
        }

        struct ShortcutEmbryo
        {
            public IPathTransformer PathTransformer { get; }
            public IFileInfo FileInfo { get; }
            public string InputBasePath { get; }
            public string OutputPath { get; }
            public string OutputFilePath => this.CreateOutputFilePath();
            public string OutputName => Path.GetFileNameWithoutExtension(this.OutputFilePath);

            public ShortcutEmbryo(IPathTransformer pathTransformer
                , IFileInfo fileInfo
                , string inputBasePath
                , string outputPath
                )
            {
                this.PathTransformer = pathTransformer;
                this.FileInfo = fileInfo;
                this.InputBasePath = inputBasePath;
                this.OutputPath = outputPath;
            }

            private string CreateOutputFilePath()
            {
                return this.PathTransformer
                    .TransformToFlatOutput(this.InputBasePath
                        , this.FileInfo.FullName
                        , this.OutputPath
                        , true
                    ) + ".lnk";
            }
        }
    }
}
