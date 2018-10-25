using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lifestoned.Lib.ClientLib.Enum;

namespace Lifestoned.Lib.ClientLib
{
    internal static class Constants
    {
        public const float TOLERANCE                              = 0.0002f;
        public const float QUANTUM_MAX_97                         = 0.2f;
        public const float QUANTUM_ABSURDUM                       = 2.0f;
        public const float RADIANS_PER_DEGREE                     = (float)Math.PI / 180f;
        public const float DEGREES_PER_RADIAN                     = 180f / (float)Math.PI;
        public const float DUMMY_SPHERE_RADIUS                    = 0.1f;

        // use this site for LODWORD - hex to float conversions   Thanks for the assist Behemoth
        // https://gregstoll.dyndns.org/~gregstoll/floattohex/
        /// <summary>
        /// acclient.c pulled from various parts of the client where magic numbers where used
        /// </summary>
        public const float DefaultMinDistance                     = 0.0f;
        public const float DefaultDistanceToObject                = 0.6f;
        public const float DefaultFailDistance                    = float.MaxValue;
        public const float DefaultSpeed                           = 1.0f;
        public const float DefaultWalkRunThreshold                = 15.0f;
        public const float DefaultDesiredHeading                  = 0f;
        public const float BackwardsFactor                        = 0.64999f;
        public const float MaxSidestepAnimRate                    = 3.0f;
        public const float RunAnimSpeed                           = 4.0f;
        public const float RunTurnFactor                          = 1.5f;
        public const float SidestepAnimSpeed                      = 1.25f;
        public const float SidestepFactor                         = 0.5f;
        public const float WalkAnimSpeed                          = 3.11999f;
        public const float LargeDistance                          = 999999.0f;
        public const float MaxInterpolatedVelocity                = 7.5f;
        public const float StickyRadius                           = 0.3f;
        public const float MaxJumpVelocityZ                       = 10.0f;

        // Added to replace the repetitive calculation:
        //Constants.SidestepFactor * (Constants.WalkAnimSpeed / Constants.SidestepAnimSpeed)
        public const float DefaultSideStepRightAdj                = 1.24799996f;
        public const uint DefaultContextId                        = 0;
        public const uint DefaultActionStamp                      = 0;
        // public const MovementParamsFlags NormalBitfield           = (MovementParamsFlags)0x1EE0F;
        public const double ZLimit                                = 0.984807753d;
    }
}
