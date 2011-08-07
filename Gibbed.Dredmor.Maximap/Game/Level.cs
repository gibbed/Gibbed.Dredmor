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
using System.Text;

namespace Gibbed.Dredmor.Maximap.Game
{
    internal class Level
    {
        private Level()
        {
        }

        public int Floor { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public Square[,] Squares { get; private set; }
        public List<string> RoomNames = new List<string>();

        // 1.0.3.1 (hotfix)
        private const uint OffsetRoomNamesStart = 0x14;
        private const uint OffsetRoomNamesEnd = 0x18;
        private const uint OffsetSquares = 0x00;
        private const uint OffsetWidth = 0x50;
        private const uint OffsetHeight = 0x54;
        private const uint OffsetLevel = 0x6C;

        public static Level Read(ProcessMemory memory, uint baseAddress)
        {
            var level = new Level();
            level.Floor = memory.ReadS32(baseAddress + OffsetLevel);
            level.Width = memory.ReadS32(baseAddress + OffsetWidth);
            level.Height = memory.ReadS32(baseAddress + OffsetHeight);

            var roomNamesStartAddress = memory.ReadU32(baseAddress + OffsetRoomNamesStart);
            var roomNamesEndAddress = memory.ReadU32(baseAddress + OffsetRoomNamesEnd);

            var roomNameCount = (roomNamesEndAddress - roomNamesStartAddress) / 28;
            var roomNameData = new byte[0x1C * roomNameCount];
            if (memory.Read(roomNamesStartAddress, ref roomNameData) != roomNameData.Length)
            {
                throw new InvalidOperationException();
            }

            level.RoomNames.Clear();
            for (int i = 0; i < roomNameData.Length; i += 0x1C)
            {
                var roomNameLength = BitConverter.ToInt32(roomNameData, i + 0x14);

                if (roomNameLength < 16)
                {
                    level.RoomNames.Add(Encoding.ASCII.GetString(roomNameData, i + 4, roomNameLength));
                }
                else
                {
                    var roomName = new byte[roomNameLength];
                    if (memory.Read(BitConverter.ToUInt32(roomNameData, i + 0x04), ref roomName) != roomName.Length)
                    {
                        throw new InvalidOperationException();
                    }
                    level.RoomNames.Add(Encoding.ASCII.GetString(roomName, 0, roomNameLength));
                }
            }

            var tileAddress = memory.ReadU32(baseAddress + OffsetSquares);

            // read all tile data at once instead of one tile at a time (speed!)
            var tileData = new byte[level.Width * level.Height * 0x5C];
            if (memory.Read(tileAddress, ref tileData) != tileData.Length)
            {
                throw new InvalidOperationException();
            }

            level.Squares = new Square[level.Width, level.Height];
            for (int y = 0; y < level.Height; y++)
            {
                for (int x = 0; x < level.Width; x++)
                {
                    level.Squares[x, y] = Square.Read(tileData, ((y * level.Width) + x) * 0x5C, memory);
                }
            }

            return level;
        }
    }
}
