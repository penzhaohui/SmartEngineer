﻿using System;

namespace ECommon.Storage.Exceptions
{
    public class ChunkFileNotExistException : Exception
    {
        public ChunkFileNotExistException(string fileName) : base(string.Format("Chunk file '{0}' not exist.", fileName)) { }
    }
}
