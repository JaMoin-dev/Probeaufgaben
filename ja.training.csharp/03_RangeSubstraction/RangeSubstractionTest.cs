using ja.training.csharp._01_TimeboxedCounter;
using ja.training.csharp._02_FormatWith;
using ja.training.csharp.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace ja.training.csharp._03_RangeSubstraction
{
    public class RangeSubstractionTest
    {
        [Fact]
        // a   |---------|
        // b      |--|
        // r   |-|    |--|
        public void Substract_Middle()
        {
            // arrange
            var a = new IntRange("10", "100");
            var b = new IntRange("20", "40");
            var expected = new List<IntRange>
            {
                new IntRange("10", "19"),
                new IntRange("41", "100")
            };

            // act
            var actual = a.Substract(b);

            // assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [Fact]
        // a   |---------|
        // b      |--|
        // r   |-|    |--|
        public void Substract_large_numbers()
        {
            // arrange
            var a = new IntRange("12345678901234567890123451000", "12345678901234567890123451200");
            var b = new IntRange("12345678901234567890123451030", "12345678901234567890123451040");
            var expected = new List<IntRange>
            {
                new IntRange("12345678901234567890123451000", "12345678901234567890123451029"),
                new IntRange("12345678901234567890123451041", "12345678901234567890123451200")
            };

            // act
            var actual = a.Substract(b);

            // assert
            CollectionAssert.AreEqual(expected, actual);
        }




        [Theory]
        // a   |-------|
        // b |---|
        // r      |----|
        // und andere linke Randbedingungen
        [InlineData("10", "100", "5", "15", "16", "100")]
        [InlineData("10", "100", "10", "15", "16", "100")]
        [InlineData("10", "100", "5", "10", "11", "100")]
        [InlineData("10", "100", "5", "9", "10", "100")]
        // a   |-------|
        // b         |---|
        // r   |----|
        // und andere rechte Randbedingungen
        [InlineData("10", "100", "90", "110", "10", "89")]
        [InlineData("10", "100", "90", "100", "10", "89")]
        [InlineData("10", "100", "100", "110", "10", "99")]
        [InlineData("10", "100", "101", "110", "10", "100")]
        public void Substract_Borders(string ast, string ae, string bs, string be, string rs, string re)
        {
            // arrange
            var a = new IntRange(ast, ae);
            var b = new IntRange(bs, be);
            var expected = new List<IntRange>
            {
                new IntRange(rs, re),
            };

            // act
            var actual = a.Substract(b);

            // assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [Fact]
        // a   |---------| |---------|
        // b            |---|   
        // r   |-------|     |-------|
        public void Substract_Single_from_List()
        {
            // arrange
            var a = new List<IntRange>
            {
                new IntRange("10", "50"),
                new IntRange("60", "100")
            };
            var b = new IntRange("45", "60");

            var expected = new List<IntRange>
            {
                new IntRange("10", "44"),
                new IntRange("61", "100")
            };

            // act
            var actual = a.Substract(b);

            // assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [Fact]
        // a   |---------| |---------|
        // b      |-|   |---|   |-|
        // r   |-|   |-|     |-|   |-|
        public void Substract_List_from_List()
        {
            // arrange
            var a = new List<IntRange>
            {
                new IntRange("10", "50"),
                new IntRange("60", "100")
            };
            var b = new List<IntRange>
            {
                new IntRange("15", "20"),
                new IntRange("90", "91"),
                new IntRange("45", "60")
            };

            var expected = new List<IntRange>
            {
                new IntRange("10", "14"),
                new IntRange("21", "44"),
                new IntRange("61", "89"),
                new IntRange("92", "100")
            };

            // act
            var actual = a.Substract(b);

            // assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
