using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ja.training.csharp._03_RangeSubstraction
{
    public static class IntRangeExtensions
    {

        public static List<IntRange> Substract(this List<IntRange> me, IntRange toSubstract)
        {
            // todo
            throw new NotImplementedException();
        }

        public static List<IntRange> Substract(this List<IntRange> me, List<IntRange> toSubstract)
        {
            // todo
            throw new NotImplementedException();
        }

        /// <summary>
        /// gibt 0-2 Teil-Bundles zurück, die übrigbleiben, wenn "other" abgezogen wird
        ///
        /// ich:    |----------------| gibt nichts zurück
        /// other:  |----------------|
        /// 
        /// ich:    |----------------| gibt rechten Teil zurück
        /// other:  |-----|
        ///
        /// ich:    |----------------| gibt rechten und linken Teil zurück
        /// other:     |-----|
        ///
        /// ich:    |----------------| gibt linken Teil zurück
        /// other:             |-----|
        /// </summary>
        public static List<IntRange> Substract(this IntRange me, IntRange other)
        {
            // todo
            throw new NotImplementedException();
        }
    }
}
