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

using System.Diagnostics;

namespace Gibbed.Dredmor.Maximap.Game
{
    internal class State
    {
        public Level CurrentLevel;
        public Player Player;

        private State()
        {
        }

        // 1.00? I don't remember
        //private const uint LevelAddress = 0x005482A0;
        //private const uint PlayerAddress = 0x005493D8;

        // 1.0.3.1 (hotfix)
        private const uint LevelAddress = 0x0054C580;
        private const uint PlayerAddress = 0x0054D6C8;

        public static State ReadState()
        {
            var processes = Process.GetProcessesByName("dungeons of dredmor");
            if (processes.Length == 0)
            {
                return null;
            }

            using (var memory = new ProcessMemory())
            {
                if (memory.Open(processes[0]) == false)
                {
                    return null;
                }

                var state = new State();

                var levelAddress = memory.ReadU32(LevelAddress);
                state.CurrentLevel = levelAddress == 0 ?
                    null : Level.Read(memory, levelAddress);

                var playerAddress = memory.ReadU32(PlayerAddress);
                state.Player = playerAddress == 0 ?
                    null : Player.Read(memory, playerAddress);

                return state;
            }
        }
    }
}
