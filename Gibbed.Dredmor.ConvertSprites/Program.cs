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
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
using NDesk.Options;

namespace Gibbed.Dredmor.ConvertSprites
{
    internal class Program
    {
        private static string GetExecutableName()
        {
            return Path.GetFileName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
        }

        public static void Main(string[] args)
        {
            bool showHelp = false;

            OptionSet options = new OptionSet()
            {
                {
                    "h|help",
                    "show this message and exit", 
                    v => showHelp = v != null
                },
            };

            List<string> extras;

            try
            {
                extras = options.Parse(args);
            }
            catch (OptionException e)
            {
                Console.Write("{0}: ", GetExecutableName());
                Console.WriteLine(e.Message);
                Console.WriteLine("Try `{0} --help' for more information.", GetExecutableName());
                return;
            }

            if (showHelp == true ||
                extras.Count < 1 ||
                extras.Count > 2)
            {
                Console.WriteLine("Usage: {0} [OPTIONS]+ input [output]", GetExecutableName());
                Console.WriteLine();
                Console.WriteLine("Options:");
                options.WriteOptionDescriptions(Console.Out);
                return;
            }

            string inputBasePath = extras[0];
            string outputBasePath = extras.Count > 1 ? extras[1] : inputBasePath + "_converted";

            if (inputBasePath.EndsWith("\\") == false)
            {
                inputBasePath += "\\";
            }

            foreach (var inputPath in Directory.GetFiles(inputBasePath, "*.spr", SearchOption.AllDirectories))
            {
                var sprite = new SpriteFile();
                using (var input = File.OpenRead(inputPath))
                {
                    sprite.Deserialize(input);
                }

                var partPath = inputPath.Substring(inputBasePath.Length);
                Console.WriteLine(partPath);
                
                var outputPath = Path.ChangeExtension(Path.Combine(outputBasePath, partPath), ".xml");

                if (File.Exists(outputPath) == true)
                {
                    continue;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                var baseFramePath = Path.ChangeExtension(outputPath, null);

                var settings = new XmlWriterSettings() { Indent = true, Encoding = Encoding.ASCII };
                using (var writer = XmlWriter.Create(outputPath, settings))
                {
                    var numberLength = sprite.Frames.Count.ToString().Length;

                    writer.WriteStartDocument();
                    writer.WriteStartElement("sprite");

                    var area = new Rectangle(0, 0, sprite.Width, sprite.Height);

                    for (int i = 0; i < sprite.Frames.Count; i++)
                    {
                        var framePath = string.Format("{0}_{1}.png", baseFramePath, i.ToString().PadLeft(numberLength, '0'));
                        var frame = sprite.Frames[i];

                        writer.WriteStartElement("frame");
                        writer.WriteAttributeString("delay", frame.Delay.ToString());
                        writer.WriteValue(Path.GetFileName(framePath));
                        writer.WriteEndElement();

                        using (var bitmap = new Bitmap(sprite.Width, sprite.Height, PixelFormat.Format8bppIndexed))
                        {
                            var palette = bitmap.Palette;
                            for (int j = 0, k = 0; j < 256; j++, k += 3)
                            {
                                palette.Entries[j] = Color.FromArgb(
                                    frame.Palette[k + 0],
                                    frame.Palette[k + 1],
                                    frame.Palette[k + 2]);
                            }
                            palette.Entries[0] = Color.FromArgb(
                                0,
                                palette.Entries[0].R,
                                palette.Entries[0].G,
                                palette.Entries[0].B);
                            bitmap.Palette = palette;

                            var data = bitmap.LockBits(area, ImageLockMode.WriteOnly, bitmap.PixelFormat);
                            var scan = data.Scan0;
                            for (int o = 0; o < sprite.Height * sprite.Width; o += sprite.Width)
                            {
                                Marshal.Copy(frame.Pixels, o, scan, sprite.Width);
                                scan += data.Stride;
                            }
                            bitmap.UnlockBits(data);

                            bitmap.Save(framePath, ImageFormat.Png);
                        }
                        
                    }

                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
            }
        }
    }
}
