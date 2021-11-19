using System.Collections.Generic;

namespace ja.training.csharp._07_Vertragserfüllung
{
    public class Qualitätsmerkmale
    {
        public bool Windkraft { get; }
        public bool Wasserkraft { get; }
        public bool Fischtreppe { get; }
        public bool OhneSubvention { get; }

        public Qualitätsmerkmale(bool wind, bool wasser, bool fisch, bool ohne)
        {
            Windkraft = wind;
            Wasserkraft = wasser;
            Fischtreppe = fisch;
            OhneSubvention = ohne;
        }

        public Qualitätsmerkmale(Qualitätsmerkmale qualis)
        {
            Windkraft = qualis.Windkraft;
            Wasserkraft = qualis.Wasserkraft;
            Fischtreppe = qualis.Fischtreppe;
            OhneSubvention = qualis.OhneSubvention;
        }

        /// <summary>
        /// testet, ob alle gesetzten Qualitätsmerkmale auch durch die zu testenden Qualitätsmerkmale erfüllt sind. 
        /// Wenn die Ergebnisliste leer ist, sind alle geforderten Qualitätsmerkmale erfüllt
        /// </summary>
        /// <returns>Liste der gesetzten Qualitätsmerkmale die in den zu testenden Qualitätsmerkmale nicht erfüllt sind</returns>
        public List<string> GetUnmatchedProperties(Qualitätsmerkmale test)
        {
            var result = new List<string>();

            if (Windkraft && !test.Windkraft) result.Add(nameof(Windkraft));
            if (Wasserkraft && !test.Wasserkraft) result.Add(nameof(Wasserkraft));
            if (Fischtreppe && !test.Fischtreppe) result.Add(nameof(Fischtreppe));
            if (OhneSubvention && !test.OhneSubvention) result.Add(nameof(OhneSubvention));

            return result;
        }
    }
}
