namespace ja.training.csharp._07_Vertragserfüllung
{
    public class StromBundle
    {
        public StromBundle(int mwh, bool wind, bool wasser, bool fisch, bool ohne)
        {
            MWh = mwh;
            Qualitätsmerkmale = new Qualitätsmerkmale(wind, wasser, fisch, ohne);
        }

        public StromBundle(int mwh, Qualitätsmerkmale qualis)
        {
            MWh = mwh;
            Qualitätsmerkmale = new Qualitätsmerkmale(qualis);
        }

        public int MWh { get; set; }

        public Qualitätsmerkmale Qualitätsmerkmale { get; set; }

        public override string ToString()
        {
            return $"{MWh}:{(Qualitätsmerkmale.Windkraft ? 1 : 0)},{(Qualitätsmerkmale.Wasserkraft ? 1 : 0)},{(Qualitätsmerkmale.Fischtreppe ? 1 : 0)},{(Qualitätsmerkmale.OhneSubvention ? 1 : 0)}";
        }
    }
}
