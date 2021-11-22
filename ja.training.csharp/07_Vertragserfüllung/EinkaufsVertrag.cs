using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ja.training.csharp._07_Vertragserfüllung
{
    public class EinkaufsVertrag
    {
        public List<StromBundle> VertragsPositionen { get; }

        public EinkaufsVertrag(List<StromBundle> positionen)
        {
            VertragsPositionen = positionen;
        }

        public bool WirdErfülltDurch(List<StromBundle> einlieferungen)
        {
            // TODO
            throw new NotImplementedException();
        }
    }
}
