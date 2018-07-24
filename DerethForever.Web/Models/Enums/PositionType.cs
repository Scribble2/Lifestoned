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
    public enum PositionType
    {
        /// <summary>
        /// I got nothing for you.
        /// </summary>
        [Display(Name = "000 - Invalid")]
        Undef = 0,

        /// <summary>
        /// Current Position
        /// </summary>
        [Display(Name = "001 - Location")]
        Location = 1,

        /// <summary>
        /// May be used to store where we are headed when we teleport (?)
        /// </summary>
        [Display(Name = "002 - Destination")]
        Destination = 2,

        /// <summary>
        /// Where will we pop into the world (?)
        /// </summary>
        [Display(Name = "003 - Instantiation")]
        Instantiation = 3,

        /// <summary>
        ///  Last Lifestone Used? (@ls)? | @home | @save | @recall
        /// </summary>
        [Display(Name = "004 - Sanctuary")]
        Sanctuary = 4,

        /// <summary>
        /// Not sure - this could be your house?
        /// </summary>
        [Display(Name = "005 - Home")]
        Home = 5,

        /// <summary>
        /// The need to research
        /// </summary>
        [Display(Name = "006 - Activation Move")]
        ActivationMove = 6,

        /// <summary>
        /// The the position of target.
        /// </summary>
        [Display(Name = "007 - Target")]
        Target = 7,

        /// <summary>
        /// Primary Portal Recall | Summon Primary Portal | Primary Portal Tie
        /// </summary>
        [Display(Name = "008 - Linked Portal One")]
        LinkedPortalOne = 8,

        /// <summary>
        /// Portal Recall (Last Used Portal that can be recalled to)
        /// </summary>
        [Display(Name = "009 - Last Portal")]
        LastPortal = 9,

        /// <summary>
        /// The portal storm - need research - maybe where you were portaled from or to - to does not seem likely to me.
        /// </summary>
        [Display(Name = "010 - Portal Storm")]
        PortalStorm = 10,

        /// <summary>
        /// The crash and turn - I can't wait to find out.
        /// </summary>
        [Display(Name = "011 - Crash and Turn")]
        CrashAndTurn = 11,

        /// <summary>
        /// We are tracking what the portal ties are - could this be the physical location of the portal you summoned?   More research needed.
        /// </summary>
        [Display(Name = "012 - Portal Summon Location")]
        PortalSummonLoc = 12,

        /// <summary>
        /// That little spot you get sent to just outside the barrier when the slum lord evicts you (??)
        /// </summary>
        [Display(Name = "013 - House Boot")]
        HouseBoot = 13,

        /// <summary>
        /// The last outside death. --- boy would I love to extend this to cover deaths in dungeons as well.
        /// </summary>
        [Display(Name = "014 - Last Outside Death")]
        LastOutsideDeath = 14, // Location of Corpse

        /// <summary>
        /// The linked lifestone - Lifestone Recall | Lifestone Tie
        /// </summary>
        [Display(Name = "015 - Linked Lifestone")]
        LinkedLifestone = 15,

        /// <summary>
        /// Secondary Portal Recall | Summon Secondary Portal | Secondary Portal Tie
        /// </summary>
        [Display(Name = "016 - Linked Portal Two")]
        LinkedPortalTwo = 16,

        /// <summary>
        /// Admin Quick Recall Positions
        /// </summary>
        [Display(Name = "017 - Admin Save1")]
        Save1 = 17, // @save 1 | @home 1 | @recall 1

        /// <summary>
        /// Admin Quick Recall Positions
        /// </summary>
        [Display(Name = "018 - Admin Save2")]
        Save2 = 18, // @save 2 | @home 2 | @recall 2

        /// <summary>
        /// Admin Quick Recall Positions
        /// </summary>
        [Display(Name = "019 - Admin Save3")]
        Save3 = 19, // @save 3 | @home 3 | @recall 3

        /// <summary>
        /// Admin Quick Recall Positions
        /// </summary>
        [Display(Name = "020 - Admin Save4")]
        Save4 = 20, // @save 4 | @home 4 | @recall 4

        /// <summary>
        /// Admin Quick Recall Positions
        /// </summary>
        [Display(Name = "021 - Admin Save5")]
        Save5 = 21, // @save 5 | @home 5 | @recall 5

        /// <summary>
        /// Admin Quick Recall Positions
        /// </summary>
        [Display(Name = "022 - Admin Save6")]
        Save6 = 22, // @save 6 | @home 6 | @recall 6

        /// <summary>
        /// Admin Quick Recall Positions
        /// </summary>
        [Display(Name = "023 - Admin Save7")]
        Save7 = 23, // @save 7 | @home 7 | @recall 7

        /// <summary>
        /// Admin Quick Recall Positions
        /// </summary>
        [Display(Name = "024 - Admin Save8")]
        Save8 = 24, // @save 8 | @home 8 | @recall 8

        /// <summary>
        /// Admin Quick Recall Positions
        /// </summary>
        [Display(Name = "025 - Admin Save9")]
        Save9 = 25, // @save 9 | @home 9 | @recall 9

        /// <summary>
        /// needs research
        /// </summary>
        [Display(Name = "026 - Relative Destination")]
        RelativeDestination = 26,

        [Display(Name = "027 - Teleported Character")]
        TeleportedCharacter = 27,
    }

    public static class PositionTypeExtensions
    {
        public static string GetDescription(this PositionType prop)
        {
            var description = EnumHelper.GetAttributeOfType<DisplayAttribute>(prop);
            return description?.Description ?? prop.ToString();
        }

        public static string GetName(this PositionType prop)
        {
            var description = EnumHelper.GetAttributeOfType<DisplayAttribute>(prop);
            return description?.Name ?? prop.ToString();
        }
    }
}
