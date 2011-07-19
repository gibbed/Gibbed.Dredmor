/* Copyright (c) 2011 Rick (rick 'at' gibbed 'dot' us)
 * 
 * This software is provided 'as-is', without any express or implied
 * warranty. In no event will the authors be held liable for any damages
 * arising from the use of this software.
 * 
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 * 
 * 1. The origin of this software must not be misrepresented; you must not
 *    claim that you wrote the original software. If you use this software
 *    in a product, an acknowledgment in the product documentation would
 *    be appreciated but is not required.
 * 
 * 2. Altered source versions must be plainly marked as such, and must not
 *    be misrepresented as being the original software.
 * 
 * 3. This notice may not be removed or altered from any source
 *    distribution.
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Gibbed.Helpers;

namespace Gibbed.Dredmor.ConvertSprites
{
    public class SpriteFile
    {
        public int Width;
        public int Height;
        public List<Frame> Frames = new List<Frame>();

        public void Deserialize(Stream input)
        {
            if (input.ReadString(3, Encoding.ASCII) != "SPR")
            {
                throw new FormatException("not a sprite file");
            }

            var frameCount = input.ReadValueU16();
            this.Width = input.ReadValueU16();
            this.Height = input.ReadValueU16();

            this.Frames.Clear();
            for (int i = 0; i < frameCount; i++)
            {                                
                var frame = new Frame();
                frame.Delay = input.ReadValueU16();
                
                frame.Palette = new byte[256 * 3];
                if (input.Read(frame.Palette, 0, frame.Palette.Length) != frame.Palette.Length)
                {
                    throw new FormatException();
                }

                frame.Pixels = new byte[this.Width * this.Height];
                if (input.Read(frame.Pixels, 0, frame.Pixels.Length) != frame.Pixels.Length)
                {
                    throw new FormatException();
                }

                this.Frames.Add(frame);
            }
        }

        public struct Frame
        {
            public int Delay;
            public byte[] Palette;
            public byte[] Pixels;
        }
    }
}
