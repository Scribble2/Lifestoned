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
using System.ComponentModel.DataAnnotations;

namespace DerethForever.Web.Models.Enums
{
    public enum DidPropertyId
    {
        [Display(Name              = "000 - Undef")]
        Undef                      = 0,
        [Display(Name              = "001 - Setup")]
        Setup                      = 1,
        [Display(Name              = "002 - Motion Table")]
        MotionTable                = 2,
        [Display(Name              = "003 - Sound Table")]
        SoundTable                 = 3,
        [Display(Name              = "004 - Combat Table")]
        CombatTable                = 4,
        [Display(Name              = "005 - Quality Filter")]
        QualityFilter              = 5,
        [Display(Name              = "006 - Palette Base")]
        PaletteBase                = 6,
        [Display(Name              = "007 - Clothing Base")]
        ClothingBase               = 7,
        [Display(Name              = "008 - Icon")]
        Icon                       = 8,
        [Display(Name              = "009 - Eyes Texture")]
        EyesTexture                = 9,
        [Display(Name              = "010 - Nose Texture")]
        NoseTexture                = 10,
        [Display(Name              = "011 - Mouth Texture")]
        MouthTexture               = 11,
        [Display(Name              = "012 - Default Eyes Texture")]
        DefaultEyesTexture         = 12,
        [Display(Name              = "013 - Default Nose Texture")]
        DefaultNoseTexture         = 13,
        [Display(Name              = "014 - Default Mouth Texture")]
        DefaultMouthTexture        = 14,
        [Display(Name              = "015 - Hair Palette")]
        HairPalette                = 15,
        [Display(Name              = "016 - Eyes Palette")]
        EyesPalette                = 16,
        [Display(Name              = "017 - Skin Palette")]
        SkinPalette                = 17,
        [Display(Name              = "018 - Head Object")]
        HeadObject                 = 18,
        [Display(Name              = "019 - Activation Animation")]
        ActivationAnimation        = 19,
        [Display(Name              = "020 - Initial Motion")]
        InitMotion                 = 20,
        [Display(Name              = "021 - Activation Sound")]
        ActivationSound            = 21,
        [Display(Name              = "022 - Physics Effect Table")]
        PhysicsEffectTable         = 22,
        [Display(Name              = "023 - Use Sound")]
        UseSound                   = 23,
        [Display(Name              = "024 - Use Target Animation")]
        UseTargetAnimation         = 24,
        [Display(Name              = "025 - Use Target Success Animation")]
        UseTargetSuccessAnimation  = 25,
        [Display(Name              = "026 - Use Target Failure Animation")]
        UseTargetFailureAnimation  = 26,
        [Display(Name              = "027 - Use User Animation")]
        UseUserAnimation           = 27,
        [Display(Name              = "028 - Spell")]
        Spell                      = 28,
        [Display(Name              = "029 - Spell Component")]
        SpellComponent             = 29,
        [Display(Name              = "030 - Physics Script")]
        PhysicsScript              = 30,
        [Display(Name              = "031 - Linked Portal One")]
        LinkedPortalOne            = 31,
        [Display(Name              = "032 - Wielded Treasure Type")]
        WieldedTreasureType        = 32,
        [Display(Name              = "033 - Unknown Guessed Name")]
        UnknownGuessedname         = 33,
        [Display(Name              = "034 - Unknown Guessed Name 2")]
        UnknownGuessedname2        = 34,
        [Display(Name              = "035 - Death Treasure Type")]
        DeathTreasureType          = 35,
        [Display(Name              = "036 - Mutate Filter")]
        MutateFilter               = 36,
        [Display(Name              = "037 - Item Skill Limit")]
        ItemSkillLimit             = 37,
        [Display(Name              = "038 - Use Create Item")]
        UseCreateItem              = 38,
        [Display(Name              = "039 - Death Spell")]
        DeathSpell                 = 39,
        [Display(Name              = "040 - Vendors Class Id")]
        VendorsClassId             = 40,
        [Display(Name              = "041 - Item Specialized Only")]
        ItemSpecializedOnly        = 41,
        [Display(Name              = "042 - House Id")]
        HouseId                    = 42,
        [Display(Name              = "043 - Account House Id")]
        AccountHouseId             = 43,
        [Display(Name              = "044 - Restriction Effect")]
        RestrictionEffect          = 44,
        [Display(Name              = "045 - Creation Mutation Filter")]
        CreationMutationFilter     = 45,
        [Display(Name              = "046 - Tsys Mutation Filter")]
        TsysMutationFilter         = 46,
        [Display(Name              = "047 - Last Portal")]
        LastPortal                 = 47,
        [Display(Name              = "048 - Linked Portal Two")]
        LinkedPortalTwo            = 48,
        [Display(Name              = "049 - Original Portal")]
        OriginalPortal             = 49,
        [Display(Name              = "050 - Icon Overlay")]
        IconOverlay                = 50,
        [Display(Name              = "051 - Icon Overlay Secondary")]
        IconOverlaySecondary       = 51,
        [Display(Name              = "052 - Icon Underlay")]
        IconUnderlay               = 52,
        [Display(Name              = "053 - Augmentation Mutation Filter")]
        AugmentationMutationFilter = 53,
        [Display(Name              = "054 - Augmentation Effect")]
        AugmentationEffect         = 54,
        [Display(Name              = "055 - Proc Spell")]
        ProcSpell                  = 55,
        [Display(Name              = "056 - Augmentation Create Item")]
        AugmentationCreateItem     = 56,
        [Display(Name              = "057 - Alternate Currency")]
        AlternateCurrency          = 57,
        [Display(Name              = "058 - Blue Surge Spell")]
        BlueSurgeSpell             = 58,
        [Display(Name              = "059 - Yellow Surge Spell")]
        YellowSurgeSpell           = 59,
        [Display(Name              = "060 - Red Surge Spell")]
        RedSurgeSpell              = 60,
        [Display(Name              = "061 - Olthoi Death Treasure Type")]
        OlthoiDeathTreasureType    = 61,
        [Display(Name              = "9001 - Hair Texture")]
        HairTexture                = 9001,
        [Display(Name              = "9002 - Default Hair Texture")]
        DefaultHairTexture         = 9002
    }

    public static class PropertyDidExtensions
    {
        public static string GetDescription(this DidPropertyId prop)
        {
            var description = EnumHelper.GetAttributeOfType<DisplayAttribute>(prop);
            return description?.Description ?? prop.ToString();
        }

        public static string GetName(this DidPropertyId prop)
        {
            var description = EnumHelper.GetAttributeOfType<DisplayAttribute>(prop);
            return description?.Name ?? prop.ToString();
        }
    }
}
