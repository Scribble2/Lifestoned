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

namespace Lifestoned.DataModel.Shared
{
    public enum IidPropertyId
    {
        [Display(Name                    = "000 - Undef")]
        Undef                            = 0,
        [Display(Name                    = "001 - Owner")]
        Owner                            = 1,
        [Display(Name                    = "002 - Container")]
        Container                        = 2,
        [Display(Name                    = "003 - Wielder")]
        Wielder                          = 3,
        [Display(Name                    = "004 - Freezer")]
        Freezer                          = 4,
        [Display(Name                    = "005 - Viewer")]
        Viewer                           = 5,
        [Display(Name                    = "006 - Generator")]
        Generator                        = 6,
        [Display(Name                    = "007 - Scribe")]
        Scribe                           = 7,
        [Display(Name                    = "008 - Current Combat Target")]
        CurrentCombatTarget              = 8,
        [Display(Name                    = "009 - Current Enemy")]
        CurrentEnemy                     = 9,
        [Display(Name                    = "010 - Projectile Launcher")]
        ProjectileLauncher               = 10,
        [Display(Name                    = "011 - Current Attacker")]
        CurrentAttacker                  = 11,
        [Display(Name                    = "012 - Current Damager")]
        CurrentDamager                   = 12,
        [Display(Name                    = "013 - Current Follow Target")]
        CurrentFollowTarget              = 13,
        [Display(Name                    = "014 - Current Appraisal Target")]
        CurrentAppraisalTarget           = 14,
        [Display(Name                    = "015 - Current Fellowship Appraisal Target")]
        CurrentFellowshipAppraisalTarget = 15,
        [Display(Name                    = "016 - Activation Target")]
        ActivationTarget                 = 16,
        [Display(Name                    = "017 - Creator")]
        Creator                          = 17,
        [Display(Name                    = "018 - Victim")]
        Victim                           = 18,
        [Display(Name                    = "019 - Killer")]
        Killer                           = 19,
        [Display(Name                    = "020 - Vendor")]
        Vendor                           = 20,
        [Display(Name                    = "021 - Customer")]
        Customer                         = 21,
        [Display(Name                    = "022 - Bonded")]
        Bonded                           = 22,
        [Display(Name                    = "023 - Wounder")]
        Wounder                          = 23,
        [Display(Name                    = "024 - Allegiance")]
        Allegiance                       = 24,
        [Display(Name                    = "025 - Patron")]
        Patron                           = 25,
        [Display(Name                    = "026 - Monarch")]
        Monarch                          = 26,
        [Display(Name                    = "027 - Combat Target")]
        CombatTarget                     = 27,
        [Display(Name                    = "028 - Health Query Target")]
        HealthQueryTarget                = 28,
        [Display(Name                    = "029 - Last Unlocker")]
        LastUnlocker                     = 29,
        [Display(Name                    = "030 - Crash And Turn Target")]
        CrashAndTurnTarget               = 30,
        [Display(Name                    = "031 - Allowed Activator")]
        AllowedActivator                 = 31,
        [Display(Name                    = "032 - House Owner")]
        HouseOwner                       = 32,
        [Display(Name                    = "033 - House")]
        House                            = 33,
        [Display(Name                    = "034 - Slumlord")]
        Slumlord                         = 34,
        [Display(Name                    = "035 - Mana Query Target")]
        ManaQueryTarget                  = 35,
        [Display(Name                    = "036 - Current Game")]
        CurrentGame                      = 36,
        [Display(Name                    = "037 - Requested Appraisal Target")]
        RequestedAppraisalTarget         = 37,
        [Display(Name                    = "038 - Allowed Wielder")]
        AllowedWielder                   = 38,
        [Display(Name                    = "039 - Assigned Target")]
        AssignedTarget                   = 39,
        [Display(Name                    = "040 - Limbo Source")]
        LimboSource                      = 40,
        [Display(Name                    = "041 - Snooper")]
        Snooper                          = 41,
        [Display(Name                    = "042 - Teleported Character")]
        TeleportedCharacter              = 42,
        [Display(Name                    = "043 - Pet")]
        Pet                              = 43,
        [Display(Name                    = "044 - Pet Owner")]
        PetOwner                         = 44,
        [Display(Name                    = "045 - Pet Device")]
        PetDevice                        = 45,
        [Display(Name                    = "9001 - Subscription")]
        Subscription                     = 9001,
        [Display(Name                    = "9002 - Friend")]
        Friend                           = 9002
    }

    public static class PropertyIidExtensions
    {
        public static string GetDescription(this IidPropertyId prop)
        {
            var description = EnumHelper.GetAttributeOfType<DisplayAttribute>(prop);
            return description?.Description ?? prop.ToString();
        }

        public static string GetName(this IidPropertyId prop)
        {
            var description = EnumHelper.GetAttributeOfType<DisplayAttribute>(prop);
            return description?.Name ?? prop.ToString();
        }
    }
}
