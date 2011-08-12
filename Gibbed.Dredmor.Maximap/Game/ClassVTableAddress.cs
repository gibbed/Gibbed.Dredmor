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

namespace Gibbed.Dredmor.Maximap.Game
{
    // 1.0.3.1 (hotfix)
    internal enum ClassVTableAddress : uint
    {
        Anvil            = 0x005103F4, // ??_7Anvil@@6B@             GameObj, 0x70 bytes
        Armour           = 0x0051069C, // ??_7Armour@@6B@            Item, 0x328 bytes
        BBQ              = 0x00510E74, // ??_7BBQ@@6B@               GameObj, 0x6C bytes
        Blocker          = 0x00511ABC, // ??_7Blocker@@6B@           GameObj, 0xEC bytes
        Bookshelf        = 0x0051121C, // ??_7Bookshelf@@6B@         GameObj, 0x88 bytes
        Breakable        = 0x005119EC, // ??_7Breakable@@6B@         GameObj, 0xAC bytes
        Chest            = 0x00511CC4, // ??_7Chest@@6B@             GameObj, 0x74 bytes
        Coffin           = 0x00511FAC, // ??_7Coffin@@6B@            GameObj, 0x68 bytes
        CraftTable       = 0x005130CC, // ??_7CraftTable@@6B@        GameObj, 0x6C bytes
        Dirt             = 0x005143E4, // ??_7Dirt@@6B@              GameObj, 0x70 bytes
        Dispenser        = 0x0051113C, // ??_7Dispenser@@6B@         GameObj, 0xAC bytes
        Door             = 0x005144B4, // ??_7Door@@6B@              GameObj, 0x8C bytes
        DredmorStatue    = 0x0051176C, // ??_7DredmorStatue@@6B@     GameObj, 0x6C bytes
        Engraving        = 0x00511C0C, // ??_7Engraving@@6B@         GameObj, 0x104 bytes
        EvilChest        = 0x0051494C, // ??_7EvilChest@@6B@         GameObj, 0x6C bytes
        Food             = 0x00514D24, // ??_7Food@@6B@              Item, 0x24C bytes
        Fountain         = 0x00514E64, // ??_7Fountain@@6B@          GameObj, 0x6C bytes
        Freezer          = 0x00514F94, // ??_7Freezer@@6B@           GameObj, 0x6C bytes
        GameObj          = 0x00515154, // ??_7GameObj@@6B@           Serializable, abstract class?
        Gem              = 0x00515204, // ??_7Gem@@6B@               Item, 0x250 bytes
        Hittable         = 0x00515644, // ??_7Hittable@@6B@          GameObj, may be 0x324 bytes
        Item             = 0x00515E14, // ??_7Item@@6B@              GameObj, abstract class?
        Lever            = 0x00516A0C, // ??_7Lever@@6B@             GameObj, 0x7C bytes
        LutefiskStatue   = 0x00516CBC, // ??_7LutefiskStatue@@6B@    GameObj, 0x6C bytes
        Misc             = 0x0051610C, // ??_7Misc@@6B@              Item, 0x274 bytes
        Monster          = 0x00518A64, // ??_7Monster@@6B@           Hittable, 0x46C bytes
        Mushroom         = 0x005192FC, // ??_7Mushroom@@6B@          Item, 0x254 bytes
        Pedestal         = 0x005196A4, // ??_7Pedestal@@6B@          GameObj, 0xA0 bytes
        Player           = 0x0051A31C, // ??_7Player@@6B@            Hittable, 0x838 bytes
        Potion           = 0x0051B1CC, // ??_7Potion@@6B@            Item, 0x26C bytes
        QuestBlocker     = 0x0051B2EC, // ??_7QuestBlocker@@6B@      GameObj, 0x70 bytes
        Reagent          = 0x0051B64C, // ??_7Reagent@@6B@           Item, 0x250 bytes
        Rift             = 0x0051C224, // ??_7Rift@@6B@              GameObj, 0x6C bytes
        RingOfProtection = 0x005118EC, // ??_7RingOfProtection@@6B@  GameObj, 0x78 bytes
        Roots            = 0x0051E03C, // ??_7Roots@@6B@             GameObj, 0x6C bytes
        ShopPedestal     = 0x0051C68C, // ??_7ShopPedestal@@6B@      GameObj, 0x6C bytes
        Shopkeeper       = 0x0051C76C, // ??_7Shopkeeper@@6B@        Monster, 0x48A bytes
        SignPost         = 0x0051CD7C, // ??_7SignPost@@6B@          GameObj, 0x180 bytes
        SkillItem        = 0x0051CE34, // ??_7SkillItem@@6B@         Item, 0x254 bytes
        Smoke            = 0x0051DF74, // ??_7Smoke@@6B@             GameObj, 0x6C bytes
        Splat            = 0x00511814, // ??_7Splat@@6B@             GameObj, 0x70 bytes
        Stairs           = 0x0051EC24, // ??_7Stairs@@6B@            GameObj, 0x6C bytes
        Statue           = 0x0051ED4C, // ??_7Statue@@6B@            GameObj, 0x6C bytes
        Teleporter       = 0x0051FABC, // ??_7Teleporter@@6B@        Teleporter, 0x70 bytes
        Toolkit          = 0x00512E34, // ??_7Toolkit@@6B@           Item, 0x254 bytes
        Trap             = 0x005205E4, // ??_7Trap@@6B@              Item, 0x264 bytes
        UberChest        = 0x00511DAC, // ??_7UberChest@@6B@         GameObj, 0x70 bytes
        Wand             = 0x005209EC, // ??_7Wand@@6B@              Item, 0x258 bytes
        Weapon           = 0x00520BD4, // ??_7Weapon@@6B@            Item, 0x31C bytes
        Zorkmids         = 0x00515FFC, // ??_7Zorkmids@@6B@          Item, 0x250 bytes
    }
}
