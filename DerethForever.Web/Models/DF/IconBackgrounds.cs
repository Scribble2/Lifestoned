/*****************************************************************************************
Copyright 2018 Dereth Forever

Permission is hereby granted, free of charge, to any person obtaining a copy of this
software and associated documentation files (the "Software"), to deal in the Software
without restriction, including without limitation the rights to use, copy, modify, merge,
publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons
to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or
substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
DEALINGS IN THE SOFTWARE.
*****************************************************************************************/
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DerethForever.Web.Models.Enums
{
    public class IconBackgrounds
    {
        private ReadOnlyDictionary<ItemType, uint> _iconBackgrounds;

        private Dictionary<ItemType, uint> _backgroundDict = new Dictionary<ItemType, uint>();
    
        public IconBackgrounds()
        {
            _backgroundDict.Add(ItemType.None, 0);
            _backgroundDict.Add(ItemType.MeleeWeapon, 100667851);
            _backgroundDict.Add(ItemType.Armor, 100667855);
            _backgroundDict.Add(ItemType.Clothing, 100667891);
            _backgroundDict.Add(ItemType.Jewelry, 100667861);
            _backgroundDict.Add(ItemType.Creature, 100667857);
            _backgroundDict.Add(ItemType.Food, 100667852);
            _backgroundDict.Add(ItemType.Money, 100667892);
            _backgroundDict.Add(ItemType.Misc, 100667860);
            _backgroundDict.Add(ItemType.MissileWeapon, 100667858);
            _backgroundDict.Add(ItemType.Container, 100667854);
            _backgroundDict.Add(ItemType.Useless, 100667856);
            _backgroundDict.Add(ItemType.Gem, 100667859);
            _backgroundDict.Add(ItemType.SpellComponents, 100667853);
            _backgroundDict.Add(ItemType.Writable, 100667860);
            _backgroundDict.Add(ItemType.Key, 100667860);
            _backgroundDict.Add(ItemType.Caster, 100667860);
            _backgroundDict.Add(ItemType.Portal, 100667860);
            _backgroundDict.Add(ItemType.Lockable, 100667860);
            _backgroundDict.Add(ItemType.PromissoryNote, 100667860);
            _backgroundDict.Add(ItemType.ManaStone, 100667860);
            _backgroundDict.Add(ItemType.Service, 100687395);
            _backgroundDict.Add(ItemType.MagicWieldable, 100667860);
            _backgroundDict.Add(ItemType.CraftCookingBase, 100667860);
            _backgroundDict.Add(ItemType.CraftAlchemyBase, 100667860);
            _backgroundDict.Add(ItemType.CraftFletchingBase, 100667860);
            _backgroundDict.Add(ItemType.NotUsed, 100667860);
            _backgroundDict.Add(ItemType.CraftAlchemyIntermediate, 100667860);
            _backgroundDict.Add(ItemType.CraftFletchingIntermediate, 100667860);
            _backgroundDict.Add(ItemType.LifeStone, 100667860);
            _backgroundDict.Add(ItemType.TinkeringTool, 100667860);
            _backgroundDict.Add(ItemType.TinkeringMaterial, 100667860);
            _backgroundDict.Add(ItemType.Gameboard, 100667860);
            _backgroundDict.Add(ItemType.Default, 100667860);
        }

        public ReadOnlyDictionary<ItemType, uint> Backgrounds
        {
            get
            {
                _iconBackgrounds = new ReadOnlyDictionary<ItemType, uint>(_backgroundDict);
                return _iconBackgrounds;
            }
        }
    }
}
