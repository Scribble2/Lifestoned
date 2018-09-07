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
using System;

namespace Lifestoned.DataModel.Shared
{
    [Flags]
    public enum Usable
    {
        Undef                                   = 0,
        No                                      = 1,
        Self                                    = 2,
        Wielded                                 = 4,
        Contained                               = 8,
        Viewed                                  = 16,
        Remote                                  = 32,
        NeverWalk                               = 64,
        ObjSelf                                 = 128,

        SourceWieldedTargetWielded              = 262148,
        SourceWieldedTargetContained            = 524292,
        SourceWieldedTargetViewed               = 1048580,
        SourceWieldedTargetRemote               = 2097156,
        SourceWieldedTargetRemoteNeverWalk      = 6291460,

        SourceContainedTargetWielded            = 262152,
        SourceContainedTargetContained          = 524296,
        SourceContainedTargetObjselfOrContained = 8912904,
        SourceContainedTargetSelfOrContained    = 655368,
        SourceContainedTargetViewed             = 1048584,
        SourceContainedTargetRemote             = 2097160,
        SourceContainedTargetRemoteNeverWalk    = 6291464,
        SourceContainedTargetRemoteOrSelf       = 2228232,

        SourceViewedTargetWielded               = 262160,
        SourceViewedTargetContained             = 524304,
        SourceViewedTargetViewed                = 1048592,
        SourceViewedTargetRemote                = 2097168,

        SourceRemoteTargetWielded               = 262176,
        SourceRemoteTargetContained             = 524320,
        SourceRemoteTargetViewed                = 1048608,
        SourceRemoteTargetRemote                = 2097184,
        SourceRemoteTargetRemoteNeverWalk       = 6291488
    }
}
