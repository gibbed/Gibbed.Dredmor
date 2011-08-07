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

namespace Gibbed.Dredmor.Maximap.Game
{
    internal class StdVector
    {
        public uint Unknown0;
        public uint Unknown4;
        public uint Unknown8;

        public static StdVector Read(byte[] data, int offset)
        {
            var vector = new StdVector();
            vector.Unknown0 = BitConverter.ToUInt32(data, offset + 0x0);
            vector.Unknown4 = BitConverter.ToUInt32(data, offset + 0x4);
            vector.Unknown8 = BitConverter.ToUInt32(data, offset + 0x8);
            return vector;
        }
    }
}
