namespace ja.training.csharp._07_Vertragserfuellung
{
    public class StromBundle
    {
        public StromBundle(int mwh, bool wind, bool wasser, bool fisch, bool ohne)
        {
            MWh = mwh;
            Qualitaetsmerkmale = new Qualitaetsmerkmale(wind, wasser, fisch, ohne);
        }

        public StromBundle(int mwh, Qualitaetsmerkmale qualis)
        {
            MWh = mwh;
            Qualitaetsmerkmale = new Qualitaetsmerkmale(qualis);
        }

        public int MWh { get; set; }

        public Qualitaetsmerkmale Qualitaetsmerkmale { get; set; }

        public override string ToString()
        {
            return $"{MWh}:{(Qualitaetsmerkmale.Windkraft ? 1 : 0)},{(Qualitaetsmerkmale.Wasserkraft ? 1 : 0)},{(Qualitaetsmerkmale.Fischtreppe ? 1 : 0)},{(Qualitaetsmerkmale.OhneSubvention ? 1 : 0)}";
        }
    }
}
