# OpenPixelControlSharp
A C# implamentation of an Open Pixel Control Client

To install Open Pixel Control Client, run the following command in the Package Manager Console
```
PM> Install-Package OpenPixelControlSharp.Core.Client
```

```csharp

using System;
using OpenPixelControl;
using System.Threading;

namespace OPCTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Client client = new Client("127.0.0.1", 7890, true, true);
            PixelStrip pixels = new PixelStrip(30);

            var test = new HSLColor(System.Drawing.Color.DarkViolet);
            Console.WriteLine(test.ToRGBString());

            while (true)
            {   
                //Rainbow effect
                for (int i = 0; i <= 360; i = i + 5)
                {
                    var color = new HSLColor(hue: i, saturation: 100, luminosity: 100);
                    pixels.AddFirst(color.ToRgbPixel());
                    client.putPixels(pixels);
                    Thread.Sleep(100);
                }
            }
        }
    }
}
```
