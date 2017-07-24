using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RecyclableStream.Example
{
    public class RecyclableStreamUse
    {
        static RecyclableMemoryStreamManager<int> streamCache = new RecyclableMemoryStreamManager<int>();

        public void Test1()
        {
            MemoryStream<int> stream = streamCache.GetStream(Guid.NewGuid().ToString(), 100);

            
        }

    }
}
