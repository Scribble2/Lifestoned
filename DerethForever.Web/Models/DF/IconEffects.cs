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
using DerethForever.Web.Models.Enums;

namespace DerethForever.Web.Models.DF
{
    public class IconEffects
    {
        private ReadOnlyDictionary<IconEffectType, uint> _iconEffects;

        private Dictionary<IconEffectType, uint> _effectsDict = new Dictionary<IconEffectType, uint>();

        public IconEffects()
        {
            _effectsDict.Add(IconEffectType.Magical, 100667850);
            _effectsDict.Add(IconEffectType.Poisoned, 100667846);
            _effectsDict.Add(IconEffectType.BoostHealth, 100670213);
            _effectsDict.Add(IconEffectType.BoostMana, 100667850);
            _effectsDict.Add(IconEffectType.BoostStamina, 100670214);
            _effectsDict.Add(IconEffectType.Fire, 100670254);
            _effectsDict.Add(IconEffectType.Lightning, 100670253);
            _effectsDict.Add(IconEffectType.Frost, 100670255);
            _effectsDict.Add(IconEffectType.Acid, 100670252);
            _effectsDict.Add(IconEffectType.Bludgeoning, 100676547);
            _effectsDict.Add(IconEffectType.Slashing, 100676546);
            _effectsDict.Add(IconEffectType.Piercing, 100676548);
            _effectsDict.Add(IconEffectType.Nether, 100667845); // MISSING?! TODO: Find actual value
            _effectsDict.Add(IconEffectType.Default, 100667845);
        }

        public ReadOnlyDictionary<IconEffectType, uint> Effects
        {
            get
            {
                _iconEffects = new ReadOnlyDictionary<IconEffectType, uint>(_effectsDict);
                return _iconEffects;
            }
        }
    }
}
