using ja.training.csharp._01_TimeboxedCounter;
using ja.training.csharp._02_FormatWith;
using ja.training.csharp.Services;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace ja.training.csharp._07_Vertragserfüllung
{
    public class EinkaufsVertragTest
    {

        [Theory]
        [InlineData(100, false, true, false, false)]
        [InlineData(200, false, true, false, false)]
        [InlineData(100, false, true, true, true)]
        public void Simple_erfüllt(int mwh, bool wind, bool wasser, bool fisch, bool ohne)
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
            Assert.True(vertrag.WirdErfülltDurch(einlieferung));
        }

        [Theory]
        [InlineData(100, false, false, false, false)]
        [InlineData(200, false, false, true, true)]
        [InlineData(99, false, true, true, true)]
        public void Simple_nicht_erfüllt(int mwh, bool wind, bool wasser, bool fisch, bool ohne)
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
            Assert.False(vertrag.WirdErfülltDurch(einlieferung));
        }

        [Theory]
        [InlineData(300, false, true, true, false, 2000, true, false, false, true)]
        [InlineData(300, false, true, false, true, 2000, true, false, false, true)]
        [InlineData(290, false, true, true, true, 2000, true, false, false, true)]
        [InlineData(300, false, true, true, true, 2000, true, false, false, false)]
        public void Complex_nicht_erfüllt(int mwh, bool wind, bool wasser, bool fisch, bool ohne,
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
            Assert.False(vertrag.WirdErfülltDurch(einlieferung));
        }

        [Fact]
        public void Complex_nicht_erfüllt2()
        {
            // arrange
            var vertrag = CreateComplexEkv();
            var einlieferung = CreateComplexEkv().VertragsPositionen;
            einlieferung.RemoveAt(4);

            // assert
            Assert.False(vertrag.WirdErfülltDurch(einlieferung));
        }

        [Theory]
        [InlineData(200, false, true, true, true, 2100, true, true, true, true)]
        [InlineData(300, false, true, true, true, 2000, true, false, false, true)]
        public void Complex_erfüllt(int mwh, bool wind, bool wasser, bool fisch, bool ohne,
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
            Assert.True(vertrag.WirdErfülltDurch(einlieferung));
        }

        [Fact]
        public void Complex_erfüllt2()
        {
            // arrange
            var vertrag = CreateComplexEkv();
            var einlieferung = CreateComplexEkv().VertragsPositionen;

            // assert
            Assert.True(vertrag.WirdErfülltDurch(einlieferung));
        }

        [Fact]
        public void Complex_erfüllt3()
        {
            // arrange
            var vertrag = CreateComplexEkv();
            var einlieferung = CreateComplexEkv().VertragsPositionen;
            einlieferung.Add(einlieferung[0]);
            einlieferung.RemoveAt(0);

            // assert
            Assert.True(vertrag.WirdErfülltDurch(einlieferung));
        }

        [Fact]
        public void Complex_erfüllt4()
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
            Assert.True(vertrag.WirdErfülltDurch(einlieferung));
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
