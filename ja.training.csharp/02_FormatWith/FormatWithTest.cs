using ja.training.csharp._01_TimeboxedCounter;
using ja.training.csharp._02_FormatWith;
using ja.training.csharp.Services;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace ja.training.csharp._02_FormatWith
{
    public class FormatWithTest
    {
        private Lecture lecture;

        public FormatWithTest()
        {
            var trainer = new Trainer()
            {
                Birthday = new DateTime(1980, 08, 05),
                FullName = "John Doe",
                Title = "Dipl. Ing.",
                Lectures = new List<Lecture>(),
            };

            lecture = new Lecture()
            {
                StartsAt = new DateTime(2021, 01, 31),
                Title = "Super Lecture",
                Trainer = trainer,
                Type = LectureType.AdvancedLecture
            };

            trainer.Lectures.Add(lecture);
            trainer.FavoriteLecture = new Lecture() { Title = "another Lecture" };
        }

        [Fact]
        public void FormatWith_interpolates_simple_Properties()
        {
            // arrange
            var formatStr = "Sie nehmen am Kurs '{Title}' teil";

            // act
            var result = formatStr.FormatWith(lecture);

            // assert
            Assert.Equal("Sie nehmen am Kurs 'Super Lecture' teil", result);
        }

        [Fact]
        public void FormatWith_interpolates_deep_Properties()
        {
            // arrange
            var formatStr = "Sie nehmen am Kurs von '{Trainer.FullName}' teil";

            // act
            var result = formatStr.FormatWith(lecture);

            // assert
            Assert.Equal("Sie nehmen am Kurs von 'John Doe' teil", result);
        }

        [Fact]
        public void FormatWith_interpolates_deep_Properties2()
        {
            // arrange
            var formatStr = "Der Titel vom Trainer ist '{Trainer.Title}'";

            // act
            var result = formatStr.FormatWith(lecture);

            // assert
            Assert.Equal("Der Titel vom Trainer ist 'Dipl. Ing.'", result);
        }

        [Fact]
        public void FormatWith_interpolates_deeper_Properties()
        {
            // arrange
            var formatStr = "der Lielblingskurs des Trainers von Kurs '{Title}' ist '{Trainer.FavoriteLecture.Title}'";

            // act
            var result = formatStr.FormatWith(lecture);

            // assert
            Assert.Equal("der Lielblingskurs des Trainers von Kurs 'Super Lecture' ist 'another Lecture'", result);
        }

        [Fact]
        public void FormatWith_interpolates_special_Properties()
        {
            // arrange
            var formatStr = "Sie nehmen am Kurs im Jahre '{StartsAt.Year}' teil";

            // act
            var result = formatStr.FormatWith(lecture);

            // assert
            Assert.Equal("Sie nehmen am Kurs im Jahre '2021' teil", result);
        }

        [Fact]
        public void FormatWith_interpolates_with_format_string()
        {
            // arrange
            var formatStr = "Sie nehmen am Kurs im Monat '{StartsAt:yyyy.MM}' teil";

            // act
            var result = formatStr.FormatWith(lecture);

            // assert
            Assert.Equal("Sie nehmen am Kurs im Monat '2021.01' teil", result);
        }

        [Fact]
        public void FormatWith_interpolates_Enums()
        {
            // arrange
            var formatStr = "Sie nehmen am Kurs vom Typ '{Type}' teil";

            // act
            var result = formatStr.FormatWith(lecture);

            // assert
            Assert.Equal("Sie nehmen am Kurs vom Typ 'AdvancedLecture' teil", result);
        }

        private class Lecture
        {
            public DateTime StartsAt { get; set; }
            public Trainer Trainer { get; set; }
            public LectureType Type { get; set; }
            public string Title { get; set; }
        }

        private class Trainer
        {
            public string FullName { get; set; }
            public DateTime Birthday { get; set; }
            public List<Lecture> Lectures { get; set; }
            public Lecture FavoriteLecture { get; set; }
            public string Title { get; set; }
        }

        private enum LectureType
        {
            SimpleLecture,
            AdvancedLecture
        }
    }
}
