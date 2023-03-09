using System.Collections.Generic;
using Xunit;

namespace ja.training.csharp._07_Vertragserfuellung
{
    public class EinkaufsVertragTest
    {

        [Theory]
        [InlineData(100, false, true, false, false)]
        [InlineData(200, false, true, false, false)]
        [InlineData(100, false, true, true, true)]
        public void Simple_erfuellt(int mwh, bool wind, bool wasser, bool fisch, bool ohne)
        {
            // arrange
            var vertrag = new EinkaufsVertrag(new List<StromBundle>
            {
                new StromBundle(100, false, true, false, false)
            });

            var einlieferung = new List<StromBundle>
            {
                new StromBundle(mwh, wind, wasser, fisch, ohne)
            };

            // assert
            Assert.True(vertrag.WirdErfuelltDurch(einlieferung));
        }

        [Theory]
        [InlineData(100, false, false, false, false)]
        [InlineData(200, false, false, true, true)]
        [InlineData(99, false, true, true, true)]
        public void Simple_nicht_erfuellt(int mwh, bool wind, bool wasser, bool fisch, bool ohne)
        {
            // arrange
            var vertrag = new EinkaufsVertrag(new List<StromBundle>
            {
                new StromBundle(100, false, true, false, false)
            });

            var einlieferung = new List<StromBundle>
            {
                new StromBundle(mwh, wind, wasser, fisch, ohne)
            };

            // assert
            Assert.False(vertrag.WirdErfuelltDurch(einlieferung));
        }

        [Theory]
        [InlineData(300, false, true, true, false, 2000, true, false, false, true)]
        [InlineData(300, false, true, false, true, 2000, true, false, false, true)]
        [InlineData(290, false, true, true, true, 2000, true, false, false, true)]
        [InlineData(300, false, true, true, true, 2000, true, false, false, false)]
        [InlineData(290, false, true, true, true, 2010, true, false, false, true)]
        public void Complex_nicht_erfuellt(int mwh, bool wind, bool wasser, bool fisch, bool ohne,
            int mwh2, bool wind2, bool wasser2, bool fisch2, bool ohne2)
        {
            // arrange
            var vertrag = CreateComplexEkv();

            var einlieferung = new List<StromBundle>
            {
                new StromBundle(mwh, wind, wasser, fisch, ohne),
                new StromBundle(mwh2, wind2, wasser2, fisch2, ohne2)
            };

            // assert
            Assert.False(vertrag.WirdErfuelltDurch(einlieferung));
        }

        [Fact]
        public void Complex_nicht_erfuellt2()
        {
            // arrange
            var vertrag = CreateComplexEkv();
            var einlieferung = CreateComplexEkv().VertragsPositionen;
            einlieferung.RemoveAt(4);

            // assert
            Assert.False(vertrag.WirdErfuelltDurch(einlieferung));
        }

        [Fact]
        public void Complex_nicht_erfuellt3_will_crush_naiive_Implementations()
        {
            // arrange
            var vertrag = CreateComplexEkv();

            var einlieferung = new List<StromBundle>
            {
                new StromBundle(100, false, true, false, false),
                new StromBundle(100, false, true, true, false),
                new StromBundle(100, false, true, true, true),
                new StromBundle(1000, true, false, false, false)
            };
            for (int i = 0; i < 99; i++)
                einlieferung.Add(new StromBundle(10, true, false, false, true));

            // assert
            Assert.False(vertrag.WirdErfuelltDurch(einlieferung));
        }

        [Theory]
        [InlineData(200, false, true, true, true, 2100, true, true, true, true)]
        [InlineData(300, false, true, true, true, 2000, true, false, false, true)]
        public void Complex_erfuellt(int mwh, bool wind, bool wasser, bool fisch, bool ohne,
            int mwh2, bool wind2, bool wasser2, bool fisch2, bool ohne2)
        {
            // arrange
            var vertrag = CreateComplexEkv();
            var einlieferung = new List<StromBundle>
            {
                new StromBundle(mwh, wind, wasser, fisch, ohne),
                new StromBundle(mwh2, wind2, wasser2, fisch2, ohne2)
            };

            // assert
            Assert.True(vertrag.WirdErfuelltDurch(einlieferung));
        }

        [Fact]
        public void Complex_erfuellt2()
        {
            // arrange
            var vertrag = CreateComplexEkv();
            var einlieferung = CreateComplexEkv().VertragsPositionen;

            // assert
            Assert.True(vertrag.WirdErfuelltDurch(einlieferung));
        }

        [Fact]
        public void Complex_erfuellt3()
        {
            // arrange
            var vertrag = CreateComplexEkv();
            var einlieferung = CreateComplexEkv().VertragsPositionen;
            einlieferung.Add(einlieferung[0]);
            einlieferung.RemoveAt(0);

            // assert
            Assert.True(vertrag.WirdErfuelltDurch(einlieferung));
        }

        [Fact]
        public void Complex_erfuellt4()
        {
            // arrange
            var vertrag = CreateComplexEkv();
            var einlieferung = new List<StromBundle>(){
                new StromBundle(100, true, true, true, true),
                new StromBundle(100, false, true, true, false),
                new StromBundle(100, false, true, false, false),
                new StromBundle(1000, true, false, false, false),
                new StromBundle(900, true, false, false, true),
                new StromBundle(100, true, true, true, true)
            };

            // assert
            Assert.True(vertrag.WirdErfuelltDurch(einlieferung));
        }

        [Fact]
        public void Complex_erfuellt5_fuer_Mirco()
        {
            // arrange
            var vertrag = new EinkaufsVertrag(new List<StromBundle>
            {
                new StromBundle(100, true, false, false, false),
                new StromBundle(100, false, true, false, false),
            });

            var einlieferung = new List<StromBundle>
            {
                new StromBundle(100, true, true, false, false),
                new StromBundle(100, true, false, true, false),
            };

            // assert
            Assert.True(vertrag.WirdErfuelltDurch(einlieferung));
        }

        [Fact]
        public void Complex_erfuellt6_fuer_Mirco()
        {
            // arrange
            var vertrag = new EinkaufsVertrag(new List<StromBundle>
            {
                new StromBundle(100, true, false, false, false),
                new StromBundle(100, false, true, false, false),
            });

            var einlieferung = new List<StromBundle>
            {
                new StromBundle(100, true, false, true, false),
                new StromBundle(100, true, true, false, false),
            };

            // assert
            Assert.True(vertrag.WirdErfuelltDurch(einlieferung));
        }


        /// <summary>
        /// 100 Wasser
        /// 100 Wasser mit Fischtreppe
        /// 100 Wasser mit Fischtreppe und ohne Förderung
        /// 1000 Wind
        /// 1000 Wind ohne Förderung
        /// </summary>
        private EinkaufsVertrag CreateComplexEkv()
        {
            return new EinkaufsVertrag(new List<StromBundle>
            {
                new StromBundle(100, false, true, false, false),
                new StromBundle(100, false, true, true, false),
                new StromBundle(100, false, true, true, true),
                new StromBundle(1000, true, false, false, false),
                new StromBundle(1000, true, false, false, true),
            });
        }
    }
}
