using System.Collections.Generic;

namespace ja.training.csharp._03_RangeSubstraction
{
    // TODO so anpassen, dass large-numbers auch funktionieren
    public struct IntRange : IEqualityComparer<IntRange>
    {
        public IntRange(string start, string end)
        {
            Start = int.Parse( start);
            End = int.Parse(end);
        }

        public int Start { get; }
        public int End { get; }

        public bool Equals(IntRange a, IntRange b)
        {
            return a.Start == b.Start && a.End == b.End;
        }

        public int GetHashCode(IntRange a)
        {
            return $"{a.Start};{a.End}".GetHashCode();
        }
    }
}
