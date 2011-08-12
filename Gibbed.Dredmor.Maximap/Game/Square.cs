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
using System.Text;

namespace Gibbed.Dredmor.Maximap.Game
{
    internal struct Square
    {
        public Tile Tile; // +00
        public byte Room; // +01
        public ushort Unknown02;
        public uint Unknown04;
        public byte Unknown08;
        public uint Unknown0C;
        public uint Unknown10;
        public uint Unknown14;
        public uint Unknown18;
        public uint Unknown1C;
        public uint Unknown20;
        public uint Unknown24;
        public uint Unknown28;
        public StdList Effects; // +2C (12 bytes)
        public StdList Mines; // +38 (12 bytes)
        public StdList Objects; // +44 (12 bytes)
        public AStarSquare Pathfinding; // +50 (12 bytes)

        public uint? QuestItem;
        public string QuestItemName;
        public uint? BossMonster;
        public string BossMonsterName;

        public bool HasDredmorStatue;
        public bool HasUberChest;

        public static Square Read(byte[] data, int offset, ProcessMemory memory)
        {
            // 1.0.3.1 (hotfix)
            var square = new Square();
            square.Tile = (Tile)data[offset + 0x00];
            square.Room = data[offset + 0x01];
            square.Unknown02 = BitConverter.ToUInt16(data, offset + 0x02);
            square.Unknown04 = BitConverter.ToUInt32(data, offset + 0x04);
            square.Unknown08 = data[offset + 0x08];
            square.Unknown0C = BitConverter.ToUInt32(data, offset + 0x0C);
            square.Unknown10 = BitConverter.ToUInt32(data, offset + 0x10);
            square.Unknown14 = BitConverter.ToUInt32(data, offset + 0x14);
            square.Unknown18 = BitConverter.ToUInt32(data, offset + 0x18);
            square.Unknown1C = BitConverter.ToUInt32(data, offset + 0x1C);
            square.Unknown20 = BitConverter.ToUInt32(data, offset + 0x20);
            square.Unknown24 = BitConverter.ToUInt32(data, offset + 0x24);
            square.Unknown28 = BitConverter.ToUInt32(data, offset + 0x28);
            square.Effects = StdList.Read(data, offset + 0x2C, memory);
            square.Mines = StdList.Read(data, offset + 0x38, memory);
            square.Objects = StdList.Read(data, offset + 0x44, memory);
            square.Pathfinding = AStarSquare.Read(data, offset + 0x50);

            if (square.Unknown02 != 0)
            {
                throw new FormatException();
            }

            square.HasDredmorStatue = false;
            square.HasUberChest = false;
            square.BossMonsterName = null;
            square.QuestItemName = null;

            foreach (var element in square.Objects.Elements)
            {
                var objectType = (ClassVTableAddress)memory.ReadU32(element);
                switch (objectType)
                {
                    case ClassVTableAddress.DredmorStatue:
                    {
                        square.HasDredmorStatue = true;
                        break;
                    }

                    case ClassVTableAddress.UberChest:
                    {
                        square.HasUberChest = true;
                        break;
                    }

                    case ClassVTableAddress.Monster:
                    {
                        if (square.BossMonster.HasValue == false)
                        {
                            if (memory.ReadU32(element + 0x11C) == 1)
                            {
                                square.BossMonster = element;
                                square.BossMonsterName = StdString.Read(memory, element + 0x434);
                            }
                            /*
                            else
                            {
                                var templatePointer = memory.ReadU32(element + 0x388);
                                if (templatePointer == 0)
                                {
                                    name = "Monster";
                                }
                                else
                                {
                                    name = StdString.Read(memory, templatePointer + 0x64);
                                }
                            }
                            */
                        }

                        break;
                    }

                    case ClassVTableAddress.Misc:
                    {
                        if (square.QuestItem.HasValue == false)
                        {
                            // quest item
                            if (memory.ReadU32(element + 0x6C) == 3)
                            {
                                square.QuestItem = element;
                                square.QuestItemName = StdString.Read(memory, element + 0x254);
                            }
                        }

                        break;
                    }
                }
            }

            return square;
        }

        public class AStarSquare
        {
            public uint VTable;
            public uint X;
            public uint Y;

            public static AStarSquare Read(byte[] data, int offset)
            {
                var template = new AStarSquare();
                template.VTable = BitConverter.ToUInt32(data, offset + 0x0);
                template.X = BitConverter.ToUInt32(data, offset + 0x4);
                template.Y = BitConverter.ToUInt32(data, offset + 0x8);
                return template;
            }
        }
    }
}
