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
    internal static class StdString
    {
        public static string Read(ProcessMemory memory, uint baseAddress)
        {
            var length = memory.ReadU32(baseAddress + 0x10);

            uint valueAddress;
            if (length < 16)
            {
                valueAddress = baseAddress + 0x00;
            }
            else
            {
                valueAddress = memory.ReadU32(baseAddress + 0x00);
            }

            var valueBytes = new byte[length];
            if (memory.Read(valueAddress, ref valueBytes) != valueBytes.Length)
            {
                throw new InvalidOperationException();
            }

            return Encoding.ASCII.GetString(valueBytes, 0, valueBytes.Length);
        }
    }
}
