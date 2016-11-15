using System;
using System.Collections.Generic;
using System.Drawing;

namespace OpenPixelControl
{
    public class PixelStrip : LinkedList<Pixel>
    {
        private readonly object syncObject = new object();

        public int Size { get; private set; }

        public PixelStrip(int size)
        {
            Size = size;
            for (int i = 0; i < Size; i++)
            {
                AddFirst(0, 0, 0);
            }
        }

        public void AddFirst(byte obj, byte obj2, byte obj3)
        {
            base.AddFirst(new Pixel(obj, obj2, obj3));
            lock (syncObject)
            {
                while (base.Count > Size)
                {
                    base.RemoveLast();
                }
            }
        }

        public void AddLast(byte obj, byte obj2, byte obj3)
        {
            base.AddLast(new Pixel(obj, obj2, obj3));
            lock (syncObject)
            {
                while (base.Count > Size)
                {
                    base.RemoveFirst();
                }
            }
        }

        public void SetColor(Color color)
        {
            var colour = new HSLColor(color);
            for (int i = 0; i < Size; i++)
            {
                AddFirst(colour.ToRgbPixel());
            }
        }

        public void SetColor(byte red, byte green, byte blue)
        {
            var pixel = new Pixel(red, green, blue);
            for (int i = 0; i < Size; i++)
            {
                AddFirst(pixel);
            }
        }

        public void SetColor(int hue, int saturation, int luminosity)
        {
            var color = new HSLColor(hue: hue, saturation: saturation, luminosity: luminosity);
            for (int i = 0; i < Size; i++)
            {
                AddFirst(color.ToRgbPixel());
            }

        }

    }

    public class Pixel : Tuple<byte, byte, byte>
    {
        public byte r;
        public byte g;
        public byte b;

        public Pixel(byte red, byte green, byte blue) : base(red, green, blue)
        {
            r = red;
            g = green;
            b = blue;
        }
    }
}
