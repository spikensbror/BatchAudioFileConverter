﻿using Mover.Models;

namespace Mover.Factories.Models
{
    public interface IMetaDataFactory
    {
        IMetaData Create(string inputBasePath
            , string inputFilePath
            , string outputBasePath
            );
    }
}