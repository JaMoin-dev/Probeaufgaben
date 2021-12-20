using System.Collections.Generic;

namespace ja.training.csharp._07_Vertragserfuellung
{
    public class Qualitaetsmerkmale
    {
        public bool Windkraft { get; }
        public bool Wasserkraft { get; }
        public bool Fischtreppe { get; }
        public bool OhneSubvention { get; }

        public Qualitaetsmerkmale(bool wind, bool wasser, bool fisch, bool ohne)
        {
            Windkraft = wind;
            Wasserkraft = wasser;
            Fischtreppe = fisch;
            OhneSubvention = ohne;
        }

        public Qualitaetsmerkmale(Qualitaetsmerkmale qualis)
        {
            Windkraft = qualis.Windkraft;
            Wasserkraft = qualis.Wasserkraft;
            Fischtreppe = qualis.Fischtreppe;
            OhneSubvention = qualis.OhneSubvention;
        }

        /// <summary>
        /// testet, ob alle gesetzten Qualitaetsmerkmale auch durch die zu testenden Qualitaetsmerkmale erfüllt sind. 
        /// Wenn die Ergebnisliste leer ist, sind alle geforderten Qualitaetsmerkmale erfüllt
        /// </summary>
        /// <returns>Liste der gesetzten Qualitaetsmerkmale die in den zu testenden Qualitaetsmerkmale nicht erfüllt sind</returns>
        public List<string> GetUnmatchedProperties(Qualitaetsmerkmale test)
        {
            var result = new List<string>();

            if (Windkraft && !test.Windkraft) result.Add(nameof(Windkraft));
            if (Wasserkraft && !test.Wasserkraft) result.Add(nameof(Wasserkraft));
            if (Fischtreppe && !test.Fischtreppe) result.Add(nameof(Fischtreppe));
            if (OhneSubvention && !test.OhneSubvention) result.Add(nameof(OhneSubvention));

            return result;
        }

        public override string ToString()
        {
            return $"{(Windkraft?1:0)},{(Wasserkraft ? 1 : 0)},{(Fischtreppe ? 1 : 0)},{(OhneSubvention ? 1 : 0)}";
        }
    }
}
