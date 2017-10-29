﻿using System.IO;

namespace ECommon.Storage
{
    internal class ReaderWorkItem
    {
        public readonly Stream Stream;
        public readonly BinaryReader Reader;

        public ReaderWorkItem(Stream stream, BinaryReader reader)
        {
            Stream = stream;
            Reader = reader;
        }
    }
}
