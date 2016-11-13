# OpenPixelControlSharp
A C# implamentation of an Open Pixel Control Client

To install Open Pixel Control Client, run the following command in the Package Manager Console
```
PM> Install-Package OpenPixelControlSharp.Core.Client
```

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenPixelControl;

namespace OpcExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Client client = new Client("127.0.0.1", 7890, true, true);
            PixelStrip pixels = new PixelStrip(30);
            client.putPixels(pixels);
        }
    }
}
```
